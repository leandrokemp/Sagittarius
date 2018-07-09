Imports FuncoesComuns.FuncoesComuns.MemberShips
Imports System.Configuration

Partial Class PortalReciclagem_UserControl_Usuarios_wucCadastrarUsuarios
    Inherits System.Web.UI.UserControl


    Public Property DsResiduosAdicionados() As Data.DataSet
        Get
            If (Session("DsResiduosAdicionados") IsNot Nothing) Then
                Return CType(Session("DsResiduosAdicionados"), Data.DataSet)
            Else

                Return New Data.DataSet
            End If
        End Get

        Set(ByVal value As Data.DataSet)
            Session("DsResiduosAdicionados") = value
        End Set
    End Property


    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintUsuarios As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuUsuarios As buSeguranca.buUsuarios
    Private clsbuGrupos As buSeguranca.buGrupos
    Private clsResiduos As buCadastros.buResiduos
    Private clsUsuariosResiduos As buSeguranca.buUsuariosResiduos
    Private clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper


    'variaveis que indicarão qual é o tipo de operação que o usuario deseja realizar na tela edição
    Private mblnIncluir, mblnExcluir, mblnConsultar, mblnAlterar, mblnIsRegistro As Boolean
    Private mstrMinhaPagina As String
    Private mstrLogin As String
    ''' <summary>
    ''' Evento que é disparado quando a pagina é carregada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verifica se é a primeira vez que esta sendo feito o refresh da pagina
        If Not IsPostBack Then

            'Quando for registro feito pelo proprio usuario
            mblnIsRegistro = IIf(Not String.IsNullOrEmpty(Request.QueryString("IsRegistro")), Convert.ToBoolean(Request.QueryString("IsRegistro")), False)

            'verifica se o usuario esta querendo incluir
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mblnIncluir = True
                btnConfirmar.Visible = True
                tbchkSenha.Visible = False
                tbSenha.Visible = True
                mstrLogin = IIf(Not String.IsNullOrEmpty(Request.QueryString("Login")), Convert.ToString(Request.QueryString("Login")), "")
                populacboGrupo()



                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintUsuarios
                mintUsuarios = Request.QueryString("Consultar")
                mstrMinhaPagina = IIf(Not String.IsNullOrEmpty(Request.QueryString("MinhaPagina")), Convert.ToString(Request.QueryString("MinhaPagina")), "")
                mblnConsultar = True
                btnAlterar.Visible = True
                populacboGrupo()
                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintUsuarios = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
                populacboGrupo()
                ExibeDados()
            End If

            PopulaResiduos()
            'senão for a primeira vez que ocorre o refresh da pagina..
            'verifica novamente qual a operação que o usuario ta realizando
        Else
            'Quando for registro feito pelo proprio usuario
            mblnIsRegistro = IIf(Not String.IsNullOrEmpty(Request.QueryString("IsRegistro")), Convert.ToBoolean(Request.QueryString("IsRegistro")), False)


            'Como a variável global btnInclui, btnExcluir, btnAlterar e intID não guardam 
            'o valor, e ao invés de guardar em variável de sessão. Essa verificação é retomada.
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mblnIncluir = True
                btnConfirmar.Visible = True
                tbchkSenha.Visible = False
                tbSenha.Visible = True
                mstrLogin = IIf(Not String.IsNullOrEmpty(Request.QueryString("Login")), Convert.ToString(Request.QueryString("Login")), "")
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintUsuarios = Request.QueryString("Consultar")
                mstrMinhaPagina = IIf(Not String.IsNullOrEmpty(Request.QueryString("MinhaPagina")), Convert.ToString(Request.QueryString("MinhaPagina")), "")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintUsuarios = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
            End If


        End If
    End Sub

    Protected Sub btnRetornar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRetornar.Click
        Try
            ''retorna para a tela de consulta
            'If String.IsNullOrEmpty(mstrMinhaPagina) Then
            '    Response.Redirect("Default.aspx")
            'Else
            '    Response.Redirect("../../MinhaPagina/" & mstrMinhaPagina)
            'End If

            If String.IsNullOrEmpty(mstrMinhaPagina) And String.IsNullOrEmpty(mstrLogin) Then
                Response.Redirect("Default.aspx")
            ElseIf String.IsNullOrEmpty(mstrLogin) Then
                Response.Redirect("../../MinhaPagina/" & mstrMinhaPagina)
            ElseIf String.IsNullOrEmpty(mstrMinhaPagina) Then
                Response.Redirect(mstrLogin)
            End If

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
            'If txtNome.Text = String.Empty And txtLogin.Text = String.Empty And txtSenha.Text = String.Empty _
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

            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Private Sub ExibeDados()
        Dim dsUsuarios As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbuUsuarios = New buSeguranca.buUsuarios
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("usCodigo = ")
            strWhere.Append(mintUsuarios)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsUsuarios = clsbuUsuarios.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsUsuarios.Tables(0).Rows.Count > 0 Then
                Dim strAux1() As String = Roles.GetRolesForUser(dsUsuarios.Tables(0).Rows(0)("usLogin").ToString)

                rblRoles.SelectedValue = strAux1(0).ToString()
                VerificaPessoaOuEmpresa()

                txtNome.Text = dsUsuarios.Tables(0).Rows(0)("usNome").ToString
                txtLogin.Text = dsUsuarios.Tables(0).Rows(0)("usLogin").ToString
                txtEndereco.Text = dsUsuarios.Tables(0).Rows(0)("usEndereco").ToString
                txtEmail.Text = dsUsuarios.Tables(0).Rows(0)("usEmail").ToString
                txtFone.Text = dsUsuarios.Tables(0).Rows(0)("usTelefone").ToString
                txtCnpj.Text = dsUsuarios.Tables(0).Rows(0)("usCnpj").ToString



                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then
                    rblRoles.Enabled = False
                    txtNome.Enabled = False
                    txtLogin.Enabled = False
                    btnAdicionar.Enabled = False
                    tbchkSenha.Visible = False
                    tbSenha.Visible = False
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    rblRoles.Enabled = True
                    txtNome.Enabled = True
                    'txtLogin.Enabled = True
                    lblSenha.Visible = True
                    btnAdicionar.Enabled = True
                    tbchkSenha.Visible = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsUsuarios = Nothing
            clsbuUsuarios = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try



            Dim dsDadosAux As Data.DataSet = New Data.DataSet
            Dim strAux As StringBuilder = New StringBuilder

            strAux.Append(" usCodigo = ")
            strAux.Append(mintUsuarios)

            clsbuUsuarios = New buSeguranca.buUsuarios
            dsDadosAux = clsbuUsuarios.Consultar(strAux.ToString)


            Dim strAux1() As String = Roles.GetRolesForUser(dsDadosAux.Tables(0).Rows(0)("usLogin").ToString)
            Dim StrRole As String = strAux1(0).ToString()

            clsbuUsuarios = New buSeguranca.buUsuarios
            If clsbuUsuarios.Alterar(mintUsuarios, txtEmail.Text, txtNome.Text, Trim(txtLogin.Text), txtEndereco.Text, txtCnpj.Text, txtFone.Text) Then



                Roles.RemoveUserFromRole(dsDadosAux.Tables(0).Rows(0)("usLogin").ToString, StrRole)


                Dim strUser(0) As String
                strUser(0) = txtLogin.Text
                Roles.AddUsersToRole(strUser, rblRoles.SelectedValue)


                If chkAlterarSenha.Checked Then

                    Dim user As MembershipUser = Membership.GetUser(dsDadosAux.Tables(0).Rows(0)("usLogin").ToString)
                    Dim StrinNewSenha As String = user.ResetPassword
                    user.ChangePassword(StrinNewSenha, txtSenha.Text)

                End If

                SalvaResiduos(mintUsuarios)

                lblAcao.Text = "Alteração"
                lblTextoAcao.Text = "Registro Alterado com Sucesso"

                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)
                Session("DsResiduosAdicionados") = Nothing


            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Incluir()
        Try

            clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
            clsbuUsuarios = New buSeguranca.buUsuarios
            Dim dsDadosAux As Data.DataSet
            dsDadosAux = clsbuUsuarios.IncluirRetornaIncluido(txtNome.Text, Trim(txtLogin.Text), txtEmail.Text.Trim(), txtEndereco.Text, txtCnpj.Text, txtFone.Text)


            If dsDadosAux.Tables(0).Rows.Count > 0 Then


                Dim clsMembership As MemberShipHelper

                clsMembership = New MemberShipHelper


                clsMembership.CreateUser(rblRoles, txtLogin.Text, txtSenha.Text, txtEmail.Text, "", Not mblnIsRegistro, txtNome.Text)
                clsbuUsuarios.AlterarUserID(CType(dsDadosAux.Tables(0).Rows(0)("usCodigo"), Int32), Membership.GetUser(dsDadosAux.Tables(0).Rows(0)("usLogin").ToString()).ProviderUserKey.ToString())



                'Salva os Residuos caso seja empresa
                SalvaResiduos(Convert.ToInt32(dsDadosAux.Tables(0).Rows(0)("usCodigo").ToString))


                lblAcao.Text = "Inclusão"
                lblTextoAcao.Text = "Registro Incluido com Sucesso"
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)
                Session("DsResiduosAdicionados") = Nothing
            Else

                MsgBox(MsgBoxStyle.OkOnly)
            End If




        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub SalvaResiduos(ByVal usCodigo As Integer)


        'somente se for alguma empresa
        If rblRoles.SelectedValue.Equals(ConfigurationSettings.AppSettings("ROLE_EMPRESADOADORA").ToString) Or rblRoles.SelectedValue.Equals(ConfigurationSettings.AppSettings("ROLE_RECEPTORA").ToString) Or _
       rblRoles.SelectedValue.Equals(ConfigurationSettings.AppSettings("ROLE_EMPRESADOADORA").ToString) Then

            clsUsuariosResiduos = New buSeguranca.buUsuariosResiduos

            clsUsuariosResiduos.Excluir("usCodigo = " & usCodigo)


            For Each drRowAux As Data.DataRow In DsResiduosAdicionados.Tables(0).Rows
                clsUsuariosResiduos = New buSeguranca.buUsuariosResiduos
                clsUsuariosResiduos.Incluir(usCodigo, drRowAux("reCodigo"))
            Next
        End If


    End Sub
    Private Sub Excluir()
        Try
            Dim strAux As StringBuilder = New StringBuilder
            Dim dsDados As Data.DataSet
            strAux.Append(" UsCodigo = ").Append(mintUsuarios)

            clsbuUsuarios = New buSeguranca.buUsuarios()
            dsDados = clsbuUsuarios.Consultar(strAux.ToString)


            clsbuUsuarios = New buSeguranca.buUsuarios
            If clsbuUsuarios.Excluir(mintUsuarios, txtLogin.Text) Then


                Dim clsMemberShip As MemberShipHelper
                clsMemberShip = New MemberShipHelper
                clsMemberShip.deleteUser(dsDados.Tables(0).Rows(0)("usLogin"))


                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Registro Excluido com Sucesso"
                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)


            Else
                MsgBox("não foi possivel excluir esse registro devido a relacionamentos")
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

            'If String.IsNullOrEmpty(mstrMinhaPagina) Then
            '    Response.Redirect("Default.aspx?")
            'Else
            '    Response.Redirect("../../MinhaPagina/" & mstrMinhaPagina)
            'End If

            If String.IsNullOrEmpty(mstrMinhaPagina) Or String.IsNullOrEmpty(mstrLogin) Then
                Response.Redirect("Default.aspx")
            ElseIf String.IsNullOrEmpty(mstrLogin) Then
                Response.Redirect("../../MinhaPagina/" & mstrMinhaPagina)
            ElseIf String.IsNullOrEmpty(mstrMinhaPagina) Then
                Response.Redirect(mstrLogin)
            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    ''' <summary>
    ''' Função que popula a combo
    ''' </summary>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Public Sub populacboGrupo()
        Dim dsDados As Data.DataSet
        Dim intCount As Integer = 0

        Try
            Dim clsMemberShipHelper As MemberShipHelper = New MemberShipHelper

            dsDados = clsMemberShipHelper.GetRolesJustName






            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1 Step 1

                If Not mblnIsRegistro Then
                    If Not dsDados.Tables(0).Rows(i)("RoleName").ToString.Equals(ConfigurationSettings.AppSettings("ROLE_USUARIOANONIMO").ToString) Then
                        rblRoles.Items.Add(dsDados.Tables(0).Rows(i)("RoleName").ToString)


                    End If

                Else
                    If Not dsDados.Tables(0).Rows(i)("RoleName").ToString.Equals(ConfigurationSettings.AppSettings("ROLE_USUARIOANONIMO").ToString) And Not dsDados.Tables(0).Rows(i)("RoleName").ToString.Equals(ConfigurationSettings.AppSettings("ROLE_ADMINISTRADOR").ToString) Then
                        rblRoles.Items.Add(dsDados.Tables(0).Rows(i)("RoleName").ToString)


                    End If
                End If

            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnACAO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnACAO.Click
        RedirecionaPagina()
    End Sub

    Protected Sub chkAlterarSenha_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAlterarSenha.CheckedChanged

        If chkAlterarSenha.Checked Then
            rfvtxtSenha.Enabled = True
            rfvtxtConfirmaSenha.Enabled = True
            tbSenha.Visible = True
        Else
            rfvtxtSenha.Enabled = False
            rfvtxtConfirmaSenha.Enabled = False
            tbSenha.Visible = False
        End If
    End Sub

    Protected Sub rblRoles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblRoles.SelectedIndexChanged

        VerificaPessoaOuEmpresa()

    End Sub

    Protected Sub VerificaPessoaOuEmpresa()


        If rblRoles.SelectedValue.Equals(ConfigurationSettings.AppSettings("ROLE_EMPRESADOADORA").ToString) Or rblRoles.SelectedValue.Equals(ConfigurationSettings.AppSettings("ROLE_RECEPTORA").ToString) Or _
       rblRoles.SelectedValue.Equals(ConfigurationSettings.AppSettings("ROLE_EMPRESADOADORA").ToString) Then

            trCnpj.Visible = True
            divResiduos.Visible = True
        Else 'adim ou pessoa fisica
            trCnpj.Visible = False
            divResiduos.Visible = False

        End If

    End Sub

    Public Sub PopulaResiduos()

        If (mintUsuarios <> Nothing) Then
            Dim strAux1 As StringBuilder = New StringBuilder
            strAux1.Append(" usCodigo = ").Append(mintUsuarios)
            clsUsuariosResiduos = New buSeguranca.buUsuariosResiduos


            Me.DsResiduosAdicionados = clsUsuariosResiduos.Consultar(strAux1.ToString)

            gvwAdicionados.DataSource = DsResiduosAdicionados
            gvwAdicionados.DataBind()

            PopulaResiduosAux()
        Else ' é inclusão
            clsResiduos = New buCadastros.buResiduos
            Dim strAux As StringBuilder = New StringBuilder
            gvwResiduos.DataSource = clsResiduos.Consultar()
            gvwResiduos.DataBind()

        End If


    End Sub

    ''' <summary>
    ''' Popula a combo de residuos de cima quando é alteração, adiçao ou exclusão de algum residuo da grid Adicionados
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PopulaResiduosAux()

        Dim strAux As StringBuilder = New StringBuilder


        clsResiduos = New buCadastros.buResiduos
        Dim dsData1Aux = New Data.DataSet
        dsData1Aux = clsResiduos.Consultar()


        If DsResiduosAdicionados.Tables(0).Rows.Count > 0 Then
            For Each drRowAux As Data.DataRow In DsResiduosAdicionados.Tables(0).Rows
                strAux = New StringBuilder

                strAux.Append(drRowAux("ReCodigo")).Append(",")

            Next


            gvwResiduos.DataSource = dsData1Aux.Tables(0).Select(" Recodigo not in ( " & strAux.ToString.Substring(0, strAux.Length - 1) & ")")
            gvwResiduos.DataBind()
        Else
            gvwResiduos.DataSource = dsData1Aux
            gvwResiduos.DataBind()
        End If



    End Sub


    Protected Sub gvwAdicionados_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvwAdicionados.RowDeleting

        Dim intCodRe As Integer = gvwAdicionados.DataKeys(e.RowIndex).Value

        Dim dsAux As Data.DataSet = New Data.DataSet
        Dim drAux() As Data.DataRow




        dsAux = Me.DsResiduosAdicionados
        drAux = dsAux.Tables(0).Select("ReCodigo =(" & intCodRe & ")")


        Me.DsResiduosAdicionados.Tables(0).Rows.Remove(drAux(0))


        gvwAdicionados.DataSource = DsResiduosAdicionados
        gvwAdicionados.DataBind()

        PopulaResiduosAux()



    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionar.Click

        Dim dsDataAux As Data.DataSet
        Dim drAux As Data.DataRow
        Dim i As Integer = 0


        dsDataAux = New Data.DataSet


        dsDataAux.Tables.Add()

        dsDataAux.Tables(0).Columns.Add("reNome", GetType(String))
        dsDataAux.Tables(0).Columns.Add("ReCodigo", GetType(Integer))


        For Each row As GridViewRow In gvwResiduos.Rows

            Dim chkSelecionar As CheckBox = CType(row.FindControl("chkSelecionar"), CheckBox)
            Dim litNome As Literal = CType(row.FindControl("litNome"), Literal)



            If chkSelecionar.Checked Then

                drAux = dsDataAux.Tables(0).NewRow
                drAux("ReNome") = litNome.Text
                drAux("ReCodigo") = gvwResiduos.DataKeys(i).Value
                dsDataAux.Tables(0).Rows.Add(drAux)

            End If

            i = i + 1
        Next


        Me.DsResiduosAdicionados = dsDataAux


        gvwAdicionados.DataSource = DsResiduosAdicionados
        gvwAdicionados.DataBind()

        PopulaResiduosAux()





    End Sub


End Class
