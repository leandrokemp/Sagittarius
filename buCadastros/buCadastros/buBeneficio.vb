Imports Microsoft.VisualBasic
Imports System.Data

Public Class buBeneficio
    Dim clsdbBeneficio As dbCadastros.dbBeneficio



    
    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        Try

            clsdbBeneficio = New dbCadastros.dbBeneficio
            ConsultarRelacionamentoUserID = clsdbBeneficio.ConsultarRelacionamentoUserID(strWhere)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Incluir(ByVal strustipo_usuario As String, ByVal strustipo_residuo As String, _
                           ByVal strusdescricao_residuo As String, _
                           ByVal strEndereco As String) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbBeneficio = New dbCadastros.dbBeneficio
            'dbBeneficio ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("ustipo_residuo='")
            strAux.Append(strustipo_residuo)
            strAux.Append("'")

            dsConsulta = clsdbBeneficio.Consultar(strAux.ToString)

            'Verifica se não existe o tipo_residuo
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                If clsdbBeneficio.Incluir(strustipo_usuario, _
                                       strustipo_residuo, _
                                       strusdescricao_residuo, _
                                       strEndereco _
                                       ) Then

                    Return True
                End If

            Else


            End If

        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing
            strWhere = Nothing
            intUser = Nothing
        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strustipo_usuario As String, ByVal strustipo_residuo As String, _
                           ByVal strusdescricao_residuo As String, _
                           ByVal strEndereco As String) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbBeneficio = New dbCadastros.dbBeneficio
            'dbBeneficio ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("ustipo_residuo='")
            strAux.Append(strustipo_residuo)
            strAux.Append("'")

            dsConsulta = clsdbBeneficio.Consultar(strAux.ToString)

            'Verifica se não existe o tipo_residuo
            If dsConsulta.Tables(0).Rows.Count = 0 Then





                IncluirRetornaIncluido = clsdbBeneficio.IncluirRetornaIncluido(strustipo_usuario, strustipo_residuo, strusdescricao_residuo, strEndereco)
            Else
                IncluirRetornaIncluido = New DataSet

            End If




        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing
            strWhere = Nothing
            intUser = Nothing
        End Try
    End Function
    Public Function AlterarUserID(ByVal intIDUsuario As Integer, ByVal strUserID As String) As Boolean
        Try
            If clsdbBeneficio.AlterarUserID(intIDUsuario, strUserID) Then
                Return True
            End If

        Catch ex As Exception
            Throw New ApplicationException("Exception Occured")
        End Try

    End Function

    Public Function Alterar(ByVal intIDUsuario As Integer, ByVal strUsdescricao_residuo As String, ByVal strustipo_usuario As String, _
                            ByVal strustipo_residuo As String, ByVal strUsEndereco As String) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" Beneficio.ustipo_residuo ='")
            strWhere.Append(strustipo_residuo)
            strWhere.Append("' AND Beneficio.usCodigo <> ")
            strWhere.Append(intIDUsuario)

            clsdbBeneficio = New dbCadastros.dbBeneficio

            dsUsuario = Consultar(strWhere.ToString)
            If dsUsuario.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo tipo_residuo.

                'Retorno da mensagem de Validação.

                'Obter termo referente à validação.


                Return False
            End If






            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbBeneficio = New dbCadastros.dbBeneficio

            'altera as informacoes na tabela usuario
            If clsdbBeneficio.Alterar(intIDUsuario, _
                                   strUsdescricao_residuo, _
                                   strustipo_usuario, _
                                   strustipo_residuo, _
                                   strUsEndereco) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbBeneficio = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intIDUsuario As Integer, _
                               ByVal strUsertipo_residuo As String) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbBeneficio = New dbCadastros.dbBeneficio
            Excluir = clsdbBeneficio.Excluir(intIDUsuario)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function

    ''' <summary>
    ''' Função que efetua uma consulta na tabela Beneficio.
    ''' </summary>
    ''' <returns>
    ''' Retorna um Dataset com os dados selecionados.
    ''' </returns>
    ''' <remarks> 
    ''' Implementado em: 13/06/2005 por: Rodrigo S. Teixeira.
    ''' Alterado em: 25/11/2005  por: Karen Cristina Geraldo. 
    ''' Alterado o tratamento de consulta, pois o campo não faz mais parte da 
    ''' tabela de Cadastros, mas sim da tabela Beneficio.
    ''' Alterado em: 28/08/2006 por: João Geraldo Vieira
    ''' Alterado a passagem da string de conexão com a base de dados
    ''' </remarks>
    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbBeneficio = New dbCadastros.dbBeneficio
            Consultar = clsdbBeneficio.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
