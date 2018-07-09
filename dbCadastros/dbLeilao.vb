Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Leilão.

Public Class dbLeilao

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela Leilao para verificar se um LeID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM Leilao WHERE ")
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


    Public Function Incluir(ByVal ReCodigo As Integer, ByVal LeKg As Double, ByVal LeDataInicio As Date, _
                            ByVal LeDataFim As Date, ByVal LeLanceInicial As Double, ByVal usCodigo As Integer) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Leilao (")
            strSQL.Append("ReCodigo,Lekg,LeDataInicio,LeDataFim,LeLanceInicial,usCodigo")
            strSQL.Append(") VALUES (")
            strSQL.Append(ReCodigo)
            strSQL.Append(",")
            strSQL.Append(LeKg)
            strSQL.Append(", Convert(Datetime,'")
            strSQL.Append(LeDataInicio).Append("',103)")
            strSQL.Append(", Convert(Datetime,'")
            strSQL.Append(LeDataFim).Append("',103)")
            strSQL.Append(",")
            strSQL.Append(LeLanceInicial)
            strSQL.Append(",")
            strSQL.Append(usCodigo)
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

    Public Function IncluirRetornaIncluido(ByVal ReCodigo As Integer, ByVal LeKg As Double, ByVal LeDataInicio As Date, _
                            ByVal LeDataFim As Date, ByVal LeLanceInicial As Double, ByVal usCodigo As Integer) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Leilao (")
            strSQL.Append("ReCodigo,Lekg,LeDataInicio,LeDataFim,LeLanceInicial,usCodigo")
            strSQL.Append(") VALUES (")
            strSQL.Append(ReCodigo)
            strSQL.Append(",")
            strSQL.Append(LeKg)
            strSQL.Append(", Convert(Datetime,'")
            strSQL.Append(LeDataInicio).Append("',103)")
            strSQL.Append(", Convert(Datetime,'")
            strSQL.Append(LeDataFim).Append("',103)")
            strSQL.Append(",")
            strSQL.Append(LeLanceInicial)
            strSQL.Append(",")
            strSQL.Append(usCodigo)
            strSQL.Append(");")
            strSQL.Append("Select * from Leilao WHERE LeCodigo = @@Identity")


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

    Public Function Alterar(ByVal LeCodigo As Integer, ByVal ReCodigo As Integer, ByVal LeKg As Double, ByVal LeDataInicio As Date, _
                            ByVal LeDataFim As Date, ByVal LeLanceInicial As Double) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("LeKg = ")
            strFields.Append(LeKg)
            strFields.Append(", LeDataInicio = Convert(datetime,'")
            strFields.Append(LeDataInicio).Append("',103)")
            strFields.Append(", LeDataFim = Convert(datetime,'")
            strFields.Append(LeDataFim).Append("',103),")
            strFields.Append(" LeLanceInicial = ")
            strFields.Append(LeLanceInicial)





            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Leilao SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE LeCodigo = ")
                strSQL.Append(LeCodigo)


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

    Public Function Excluir(ByVal LeCodigo As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM Leilao")
            strSQL.Append(" WHERE LeCodigo = ")
            strSQL.Append(LeCodigo)

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
            strSQL.Append(" select u.usNome, r.ReNome, l.* from Leilao l inner join Usuarios u on u.usCodigo=l.usCodigo inner join Residuos r on r.ReCodigo=l.ReCodigo ")

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

End Class
