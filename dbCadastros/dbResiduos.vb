Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Residuos.
''' </summary>

Public Class dbResiduos

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String
    Public Function IncluirRetornaIncluido(ByVal strReNome As String, ByVal dblRePontoKG As Double, ByVal BlnHabilitado As Boolean) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Dim strAux As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Residuos (")
            strSQL.Append("ReNome,RePontoKG,ReHabilitado")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strReNome)
            strSQL.Append("','")
            strSQL.Append(dblRePontoKG)
            strSQL.Append("','")
            strSQL.Append(BlnHabilitado)
            strSQL.Append("'")
            strSQL.Append(");")
            strSQL.Append("Select * from Residuos WHERE ReCodigo = @@Identity")


            'Executando a instrução de inserção
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            IncluirRetornaIncluido = mdaAcessos.Retrieve(strSQL.ToString)






        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function
    Public Function Incluir(ByVal strReNome As String, ByVal dblRePontoKG As Double, ByVal blnHabilitado As Boolean) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Residuos (")
            strSQL.Append("ReNome,RePontoKG,ReHabilitado")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strReNome)
            strSQL.Append("',")
            strSQL.Append(dblRePontoKG)
            strSQL.Append(",'")
            strSQL.Append(blnHabilitado)
            strSQL.Append("'")

            strSQL.Append(");")

            'Executando a instrução de inserção
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            Incluir = mdaAcessos.Execute(strSQL.ToString)


        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function

    Public Function Alterar(ByVal intIDResiduo As Integer, ByVal strReNome As String, _
                            ByVal dblRePontoKG As Double, ByVal blnHabilitado As Boolean) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("ReNome = '")
            strFields.Append(strReNome)
            strFields.Append("', RePontoKG = ")
            strFields.Append(Convert.ToDouble(dblRePontoKG))
            strFields.Append(", ReHabilitado = ")
            strFields.Append(IIf(blnHabilitado, "1", "0"))






            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Residuos SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE ReCodigo = ")
                strSQL.Append(intIDResiduo)


                'Executando instrução Update
                'Utilizando a variável que contém a conexão atualmente selecionada
                mdaAcessos = New daAcessos.daAcessos
                Alterar = mdaAcessos.Execute(strSQL.ToString)

                ''Enviando mensagem para a BU, indicando o comando realizado para ser registrado em LOG.
                'Mensagem = New FuncoesComuns.clsMensagem
                'Mensagem.TipoMensagem = FuncoesComuns.clsMensagem.enTipoLog.entlInformacao
                'Mensagem.MensagemOriginal = strSQL.ToString

            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
            strFields = Nothing
        End Try
    End Function

    Public Function Excluir(ByVal intIDResiduo As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM Residuos")
            strSQL.Append(" WHERE ReCODIGO = ")
            strSQL.Append(intIDResiduo)

            'Executando instrução insert
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            Excluir = mdaAcessos.Execute(strSQL.ToString)

            ''Enviando mensagem para a BU, indicando o comando realizado para ser registrado em LOG.
            'Mensagem = New FuncoesComuns.clsMensagem
            'Mensagem.TipoMensagem = FuncoesComuns.clsMensagem.enTipoLog.entlInformacao
            'Mensagem.MensagemOriginal = strSQL.ToString

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try
    End Function


    Public Function Consultar(ByVal strWhere As String, Optional ByVal strOrdem As String = "") As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append(" SELECT * FROM Residuos ")

            If Trim(strWhere) <> "" Then
                strSQL.Append(" WHERE ")
                strSQL.Append(strWhere)
            End If

            If Trim(strOrdem) <> "" Then
                strSQL.Append(" ORDER BY ")
                strSQL.Append(strOrdem)
            End If

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            mdaAcessos = New daAcessos.daAcessos
            Consultar = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function


End Class
