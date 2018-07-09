Imports Microsoft.VisualBasic
Imports System.Data

Public Class buNoticias
    Dim clsdbNoticias As dbCadastros.dbNoticias

    Public Function Incluir(ByVal strNotNome As String, ByVal strNotDescricao As String, _
                           ByVal strNotImagem As String, _
                           ByVal strNotVideo As String, ByVal dtData As Date) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbNoticias = New dbCadastros.dbNoticias
            'dbNoticias ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("NotNome='")
            strAux.Append(strNotDescricao)
            strAux.Append("'")

            dsConsulta = clsdbNoticias.Consultar(strAux.ToString)

            'Verifica se não existe o LOGIN
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                If clsdbNoticias.Incluir(strNotNome, _
                                       strNotDescricao, _
                                       strNotImagem, _
                                       strNotVideo, dtData _
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

    Public Function Alterar(ByVal intNotCodigo As Integer, ByVal strNotNome As String, _
                            ByVal strNotDescricao As String, ByVal strNotvideo As String, ByVal dtData As Date) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" Noticias.NotNome ='")
            strWhere.Append(strNotDescricao)
            strWhere.Append("' AND Noticias.NotCodigo <> ")
            strWhere.Append(intNotCodigo)

            clsdbNoticias = New dbCadastros.dbNoticias

            dsUsuario = Consultar(strWhere.ToString)
            If dsUsuario.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo Login.

                'Retorno da mensagem de Validação.

                'Obter termo referente à validação.


                Return False
            End If






            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbNoticias = New dbCadastros.dbNoticias

            'altera as informacoes na tabela usuario
            If clsdbNoticias.Alterar(intNotCodigo, _
                                   strNotvideo, _
                                   strNotNome, _
                                   strNotDescricao, _
                                    dtData) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbNoticias = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intNotCodigo As Integer, _
                               ByVal strUserLogin As String) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbNoticias = New dbCadastros.dbNoticias
            Excluir = clsdbNoticias.Excluir(intNotCodigo)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strNotNome As String, ByVal strNotDescricao As String, _
                           ByVal strNotImagem As String, _
                           ByVal strNotVideo As String, ByVal dtData As Date) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbNoticias = New dbCadastros.dbNoticias
            'dbNoticias ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("NotNome='")
            strAux.Append(strNotDescricao)
            strAux.Append("'")

            dsConsulta = clsdbNoticias.Consultar(strAux.ToString)

            'Verifica se não existe o LOGIN
            If dsConsulta.Tables(0).Rows.Count = 0 Then




                IncluirRetornaIncluido = clsdbNoticias.IncluirRetornaIncluido(strNotNome, _
                                       strNotDescricao, _
                                       strNotImagem, _
                                       strNotVideo, dtData _
                                       )
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
    Public Function AlterarImagem(ByVal intNoticia As Integer, ByVal strImagem As String) As Boolean
        Try
            clsdbNoticias = New dbCadastros.dbNoticias
            If clsdbNoticias.AlterarImagem(intNoticia, strImagem) Then
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbNoticias = New dbCadastros.dbNoticias
            Consultar = clsdbNoticias.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
