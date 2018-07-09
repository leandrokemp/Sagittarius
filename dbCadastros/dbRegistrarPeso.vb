Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Ranking.
''' </summary>
''' <remarks> 
''' </remarks>

Public Class dbRegistrarPeso

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
            strSQL.Append("FROM RegistrarPeso WHERE ")
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

    Public Function IncluirRetornaIncluido(ByVal strIdUsuario As String, ByVal strIdResiduo As String, _
                                           ByVal strPeso As String, ByVal dtData As Date) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Dim strAux As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO RegistrarPeso (")
            strSQL.Append(" UsCodigo, ReCodigo, Peso, Data")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strIdUsuario)
            strSQL.Append("','")
            strSQL.Append(strIdResiduo)
            strSQL.Append("','")
            strSQL.Append(strPeso)
            strSQL.Append("', '")
            strSQL.Append(dtData).Append("'")
            strSQL.Append(");")
            strSQL.Append("Select * from RegistrarPeso WHERE IdRegistrapeso = @@Identity")


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
    Public Function Incluir(ByVal strIdUsuario As String, ByVal strIdResiduo As String, _
                                           ByVal strPeso As String, ByVal dtData As Date) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO RegistrarPeso (")
            strSQL.Append(" UsCodigo, ReCodigo, Peso, Data")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strIdUsuario)
            strSQL.Append("','")
            strSQL.Append(strIdResiduo)
            strSQL.Append("','")
            strSQL.Append(strPeso)
            strSQL.Append("', convert (DateTime, '")
            strSQL.Append(dtData).Append("',103) ")
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

    Public Function Alterar(ByVal intIDRegistrarPeso As Integer, ByVal strIdUsuario As String, _
                            ByVal strIdResiduo As String, ByVal strPeso As String, ByVal dtData As Date) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("UsCodigo = '")
            strFields.Append(strIdUsuario)
            strFields.Append("', ReCodigo = '")
            strFields.Append(strIdResiduo)
            strFields.Append("', Peso = '")
            strFields.Append(strPeso)
            strFields.Append("', Data = '")
            strFields.Append(dtData)
            strFields.Append("'")

            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE RegistrarPeso SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE IdRegistrapeso = ")
                strSQL.Append(intIDRegistrarPeso)

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

    Public Function Excluir(ByVal intIDRegistrarPeso As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder
        Try
            strSQL = New System.Text.StringBuilder
            'Montando instrução Insert
            strSQL.Append("DELETE FROM RegistrarPeso")
            strSQL.Append(" WHERE IdRegistrapeso = ")
            strSQL.Append(intIDRegistrarPeso)

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
            strSQL.Append(" SELECT * FROM RegistrarPeso ")

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

    Public Function Consultarusuario(ByVal strWhere As String, Optional ByVal strOrdem As String = "") As DataSet
        Dim strSQL As System.Text.StringBuilder
        Try
            strSQL = New System.Text.StringBuilder
            'Montando instrução Select
            strSQL.Append(" SELECT usCodigo, usNome FROM Usuarios")

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
            Consultarusuario = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function


End Class
