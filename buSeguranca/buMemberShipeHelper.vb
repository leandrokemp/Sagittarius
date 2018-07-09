Imports Microsoft.VisualBasic
Imports System.Data

Public Class buMemberShipHelper
    Dim clsdbMemberShipHelper As dbSeguranca.dbMemberShipHelper



   

   
    Public Function ConsultarRolesAll(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbMemberShipHelper = New dbSeguranca.dbMemberShipHelper
            ConsultarRolesAll = clsdbMemberShipHelper.ConsultarRolesAll(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
