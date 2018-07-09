Imports Microsoft.VisualBasic
Imports System.Data

Public Class buRegistrarPeso
    Dim clsdbRegistrarPeso As dbCadastros.dbRegistrarPeso

    Public Function Incluir(ByVal strIdUsuario As String, ByVal strIdResiduo As String, _
                                           ByVal strPeso As String, ByVal dtData As Date) As Boolean

        Dim dsRegistrarPeso As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intRegistrarPeso As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbRegistrarPeso = New dbCadastros.dbRegistrarPeso
            'dbRanking ja é iniciado logo que a classe buRegistrarPeso é iniciada

            If clsdbRegistrarPeso.Incluir(strIdUsuario, strIdResiduo, strPeso, dtData) Then
                Return True
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dsRegistrarPeso = Nothing
            strWhere = Nothing
            intRegistrarPeso = Nothing
        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strIdUsuario As String, ByVal strIdResiduo As String, _
                                           ByVal strPeso As String, ByVal dtData As Date) As DataSet

        Dim dsRegistrarPeso As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intRegistrarPeso As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbRegistrarPeso = New dbCadastros.dbRegistrarPeso
            'dbRegistrarPeso ja é iniciado logo que a classe buRegistrarPeso é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("UsCodigo='")
            strAux.Append(strIdUsuario)
            strAux.Append("'")

            dsConsulta = clsdbRegistrarPeso.Consultar(strAux.ToString)

            'Verifica se não existe o Nome
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                IncluirRetornaIncluido = clsdbRegistrarPeso.IncluirRetornaIncluido(strIdUsuario, strIdResiduo, strPeso, dtData)
            Else
                IncluirRetornaIncluido = New DataSet
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dsRegistrarPeso = Nothing
            strWhere = Nothing
            intRegistrarPeso = Nothing
        End Try
    End Function

    Public Function Alterar(ByVal intIDRegistrarPeso As Integer, ByVal strIdUsuario As String, ByVal strIdResiduo As String, _
                                           ByVal strPeso As String, ByVal dtData As Date) As Boolean

        Dim dsRegistrarPeso As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" RegistrarPeso.ReCodigo ='")
            strWhere.Append(strIdResiduo)
            strWhere.Append("' AND RegistrarPeso.IdRegistrapeso <> ")
            strWhere.Append(intIDRegistrarPeso)

            clsdbRegistrarPeso = New dbCadastros.dbRegistrarPeso

            dsRegistrarPeso = Consultar(strWhere.ToString)
            If dsRegistrarPeso.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo Nome.
                'Retorno da mensagem de Validação.
                'Obter termo referente à validação.

                Return False
            End If

            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRegistrarPeso = New dbCadastros.dbRegistrarPeso
            'altera as informacoes na tabela RegistrarPeso
            If clsdbRegistrarPeso.Alterar(intIDRegistrarPeso, _
                                   strIdUsuario, _
                                   strIdResiduo, strPeso, dtData) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbRegistrarPeso = Nothing
            dsRegistrarPeso = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intIDRegistrarPeso As Integer) As Boolean
        Dim strAux As Text.StringBuilder
        Try

            'Dispara a ação de exclusão do RegistrarPeso
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRegistrarPeso = New dbCadastros.dbRegistrarPeso
            Excluir = clsdbRegistrarPeso.Excluir(intIDRegistrarPeso)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function

    ''' <summary>
    ''' Função que efetua uma consulta na tabela RegistrarPeso.
    ''' </summary>
    ''' <returns>
    ''' Retorna um Dataset com os dados selecionados.
    ''' </returns>
    ''' <remarks> 
    ''' Implementado em: 25/10/2010 por Renato Matsumoto
    ''' </remarks>
    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRegistrarPeso = New dbCadastros.dbRegistrarPeso
            Consultar = clsdbRegistrarPeso.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function

    Public Function Consultarusuario(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRegistrarPeso = New dbCadastros.dbRegistrarPeso
            Consultarusuario = clsdbRegistrarPeso.Consultarusuario(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function

End Class
