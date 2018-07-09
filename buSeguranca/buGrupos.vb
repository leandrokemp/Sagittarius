Imports System
Imports System.Data

Public Class buGrupos

    Private clsdbGrupos As dbSeguranca.dbGrupos
    Private clsbuUsuarios As buSeguranca.buUsuarios



    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String



    '''<summary>
    ''' Função que inclui um novo tipo de grupo na tabela Grupos.
    ''' </summary>
    ''' <returns> 
    ''' True se incluiu com sucesso, False se não conseguiu incluir.
    ''' </returns>
    ''' <remarks>
    ''' 1. Implementado em: 14/06/2005  por: Rodrigo S. Teixeira.
    ''' 2.1 Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''     - Alterado o tratamento da inclusão, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela Grupos.
    ''' 2.2 Alterado em: 28/08/2006 por: João Geraldo Vieira
    '''     -  Alterado a passagem da string de conexão com a base de dados
    ''' 3. Alterado em: 10/01/2007 por Douglas Rossetim.
    '''    3.1 - Incluido a string strUserLogin no recebimento dos parametros.
    ''' 4. Alterado em: 11/09/2008 por Felipe Caron.
    '''    4.1 - Incluido Consulta para verificar s já existe o registro no banco.
    Public Function Incluir(ByVal strgrNome As String _
                           ) As Boolean
        Dim dsGrupo, dsConsulta As New DataSet
        Dim strWhere As Text.StringBuilder
        Dim intGroup As Integer

        Try
            'Instanciando...
            'Utilizando a variável que contém a conexão atualmente selecionada

            '4.1 - Consulta se existe um registro igual ao que está tentando incluir
            'Montando o Where
            strWhere = New Text.StringBuilder
            strWhere.Append("grpNome = '")
            strWhere.Append(strgrNome)
            strWhere.Append("'")

            clsdbGrupos = New dbSeguranca.dbGrupos
            dsConsulta = clsdbGrupos.Consultar(strWhere.ToString)

            'Verifica se não existe o grupo
            If dsConsulta.Tables(0).Rows.Count = 0 Then

                'Incluindo o novo Grupo.
                clsdbGrupos = New dbSeguranca.dbGrupos
                Incluir = clsdbGrupos.Incluir(strgrNome)

                'Se inclui, vai incluir as permissões 
                'If Incluir Then

                '    'Montando o Where
                '    strWhere = New Text.StringBuilder
                '    strWhere.Append("grNome = '")
                '    strWhere.Append(strgrNome)
                '    strWhere.Append("'")

                '    'Consultando o ID do item incluído.
                '    dsGrupo = clsdbGrupos.Consultar(strWhere.ToString)
                '    If dsGrupo.Tables(0).Rows.Count > 0 Then
                '        intGroup = dsGrupo.Tables(0).Rows(0)("grId")
                '    End If

                '    Return True
                'End If

            Else
                'Já existe esse Grupo

                'Retorno da mensagem de Validação.


                Return False
            End If

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Função que altera um registro na tabela Grupos.
    ''' </summary>
    ''' <returns>
    ''' True se alterou com sucesso, False se não conseguiu alterar.
    ''' </returns>
    ''' <remarks> 
    ''' 1. Implementado em: 14/06/2005  por: Rodrigo S. Teixeira. 
    ''' 2. Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''     2.1 - Alterado o tratamento de alteracão, pois o campo não faz mais parte da 
    '''           tabela de Cadastros, mas sim da tabela Grupos.
    ''' 3.Alterado em: 28/08/2006 por: João Geraldo Vieira
    '''    3.1 - Alterado a passagem da string de conexão com a base de dados
    ''' 4. Alterado em: 10/01/2007 por Douglas Rossetim.
    '''    4.1 - Incluido a string strUserLogin no recebimento dos parametros.
    ''' </remarks>

    Public Function Alterar(ByVal strgrNome As String, _
                            ByVal intIDGrupos As Integer _
                            ) As Boolean

        Dim strWhere As Text.StringBuilder
        Dim dsConsulta As Data.DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada

            '4.1 - Consulta se existe um registro igual ao que está tentando incluir
            'Montando o Where
            strWhere = New Text.StringBuilder
            strWhere.Append("grpNome = '")
            strWhere.Append(strgrNome)
            strWhere.Append("'")

            clsdbGrupos = New dbSeguranca.dbGrupos
            dsConsulta = clsdbGrupos.Consultar(strWhere.ToString)

            'Verifica se não existe o grupo
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                clsdbGrupos = New dbSeguranca.dbGrupos
                Alterar = clsdbGrupos.Alterar(strgrNome, intIDGrupos)

            Else
                'Já existe esse Grupo

                'Retorno da mensagem de Validação.


                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    ''' <summary>
    ''' Função que exclui um registro da tabela Grupos, com base na identificação do grupo.
    ''' </summary>
    ''' <returns>
    ''' True se excluiu com sucesso, False se não conseguiu excluir.
    ''' </returns>
    ''' <remarks> 
    ''' 1. Implementado em: 13/06/2005 por: Rodrigo S. Teixeira.
    ''' 2. Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''     2.1 - Alterado o tratamento de exclusão, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela Grupos.
    ''' 3. Alterado em 10/05/2006 por Flavio F Nigra
    '''    3.1 - Corrigido problema na exclusao (nao era possivel excluir grupo).
    ''' 4. Alterado em 28/08/2006 por: João Geraldo Vieira
    '''    4.1 - Alterado a passagem da string de conexão com a base de dados
    ''' 5. Alterado em: 10/01/2007 por Douglas Rossetim.
    '''    5.1 - Incluido a string strUserLogin no recebimento dos parametros.
    ''' </remarks>

    Public Function Excluir(ByVal intIDGrupos As Integer _
                            ) As Boolean

        Dim dsGrupos As Data.DataSet
        Dim strAux As New Text.StringBuilder

        Try

            'Na exclusao eu instancio o que desejo consultar e realizo 
            'consulta para verificar se não tem nada relacionado
            'Utilizando a variável que contém a conexão atualmente selecionada


            strAux = New Text.StringBuilder
            strAux.Append("grpCodigo = ")
            strAux.Append(intIDGrupos)



            '1.1 - sistema passa a verificar somente os relacionamentos com usuarios,
            '      uma vez que sempre havera relacionamento com modulos.
            ''clsdbGrupos = New dbSeguranca.dbGrupos
            ''dsGrupos = clsbuUsuarios.ConsultarRelacionamentoUserID(strAux.ToString)
            ''If Not dsGrupos.Tables(0).Rows(0)("qtdeReg") = 0 Then

            ''    'Existe  registro relacionados

            ''    'Criando instancia da classe que será usada para carregar os termos.


            ''    Dim myErro As New Exception("USUARIO ASSOCIADO")
            ''    myErro.Source = "Relacionamento"
            ''    Throw myErro

            ''End If

            '1.1 - o sistema exclui todos os registros referentes a este grupo da tabela ModulosXGrupos
            ' clsbuPermissoes.ExcluirPermissoesGrupos(strAux.ToString)

            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbGrupos = New dbSeguranca.dbGrupos
            Excluir = clsdbGrupos.Excluir(intIDGrupos)

        Catch ex As Exception
            Throw ex
        Finally

            dsGrupos = Nothing
            strAux = Nothing
        End Try
    End Function



    ''' <summary>
    ''' Função que efetua uma consulta na tabela Grupos.
    ''' </summary>
    ''' <returns>
    ''' Retorna um Dataset com os dados selecionados.
    ''' </returns>
    ''' <remarks> 
    ''' 1.Implementado em: 13/06/2005 por: Rodrigo S. Teixeira.
    ''' 2. Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''    2.1 - Alterado o tratamento de consulta, pois o campo não faz mais parte da 
    '''          tabela de Cadastros, mas sim da tabela Grupos.
    ''' 3. Alterado em: 28/08/2006 por: João Geraldo Vieira
    '''     3.1 - Alterado a passagem da string de conexão com a base de dados
    ''' </remarks>

    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrderm As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbGrupos = New dbSeguranca.dbGrupos
            Consultar = clsdbGrupos.Consultar(strWhere, strOrderm)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function



    Public Function ConsultarRelacionamento(Optional ByVal strWhere As String = "", Optional ByVal strOrderm As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbGrupos = New dbSeguranca.dbGrupos
            ConsultarRelacionamento = clsdbGrupos.ConsultarRelacionamento(strWhere)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Public Function ConsultarRelacionamento2(Optional ByVal strWhere As String = "", Optional ByVal strOrderm As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbGrupos = New dbSeguranca.dbGrupos
            ConsultarRelacionamento2 = clsdbGrupos.ConsultarRelacionamento2(strWhere)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
End Class
