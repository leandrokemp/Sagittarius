Imports Microsoft.VisualBasic
Imports System.Data

Public Class buLeilao

    Dim clsdbLeilao As dbCadastros.dbLeilao

    Public Function Incluir(ByVal ReCodigo As Integer, ByVal LeKg As Double, ByVal LeDataInicio As Date, _
                            ByVal LeDataFim As Date, ByVal LeLanceInicial As Double, ByVal usCodigo As Integer) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbLeilao = New dbCadastros.dbLeilao
            'dbLeilao ja é iniciado logo que a classe buUsuario é iniciada



            If clsdbLeilao.Incluir(ReCodigo, _
                                   LeKg, _
                                   LeDataInicio, _
                                   LeDataFim, _
                                   LeLanceInicial, _
                                   usCodigo) Then

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

    Public Function Alterar(ByVal LeCodigo As Integer, ByVal ReCodigo As Integer, ByVal LeKg As Double, ByVal LeDataInicio As Date, _
                            ByVal LeDataFim As Date, ByVal LeLanceInicial As Double) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try

            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbLeilao = New dbCadastros.dbLeilao

            'altera as informacoes na tabela usuario
            If clsdbLeilao.Alterar(LeCodigo, _
                                   ReCodigo, _
                                   LeKg, _
                                   LeDataInicio, _
                                   LeDataFim, _
                                   LeLanceInicial) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbLeilao = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal LeCodigo As Integer) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbLeilao = New dbCadastros.dbLeilao
            Excluir = clsdbLeilao.Excluir(LeCodigo)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal ReCodigo As Integer, ByVal LeKg As Double, ByVal LeDataInicio As Date, _
                            ByVal LeDataFim As Date, ByVal LeLanceInicial As Double, ByVal usCodigo As Integer) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbLeilao = New dbCadastros.dbLeilao
            'dbLeilao ja é iniciado logo que a classe buUsuario é iniciada

            IncluirRetornaIncluido = clsdbLeilao.IncluirRetornaIncluido(ReCodigo, _
                                   LeKg, _
                                   LeDataInicio, _
                                   LeDataFim, LeLanceInicial, _
                                   usCodigo)

            IncluirRetornaIncluido = New DataSet


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
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbLeilao = New dbCadastros.dbLeilao
            Consultar = clsdbLeilao.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function

End Class
