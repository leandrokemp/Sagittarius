Imports Microsoft.VisualBasic
Imports System.Data

Public Class buLanceLeilao
    Dim clsdbLanceLeilao As dbCadastros.dbLanceLeilao

    Public Function Incluir(ByVal intLeilaoCodigo As Int32, ByVal dblLanValor As Double, _
                           ByVal intUscCodigo As Int32, _
                           ByVal blnLanVencedor As Boolean, ByVal dtData As Date) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer


        Try

            If clsdbLanceLeilao.Incluir(intLeilaoCodigo, _
                                   dblLanValor, _
                                   intUscCodigo, _
                                   blnLanVencedor, dtData _
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

    Public Function Alterar(ByVal intECodigo As Integer, ByVal intLeilaoCodigo As String, ByVal intUsCodigo As Int32, _
                            ByVal dblLanValor As String, ByVal blnLanVencedor As String, ByVal dtData As Date) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try

            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbLanceLeilao = New dbCadastros.dbLanceLeilao

            'altera as informacoes na tabela usuario
            If clsdbLanceLeilao.Alterar(intECodigo, intUsCodigo, intLeilaoCodigo, dblLanValor, _
                                   blnLanVencedor, _
                                    dtData) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbLanceLeilao = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intECodigo As Integer) As Boolean
        Dim strAux As Text.StringBuilder
        Try

            Dim dsDados As Data.DataSet

            clsdbLanceLeilao = New dbCadastros.dbLanceLeilao
            'Verificando se o lance que está sendo excluido é o maior (vencedor até o momento)
            'caso sim o segudo maior lace que passará a ser o vencedor
            dsDados = clsdbLanceLeilao.Consultar(" lanCodigo in (select top 2 lanCodigo from LanceLeilao order by lanValor desc) ")


            If Not dsDados.Tables(0).Rows.Count = 0 Then


                If dsDados.Tables(0).Rows(0)("lancodigo") = intECodigo And dsDados.Tables(0).Rows.Count > 1 Then
                    clsdbLanceLeilao = New dbCadastros.dbLanceLeilao
                    clsdbLanceLeilao.AlterarVencedor(dsDados.Tables(0).Rows(1)("lancodigo"), True)

                End If
            End If

            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbLanceLeilao = New dbCadastros.dbLanceLeilao
            Excluir = clsdbLanceLeilao.Excluir(intECodigo)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal intLeilaoCodigo As String, ByVal dblLanValor As String, _
                           ByVal intUscCodigo As String, _
                           ByVal blnLanVencedor As String, ByVal dtData As Date) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try

            clsdbLanceLeilao = New dbCadastros.dbLanceLeilao
            IncluirRetornaIncluido = clsdbLanceLeilao.IncluirRetornaIncluido(intLeilaoCodigo, _
                                   dblLanValor, blnLanVencedor, _
                                   intUscCodigo, _
                                    dtData _
                                   )




        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing
            strWhere = Nothing
            intUser = Nothing
        End Try
    End Function
    Public Function AlterarVencedor(ByVal intEleraning As Integer, ByVal blnVencedor As Boolean, Optional ByVal blnIsIgual As Boolean = False) As Boolean
        Try
            clsdbLanceLeilao = New dbCadastros.dbLanceLeilao
            If clsdbLanceLeilao.AlterarVencedor(intEleraning, blnVencedor, blnIsIgual) Then
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbLanceLeilao = New dbCadastros.dbLanceLeilao
            Consultar = clsdbLanceLeilao.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
