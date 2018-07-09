
Partial Class UserControl_GruposXFuncionalidade_wucCadastrarGruposXFuncionalidade
    Inherits System.Web.UI.UserControl

    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintGruposxFuncionalidades As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuGruposxFuncionalidades As buSeguranca.buGruposxFuncionalidades
    Private clsbuTipoFuncionalidade As buSeguranca.buTipoFuncionalidade

    'variaveis que indicarão qual é o tipo de operação que o usuario deseja realizar na tela edição
    Private mblnIncluir, mblnExcluir, mblnConsultar, mblnAlterar As Boolean


    ''' <summary>
    ''' Evento que é disparado quando a pagina é carregada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verifica se é a primeira vez que esta sendo feito o refresh da pagina
        If Not IsPostBack Then


            'verifica se o usuario esta querendo incluir
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mblnIncluir = True
                btnConfirmar.Visible = True

                If Not IsNothing(Request.QueryString("SelectedRoleIncluir")) Then
                    Session("SelectedRoleIncluir") = Request.QueryString("SelectedRoleIncluir")
                End If

                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintGruposxFuncionalidades
                mintGruposxFuncionalidades = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintGruposxFuncionalidades = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True

                If Not IsNothing(Request.QueryString("SelectedRoleExcluir")) Then
                    Session("SelectedRoleExcluir") = Request.QueryString("SelectedRoleExcluir")
                End If


                ExibeDados()


            End If
            'senão for a primeira vez que ocorre o refresh da pagina..
            'verifica novamente qual a operação que o usuario ta realizando


        Else
            'Como a variável global btnInclui, btnExcluir, btnAlterar e intID não guardam 
            'o valor, e ao invés de guardar em variável de sessão. Essa verificação é retomada.
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mblnIncluir = True
                btnConfirmar.Visible = True
                If Not IsNothing(Request.QueryString("SelectedRoleIncluir")) Then
                    Session("SelectedRoleIncluir") = Request.QueryString("SelectedRoleIncluir")
                End If
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintGruposxFuncionalidades = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintGruposxFuncionalidades = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True

                If Not IsNothing(Request.QueryString("SelectedRoleExcluir")) Then
                    Session("SelectedRoleExcluir") = Request.QueryString("SelectedRoleExcluir")
                End If

                btnConfirmar.Visible = True
            End If


        End If

        populacboTipoFuncionalidade()
    End Sub

    Protected Sub btnRetornar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRetornar.Click
        Try
            'retorna para a tela de consulta
            Response.Redirect("Default.aspx")
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Protected Sub btnAlterar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAlterar.Click
        Try
            mblnAlterar = True
            mblnConsultar = False
            mblnExcluir = False

            btnAlterar.Visible = False
            btnConfirmar.Visible = True

            ExibeDados()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
        Try
            'validação dos campos
            If cboTipoFuncionalidade.SelectedValue = "-1" Then
                MsgBox("O campo Nome tem preenchimento obrigatorio", MsgBoxStyle.OkOnly, "AVISO")
            Else
                'verifica qual a operaçao o usuario esta realizando para saber qual açao executar
                If mblnExcluir Then
                    Excluir()
                ElseIf mblnIncluir Then
                    Incluir()
                ElseIf mblnAlterar Or mblnConsultar Then
                    Alterar()
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ExibeDados()
        Dim dsGruposxFuncionalidades As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            populacboTipoFuncionalidadeExcluir()
            clsbuGruposxFuncionalidades = New buSeguranca.buGruposxFuncionalidades
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("gxf.funcCodigo = ")
            strWhere.Append(mintGruposxFuncionalidades)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsGruposxFuncionalidades = clsbuGruposxFuncionalidades.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsGruposxFuncionalidades.Tables(0).Rows.Count > 0 Then
                cboTipoFuncionalidade.SelectedValue = dsGruposxFuncionalidades.Tables(0).Rows(0)("FuncCodigo").ToString
                ' txtDescricao.Text = dsGruposxFuncionalidades.Tables(0).Rows(0)("cliEnd").ToString

                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then
                    cboTipoFuncionalidade.Enabled = False
                    ' txtDescricao.Enabled = False

                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    cboTipoFuncionalidade.Enabled = True
                    ' txtDescricao.Enabled = True

                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsGruposxFuncionalidades = Nothing
            clsbuGruposxFuncionalidades = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        'Try

        '    clsbuGruposxFuncionalidades = New buSeguranca.buGruposxFuncionalidades
        '    If clsbuGruposxTipoFuncionalidade.Alterar(txtNome.Text, mintGruposxTipoFuncionalidade) Then
        '        If MsgBox("Registro Alterado com sucesso", MsgBoxStyle.OkOnly, "ALTERACAO") = MsgBoxResult.Ok Then
        '            RedirecionaPagina()
        '        End If

        '    End If
        'Catch ex As Exception
        '    Throw ex
        'Finally

        'End Try
    End Sub

    Private Sub Incluir()
        Try

            clsbuGruposxFuncionalidades = New buSeguranca.buGruposxFuncionalidades
            If clsbuGruposxFuncionalidades.Incluir(cboTipoFuncionalidade.SelectedValue, Session("SelectedRoleIncluir")) Then
                If MsgBox("Registro Incluido com sucesso", MsgBoxStyle.OkOnly, "INCLUSAO") = MsgBoxResult.Ok Then
                    RedirecionaPagina()
                End If

            End If

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Excluir()
        Try

            clsbuGruposxFuncionalidades = New buSeguranca.buGruposxFuncionalidades
            Dim strwhere As Text.StringBuilder = New Text.StringBuilder()


            strwhere.Append("funcCodigo =")
            strwhere.Append(mintGruposxFuncionalidades)
            strwhere.Append(" and grpCodigo = ")
            strwhere.Append(Session("SelectedRoleExcluir"))
            If clsbuGruposxFuncionalidades.Excluir(strwhere.ToString) Then
                If MsgBox("Registro Excluido com sucesso", MsgBoxStyle.OkOnly, "DELECAO") = MsgBoxResult.Ok Then
                    RedirecionaPagina()
                End If

            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    ''' <summary>
    ''' Função que irá redirecionar a pagina para ela mesma ou para a tela de consulta
    ''' </summary>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Private Sub RedirecionaPagina()
        Dim strAux As Text.StringBuilder

        Try
            'se for uma exclusão ou uma cosulta (alteração) apos realizada a operação
            'a pagina será para a tela de consulta
            If mblnExcluir Or mblnConsultar Or mblnAlterar Or mblnIncluir Then
                Response.Redirect("Default.aspx?")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Função que popula a combo
    ''' </summary>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Public Sub populacboTipoFuncionalidade()
        Dim dsDados As Data.DataSet
        Dim dsDadosAux As Data.DataSet
        Dim StrAux As Text.StringBuilder
        Dim blnVirgula As Boolean = False

        Try
            clsbuGruposxFuncionalidades = New buSeguranca.buGruposxFuncionalidades
            StrAux = New Text.StringBuilder

            StrAux.Append("roleId = ")

            If mblnIncluir Then
                StrAux.Append(Session("SelectedRoleIncluir"))
            ElseIf mblnExcluir Then
                StrAux.Append(Session("SelectedRoleExcluir"))
            End If
            dsDadosAux = clsbuGruposxFuncionalidades.ConsultarFuncionalidadesdoGrupo(StrAux.ToString)

            If dsDadosAux.Tables(0).Rows.Count <> 0 Then
                StrAux = New Text.StringBuilder
                StrAux.Append("TipoFuncionalidade.TipofuncCodigo not in(")
                For i As Integer = 0 To dsDadosAux.Tables(0).Rows.Count - 1
                    If blnVirgula Then
                        StrAux.Append(",")
                    End If
                    StrAux.Append(dsDadosAux.Tables(0).Rows(i)("TipofuncCodigo").ToString)
                    blnVirgula = True
                Next
                StrAux.Append(")")



                clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
                dsDados = clsbuTipoFuncionalidade.Consultar(StrAux.ToString)
            Else
                clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
                dsDados = clsbuTipoFuncionalidade.Consultar("")
            End If



            cboTipoFuncionalidade.Items.Add("Selecione")
            cboTipoFuncionalidade.Items(0).Value = "-1"

            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1
                cboTipoFuncionalidade.Items.Add(dsDados.Tables(0).Rows(i)("Descricao").ToString)
                cboTipoFuncionalidade.Items(i + 1).Value = dsDados.Tables(0).Rows(i)("tipofuncCodigo").ToString
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub populacboTipoFuncionalidadeExcluir()
        Dim dsDados As Data.DataSet
        Try
            clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
            dsDados = clsbuTipoFuncionalidade.Consultar()

            cboTipoFuncionalidade.Items.Add("Selecione")
            cboTipoFuncionalidade.Items(0).Value = "-1"

            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1
                cboTipoFuncionalidade.Items.Add(dsDados.Tables(0).Rows(i)("funcNOme").ToString)
                cboTipoFuncionalidade.Items(i + 1).Value = dsDados.Tables(0).Rows(i)("funcCodigo").ToString
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
