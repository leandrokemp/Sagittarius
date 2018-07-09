Imports Microsoft.VisualBasic
Imports System.Data

Public Class buRanking
    Dim clsdbRanking As dbCadastros.dbRanking

    Public Function Incluir(ByVal strNomeRanking As String, ByVal strView As String, _
                                           ByVal BlnHabilitado As String) As Boolean

        Dim dsRanking As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intRanking As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbRanking = New dbCadastros.dbRanking
            'dbRanking ja é iniciado logo que a classe buRanking é iniciada




       
            If clsdbRanking.Incluir(strNomeRanking, strView, BlnHabilitado) Then
                Return True
            End If

           

        Catch ex As Exception
            Throw ex
        Finally
            dsRanking = Nothing
            strWhere = Nothing
            intRanking = Nothing
        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strNomeRanking As String, ByVal strView As String, _
                                           ByVal BlnHabilitado As String) As DataSet

        Dim dsRanking As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intRanking As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbRanking = New dbCadastros.dbRanking
            'dbRanking ja é iniciado logo que a classe buRanking é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("NomeRanking='")
            strAux.Append(strNomeRanking)
            strAux.Append("'")

            dsConsulta = clsdbRanking.Consultar(strAux.ToString)

            'Verifica se não existe o Nome
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                IncluirRetornaIncluido = clsdbRanking.IncluirRetornaIncluido(strNomeRanking, strView, BlnHabilitado)
            Else
                IncluirRetornaIncluido = New DataSet
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dsRanking = Nothing
            strWhere = Nothing
            intRanking = Nothing
        End Try
    End Function

    Public Function Alterar(ByVal intIDRanking As Integer, ByVal strNomeRanking As String, ByVal strView As String, _
                                           ByVal BlnHabilitado As String) As Boolean

        Dim dsRanking As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" Ranking.NomeRanking ='")
            strWhere.Append(strNomeRanking)
            strWhere.Append("' AND Ranking.IdRanking <> ")
            strWhere.Append(intIDRanking)

            clsdbRanking = New dbCadastros.dbRanking

            dsRanking = Consultar(strWhere.ToString)
            If dsRanking.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo Nome.

                'Retorno da mensagem de Validação.

                'Obter termo referente à validação.


                Return False
            End If

            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbRanking = New dbCadastros.dbRanking

            'altera as informacoes na tabela Ranking
            If clsdbRanking.Alterar(intIDRanking, _
                                   strNomeRanking, _
                                   strView, BlnHabilitado) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbRanking = Nothing
            dsRanking = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intIDRanking As Integer) As Boolean
        Dim strAux As Text.StringBuilder
        Try

            'Dispara a ação de exclusão do Ranking
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRanking = New dbCadastros.dbRanking
            Excluir = clsdbRanking.Excluir(intIDRanking)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function

    ''' <summary>
    ''' Função que efetua uma consulta na tabela Ranking.
    ''' </summary>
    ''' <returns>
    ''' Retorna um Dataset com os dados selecionados.
    ''' </returns>
    ''' <remarks> 
    ''' Implementado em: 25/10/2010 por Renato Matsumoto
    ''' </remarks>
    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRanking = New dbCadastros.dbRanking
            Consultar = clsdbRanking.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function

    Public Function ConsultarRank(Optional ByVal strWhere As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRanking = New dbCadastros.dbRanking
            ConsultarRank = clsdbRanking.ConsultarRank(strWhere)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function

End Class
