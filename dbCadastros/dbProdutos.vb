Imports Microsoft.VisualBasic

Public Class dbProdutos

    Dim mdaAcessos As daAcessos.daAcessos
    ''' <summary>
    ''' M�todo para incluir um novo registro na tabela.
    ''' </summary>
    ''' <returns>True se incluiu com sucesso, False se n�o conseguiu incluir.</returns>
    Public Function Incluir(ByVal strNome As String, ByVal strTelefone As String, ByVal strRamal As String) As Boolean
        Dim strSQL As System.Text.StringBuilder
        Try
            'variavel de concatena�ao
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Insert
            strSQL.Append(" INSERT INTO Produtos")
            strSQL.Append(" VALUES ('")
            strSQL.Append(strNome)
            strSQL.Append("',")
            strSQL.Append(strRamal)
            strSQL.Append(",'")
            strSQL.Append(strTelefone)
            strSQL.Append("')")


            'Executando instru��o insert
            mdaAcessos = New daAcessos.daAcessos
            Incluir = mdaAcessos.Execute(strSQL.ToString)

        Catch ex As Exception
            Dim msg As New Text.StringBuilder
            msg.Append(ex.Message)
            msg.Append(" :: ")
            msg.Append(strSQL.ToString)

            Dim Ex2 As New Exception(msg.ToString, ex)
            msg = Nothing
            Throw Ex2
        Finally
            strSQL = Nothing
        End Try

    End Function

    ''' <summary>
    ''' M�todo para atualizar um registro da tabela.
    ''' </summary>
    ''' <returns>True se alterou com sucesso, False se n�o conseguiu alterar.</returns>
    Public Function Alterar(ByVal intCodigo As Integer, ByVal StrNome As String, ByVal strTElefone As String, ByVal strRamal As String) As Boolean
        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder
        Try
            strFields = New System.Text.StringBuilder
            strFields.Append("vendNome = '")
            strFields.Append(StrNome)
            strFields.Append("',")
            strFields.Append("vendTelefone = '")
            strFields.Append(strTElefone)
            strFields.Append("',")
            strFields.Append("vendRamal = ")
            strFields.Append(strRamal)



            If strFields.ToString.Length > 0 Then
                'Montando instru��o Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append(" UPDATE Produtoes SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE vendCOD = ")
                strSQL.Append(intCodigo)

                'Executando instru��o Update
                mdaAcessos = New daAcessos.daAcessos
                Alterar = mdaAcessos.Execute(strSQL.ToString)
            Else
                Return False
            End If

        Catch ex As Exception
            Dim msg As New Text.StringBuilder
            msg.Append(ex.Message)
            msg.Append(" :: ")
            msg.Append(strSQL.ToString)

            Dim Ex2 As New Exception(msg.ToString, ex)
            msg = Nothing
            Throw Ex2
        Finally
            strSQL = Nothing
            strFields = Nothing
        End Try
    End Function

    ''' <summary>
    ''' M�todo para excluir um registro da tabela, com base na identifica��o.
    ''' </summary>
    ''' <returns>True se excluiu com sucesso, False se n�o conseguiu excluir.</returns>
    Public Function Excluir(ByVal intCodigo As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Delete
            strSQL.Append(" DELETE FROM Produtoes ")
            strSQL.Append(" WHERE vendCOD = ")
            strSQL.Append(intCodigo)

            'Executando instru��o Delete
            mdaAcessos = New daAcessos.daAcessos
            Excluir = mdaAcessos.Execute(strSQL.ToString)

        Catch ex As Exception
            Dim msg As New Text.StringBuilder
            msg.Append(ex.Message)
            msg.Append(" :: ")
            msg.Append(strSQL.ToString)

            Dim Ex2 As New Exception(msg.ToString, ex)
            msg = Nothing
            Throw Ex2
        Finally
            strSQL = Nothing
        End Try

    End Function

    ''' <summary>
    ''' Fun��o que efetua uma consulta na tabela.
    ''' </summary>
    ''' <returns>Dataset contendo os dados selecionados.</returns>
    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Select
            strSQL.Append(" SELECT * FROM Produtoes ")



            If Trim(strWhere) <> "" Then
                strSQL.Append(" WHERE ")
                strSQL.Append(strWhere)

            End If

            If Trim(strOrdem) <> "" Then
                strSQL.Append(" ORDER BY ")
                strSQL.Append(strOrdem)
            End If

            'Executando instru��o Select
            mdaAcessos = New daAcessos.daAcessos
            Consultar = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Dim msg As New Text.StringBuilder
            msg.Append(ex.Message)
            msg.Append(" :: ")
            msg.Append(strSQL.ToString)

            Dim Ex2 As New Exception(msg.ToString, ex)
            msg = Nothing
            Throw Ex2
        Finally
            strSQL = Nothing
        End Try
    End Function
End Class
