Imports Microsoft.VisualBasic
Imports System.Data

Public Class buPontosdeColeta
    Dim clsdbPontosdeColeta As dbCadastros.dbPontosdeColeta


    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        Try

            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta
            ConsultarRelacionamentoUserID = clsdbPontosdeColeta.ConsultarRelacionamentoUserID(strWhere)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strusLatitude As String, _
                           ByVal strusLongitude As String, ByVal strDescricao As String, ByVal strImagem As String) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta
            'dbElearning ja é iniciado logo que a classe buUsuario é iniciada


            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("pcLatitude='")
            strAux.Append(strusLatitude)
            strAux.Append("' AND ")
            strAux.Append("pcLongitude='")
            strAux.Append(strusLongitude)
            strAux.Append("'")

            dsConsulta = clsdbPontosdeColeta.Consultar(strAux.ToString)

            'Verifica se não existe o Latitude
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                IncluirRetornaIncluido = clsdbPontosdeColeta.IncluirRetornaIncluido(strusLatitude, _
                                       strusLongitude, strDescricao, strImagem _
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
    Public Function Incluir(ByVal strusLatitude As String, _
                           ByVal strusLongitude As String, ByVal strDescricao As String, ByVal strImagem As String) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta
            'dbPontosdeColeta ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("pcLatitude='")
            strAux.Append(strusLatitude)
            strAux.Append("' AND ")
            strAux.Append("pcLogitude='")
            strAux.Append(strusLongitude)
            strAux.Append("'")

            dsConsulta = clsdbPontosdeColeta.Consultar(strAux.ToString)

            'Verifica se não existe o Latitude
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                If clsdbPontosdeColeta.Incluir(strusLatitude, _
                                       strusLongitude, strDescricao, strImagem _
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
    Public Function AlterarImagem(ByVal intID As Integer, ByVal strImagem As String) As Boolean
        Try
            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta
            If clsdbPontosdeColeta.AlterarImagem(intID, strImagem) Then
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Alterar(ByVal intID As Integer, ByVal strUsLongitude As String, _
                            ByVal strusLatitude As String, ByVal strDescricao As String) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" pcLatitude ='")
            strWhere.Append(strusLatitude)
            strWhere.Append("' AND ")
            strWhere.Append("pcLongitude='")
            strWhere.Append(strUsLongitude)
            strWhere.Append("' AND PCCodigo <> ")
            strWhere.Append(intID)

            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta

            dsUsuario = Consultar(strWhere.ToString)
            If dsUsuario.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo Latitude.

                'Retorno da mensagem de Validação.

                'Obter termo referente à validação.


                Return False
            End If






            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta

            'altera as informacoes na tabela usuario
            If clsdbPontosdeColeta.Alterar(intID, _
                                   strUsLongitude, _
                                   strusLatitude, strDescricao) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbPontosdeColeta = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intID As Integer, _
                               ByVal strUserLatitude As String) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta
            Excluir = clsdbPontosdeColeta.Excluir(intID)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function


    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbPontosdeColeta = New dbCadastros.dbPontosdeColeta
            Consultar = clsdbPontosdeColeta.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
