
Partial Class UserControl_Beneficio_WebUserControl
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintBeneficio As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuBeneficio As buCadastros.buBeneficio
    'Private clsbuBeneficio As buCadastros.buBeneficio
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
                tbchkSenha.Visible = False
                tbSenha.Visible = True

                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintBeneficio
                mintBeneficio = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True

                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintBeneficio = Convert.ToInt32(Request.QueryString("Excluir"))
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
                tbchkSenha.Visible = False
                tbSenha.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintBeneficio = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintBeneficio = Convert.ToInt32(Request.QueryString("Excluir"))
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
            'If txttipo_usuario.Text = String.Empty And txttipo_residuo.Text = String.Empty And txtSenha.Text = String.Empty _
            'And rblRoles.SelectedValue = "-1" Then

            '    MsgBox("Você não pode inserir um registro em branco", MsgBoxStyle.OkOnly, "AVISO")
            'ElseIf txttipo_usuario.Text = String.Empty Then
            '    MsgBox("O campo tipo_usuario tem preenchimento obrigatorio", MsgBoxStyle.OkOnly, "AVISO")
            'Else
            'verifica qual a operaçao o usuario esta realizando para saber qual açao executar


            If mblnExcluir Then
                Excluir()
            ElseIf mblnIncluir Then
                Incluir()
            ElseIf mblnAlterar Or mblnConsultar Then
                Alterar()
            End If

            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Private Sub ExibeDados()
        Dim dsBeneficio As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbuBeneficio = New buCadastros.buBeneficio
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("usCodigo = ")
            strWhere.Append(mintBeneficio)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsBeneficio = clsbuBeneficio.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsBeneficio.Tables(0).Rows.Count > 0 Then
                Dim strAux1() As String = Roles.GetRolesForUser(dsBeneficio.Tables(0).Rows(0)("ustipo_residuo").ToString)

                rblRoles.SelectedValue = strAux1(0).ToString()
                txttipo_usuario.Text = dsBeneficio.Tables(0).Rows(0)("ustipo_usuario").ToString
                txttipo_residuo.Text = dsBeneficio.Tables(0).Rows(0)("ustipo_residuo").ToString
                txtEndereco.Text = dsBeneficio.Tables(0).Rows(0)("usEndereco").ToString
                txtdescricao_residuo.Text = dsBeneficio.Tables(0).Rows(0)("usdescricao_residuo").ToString



                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then
                    rblRoles.Enabled = False
                    txttipo_usuario.Enabled = False
                    txttipo_residuo.Enabled = False
                    tbchkSenha.Visible = False
                    tbSenha.Visible = False
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    rblRoles.Enabled = True
                    txttipo_usuario.Enabled = True
                    'txttipo_residuo.Enabled = True
                    lblSenha.Visible = True
                    tbchkSenha.Visible = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsBeneficio = Nothing
            clsbuBeneficio = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try



            Dim dsDadosAux As Data.DataSet = New Data.DataSet
            Dim strAux As StringBuilder = New StringBuilder

            strAux.Append(" usCodigo = ")
            strAux.Append(mintBeneficio)

            clsbuBeneficio = New buCadastros.buBeneficio
            dsDadosAux = clsbuBeneficio.Consultar(strAux.ToString)


            Dim strAux1() As String = Roles.GetRolesForUser(dsDadosAux.Tables(0).Rows(0)("ustipo_residuo").ToString)
            Dim StrRole As String = strAux1(0).ToString()

            clsbuBeneficio = New buCadastros.buBeneficio
            If clsbuBeneficio.Alterar(mintBeneficio, txtdescricao_residuo.Text, txttipo_usuario.Text, Trim(txttipo_residuo.Text), txtEndereco.Text) Then



                Roles.RemoveUserFromRole(dsDadosAux.Tables(0).Rows(0)("ustipo_residuo").ToString, StrRole)


                Dim strUser(0) As String
                strUser(0) = txttipo_residuo.Text
                Roles.AddUsersToRole(strUser, rblRoles.SelectedValue)

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
            clsbuBeneficio = New buCadastros.buBeneficio
            Dim dsDadosAux As Data.DataSet
            If clsbuBeneficio.Incluir(txttipo_usuario.Text, txttipo_residuo.Text, txtdescricao_residuo.Text, txtEndereco.Text) Then
                lblAcao.Text = "Inclusão"
                lblTextoAcao.Text = "Registro Incluido com Sucesso"
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)
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


            clsbuBeneficio = New buCadastros.buBeneficio
            If clsbuBeneficio.Excluir(mintBeneficio, txttipo_residuo.Text) Then
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Registro Excluido com Sucesso"
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
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
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

