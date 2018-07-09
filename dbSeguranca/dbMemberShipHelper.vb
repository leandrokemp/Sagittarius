Imports System
Imports System.Data
Imports System.Configuration

''' <summary>
''' Classe para tratar a camada de dados da tabela MemberShipHelper.
''' </summary>

Public Class dbMemberShipHelper

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    

  


    Public Function ConsultarRolesAll(ByVal strWhere As String, Optional ByVal strOrdem As String = "") As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append(" select ar.* from aspnet_Roles ar inner join aspnet_Applications aa on aa.ApplicationID = ar.ApplicationID left join aspnet_UsersInRoles aui on aui.Roleid = ar.roleid left join usuarios u on u.Userid = aui.userid  ")

            If Trim(strWhere) <> "" Then
                strSQL.Append(" WHERE ")
                strSQL.Append(strWhere)
                strSQL.Append(" AND aa.ApplicationName = '")
                strSQL.Append(ConfigurationSettings.AppSettings("APPLICATION_NAME").ToString)
                strSQL.Append("'")
            Else
                strSQL.Append(" WHERE ")
                strSQL.Append(" aa.ApplicationName = '")
                strSQL.Append(ConfigurationSettings.AppSettings("APPLICATION_NAME").ToString)
                strSQL.Append("'")
            End If

            If Trim(strOrdem) <> "" Then
                strSQL.Append(" ORDER BY ")
                strSQL.Append(strOrdem)
            End If

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            ConsultarRolesAll = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

   

End Class
