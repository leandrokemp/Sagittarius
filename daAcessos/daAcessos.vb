Imports System.Data.SqlClient
Imports System.Web
Imports System.Configuration
Imports System.Data
Imports System.Web.Security






Public Class daAcessos
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



            '''GUARDA LOG
            Dim clsLog As Log.bulog
            Dim TabelaAux() As String = strSQL.Split(New Char() {" "})



            Dim Operacao As String
            Dim User As String = Membership.GetUser(True).UserName
            Dim tabela As String


            clsLog = New Log.bulog

            If strSQL.ToLower.Contains("insert") Then
                Operacao = "INCLUSÃO"
                tabela = TabelaAux(2)
            ElseIf strSQL.ToLower.Contains("update") Then
                Operacao = "ALTERAÇÃO"
                tabela = TabelaAux(1)
            Else 'Delete
                Operacao = "DELEÇÃO"
                tabela = TabelaAux(2)
            End If


            clsLog.Incluir(Operacao, tabela, User, Date.Now)

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
