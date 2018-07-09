Imports System.Data.SqlClient
Imports System.Web
Imports System.Configuration
Imports System.Data
Imports System


''' <summary>
''' Classe para tratar a camada de dados da tabela Log.
''' </summary>

Public Class dbLog


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela Log para verificar se um usID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM Log WHERE ")
            strSQL.Append(strWhere)

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            ConsultarRelacionamentoUserID = Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try
    End Function


    Public Function Incluir(ByVal LogOperacao As String, ByVal LogTabela As String, _
                            ByVal LogUser As String, ByVal LogData As Date) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Log (")
            strSQL.Append("LogOperacao,LogTabela,LogUser,LogData")
            strSQL.Append(") VALUES ('")
            strSQL.Append(LogOperacao)
            strSQL.Append("','")
            strSQL.Append(LogTabela)
            strSQL.Append("', '")
            strSQL.Append(LogUser)
            strSQL.Append("', Convert(DateTime,'")
            strSQL.Append(LogData).Append("',103)")


            strSQL.Append(");")

            'Executando a instrução de inserção
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos

            Incluir = Execute(strSQL.ToString)


        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

    Public Function IncluirRetornaIncluido(ByVal LogOperacao As String, ByVal LogTabela As String, _
                            ByVal LogUser As String, ByVal LogData As Date) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Log (")
            strSQL.Append("LogOperacao,LogTabela,LogUser,LogData")
            strSQL.Append(") VALUES ('")
            strSQL.Append(LogOperacao)
            strSQL.Append("','")
            strSQL.Append(LogTabela)
            strSQL.Append("', '")
            strSQL.Append(LogUser)
            strSQL.Append("', Convert(DateTime,'")
            strSQL.Append(LogData).Append("',103)")


            strSQL.Append(");")
            strSQL.Append("Select * from Log WHERE LogCodigo = @@Identity")


            'Executando a instrução de inserção
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos

            IncluirRetornaIncluido = Retrieve(strSQL.ToString)


        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

    Public Function Alterar(ByVal intECodigo As Integer, ByVal LogOperacao As String, ByVal LogTabela As String, _
                            ByVal LogUser As String, ByVal LogData As Date _
                            ) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("LogOperacao = '")
            strFields.Append(LogOperacao)
            strFields.Append("', LogTabela = '")
            strFields.Append(LogTabela)
            strFields.Append("' ")
            strFields.Append(", LogUser = '")
            strFields.Append(LogUser)
            strFields.Append("',")
            strFields.Append(" LogData = Convert(dateTime,'")
            strFields.Append(LogData).Append("',103)")





            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Log SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE LogCodigo = ")
                strSQL.Append(intECodigo)


                'Executando instrução Update
                'Utilizando a variável que contém a conexão atualmente selecionada

                Alterar = Execute(strSQL.ToString)

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


    Public Function Excluir(ByVal intECodigo As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM Log")
            strSQL.Append(" WHERE LogCodigo = ")
            strSQL.Append(intECodigo)

            'Executando instrução insert
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos

            Excluir = Execute(strSQL.ToString)

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
            strSQL.Append(" SELECT * FROM Log ")

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

            Consultar = Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

    'variavel global
    'Objeto que faz a conexão com o banco de dados
    Public mcnConn As SqlConnection




    ''' <summary>
    ''' Metodo que abre a conexão com o banco de dados
    ''' </summary>
    Public Sub Open()
        'string de contacatenação
        Dim strConnString As String
        Try
            'Obtém a string de conexão do arquivo Web.Config, na tag <connectionStrings>.
            'Ou seja, obtém a senha, o usuario, o nome do banco e aonde ele se encontra
            strConnString = ConfigurationSettings.AppSettings("ConnectionString").ToString
            'instanciando o objeto de conexão com os dados referente ao banco (senha,usuario,nome bd e local)
            mcnConn = New SqlConnection(strConnString)
            'abrindo a conexão
            mcnConn.Open()
        Catch exc As Exception
            Throw exc
        End Try
    End Sub
    ''' <summary> Método utilizado para realizar atualização em Lote no banco de dados. </summary>
    ''' <param name="dsData"> Dataset contendo os dados a serem atualizados. </param>
    ''' <param name="strQueryToUpdate"> Consulta SQL que identifica (seleciona) a tabela a ser atualizada. </param>
    ''' <returns> True caso a atualização seja realizada com sucesso. False caso não seja. </returns>
    ''' <versao ID="1.0" Data="14/09/2009" Desenvolvedor="Felipe Caron"> Criação do Método</versao>
    Public Function UpdateBatch(ByVal dsData As DataSet, _
                                ByVal strQueryToUpdate As String, _
                                Optional ByVal strMarcador As String = "") As Boolean
        Try
            'Verifica se está usando uma transação e usa a conexão da transação,
            'senão verifica se é necessário abrir uma nova conexão

            If Not mcnConn Is Nothing Then
                If mcnConn.State <> ConnectionState.Open Then
                    Open()
                End If
            Else
                Open()
            End If


            Try
                Dim myDataAdapter As New SqlDataAdapter '(strQueryToUpdate, mcnConn)
                '************************************************************************************
                'Alterado em 09/02/2007 por Rodrigo Duarte
                'Inserido o objeto ObjTrans como parametro do SelectCommand. Isso permite
                'que o UpdateBach possa ser executado dentro de uma transação.
                '************************************************************************************
                myDataAdapter.SelectCommand = New SqlCommand(strQueryToUpdate, mcnConn, Nothing)
                Dim custCB As SqlCommandBuilder = New SqlCommandBuilder(myDataAdapter)
                Dim custDS As DataSet = New DataSet

                myDataAdapter.Fill(custDS)

                custDS = dsData.GetChanges
                If Not custDS Is Nothing Then
                    myDataAdapter.Update(custDS)
                End If

                '3.1
                '--------------

                '--------------

                UpdateBatch = True
            Catch exc As Exception
                Throw exc
            Finally

            End Try
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    ''' <summary>
    ''' Metodo que fecha a conexão com o banco de dados
    ''' </summary>
    Public Sub Close()
        Try
            'verfica se o objeto de conexão não esta vazio (tratamento padrão)
            If Not mcnConn Is Nothing Then
                'verfica se a conexão não foi fechada anteriormente  (tratamento padrão)
                If mcnConn.State <> ConnectionState.Closed Then
                    'fecha a conexão com o banco
                    mcnConn.Close()
                End If
            End If
        Catch exc As Exception
            Throw exc
        Finally
            mcnConn = Nothing
        End Try
    End Sub
    ''' <summary>
    ''' Metodo utilizado para executar comando de inclusão, alterãção e exclusão
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns></returns>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Public Function Execute(ByVal strSQL As String)

        'Variavel para executar comandos sql no banco
        Dim cmdExecute As SqlCommand
        'varial de tempo maximo para tentativas de executar comando
        Dim intTimeOut As Single = 90

        Try
            Execute = False
            'verifica se o objeto de conexão não esta vazio(tratamento padrão)
            If Not mcnConn Is Nothing Then
                'verifica se a conexão não esta realmente aberta (tratamento padrão)
                If mcnConn.State <> ConnectionState.Open Then
                    'chama a funçao para abrir a conexão
                    Open()
                End If
            Else
                Open()
            End If

            'instanciando a variavel de execução com o comando a ser executado (strSql), com a string de conexão(senha,usuario,nome bd e local)
            'e passando NOTHING pois não iremos abrir uma transação
            cmdExecute = New SqlCommand(strSQL, mcnConn, Nothing)
            'definindo o tempo maximo de espera (timeOut)
            cmdExecute.CommandTimeout = intTimeOut
            'Excutando o comando
            cmdExecute.ExecuteNonQuery()






            'retornando true, indicando que foi executado com sucesso
            Execute = True
        Catch exc As Exception






        Finally
            Try
                'chama o metodo que finaliza a conexão com o banco
                Close()
            Catch ex As Exception
                Throw ex
            End Try
            cmdExecute = Nothing
        End Try

    End Function
    ''' <summary>
    ''' Metodo utilizado para consulta no banco de dados
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <returns>Retorna o proprio metodo contendo o resultado da consulta</returns>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Public Function Retrieve(ByVal strSQL As String) As DataSet
        'Variavel para executar comandos sql no banco
        Dim cmdExecute As SqlCommand
        'instanciando o proprio metodo
        Retrieve = New DataSet
        'Abre conexão, caso necessário
        If Not mcnConn Is Nothing Then
            If mcnConn.State <> ConnectionState.Open Then
                Open()
            End If
        Else
            Open()
        End If

        Try
            'instanciando o objeto 
            cmdExecute = New SqlClient.SqlCommand
            'utilizando o objeto defina para ele...
            With cmdExecute
                '...a consulta a ser realizada
                .CommandText = strSQL
                '...a string de conexão
                .Connection = mcnConn
            End With
            'declarando e ja instanciando o objeto que irá retornar para os dados da consulta a ser realizada
            Dim daExecute As New SqlDataAdapter(cmdExecute)
            'utilizando a consulta a ser realizada e a string de conxeão
            'pegando os dados que a consulta retornou e preenchendo o proprio metodo com eles
            daExecute.Fill(Retrieve)
        Catch Exc As OverflowException
            Throw Exc
        Catch exc As Exception
            Throw exc
        Finally
            'finalizando a conexão
            Close()
        End Try
    End Function

End Class
