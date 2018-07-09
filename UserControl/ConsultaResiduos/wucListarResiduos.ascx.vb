
Partial Class UserControl_ConsultaResiduos_wucConsultarResiduos
    Inherits System.Web.UI.UserControl
    Dim clsbuResiduos As buCadastros.buResiduos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            PopulaDados(" Rehabilitado = 1", True)


        End If
    End Sub


    ''' <summary>
    ''' Função que é utilizada para controlar a consulta da GridView.
    ''' </summary>
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
  
    Protected Sub PopulaDados(ByVal strWhere As String, ByVal blnShowState As Boolean, Optional ByVal strOrdem As String = "")
        Dim dsCliente As Data.DataSet
        Dim strAux As StringBuilder
        Try
            'Deixa a tela com apenas o UserSelect visível.

            dgwDados.Visible = False
            'pnlGrid.Visible = False

            clsbuResiduos = New buCadastros.buResiduos()
            dsCliente = clsbuResiduos.Consultar(strWhere, strOrdem)

            If dsCliente.Tables(0).Rows.Count > 0 Then


                dgwDados.Visible = True
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True

                If blnShowState Then

                    'Verifica a permissão do botão Excluir


                    lblTotalRegistros.Visible = True

                    'Mostra a quantidade de registros encontrados
                    strAux = New StringBuilder
                    strAux.Append("registros encontrados")
                    strAux.Append(": ")
                    strAux.Append(dsCliente.Tables(0).Rows.Count.ToString)
                    lblTotalRegistros.Text = strAux.ToString
                End If



                'Carrega o GridView
                With dgwDados
                    .DataSource = dsCliente
                    .DataBind()
                End With
            Else

                lblTotalRegistros.Visible = False
                dgwDados.Visible = False
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsCliente = Nothing
            clsbuResiduos = Nothing
            strAux = Nothing
        End Try
    End Sub

    ''' <summary> Função que popula os dados referentes a nova página. </summary>
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
    ''' <remarks> Implementado em 22/07/2009 por Nill Pinheiro. </remarks>
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
                    Case "ReNome"
                        strWhere.Append("Renome ")


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


            'Just to tests

            'Dim dsDataAux As Data.DataSet

            'dsDataAux = New Data.DataSet


            'dsDataAux.Tables.Add("Residuos")

            'dsDataAux.Tables("Residuos").Columns.Add("usCodigo", GetType(Integer))
            'dsDataAux.Tables("Residuos").Columns.Add("usNome", GetType(String))
            'dsDataAux.Tables("Residuos").Columns.Add("usLogin", GetType(String))

            'dsDataAux.Tables("Residuos").Rows.Add()
            'dsDataAux.Tables("Residuos").Rows.Add()
            'dsDataAux.Tables("Residuos").Rows.Add()

            'dsDataAux.Tables("Residuos").Rows(0)("usCodigo") = 1
            'dsDataAux.Tables("Residuos").Rows(0)("usNome") = "Nill"
            'dsDataAux.Tables("Residuos").Rows(0)("usLogin") = "nill.pinheiro"


            'dsDataAux.Tables("Residuos").Rows(1)("usCodigo") = 1
            'dsDataAux.Tables("Residuos").Rows(1)("usNome") = "Nill"
            'dsDataAux.Tables("Residuos").Rows(1)("usLogin") = "nill.pinheiro"

            'dsDataAux.Tables("Residuos").Rows(2)("usCodigo") = 1
            'dsDataAux.Tables("Residuos").Rows(2)("usNome") = "Nill"
            'dsDataAux.Tables("Residuos").Rows(2)("usLogin") = "nill.pinheiro"
            'dgwDados.DataSource = dsDataAux
            'dgwDados.DataBind()


            Session("WhereUtilizadoNaConsulta") = strWhere
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
