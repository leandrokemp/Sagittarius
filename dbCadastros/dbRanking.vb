
Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Ranking.
''' </summary>
''' <remarks> 
''' </remarks>

Public Class dbRanking

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela Ranking para verificar se um IdRanking 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM Ranking WHERE ")
            strSQL.Append(strWhere)

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            ConsultarRelacionamentoUserID = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try
    End Function

    Public Function IncluirRetornaIncluido(ByVal strNomeRanking As String, ByVal strView As String, _
                                           ByVal BlnHabilitado As String) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Dim strAux As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Ranking (")
            strSQL.Append("NomeRanking, NomeView, Habilitado")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strNomeRanking)
            strSQL.Append("','")
            strSQL.Append(strView)
            strSQL.Append("','")
            strSQL.Append(BlnHabilitado)
            strSQL.Append("'")

            strSQL.Append(");")
            strSQL.Append("Select * from Ranking WHERE IdRanking = @@Identity")


            'Executando a instrução de inserção
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            IncluirRetornaIncluido = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function
    Public Function Incluir(ByVal strNomeRanking As String, ByVal strView As String, _
                                           ByVal BlnHabilitado As String) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Ranking (")
            strSQL.Append("NomeRanking, NomeView, Habilitado")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strNomeRanking)
            strSQL.Append("','")
            strSQL.Append(strView)
            strSQL.Append("','")
            strSQL.Append(BlnHabilitado)
            strSQL.Append("'")


            strSQL.Append(");")

            'Executando a instrução de inserção
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            Incluir = mdaAcessos.Execute(strSQL.ToString)


        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

    Public Function Alterar(ByVal intIDRanking As Integer, ByVal strNomeRanking As String, _
                            ByVal strView As String, ByVal BlnHabilitado As String) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("NomeRanking = '")
            strFields.Append(strNomeRanking)
            strFields.Append("', NomeView = '")
            strFields.Append(strView)
            strFields.Append("', Habilitado = '")
            strFields.Append(BlnHabilitado)
            strFields.Append("'")


            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Ranking SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE IdRanking = ")
                strSQL.Append(intIDRanking)


                'Executando instrução Update
                'Utilizando a variável que contém a conexão atualmente selecionada
                mdaAcessos = New daAcessos.daAcessos
                Alterar = mdaAcessos.Execute(strSQL.ToString)

                ''Enviando mensagem para a BU, indicando o comando realizado para ser registrado em LOG.
                'Mensagem = New FuncoesComuns.clsMensagem
                'Mensagem.TipoMensagem = FuncoesComuns.clsMensagem.enTipoLog.entlInformacao
                'Mensagem.MensagemOriginal = strSQL.ToString

            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
            strFields = Nothing
        End Try
    End Function

    Public Function Excluir(ByVal intIDRanking As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM Ranking")
            strSQL.Append(" WHERE IdRanking = ")
            strSQL.Append(intIDRanking)

            'Executando instrução insert
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            Excluir = mdaAcessos.Execute(strSQL.ToString)

            ''Enviando mensagem para a BU, indicando o comando realizado para ser registrado em LOG.
            'Mensagem = New FuncoesComuns.clsMensagem
            'Mensagem.TipoMensagem = FuncoesComuns.clsMensagem.enTipoLog.entlInformacao
            'Mensagem.MensagemOriginal = strSQL.ToString

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try
    End Function


    Public Function Consultar(ByVal strWhere As String, Optional ByVal strOrdem As String = "") As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append(" SELECT * FROM Ranking ")

            If Trim(strWhere) <> "" Then
                strSQL.Append(" WHERE ")
                strSQL.Append(strWhere)
            End If

            If Trim(strOrdem) <> "" Then
                strSQL.Append(" ORDER BY ")
                strSQL.Append(strOrdem)
            End If

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            Consultar = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function


    Public Function ConsultarRank(ByVal strfrom As String) As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append(" SELECT * FROM ")
            strSQL.Append(strfrom)
            strSQL.Append(" ORDER BY Pontuação DESC ")



            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            ConsultarRank = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

End Class

