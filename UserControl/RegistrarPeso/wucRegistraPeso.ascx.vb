
Partial Class UserControl_RegistrarPeso_wucRegistraPeso
    Inherits System.Web.UI.UserControl

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Dim clsbuRegistrarPeso As buCadastros.buRegistrarPeso
    Private clsresiduos As buCadastros.buResiduos
    Private clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper

    'variaveis que indicarão qual é o tipo de operação que o usuario deseja realizar na tela edição
    Private mblnIncluir As Boolean

    ''' <summary>
    ''' Função que popula a combo
    ''' </summary>
    ''' <remarks>Implementado por Renato Matsumoto</remarks>
    Public Sub populacboResiduo()
        Dim dsDados As Data.DataSet

        Try
            clsresiduos = New buCadastros.buResiduos
            dsDados = clsresiduos.Consultar(" ReHabilitado=1 ")

            cboResiduo.Items.Add("Selecione")
            cboResiduo.Items(0).Value = "-1"

            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1
                cboResiduo.Items.Add(dsDados.Tables(0).Rows(i)("ReNome").ToString)
                cboResiduo.Items(i + 1).Value = dsDados.Tables(0).Rows(i)("ReCodigo").ToString
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not IsPostBack Then
        '    'Tratamento de consulta da grid, fazendo com que o usuário possa clicar em qualquer local da linha desejada.
        '    If (Request("__EVENTTARGET").ToUpper = "CONSULTAR") And IsNumeric(Request("__EVENTARGUMENT")) Then
        '        dgwDados_Consultar(Request("__EVENTARGUMENT"))
        '    End If
        'End If
        If Not IsPostBack Then
            populacboResiduo()
            ''verifica se o usuario esta querendo incluir
            'If Not IsNothing(Request.QueryString("Incluir")) Then
            '    mblnIncluir = True
            '    btnConfirmar.Visible = True
            'Else
            '    'Como a variável global btnInclui, btnExcluir, btnAlterar e intID não guardam 
            '    'o valor, e ao invés de guardar em variável de sessão. Essa verificação é retomada.
            '    If Not IsNothing(Request.QueryString("Incluir")) Then
            '        mblnIncluir = True
            '        btnConfirmar.Visible = True
            '    End If
            'End If
        End If

    End Sub

    ''' <summary>
    ''' Função que é utilizada para controlar a consulta da GridView.
    ''' </summary>
    ''' <remarks> Implementado em 19/06/2009 por Renato Matsumoto
    '''             .</remarks>
    Protected Sub dgwDados_Consultar(ByVal intCodigo As Integer)
        Dim strAux As Text.StringBuilder
        Try
            strAux = New StringBuilder
            strAux.Append("Default_Edit.aspx?")
            strAux.Append("Consultar=")
            strAux.Append(dgwDados.DataKeys(intCodigo).Value.ToString)
            Response.Redirect(strAux.ToString, False)
        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing
        End Try
    End Sub
    Protected Sub dgwDados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgwDados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Quando o mouse passa sobre a linha da gridview, as mesma fica cinza.
            For idx As Integer = 0 To DirectCast(sender, GridView).Columns.Count - 2
                e.Row.Cells(idx).Attributes.Add("onclick", "__doPostBack('CONSULTAR', " & e.Row.RowIndex & ")")
                e.Row.Cells(idx).ToolTip = "Cosultar/Alterar"
            Next
            e.Row.Style("cursor") = "hand"
        End If
    End Sub
    Protected Sub PopulaDados(ByVal strWhere As String, ByVal blnShowState As Boolean, Optional ByVal strOrdem As String = "")
        Dim dsCliente As Data.DataSet
        Dim strAux As StringBuilder
        Try
            'Deixa a tela com apenas o UserSelect visível.

            dgwDados.Visible = False
            'pnlGrid.Visible = False

            clsbuRegistrarPeso = New buCadastros.buRegistrarPeso()
            dsCliente = clsbuRegistrarPeso.Consultarusuario(strWhere, strOrdem)

            If dsCliente.Tables(0).Rows.Count > 0 Then
                dgwDados.Visible = True
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True

                'Carrega o GridView
                With dgwDados
                    .DataSource = dsCliente
                    .DataBind()
                End With
            Else

                dgwDados.Visible = False
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsCliente = Nothing
            clsbuRegistrarPeso = Nothing
            strAux = Nothing
        End Try
    End Sub

    ''' <summary> Função que popula os dados referentes a nova página. </summary>
    ''' <remarks> Implementado em 22/07/2009 por Renato Matsumoto. </remarks>
    Protected Sub dgwDados_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgwDados.PageIndexChanged
        Dim strOrderBy As String
        Dim colColecao As Collection
        Try
            'Popula os dados da busca realizada para a referente página do GridView            
            PopulaDados(Session("WhereUtilizadoNaConsulta"), False)
        Catch ex As Exception
            Throw ex
        Finally
            strOrderBy = Nothing
            colColecao = Nothing
        End Try
    End Sub

    ''' <summary> Função que controla a paginação, mas não popula os dados. </summary>
    ''' <remarks> Implementado em 22/07/2009 por Renato Matsumoto. </remarks>
    Protected Sub dgwDados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgwDados.PageIndexChanging

        'Direciona para a próxima pagina.
        dgwDados.PageIndex = e.NewPageIndex

    End Sub

    Private Function MontaFiltro() As String
        Dim strWhere As Text.StringBuilder
        Dim blnIgual As Boolean = False
        Dim blnContem As Boolean = False
        Try
            strWhere = New Text.StringBuilder
            If cboEnumerdor.SelectedValue <> "todos" Then
                Select Case (cboOpcoes.SelectedValue)
                    Case "nome"
                        strWhere.Append("usNome ")
                End Select
                Select Case (cboOpcoes.SelectedValue)
                    Case "Codigo"
                        strWhere.Append("usCodigo ")
                End Select

                Select Case (cboEnumerdor.SelectedValue)
                    Case "igual"
                        strWhere.Append(" = '")
                        blnIgual = True
                    Case "contem"
                        strWhere.Append("like '%")
                        blnContem = True
                End Select

                strWhere.Append(Trim(txtOpcoes.Text))

                If blnIgual Then
                    strWhere.Append("'")
                ElseIf blnContem Then
                    strWhere.Append("%'")
                End If
            Else
                strWhere.Append("")

            End If

            MontaFiltro = strWhere.ToString

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Dim strWhere As String
        Try
            'Monta o Filtro da Tela
            strWhere = MontaFiltro()

            'Posiciona na primeira página do Grid
            dgwDados.PageIndex = 0

            'Chama o método para preencher o datagrid com os dados
            PopulaDados(strWhere, True)

            Session("WhereUtilizadoNaConsulta") = strWhere
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub dgwDados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgwDados.SelectedIndexChanged
        txtCodUsu.Text = dgwDados.SelectedValue
        txtNomeUsu.Text = dgwDados.SelectedRow.Cells(1).Text

    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        txtcodresiduo.Text = cboResiduo.SelectedValue
        txtresiduo.Text = cboResiduo.SelectedItem.Text
    End Sub

    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click

        Try
            Incluir()


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Incluir()
        Try
            clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
            clsbuRegistrarPeso = New buCadastros.buRegistrarPeso

            If clsbuRegistrarPeso.Incluir(txtCodUsu.Text, txtcodresiduo.Text, txtpeso.Text, Date.Now) Then
                lblAcao.Text = "Inclusão"
                lblTextoAcao.Text = "Registro Incluido com Sucesso"
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)
            Else
                MsgBox(MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' Função que irá redirecionar a pagina para ela mesma ou para a tela de consulta
    ''' </summary>
    Private Sub RedirecionaPagina()

        Try
            Response.Redirect("Default.aspx?")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnACAO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnACAO.Click
        RedirecionaPagina()
    End Sub

End Class
