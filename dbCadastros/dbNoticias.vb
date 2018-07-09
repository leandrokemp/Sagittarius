Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Noticias.
''' </summary>

Public Class dbNoticias

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela Noticias para verificar se um usID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM Noticias WHERE ")
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


    Public Function Incluir(ByVal strNotNome As String, ByVal strNotDescricao As String, _
                            ByVal strNotVideo As String, ByVal strNotImagem As String, ByVal dtData As Date) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Noticias (")
            strSQL.Append("NotNome,NotVideo,NotDescricao,NotImagem,NotData")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strNotNome)
            strSQL.Append("','")
            strSQL.Append(strNotVideo)
            strSQL.Append("', '")
            strSQL.Append(strNotDescricao)
            strSQL.Append("', '")
            strSQL.Append(strNotImagem)
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

    Public Function IncluirRetornaIncluido(ByVal strNotNome As String, ByVal strNotDescricao As String, _
                           ByVal strNotImagem As String, ByVal strNotVideo As String, ByVal dtData As Date) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Noticias (")
            strSQL.Append("NotNome,NotVideo,NotDescricao,NotImagem,NotData")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strNotNome)
            strSQL.Append("','")
            strSQL.Append(strNotVideo)
            strSQL.Append("', '")
            strSQL.Append(strNotDescricao)
            strSQL.Append("', '")
            strSQL.Append(strNotImagem)
            strSQL.Append("', Convert(Datetime,'")
            strSQL.Append(dtData).Append("',103)")
            strSQL.Append(");")
            strSQL.Append("Select * from Noticias WHERE NotCodigo = @@Identity")


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

    Public Function Alterar(ByVal intNotCodigo As Integer, ByVal strNotVideo As String, ByVal strNotNome As String, _
                            ByVal strNotDescricao As String, ByVal dtData As Date _
                            ) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("NotNome = '")
            strFields.Append(strNotNome)
            strFields.Append("', NotDescricao = '")
            strFields.Append(strNotDescricao)
            strFields.Append("' ")
            strFields.Append(", NotVideo = '")
            strFields.Append(strNotVideo)
            strFields.Append("',")
            strFields.Append(" NotData = Convert(datetime,'")
            strFields.Append(dtData).Append("',103)")





            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Noticias SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE NotCodigo = ")
                strSQL.Append(intNotCodigo)


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

    Public Function AlterarImagem(ByVal intNotCodigo As Integer, ByVal strNotImagem As String) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização

            strFields.Append(" NotImagem = '")
            strFields.Append(strNotImagem)
            strFields.Append("'")


            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Noticias SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE NotCodigo = ")
                strSQL.Append(intNotCodigo)


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
    Public Function Excluir(ByVal intNotCodigo As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM Noticias")
            strSQL.Append(" WHERE NotCodigo = ")
            strSQL.Append(intNotCodigo)

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
            strSQL.Append(" SELECT * FROM Noticias ")

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
