Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Web.Security
Imports System.Web.UI.WebControls


Namespace FuncoesComuns.MemberShips


    Public Class MemberShipHelper

        Public Function getRolesAndNumberOfUser() As DataTable
            Dim dtbRoleList As DataTable

            dtbRoleList = New DataTable()
            dtbRoleList.Columns.Add("RoleName")
            dtbRoleList.Columns.Add("UserCount")

            Dim strAllRoles() As String = Roles.GetAllRoles()
            Dim clsAllUsers As MembershipUserCollection = Membership.GetAllUsers()
            Dim strRoleName As String
            For Each strRoleName In strAllRoles

                Dim intNumberOfUsersInRole As Integer = 0
                Dim strUsersInRole() As String = Roles.GetUsersInRole(strRoleName)
                For Each clsUser As MembershipUser In clsAllUsers

                    For Each strUserInRole As String In strUsersInRole

                        If (strUserInRole = clsUser.UserName) Then

                            intNumberOfUsersInRole += 1
                            Exit For
                        End If
                    Next
                Next
                Dim roleRow() As String
                roleRow(0) = strRoleName
                roleRow(1) = intNumberOfUsersInRole.ToString()

                dtbRoleList.Rows.Add(roleRow)
            Next
            Return dtbRoleList
        End Function

        Public Function GetRolesJustName(Optional ByVal strUserName As String = "") As DataSet




            Dim strAllRoles() As String

            If strUserName <> "" Then

                strAllRoles = Roles.GetRolesForUser(strUserName)
            Else

                strAllRoles = Roles.GetAllRoles
            End If




            Dim intCount As Integer = 0
            Dim dsDados As Data.DataSet


            dsDados = New Data.DataSet

            dsDados.Tables.Add("Roles")

            dsDados.Tables("Roles").Columns.Add("RoleName", GetType(String))






            For Each strNameRole As String In strAllRoles

                dsDados.Tables("Roles").Rows.Add()
                dsDados.Tables("Roles").Rows(intCount)("RoleName") = strNameRole
                intCount += 1
            Next


            Return dsDados
        End Function

        Public Function GetRolesAllInformation(Optional ByVal StrWhere As String = "") As Data.DataSet
            Dim dsDados As Data.DataSet = New Data.DataSet
            Dim clsBuMemberShipHelper As buSeguranca.buMemberShipHelper

            clsBuMemberShipHelper = New buSeguranca.buMemberShipHelper


            dsDados = clsBuMemberShipHelper.ConsultarRolesAll(StrWhere)



            Return dsDados
        End Function


        Public Sub deleteUser(ByVal strName As String)

            Dim strUsersInRole() As String = Roles.GetUsersInRole(strName)
            For Each strUser As String In strUsersInRole

                Roles.RemoveUserFromRole(strUser, strName)
                If (Roles.GetRolesForUser(strUser).Length = 0) Then
                    Membership.DeleteUser(strUser, True)
                End If
            Next
            Roles.DeleteRole(strName)
        End Sub


        Public Function getUsersByRole(ByVal strNameGroup As String) As MembershipUserCollection



            Dim clsAllUsers As MembershipUserCollection = Membership.GetAllUsers()
            Dim clsFilteredUsers As MembershipUserCollection = New MembershipUserCollection()

            Dim strUsersInRole() As String = Roles.GetUsersInRole(strNameGroup)
            For Each clsUser As MembershipUser In clsAllUsers



                For Each strUserInRole As String In strUsersInRole



                    If (strUserInRole = clsUser.UserName) Then

                        clsFilteredUsers.Add(clsUser)
                        Exit For
                    End If
                Next
            Next
            Return clsFilteredUsers
        End Function

        Public Sub getRolesByUser(ByRef rblUserRoles As RadioButtonList, ByVal strUserName As String)



            rblUserRoles.DataSource = Roles.GetAllRoles()
            rblUserRoles.DataBind()
            Dim strUserRoles() As String = Roles.GetRolesForUser(strUserName)
            For Each strRole As String In strUserRoles
                Dim lstUserRole As ListItem = rblUserRoles.Items.FindByValue(strRole)
                lstUserRole.Selected = True
            Next
        End Sub

        Private Sub UpdateUserRoles(ByRef rblUserRoles As RadioButtonList, ByVal strUserName As String)



            For Each lstUserRole As ListItem In rblUserRoles.Items



                If (lstUserRole.Selected) Then

                    If (Not Roles.IsUserInRole(strUserName, lstUserRole.Text)) Then
                        Roles.AddUserToRole(strUserName, lstUserRole.Text)

                    Else
                        If (Roles.IsUserInRole(strUserName, lstUserRole.Text)) Then
                            Roles.RemoveUserFromRole(strUserName, lstUserRole.Text)
                        End If
                    End If
                End If
            Next
        End Sub

        Public Sub DesbloquearUser(ByVal strUserName As String)
            Dim clsUser As MembershipUser = Membership.GetUser(strUserName)
            clsUser.UnlockUser()
            Membership.UpdateUser(clsUser)
        End Sub

        Public Sub BloquearUser(ByVal strUserName As String)

            Dim clsUser As MembershipUser = Membership.GetUser(strUserName)
            clsUser.IsApproved = False
            Membership.UpdateUser(clsUser)

        End Sub
        Public Sub UpdateUser(ByRef rblUserRoles As RadioButtonList, ByVal strEmail As String, ByVal strComment As String, ByVal blnIsApproved As Boolean, ByVal strUserName As String)

            Dim clsUser As MembershipUser = Membership.GetUser(strUserName)
            clsUser.Email = strEmail
            clsUser.Comment = strComment
            clsUser.IsApproved = blnIsApproved
            UpdateUserRoles(rblUserRoles, strUserName)
            Membership.UpdateUser(clsUser)
        End Sub
        Public Sub UpdateIsApproved(ByVal blnIsApproved As Boolean, ByVal strUserName As String)
            Dim clsUser As MembershipUser = Membership.GetUser(strUserName)
            clsUser.IsApproved = blnIsApproved
            Membership.UpdateUser(clsUser)
        End Sub

        Public Function CreateUser(ByRef rblUserRoles As RadioButtonList, ByVal strUserName As String, ByVal strPassword As String, ByVal strEmail As String, ByVal strComment As String, ByVal blnIsApproved As Boolean, ByVal strNome As String) As MembershipUser

            Dim clsUser As MembershipUser = Membership.CreateUser(strUserName, strPassword, strEmail)
            clsUser.IsApproved = blnIsApproved
            clsUser.Comment = strComment
            Membership.UpdateUser(clsUser)

            For Each lstUserRole As ListItem In rblUserRoles.Items

                If (lstUserRole.Selected) Then

                    Roles.AddUserToRole(clsUser.UserName, lstUserRole.Text)
                    'MemberShipHelper.SedMailDadosAcesso(strEmail, strNome, strPassword, strUserName, lstUserRole.Text)
                End If
            Next

            Return clsUser
        End Function
        'public sub InsertSite(Byref rblUserRoles As RadioButtonList , strUserName As String , strPassword As String , strEmail As String , strComment As String ,  blnIsApproved As Boolean, FuncionarioRevendaTO FuncionarioRevenda)
        '   {
        '   Membership.ApplicationName = "SharpSite"
        '   Roles.ApplicationName = "SharpSite"

        '   Try
        '       {
        '       MembershipUser(clsUser = Membership.CreateUser(strUserName, strPassword, strEmail))
        '       clsUser.IsApproved = blnIsApproved
        '       clsUser.Comment = strComment
        '       Membership.UpdateUser(clsUser)

        '           foreach (ListItem lstUserRole in rblUserRoles.Items)
        '           {
        '       Roles.AddUserToRole(clsUser.UserName, lstUserRole.Text)
        '       MemberShipHelper.SedMailDadosAcesso(strEmail, FuncionarioRevenda.Nome, strPassword, strUserName, lstUserRole.Text)
        '           }

        '       Membership.ApplicationName = "SharpIntranet"
        '       Roles.ApplicationName = "SharpIntranet"

        '       FuncionarioRevenda.UserId = clsUser.ProviderUserKey.ToString()
        '       FuncionarioRevendaBLL.UpdateUser(FuncionarioRevenda)
        '       }
        '   Catch
        '       {
        '       Membership.ApplicationName = "SharpIntranet"
        '       Roles.ApplicationName = "SharpIntranet"
        '       }
        '   }

        Public Sub UpdateEmailSite(ByVal clsUser As MembershipUser)
            Membership.ApplicationName = "SharpSite"
            Roles.ApplicationName = "SharpSite"

            Try
                Membership.UpdateUser(clsUser)

                Membership.ApplicationName = "SharpIntranet"
                Roles.ApplicationName = "SharpIntranet"

            Catch

                Membership.ApplicationName = "SharpIntranet"
                Roles.ApplicationName = "SharpIntranet"
            End Try
        End Sub

        Public Sub BlockUser(ByVal clsUser As MembershipUser)
            Membership.ApplicationName = "SharpSite"
            Roles.ApplicationName = "SharpSite"


            Try
                If (clsUser.IsApproved = True) Then
                    BloquearUser(clsUser.UserName)
                Else
                    clsUser.IsApproved = True
                    Membership.UpdateUser(clsUser)
                End If

                Membership.ApplicationName = "SharpIntranet"
                Roles.ApplicationName = "SharpIntranet"
            Catch ex As Exception
                Membership.ApplicationName = "SharpIntranet"
                Roles.ApplicationName = "SharpIntranet"
            End Try

        End Sub

        Public Function Authenticate(ByVal UserName As String, ByVal Password As String, ByRef e As AuthenticateEventArgs) As String

            Dim Usuario As MembershipUser = Membership.GetUser(UserName)

            If (Membership.ValidateUser(UserName, Password)) Then

                e.Authenticated = True
                Return ""

            Else

                If (Usuario IsNot Nothing) Then

                    If (Usuario.IsLockedOut = True) Then

                        e.Authenticated = False
                        Return "Sua conta está bloqueada, por favor contate o administrador do sistema."
                    End If

                    Return "O nome de usuário e a senha não correspondem contate o administrador."
                Else

                    e.Authenticated = False
                    Return "O nome de usuário e a senha não correspondem."

                End If
            End If
        End Function
        Public Function IsThisUsuario(ByVal strRoleGroup As String) As Boolean
            Return Roles.IsUserInRole(strRoleGroup)
        End Function



        'public static String LembrarSenha(String UserName)
        '{
        '    if (UserName.Equals(""))
        '    {
        '        return "Por favor digite um login válido.";
        '    }
        '    else
        '    {
        '        MembershipUserCollection users = Membership.GetAllUsers();
        '        String PassWord = "";
        '        Boolean Usuario = false;
        '        foreach (MembershipUser user in users)
        '        {
        '            if (user.UserName.ToLower() == UserName.ToLower())
        '            {
        '                if (!user.IsLockedOut)
        '                {
        '                    Usuario = true;
        '                    PassWord = user.ResetPassword();
        '                    EmailHelper.EnviarEmailNovaSenha(user, PassWord);

        '                    return "Sua nova senha foi enviada para o e-mail cadastrado.";
        '                }
        '                else
        '                {
        '                    Usuario = true;
        '                    return "Sua conta está bloqueada, por favor contate o administrador do sistema.";
        '                }
        '            }
        '        }

        '        if (Usuario == false)
        '            return "O nome de usuário não corresponde.";
        '        else
        '            return "";
        '    }
        '}



        'private static void SedMailDadosAcesso(String strEmail, String strNome, String strSenha, String strUsuario, String strPerfil)
        '{
        '    String strLink;
        '    if (strPerfil.ToLower().Equals("funcionario") == true)
        '        strLink = NameFile.File.Path.PATH_VIRTUAL_SITE();
        '    else
        '        strLink = NameFile.File.Path.PATH_VIRTUAL_INTRANET();

        '    EmailTO clsEmail = new EmailTO();
        '    clsEmail.MailTO = strEmail;
        '    clsEmail.NameTO = strNome;
        '    EmailHelper.EnviarEmailNovoUsuario(clsEmail, strSenha, strUsuario, strPerfil, strLink);
        '}

        'public static MembershipUser GetUserSite(String struser)
        '{
        '    MembershipUser user;

        '    try
        '    {
        '        Membership.ApplicationName = "SharpSite";
        '        Roles.ApplicationName = "SharpSite";
        '        user = Membership.GetUser(struser);
        '        Membership.ApplicationName = "SharpIntranet";
        '        Roles.ApplicationName = "SharpIntranet";
        '    }

        '    catch
        '    {
        '        Membership.ApplicationName = "SharpIntranet";
        '        Roles.ApplicationName = "SharpIntranet";
        '        return null;
        '    }

        '    return user;
        '}


        'public static void DeleteUserSite(String strUserID)
        '{
        '    try
        '    {
        '        Membership.ApplicationName = "SharpSite";
        '        Roles.ApplicationName = "SharpSite";

        '        Guid UserId = new Guid(strUserID);
        '        MembershipUser user = Membership.GetUser(UserId);
        '        string[] strUsersInRole = Roles.GetUsersInRole("Funcionario");

        '        Roles.RemoveUserFromRole(user.UserName, "Funcionario");
        '        if (Roles.GetRolesForUser(user.UserName).Length == 0)
        '            Membership.DeleteUser(user.UserName, true);

        '        Roles.DeleteRole(user.UserName);

        '        Membership.ApplicationName = "SharpIntranet";
        '        Roles.ApplicationName = "SharpIntranet";
        '    }

        '    catch
        '    {
        '        Membership.ApplicationName = "SharpIntranet";
        '        Roles.ApplicationName = "SharpIntranet";
        '    }
        '}
    End Class
End Namespace