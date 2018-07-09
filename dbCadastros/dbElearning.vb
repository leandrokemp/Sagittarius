Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Elearning.
''' </summary>

Public Class dbElearning

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela Elearning para verificar se um usID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM Elearning WHERE ")
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


    Public Function Incluir(ByVal strENome As String, ByVal strEDescricao As String, _
                            ByVal strEVideo As String, ByVal strEImagem As String, ByVal dtData As Date) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Elearning (")
            strSQL.Append("ENome,EVideo,EDescricao,EImagem,EData")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strENome)
            strSQL.Append("','")
            strSQL.Append(strEVideo)
            strSQL.Append("', '")
            strSQL.Append(strEDescricao)
            strSQL.Append("', '")
            strSQL.Append(strEImagem)
            strSQL.Append("', Convert(Datetime,'")
            strSQL.Append(dtData).Append("',103)")
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

    Public Function IncluirRetornaIncluido(ByVal strENome As String, ByVal strEDescricao As String, _
                           ByVal strEImagem As String, ByVal strEVideo As String, ByVal dtData As Date) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Elearning (")
            strSQL.Append("ENome,EVideo,EDescricao,EImagem,EData")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strENome)
            strSQL.Append("','")
            strSQL.Append(strEVideo)
            strSQL.Append("', '")
            strSQL.Append(strEDescricao)
            strSQL.Append("', '")
            strSQL.Append(strEImagem)
            strSQL.Append("', Convert(Datetime,'")
            strSQL.Append(dtData).Append("',103)")
            strSQL.Append(");")
            strSQL.Append("Select * from ELearning WHERE eCodigo = @@Identity")


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

    Public Function Alterar(ByVal intECodigo As Integer, ByVal strEVideo As String, ByVal strENome As String, _
                            ByVal strEDescricao As String, ByVal dtData As Date _
                            ) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("ENome = '")
            strFields.Append(strENome)
            strFields.Append("', EDescricao = '")
            strFields.Append(strEDescricao)
            strFields.Append("' ")
            strFields.Append(", EVideo = '")
            strFields.Append(strEVideo)
            strFields.Append("',")
            strFields.Append(" EData = Convert(datetime,'")
            strFields.Append(dtData).Append("',103)")





            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Elearning SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE ECodigo = ")
                strSQL.Append(intECodigo)


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

    Public Function AlterarImagem(ByVal intECodigo As Integer, ByVal strEImagem As String) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização

            strFields.Append(" EImagem = '")
            strFields.Append(strEImagem)
            strFields.Append("'")


            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Elearning SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE ECodigo = ")
                strSQL.Append(intECodigo)


                'Executando instrução Update
                'Utilizando a variável que contém a conexão atualmente selecionada
                mdaAcessos = New daAcessos.daAcessos
                AlterarImagem = mdaAcessos.Execute(strSQL.ToString)

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
            strSQL.Append("DELETE FROM Elearning")
            strSQL.Append(" WHERE ECodigo = ")
            strSQL.Append(intECodigo)

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
            strSQL.Append(" SELECT * FROM Elearning ")

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
