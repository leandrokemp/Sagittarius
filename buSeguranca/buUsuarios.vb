Imports Microsoft.VisualBasic
Imports System.Data

Public Class buUsuarios
    Dim clsdbUsuarios As dbSeguranca.dbUsuarios


    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        Try

            clsdbUsuarios = New dbSeguranca.dbUsuarios
            ConsultarRelacionamentoUserID = clsdbUsuarios.ConsultarRelacionamentoUserID(strWhere)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Incluir(ByVal strusNome As String, ByVal strusLogin As String, _
                           ByVal strusEmail As String, _
                           ByVal strEndereco As String, ByVal Cnpj As String, ByVal Telefone As String) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbUsuarios = New dbSeguranca.dbUsuarios
            'dbUsuarios ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("usLogin='")
            strAux.Append(strusLogin)
            strAux.Append("'")

            dsConsulta = clsdbUsuarios.Consultar(strAux.ToString)

            'Verifica se não existe o LOGIN
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                If clsdbUsuarios.Incluir(strusNome, _
                                       strusLogin, _
                                       strusEmail, _
                                       strEndereco, Cnpj, Telefone _
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
    Public Function IncluirRetornaIncluido(ByVal strusNome As String, ByVal strusLogin As String, _
                           ByVal strusEmail As String, _
                           ByVal strEndereco As String, ByVal cnpj As String, ByVal telefone As String) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbUsuarios = New dbSeguranca.dbUsuarios
            'dbUsuarios ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("usLogin='")
            strAux.Append(strusLogin)
            strAux.Append("'")

            dsConsulta = clsdbUsuarios.Consultar(strAux.ToString)

            'Verifica se não existe o LOGIN
            If dsConsulta.Tables(0).Rows.Count = 0 Then





                IncluirRetornaIncluido = clsdbUsuarios.IncluirRetornaIncluido(strusNome, strusLogin, strusEmail, strEndereco, cnpj, telefone)
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
            If clsdbUsuarios.AlterarUserID(intIDUsuario, strUserID) Then
                Return True
            End If

        Catch ex As Exception
            Throw New ApplicationException("Exception Occured")
        End Try

    End Function

    Public Function Alterar(ByVal intIDUsuario As Integer, ByVal strUsEmail As String, ByVal strusNome As String, _
                            ByVal strusLogin As String, ByVal strUsEndereco As String, ByVal cnpj As String, ByVal telefone As String) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" u.usLogin ='")
            strWhere.Append(strusLogin)
            strWhere.Append("' AND u.usCodigo <> ")
            strWhere.Append(intIDUsuario)

            clsdbUsuarios = New dbSeguranca.dbUsuarios

            dsUsuario = Consultar(strWhere.ToString)
            If dsUsuario.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo Login.

                'Retorno da mensagem de Validação.

                'Obter termo referente à validação.


                Return False
            End If






            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbUsuarios = New dbSeguranca.dbUsuarios

            'altera as informacoes na tabela usuario
            If clsdbUsuarios.Alterar(intIDUsuario, _
                                   strUsEmail, _
                                   strusNome, _
                                   strusLogin, _
                                   strUsEndereco, cnpj, telefone) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbUsuarios = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intIDUsuario As Integer, _
                               ByVal strUserLogin As String) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbUsuarios = New dbSeguranca.dbUsuarios
            Excluir = clsdbUsuarios.Excluir(intIDUsuario)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function

  
    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbUsuarios = New dbSeguranca.dbUsuarios
            Consultar = clsdbUsuarios.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
