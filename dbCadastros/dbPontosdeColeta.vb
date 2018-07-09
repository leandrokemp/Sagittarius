Imports System
Imports System.Data


Public Class dbPontosdeColeta

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Vari�vel que receber� a string de conex�o atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela PontosdeColeta para verificar se um usID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM PontosdeColeta WHERE ")
            strSQL.Append(strWhere)

            'Executando instru��o Select
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
            'mdaAcessos = New daAcessos
            ConsultarRelacionamentoUserID = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strusLatitude As String, ByVal strUsLongitude As String, ByVal strDescricao As String, ByVal strImagem As String) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instru��o de inser��o
            strSQL.Append("INSERT INTO PontosdeColeta (")
            strSQL.Append("pcLatitude,pcLongitude,pcDescricao, pcImagem")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strusLatitude)
            strSQL.Append("', '")
            strSQL.Append(strUsLongitude)
            strSQL.Append("', '")
            strSQL.Append(strDescricao)
            strSQL.Append("', '")
            strSQL.Append(strImagem)
            strSQL.Append("'")
            strSQL.Append(");")
            strSQL.Append("Select * from PontosdeColeta WHERE pcCodigo = @@Identity")


            'Executando a instru��o de inser��o
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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
   
    Public Function Incluir(ByVal strusLatitude As String, _
                            ByVal strUsLongitude As String, ByVal strDescricao As String, ByVal strImagem As String) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instru��o de inser��o
            strSQL.Append("INSERT INTO PontosdeColeta (")
            strSQL.Append("pcLatitude,pcLongitude,pcDescricao, pcImagem")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strusLatitude)
            strSQL.Append("', '")
            strSQL.Append(strUsLongitude)
            strSQL.Append("', '")
            strSQL.Append(strDescricao)
            strSQL.Append("', '")
            strSQL.Append(strImagem)
            strSQL.Append("'")
            strSQL.Append(");")

            'Executando a instru��o de inser��o
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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
    Public Function AlterarImagem(ByVal intECodigo As Integer, ByVal strEImagem As String) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instru��o de atualiza��o

            strFields.Append(" pcImagem = '")
            strFields.Append(strEImagem)
            strFields.Append("'")


            If strFields.ToString.Length > 0 Then
                'Montando instru��o Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE PontosDeColeta SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE pcCodigo = ")
                strSQL.Append(intECodigo)


                'Executando instru��o Update
                'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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
    Public Function Alterar(ByVal intID As Integer, ByVal strLongitude As String, ByVal strusLatitude As String, ByVal strDescricao As String) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            strFields.Append(" pcLatitude = '")
            strFields.Append(strusLatitude)
            strFields.Append("'")
            strFields.Append(", pcLongitude = '")
            strFields.Append(strLongitude)
            strFields.Append("'")
            strFields.Append(", pcDescricao = '")
            strFields.Append(strDescricao)
            strFields.Append("'")
          


            If strFields.ToString.Length > 0 Then
                'Montando instru��o Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE PontosdeColeta SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE pcCodigo = ")
                strSQL.Append(intID)


                'Executando instru��o Update
                'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

    Public Function Excluir(ByVal intID As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Insert
            strSQL.Append("DELETE FROM PontosdeColeta")
            strSQL.Append(" WHERE pcCODIGO = ")
            strSQL.Append(intID)

            'Executando instru��o insert
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

            'Montando instru��o Select
            strSQL.Append(" SELECT * FROM PontosdeColeta  ")

            If Trim(strWhere) <> "" Then
                strSQL.Append(" WHERE ")
                strSQL.Append(strWhere)
            End If

            If Trim(strOrdem) <> "" Then
                strSQL.Append(" ORDER BY ")
                strSQL.Append(strOrdem)
            End If

            'Executando instru��o Select
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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
