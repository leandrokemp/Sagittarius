Imports Microsoft.VisualBasic
Imports System.Data

Public Class buRegulamentoBeneficio
    Dim clsdbRegulamentoBeneficio As dbCadastros.dbRegulamentoBeneficio

    Public Function Incluir(ByVal strNotDescricao As String, ByVal dtData As Date) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbRegulamentoBeneficio = New dbCadastros.dbRegulamentoBeneficio
            'dbRegulamentoBeneficio ja é iniciado logo que a classe buUsuario é iniciada







            If clsdbRegulamentoBeneficio.Incluir(strNotDescricao, dtData _
                                   ) Then

                Return True
            End If



        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing
            strWhere = Nothing
            intUser = Nothing
        End Try
    End Function

    Public Function Alterar(ByVal intNotCodigo As Integer, ByVal strNotDescricao As String, ByVal dtData As Date) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try



            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbRegulamentoBeneficio = New dbCadastros.dbRegulamentoBeneficio

            'altera as informacoes na tabela usuario
            If clsdbRegulamentoBeneficio.Alterar(intNotCodigo, strNotDescricao, _
                                    dtData) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbRegulamentoBeneficio = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intNotCodigo As Integer _
                              ) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRegulamentoBeneficio = New dbCadastros.dbRegulamentoBeneficio
            Excluir = clsdbRegulamentoBeneficio.Excluir(intNotCodigo)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strNotDescricao As String,ByVal dtData As Date) As DataSet

        Dim dsUsuario As DataSet

        Dim intUser As Integer


        Try

            IncluirRetornaIncluido = clsdbRegulamentoBeneficio.IncluirRetornaIncluido(strNotDescricao, dtData _
                                   )



        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing

            intUser = Nothing
        End Try
    End Function

    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRegulamentoBeneficio = New dbCadastros.dbRegulamentoBeneficio
            Consultar = clsdbRegulamentoBeneficio.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
