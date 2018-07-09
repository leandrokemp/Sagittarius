Imports FuncoesComuns.FuncoesComuns.MemberShips
Partial Class UserControl_Login_wucLogin1
    Inherits System.Web.UI.UserControl


    Protected Sub btnLembrarSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        Dim clsMemberShip As MemberShipHelper



        Dim FailureText As Literal = CType(Login1.FindControl("FailureText"), Literal)


        clsMemberShip = New MemberShipHelper
        FailureText.Text = clsMemberShip.Authenticate(Login1.UserName, Login1.Password, e)
        If Not FailureText.Text.Equals(String.Empty) Then

            FailureText.Visible = True
        Else
            FailureText.Visible = False


        End If






    End Sub
End Class
