Imports FuncoesComuns.FuncoesComuns.MemberShips
Partial Class PortalReciclagem_Interfaces_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
    Public Sub montamenu()

        wucNavMenus1.populaMenus()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then


            montamenu()

            Dim clsMembershipHelper As New FuncoesComuns.FuncoesComuns.MemberShips.MemberShipHelper


            lblUsuario.Visible = False
            Dim user As MembershipUser = Membership.GetUser()
            If (user IsNot Nothing) Then
                lblUsuario.Text = "Bem-Vindo(a): " & user.UserName.ToUpper()
                btnLogoff.Visible = True
                lblUsuario.Visible = True
                btnMinhaPagina.Visible = True And Not clsMembershipHelper.IsThisUsuario(ConfigurationManager.AppSettings("ROLE_ADMINISTRADOR"))
                btnfacaLogin.Visible = False
            Else
                lblUsuario.Visible = False
                btnfacaLogin.Visible = True
                btnLogoff.Visible = False
                btnMinhaPagina.Visible = False
            End If

        End If

        clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper


        Dim url As String = HttpContext.Current.Request.ApplicationPath


        clsFuncoesComuns.setJavaScript(IIf(url = "", "", HttpContext.Current.Request.ApplicationPath) + "/util/javascript/jquery.1.3.2.js")
        clsFuncoesComuns.setJavaScript(IIf(url = "", "", HttpContext.Current.Request.ApplicationPath) + "/util/javascript/jquery.ui.1.7.2.js")
        clsFuncoesComuns.setJavaScript(IIf(url = "", "", HttpContext.Current.Request.ApplicationPath) + "/util/javascript/jquery.meio.mask.min.js")
        clsFuncoesComuns.setJavaScript(IIf(url = "", "", HttpContext.Current.Request.ApplicationPath) + "/util/javascript/AC_RunActiveContent.js")
        clsFuncoesComuns.setJavaScript(IIf(url = "", "", HttpContext.Current.Request.ApplicationPath) + "/util/javascript/slideshow.js")
        clsFuncoesComuns.setJavaScript(IIf(url = "", "", HttpContext.Current.Request.ApplicationPath) + "/util/javascript/FontSize.js")

        clsFuncoesComuns.setJavaScript(IIf(url = "", "", HttpContext.Current.Request.ApplicationPath) + "/util/javascript/Funcoes.js")



        Page.ClientScript.RegisterStartupScript(Me.GetType(), "setMask", "$('input:text').setMask();", True)


    End Sub

    Protected Sub btnLogoff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogoff.Click
        FormsAuthentication.SignOut()
        Response.Redirect("~/Interfaces/Default.aspx")
    End Sub

    Protected Sub btnMinhaPagina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMinhaPagina.Click
        Dim clsMemberShipHelper As FuncoesComuns.FuncoesComuns.MemberShips.MemberShipHelper


        clsMemberShipHelper = New FuncoesComuns.FuncoesComuns.MemberShips.MemberShipHelper
        If clsMemberShipHelper.IsThisUsuario(ConfigurationManager.AppSettings.Get("ROLE_EMPRESADOADORA")) Then
            Response.Redirect("MinhaPagina/Default_EmpresaGeradora.aspx")
        ElseIf clsMemberShipHelper.IsThisUsuario(ConfigurationManager.AppSettings.Get("ROLE_RECEPTORA")) Then
            Response.Redirect("MinhaPagina/Default_EmpresaReceptora.aspx")
        ElseIf clsMemberShipHelper.IsThisUsuario(ConfigurationManager.AppSettings.Get("ROLE_PESSOAFISICA")) Then
            Response.Redirect("MinhaPagina/Default_PessoFisica.aspx")
        ElseIf clsMemberShipHelper.IsThisUsuario(ConfigurationManager.AppSettings.Get("ROLE_EMPRESATERCEIRA")) Then
            Response.Redirect("MinhaPagina/Default_EmpresaTerceira.aspx")
        End If







    End Sub
End Class

