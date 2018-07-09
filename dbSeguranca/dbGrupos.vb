Imports System
Imports System.Data
Public Class dbGrupos
    Private clsdaAcessos As daAcessos.daAcessos

    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String



    ''' <summary>
    ''' Função que inclui um novo cadastro de grupo no banco da tabela Grupos.
    ''' </summary>
    ''' <returns>
    ''' True se incluiu com sucesso, False se não conseguiu incluir.</returns>
    ''' <remarks> 
    ''' Alterado o tratamento da inclusão, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela Grupos.
    ''' Alterado a passagem da string de conexão com a base de dados
    '''  </remarks>

    Public Function Incluir(ByVal strgrNome As String _
    ) As Boolean
        Dim strSQL As New System.Text.StringBuilder

        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Grupos (")
            strSQL.Append("grpNome")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strgrNome)
            strSQL.Append("')")

            'Executando a instrução de inserção
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            clsdaAcessos = New daAcessos.daAcessos
            Incluir = clsdaAcessos.Execute(strSQL.ToString)
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


    ''' <summary>
    ''' Função que altera um registro da tabela Grupos.
    ''' </summary>
    ''' <returns>
    ''' True se alterou com sucesso, False se não conseguiu alterar.
    ''' </returns>
    ''' <remarks>
    '''  Implementado em: 14/06/2005  por: Rodrigo S. Teixeira.
    ''' Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    ''' Alterado o tratamento de alteracão, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela Grupos.
    ''' Alterado em: 28/08/2006 por: João Geraldo Vieira
    ''' Alterado a passagem da string de conexão com a base de dados
    ''' </remarks>

    Public Function Alterar(ByVal strgrNome As String, _
    ByVal intIDGrupos As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            'Montando instrução de inserção
            strFields = New System.Text.StringBuilder

            strFields.Append("grpNome = '")
            strFields.Append(strgrNome)
            strFields.Append("'")

            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Grupos SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE grpCodigo = ")
                strSQL.Append(intIDGrupos)

                'Executando instrução Update
                'Utilizando a variável que contém a conexão atualmente selecionada
                'mdaAcessos = New daAcessos
                clsdaAcessos = New daAcessos.daAcessos
                Alterar = clsdaAcessos.Execute(strSQL.ToString)

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

    ''' <summary>
    ''' Função que exclui um registro da tabela Grupos.
    ''' </summary>
    ''' <returns>
    ''' True se excluiu com sucesso, False se não conseguiu excluir.
    ''' </returns>
    ''' <remarks>
    ''' Implementado em: 14/06/2005 por: Rodrigo S. Teixeira.
    ''' Alterado em: 23/11/2005 por: Karen Cristina Geraldo.
    ''' Alterado o tratamento de exclusão, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela Grupos.
    ''' Alterado em: 28/08/2006 por: João Geraldo Vieira
    ''' Alterado a passagem da string de conexão com a base de dados
    ''' </remarks>

    Public Function Excluir(ByVal intIDGrupos As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM Grupos ")
            strSQL.Append(" WHERE grpCodigo = ")
            strSQL.Append(intIDGrupos)

            'Executando instrução insert
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            clsdaAcessos = New daAcessos.daAcessos
            Excluir = clsdaAcessos.Execute(strSQL.ToString)

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

    ''' <summary>
    ''' Função que efetua uma consulta na tabela Grupos.
    ''' </summary>
    ''' <returns>
    ''' Dataset contendo os dados selecionados.
    ''' </returns>
    ''' <remarks>
    ''' Implementado em 13/06/2005 por: Rodrigo S. Teixeira.
    ''' Alterado em 23/11/2005 por: Karen Cristina Geraldo.
    ''' Alterado o tratamento de consulta, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela Grupos.
    ''' Alterado em: 28/08/2006 por: João Geraldo Vieira
    ''' Alterado a passagem da string de conexão com a base de dados
    ''' </remarks>

    Public Function Consultar(ByVal strWhere As String, Optional ByVal strOrdem As String = "") As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append(" SELECT * FROM Grupos ")

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
            clsdaAcessos = New daAcessos.daAcessos
            Consultar = clsdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

    Public Function ConsultarRelacionamento(ByVal strWhere As String) As DataSet

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT * ")
            strSQL.Append("FROM Usuarios WHERE grpCodigo = ")
            strSQL.Append(strWhere)

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            clsdaAcessos = New daAcessos.daAcessos
            ConsultarRelacionamento = clsdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function


    Public Function ConsultarRelacionamento2(ByVal strWhere As String) As DataSet

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT * ")
            strSQL.Append("FROM GrupoxFuncionalidade WHERE grpCodigo = ")
            strSQL.Append(strWhere)

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            clsdaAcessos = New daAcessos.daAcessos
            ConsultarRelacionamento2 = clsdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function
End Class
