Imports Microsoft.VisualBasic
Imports System.Data

Public Class buElearning
    Dim clsdbElearning As dbCadastros.dbElearning

    Public Function Incluir(ByVal strENome As String, ByVal strEDescricao As String, _
                           ByVal strEImagem As String, _
                           ByVal strEVideo As String, ByVal dtData As Date) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbElearning = New dbCadastros.dbElearning
            'dbElearning ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("ENome='")
            strAux.Append(strEDescricao)
            strAux.Append("'")

            dsConsulta = clsdbElearning.Consultar(strAux.ToString)

            'Verifica se não existe o LOGIN
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                If clsdbElearning.Incluir(strENome, _
                                       strEDescricao, _
                                       strEImagem, _
                                       strEVideo, dtData _
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

    Public Function Alterar(ByVal intECodigo As Integer, ByVal strENome As String, _
                            ByVal strEDescricao As String, ByVal strEvideo As String, ByVal dtData As Date) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" Elearning.ENome ='")
            strWhere.Append(strEDescricao)
            strWhere.Append("' AND Elearning.ECodigo <> ")
            strWhere.Append(intECodigo)

            clsdbElearning = New dbCadastros.dbElearning

            dsUsuario = Consultar(strWhere.ToString)
            If dsUsuario.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo Login.

                'Retorno da mensagem de Validação.

                'Obter termo referente à validação.


                Return False
            End If






            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbElearning = New dbCadastros.dbElearning

            'altera as informacoes na tabela usuario
            If clsdbElearning.Alterar(intECodigo, _
                                   strEvideo, _
                                   strENome, _
                                   strEDescricao, _
                                    dtData) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbElearning = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intECodigo As Integer, _
                               ByVal strUserLogin As String) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbElearning = New dbCadastros.dbElearning
            Excluir = clsdbElearning.Excluir(intECodigo)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strENome As String, ByVal strEDescricao As String, _
                           ByVal strEImagem As String, _
                           ByVal strEVideo As String, ByVal dtData As Date) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbElearning = New dbCadastros.dbElearning
            'dbElearning ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("ENome='")
            strAux.Append(strEDescricao)
            strAux.Append("'")

            dsConsulta = clsdbElearning.Consultar(strAux.ToString)

            'Verifica se não existe o LOGIN
            If dsConsulta.Tables(0).Rows.Count = 0 Then




                IncluirRetornaIncluido = clsdbElearning.IncluirRetornaIncluido(strENome, _
                                       strEDescricao, _
                                       strEImagem, _
                                       strEVideo, dtData _
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
    Public Function AlterarImagem(ByVal intEleraning As Integer, ByVal strImagem As String) As Boolean
        Try
            clsdbElearning = New dbCadastros.dbElearning
            If clsdbElearning.AlterarImagem(intEleraning, strImagem) Then
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbElearning = New dbCadastros.dbElearning
            Consultar = clsdbElearning.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
