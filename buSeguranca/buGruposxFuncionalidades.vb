Imports System
Imports System.Data

Public Class buGruposxFuncionalidades

    Private clsdbGruposxFuncionalidades As dbSeguranca.dbGruposxFuncionalidades
    Private clsbuUsuarios As buSeguranca.buUsuarios



    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String



    '''<summary>
    ''' Função que inclui um novo tipo de grupo na tabela GruposxFuncionalidades.
    ''' </summary>
    ''' <returns> 
    ''' True se incluiu com sucesso, False se não conseguiu incluir.
    ''' </returns>
    ''' <remarks>
    ''' 1. Implementado em: 14/06/2005  por: Rodrigo S. Teixeira.
    ''' 2.1 Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''     - Alterado o tratamento da inclusão, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela GruposxFuncionalidades.
    ''' 2.2 Alterado em: 28/08/2006 por: João Geraldo Vieira
    '''     -  Alterado a passagem da string de conexão com a base de dados
    ''' 3. Alterado em: 10/01/2007 por Douglas Rossetim.
    '''    3.1 - Incluido a string strUserLogin no recebimento dos parametros.
    ''' 4. Alterado em: 11/09/2008 por Felipe Caron.
    '''    4.1 - Incluido Consulta para verificar s já existe o registro no banco.
    Public Function Incluir(ByVal intFuncCodigo As Integer, ByVal intGrpCodigo As String _
                           ) As Boolean
        Dim dsGrupo, dsConsulta As New DataSet
        Dim strWhere As Text.StringBuilder
        Dim intGroup As Integer

        Try
            'Instanciando...
            'Utilizando a variável que contém a conexão atualmente selecionada

            '4.1 - Consulta se existe um registro igual ao que está tentando incluir
            'Montando o Where
            'strWhere = New Text.StringBuilder
            'strWhere.Append("grpNome = '")
            'strWhere.Append(strgrNome)
            'strWhere.Append("'")

            'clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
            'dsConsulta = clsdbGruposxFuncionalidades.Consultar(strWhere.ToString)

            'Verifica se não existe o grupo
            'If dsConsulta.Tables(0).Rows.Count = 0 Then

            'Incluindo o novo Grupo.
            clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
            Incluir = clsdbGruposxFuncionalidades.Incluir(intFuncCodigo, intGrpCodigo)

            'Se inclui, vai incluir as permissões 
            'If Incluir Then

            '    'Montando o Where
            '    strWhere = New Text.StringBuilder
            '    strWhere.Append("grNome = '")
            '    strWhere.Append(strgrNome)
            '    strWhere.Append("'")

            '    'Consultando o ID do item incluído.
            '    dsGrupo = clsdbGruposxFuncionalidades.Consultar(strWhere.ToString)
            '    If dsGrupo.Tables(0).Rows.Count > 0 Then
            '        intGroup = dsGrupo.Tables(0).Rows(0)("grId")
            '    End If

            '    Return True
            'End If

            'Else
            'Já existe esse Grupo

            'Retorno da mensagem de Validação.


            'Return False
            'End If

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    ''' <summary>
    ''' Função que altera um registro na tabela GruposxFuncionalidades.
    ''' </summary>
    ''' <returns>
    ''' True se alterou com sucesso, False se não conseguiu alterar.
    ''' </returns>
    ''' <remarks> 
    ''' 1. Implementado em: 14/06/2005  por: Rodrigo S. Teixeira. 
    ''' 2. Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''     2.1 - Alterado o tratamento de alteracão, pois o campo não faz mais parte da 
    '''           tabela de Cadastros, mas sim da tabela GruposxFuncionalidades.
    ''' 3.Alterado em: 28/08/2006 por: João Geraldo Vieira
    '''    3.1 - Alterado a passagem da string de conexão com a base de dados
    ''' 4. Alterado em: 10/01/2007 por Douglas Rossetim.
    '''    4.1 - Incluido a string strUserLogin no recebimento dos parametros.
    ''' </remarks>

    Public Function Alterar(ByVal strgrNome As String, _
                            ByVal intIDGruposxFuncionalidades As Integer _
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

            clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
            dsConsulta = clsdbGruposxFuncionalidades.Consultar(strWhere.ToString)

            'Verifica se não existe o grupo
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
                Alterar = clsdbGruposxFuncionalidades.Alterar(strgrNome, intIDGruposxFuncionalidades)

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
    ''' Função que exclui um registro da tabela GruposxFuncionalidades, com base na identificação do grupo.
    ''' </summary>
    ''' <returns>
    ''' True se excluiu com sucesso, False se não conseguiu excluir.
    ''' </returns>
    ''' <remarks> 
    ''' 1. Implementado em: 13/06/2005 por: Rodrigo S. Teixeira.
    ''' 2. Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''     2.1 - Alterado o tratamento de exclusão, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela GruposxFuncionalidades.
    ''' 3. Alterado em 10/05/2006 por Flavio F Nigra
    '''    3.1 - Corrigido problema na exclusao (nao era possivel excluir grupo).
    ''' 4. Alterado em 28/08/2006 por: João Geraldo Vieira
    '''    4.1 - Alterado a passagem da string de conexão com a base de dados
    ''' 5. Alterado em: 10/01/2007 por Douglas Rossetim.
    '''    5.1 - Incluido a string strUserLogin no recebimento dos parametros.
    ''' </remarks>

    Public Function Excluir(ByVal strIDGruposxFuncionalidades As String _
                            ) As Boolean

        Dim dsGruposxFuncionalidades As Data.DataSet
        Dim strAux As New Text.StringBuilder

        Try

            'Na exclusao eu instancio o que desejo consultar e realizo 
            'consulta para verificar se não tem nada relacionado
            'Utilizando a variável que contém a conexão atualmente selecionada


            'strAux = New Text.StringBuilder
            'strAux.Append("grpCodigo = ")
            'strAux.Append(intIDGruposxFuncionalidades)



            '1.1 - sistema passa a verificar somente os relacionamentos com usuarios,
            '      uma vez que sempre havera relacionamento com modulos.
            ''clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
            ''dsGruposxFuncionalidades = clsbuUsuarios.ConsultarRelacionamentoUserID(strAux.ToString)
            ''If Not dsGruposxFuncionalidades.Tables(0).Rows(0)("qtdeReg") = 0 Then

            ''    'Existe  registro relacionados

            ''    'Criando instancia da classe que será usada para carregar os termos.


            ''    Dim myErro As New Exception("USUARIO ASSOCIADO")
            ''    myErro.Source = "Relacionamento"
            ''    Throw myErro

            ''End If

            '1.1 - o sistema exclui todos os registros referentes a este grupo da tabela ModulosXGruposxFuncionalidades
            ' clsbuPermissoes.ExcluirPermissoesGruposxFuncionalidades(strAux.ToString)

            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
            Excluir = clsdbGruposxFuncionalidades.Excluir(strIDGruposxFuncionalidades)

        Catch ex As Exception
            Throw ex
        Finally

            dsGruposxFuncionalidades = Nothing
            strAux = Nothing
        End Try
    End Function



    ''' <summary>
    ''' Função que efetua uma consulta na tabela GruposxFuncionalidades.
    ''' </summary>
    ''' <returns>
    ''' Retorna um Dataset com os dados selecionados.
    ''' </returns>
    ''' <remarks> 
    ''' 1.Implementado em: 13/06/2005 por: Rodrigo S. Teixeira.
    ''' 2. Alterado em: 23/11/2005  por: Karen Cristina Geraldo.
    '''    2.1 - Alterado o tratamento de consulta, pois o campo não faz mais parte da 
    '''          tabela de Cadastros, mas sim da tabela GruposxFuncionalidades.
    ''' 3. Alterado em: 28/08/2006 por: João Geraldo Vieira
    '''     3.1 - Alterado a passagem da string de conexão com a base de dados
    ''' </remarks>

    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrderm As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
            Consultar = clsdbGruposxFuncionalidades.Consultar(strWhere, strOrderm)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

   


    Public Function ConsultarFuncionalidadesdoGrupo(Optional ByVal strWhere As String = "", Optional ByVal strOrderm As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbGruposxFuncionalidades = New dbSeguranca.dbGruposxFuncionalidades
            ConsultarFuncionalidadesdoGrupo = clsdbGruposxFuncionalidades.ConsultarFuncionalidadesdoGrupo(strWhere, strOrderm)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
End Class
