Imports System.Web.Security
Imports buSeguranca
Namespace FuncoesComuns.MemberShips
    Public Class UsuariosHelper
        Public Function RetornaUsuarioLogado() As Data.DataSet

            Dim muUserLogado As MembershipUser = Membership.GetUser()
            Dim clsBuUsuario As buUsuarios
            Dim strWHERE As System.Text.StringBuilder

            If muUserLogado IsNot Nothing Then
                clsBuUsuario = New buUsuarios
                strWHERE = New System.Text.StringBuilder
                strWHERE.Append(" u.userID = '").Append(muUserLogado.ProviderUserKey.ToString()).Append("'")


                RetornaUsuarioLogado = clsBuUsuario.Consultar(strWHERE.ToString)

            Else
                RetornaUsuarioLogado = New Data.DataSet
            End If


            'if (!ClientesBLL.EstaLogado()) return new ClientesTO();

            '           MembershipUser muUserLogado = Membership.GetUser();
            '           ClientesTO clsClienteLogado = ClientesBLL.GetByUserID(muUserLogado.ProviderUserKey.ToString());
            '           return clsClienteLogado;


        End Function
    End Class
End Namespace
