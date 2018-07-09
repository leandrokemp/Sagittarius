Imports Microsoft.VisualBasic
Imports System.Data

Public Class buUsuariosResiduos
    Dim clsdbUsuariosResiduos As dbSeguranca.dbUsuariosResiduos

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        Try

            clsdbUsuariosResiduos = New dbSeguranca.dbUsuariosResiduos
            ConsultarRelacionamentoUserID = clsdbUsuariosResiduos.ConsultarRelacionamentoUserID(strWhere)

        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function Incluir(ByVal intUsCodigo As Integer, ByVal intResiduos As Integer) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere As Text.StringBuilder
        Dim intUser As Integer


        Try
            clsdbUsuariosResiduos = New dbSeguranca.dbUsuariosResiduos
            'dbUsuariosResiduos ja � iniciado logo que a classe buUsuario � iniciada




            If clsdbUsuariosResiduos.Incluir(intUsCodigo, intResiduos) Then

                Return True


            Else
                Return False

            End If

        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing
            strWhere = Nothing
            intUser = Nothing
        End Try
    End Function


    Public Function Excluir(Optional ByVal strWhere As String = "") As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a a��o de exclus�o do usu�rio
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
            clsdbUsuariosResiduos = New dbSeguranca.dbUsuariosResiduos
            Excluir = clsdbUsuariosResiduos.Excluir(strWhere)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal intUsCodigo As Integer, ByVal intResiduos As Integer) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbUsuariosResiduos = New dbSeguranca.dbUsuariosResiduos
            'dbUsuariosResiduos ja � iniciado logo que a classe buUsuario � iniciada





            IncluirRetornaIncluido = clsdbUsuariosResiduos.IncluirRetornaIncluido(intUsCodigo, intResiduos)




        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing
            strWhere = Nothing
            intUser = Nothing
        End Try
    End Function
    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
            clsdbUsuariosResiduos = New dbSeguranca.dbUsuariosResiduos
            Consultar = clsdbUsuariosResiduos.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
