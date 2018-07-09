Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela TipoFuncionalidade.
''' </summary>


Public Class dbTipoFuncionalidade
    Private clsdaAcessos As daAcessos.daAcessos

    'Vari�vel que receber� a string de conex�o atualmente selecionada
    Private strConexao As String



    ''' <summary>
    ''' Fun��o que inclui um novo cadastro de grupo no banco da tabela TipoFuncionalidade.
    ''' </summary>
    ''' <returns>
    ''' True se incluiu com sucesso, False se n�o conseguiu incluir.</returns>
    ''' <remarks> 
    ''' Implementado em:14/03/2005 por: Rodrigo S. Teixeira.
    ''' Alterado em:23/11/2005 por: Karen Cristina Geraldo.
    ''' Alterado o tratamento da inclus�o, pois o campo n�o faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela TipoFuncionalidade.
    ''' Alterado em: 28/08/2006 por: Jo�o Geraldo Vieira
    ''' Alterado a passagem da string de conex�o com a base de dados
    '''  </remarks>

    Public Function Incluir(ByVal strgrNome As String, ByVal strUrl As String _
    ) As Boolean
        Dim strSQL As New System.Text.StringBuilder

        Try

            'Montando instru��o de inser��o
            strSQL.Append("INSERT INTO TipoFuncionalidade (")
            strSQL.Append("descricao,url")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strgrNome)
            strSQL.Append("','").Append(strUrl)
            strSQL.Append("')")


            'Executando a instru��o de inser��o
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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
    ''' Fun��o que altera um registro da tabela TipoFuncionalidade.
    ''' </summary>
    ''' <returns>
    ''' True se alterou com sucesso, False se n�o conseguiu alterar.
    ''' </returns>
    ''' <remarks>
    '''  Implementado em: 14/06/2005  por: Rodrigo S. Teixeira.
    ''' Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    ''' Alterado o tratamento de alterac�o, pois o campo n�o faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela TipoFuncionalidade.
    ''' Alterado em: 28/08/2006 por: Jo�o Geraldo Vieira
    ''' Alterado a passagem da string de conex�o com a base de dados
    ''' </remarks>

    Public Function Alterar(ByVal strgrNome As String, _
    ByVal intIDTipoFuncionalidade As Integer, ByVal strUrl As String) As Boolean
        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            'Montando instru��o de inser��o
            strFields = New System.Text.StringBuilder

            strFields.Append("Descricao = '")
            strFields.Append(strgrNome)
            strFields.Append("',")
            strFields.Append("Url = '")
            strFields.Append(strUrl)
            strFields.Append("'")



            If strFields.ToString.Length > 0 Then
                'Montando instru��o Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE TipoFuncionalidade SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE TipofuncCodigo = ")
                strSQL.Append(intIDTipoFuncionalidade)

                'Executando instru��o Update
                'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

    

    Public Function Excluir(ByVal intIDTipoFuncionalidade As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Insert
            strSQL.Append("DELETE FROM TipoFuncionalidade")
            strSQL.Append(" WHERE TipofuncCodigo = ")
            strSQL.Append(intIDTipoFuncionalidade)

            'Executando instru��o insert
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

    '

    Public Function Consultar(ByVal strWhere As String, Optional ByVal strOrdem As String = "") As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Select


            If Trim(strWhere) <> "" Then
                strSQL.Append(" SELECT * FROM TipoFuncionalidade left join GrupoxFuncionalidade on GrupoxFuncionalidade.TipoFuncCodigo = TipoFuncionalidade.TipoFuncCodigo  ")
                strSQL.Append(" WHERE ")
                strSQL.Append(strWhere)

            Else
                strSQL.Append(" SELECT * FROM TipoFuncionalidade ")
            End If

            If Trim(strOrdem) <> "" Then
                strSQL.Append(" ORDER BY ")
                strSQL.Append(strOrdem)
            End If

            'Executando instru��o Select
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

            'Montando instru��o Select
            strSQL.Append("SELECT * ")
            strSQL.Append("FROM GrupoXfuncionalidade WHERE funcCodigo =  ")
            strSQL.Append(strWhere)

            'Executando instru��o Select
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

End Class
