Imports Microsoft.VisualBasic
Imports System.Data

Public Class buRequisicao

    Dim clsdbRequisicao As dbCadastros.dbRequisicao

    Public Function Incluir(ByVal ReqQuantidade As Integer, ByVal usCodigo As Integer, ByVal dtReqData As Date) As Boolean

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbRequisicao = New dbCadastros.dbRequisicao
            'dbRequisicao ja é iniciado logo que a classe buUsuario é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("ReqQuantidade='")
            strAux.Append(ReqQuantidade)
            strAux.Append("'")

            dsConsulta = clsdbRequisicao.Consultar(strAux.ToString)

            'Verifica se não existe o LOGIN
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                If clsdbRequisicao.Incluir(ReqQuantidade, _
                                       usCodigo, _
                                       dtReqData) Then

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

    Public Function Alterar(ByVal ReqCodigo As Integer, ByVal ReqQuantidade As Integer) As Boolean

        Dim dsUsuario As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try

            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbRequisicao = New dbCadastros.dbRequisicao

            'altera as informacoes na tabela usuario
            If clsdbRequisicao.Alterar(ReqCodigo, _
                                   ReqQuantidade) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbRequisicao = Nothing
            dsUsuario = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal ReqCodigo As Integer) As Boolean
        Dim strAux As Text.StringBuilder
        Try



            'Dispara a ação de exclusão do usuário
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRequisicao = New dbCadastros.dbRequisicao
            Excluir = clsdbRequisicao.Excluir(ReqCodigo)

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal ReqQuantidade As Integer, ByVal usCodigo As Integer, ByVal dtReqData As Date) As DataSet

        Dim dsUsuario As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intUser As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbRequisicao = New dbCadastros.dbRequisicao
            'dbRequisicao ja é iniciado logo que a classe buUsuario é iniciada

            IncluirRetornaIncluido = clsdbRequisicao.IncluirRetornaIncluido(ReqQuantidade, _
                                   usCodigo, _
                                   dtReqData)

            IncluirRetornaIncluido = New DataSet



        Catch ex As Exception
            Throw ex
        Finally
            dsUsuario = Nothing
            strWhere = Nothing
            intUser = Nothing
        End Try
    End Function

    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbRequisicao = New dbCadastros.dbRequisicao
            Consultar = clsdbRequisicao.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function

    Public Function AlterarCheckBox(ByVal ReqCodigo As Integer, ByVal ReqAtendido As Boolean) As Boolean
        Try
            clsdbRequisicao = New dbCadastros.dbRequisicao
            If clsdbRequisicao.AlterarCheckBox(ReqCodigo, ReqAtendido) Then
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
