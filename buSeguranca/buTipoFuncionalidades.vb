Imports System
Imports System.Data

''' <summary>
''' Classe que trata a camada de negócio da tabela TipoFuncionalidade.
''' </summary>
''' <remarks> 
''' 1. Implementado em: 14/06/2005 por: Rodrigo S. Teixeira.
''' 2. Alterado em: 23/11/2005 por: Karen Cristina Geraldo. 
''' 3. Alterado em: 28/08/2006 por: João Geraldo Vieira.
''' 4. Alterado em: 10/01/2007 por: Douglas Rossetim.
'''     4.1 - Incluido função que registra um LOG para cada operação realizada, exceto consultas.
''' 5. Alterado em 29/12/2008 por Rafael Beck.
'''     - Removida a gravação de LOG pois agora todo log sera gerado dentro de Acessos
'''     - Incluido as funções New() e Finalize() para instanciar a classe db Correspondente
'''     - Removidos as inicializações de classes que estiverem dentro das funções exceto New e Finalize
''' </remarks>

Public Class buTipoFuncionalidade

    Private clsdbTipoFuncionalidade As dbSeguranca.dbTipoFuncionalidade
    Private clsbuUsuarios As buSeguranca.buUsuarios



    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String



    Public Function Incluir(ByVal strgrNome As String, ByVal strUrl As String _
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
            strWhere.Append("descricao = '")
            strWhere.Append(strgrNome)
            strWhere.Append("'")

            clsdbTipoFuncionalidade = New dbSeguranca.dbTipoFuncionalidade
            dsConsulta = clsdbTipoFuncionalidade.Consultar(strWhere.ToString)

            'Verifica se não existe o grupo
            If dsConsulta.Tables(0).Rows.Count = 0 Then

                'Incluindo o novo Grupo.
                clsdbTipoFuncionalidade = New dbSeguranca.dbTipoFuncionalidade
                Incluir = clsdbTipoFuncionalidade.Incluir(strgrNome, strUrl)



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


    Public Function Alterar(ByVal strgrNome As String, _
                            ByVal intIDTipoFuncionalidade As Integer, ByVal strUrl As String _
                            ) As Boolean

        Dim strWhere As Text.StringBuilder
        Dim dsConsulta As Data.DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada

            '4.1 - Consulta se existe um registro igual ao que está tentando incluir
            'Montando o Where
            strWhere = New Text.StringBuilder
            strWhere.Append("Descricao = '")
            strWhere.Append(strgrNome)
            strWhere.Append("'")
            strWhere.Append(" AND ")
            strWhere.Append("TipoFuncionalidade.tipofuncCodigo <> ")
            strWhere.Append(intIDTipoFuncionalidade)

            clsdbTipoFuncionalidade = New dbSeguranca.dbTipoFuncionalidade
            dsConsulta = clsdbTipoFuncionalidade.Consultar(strWhere.ToString)

            'Verifica se não existe o grupo
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                clsdbTipoFuncionalidade = New dbSeguranca.dbTipoFuncionalidade
                Alterar = clsdbTipoFuncionalidade.Alterar(strgrNome, intIDTipoFuncionalidade, strUrl)

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

   

    Public Function Excluir(ByVal intIDTipoFuncionalidade As Integer _
                            ) As Boolean

        Dim dsTipoFuncionalidade As Data.DataSet
        Dim strAux As New Text.StringBuilder

        Try

       


            strAux = New Text.StringBuilder
            strAux.Append("TipoFuncionalidade.tipofuncCodigo = ")
            strAux.Append(intIDTipoFuncionalidade)




            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbTipoFuncionalidade = New dbSeguranca.dbTipoFuncionalidade
            Excluir = clsdbTipoFuncionalidade.Excluir(intIDTipoFuncionalidade)

        Catch ex As Exception
            Throw ex
        Finally

            dsTipoFuncionalidade = Nothing
            strAux = Nothing
        End Try
    End Function




    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrderm As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbTipoFuncionalidade = New dbSeguranca.dbTipoFuncionalidade
            Consultar = clsdbTipoFuncionalidade.Consultar(strWhere, strOrderm)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


    Public Function ConsultarRelacionamento(Optional ByVal strWhere As String = "", Optional ByVal strOrderm As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbTipoFuncionalidade = New dbSeguranca.dbTipoFuncionalidade
            ConsultarRelacionamento = clsdbTipoFuncionalidade.ConsultarRelacionamento(strWhere)
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function


End Class
