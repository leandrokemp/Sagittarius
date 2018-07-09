
Partial Class UserControl_Residuos_WebUserControl
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintResiduos As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuResiduos As buCadastros.buResiduos
    Private clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper


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
                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintResiduos
                mintResiduos = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintResiduos = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
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
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintResiduos = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintResiduos = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
            End If


        End If
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
            'validação dos campos Antiga....agora é feito via ajax
            'If txtNome.Text = String.Empty And txtHabilitado.Text = String.Empty And txtSenha.Text = String.Empty _
            'And rblRoles.SelectedValue = "-1" Then

            '    MsgBox("Você não pode inserir um registro em branco", MsgBoxStyle.OkOnly, "AVISO")
            'ElseIf txtNome.Text = String.Empty Then
            '    MsgBox("O campo Nome tem preenchimento obrigatorio", MsgBoxStyle.OkOnly, "AVISO")
            'Else
            'verifica qual a operaçao o usuario esta realizando para saber qual açao executar


            If mblnExcluir Then
                Excluir()
            ElseIf mblnIncluir Then
                Incluir()
            ElseIf mblnAlterar Or mblnConsultar Then
                Alterar()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub




    Private Sub ExibeDados()
        Dim dsResiduos As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbuResiduos = New buCadastros.buResiduos
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("ReCodigo = ")
            strWhere.Append(mintResiduos)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsResiduos = clsbuResiduos.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsResiduos.Tables(0).Rows.Count > 0 Then



                txtNome.Text = dsResiduos.Tables(0).Rows(0)("ReNome").ToString
                txtPontoKG.Text = dsResiduos.Tables(0).Rows(0)("RePontoKG").ToString
                txtHabilitado.Checked = Convert.ToBoolean(dsResiduos.Tables(0).Rows(0)("ReHabilitado"))



                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then

                    txtNome.Enabled = False
                    txtPontoKG.Enabled = False
                    txtHabilitado.Enabled = False
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    txtHabilitado.Enabled = True
                    txtPontoKG.Enabled = True
                    txtNome.Enabled = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsResiduos = Nothing
            clsbuResiduos = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try



            Dim dsDadosAux As Data.DataSet = New Data.DataSet
            Dim strAux As StringBuilder = New StringBuilder

            clsbuResiduos = New buCadastros.buResiduos
            If clsbuResiduos.Alterar(mintResiduos, txtNome.Text, Convert.ToDouble(txtPontoKG.Text), txtHabilitado.Checked) Then




                lblAcao.Text = "Alteração"
                lblTextoAcao.Text = "Registro Alterado com Sucesso"

                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)



            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Incluir()
        Try

            clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
            clsbuResiduos = New buCadastros.buResiduos




            If clsbuResiduos.Incluir(txtNome.Text, Convert.ToDouble(txtPontoKG.Text), txtHabilitado.Checked) Then
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

    Private Sub Excluir()
        Try


            clsbuResiduos = New buCadastros.buResiduos
            If clsbuResiduos.Excluir(mintResiduos) Then
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Registro Excluido com Sucesso"
                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)

            Else
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Registro não pode ser excluido devido aos relacionamentos existentes no banco"
                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)

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
