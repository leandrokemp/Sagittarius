Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela LanceLeilao.
''' </summary>

Public Class dbLanceLeilao

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela LanceLeilao para verificar se um usID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM LanceLeilao WHERE ")
            strSQL.Append(strWhere)

            'Executando instrução Select
            'Utilizando a variável que contém a conexão atualmente selecionada
            'mdaAcessos = New daAcessos
            ConsultarRelacionamentoUserID = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try
    End Function


    Public Function Incluir(ByVal strLeilaoCodigo As Integer, ByVal strLanValor As Double, _
                            ByVal strUsCodigo As Integer, ByVal strLanVencedor As Boolean, ByVal LanData As Date) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO LanceLeilao (")
            strSQL.Append("LeilaoCodigo,UsCodigo,LanValor,LanVencedor,LanData")
            strSQL.Append(") VALUES (")
            strSQL.Append(strLeilaoCodigo)
            strSQL.Append(",")
            strSQL.Append(strUsCodigo)
            strSQL.Append(",")
            strSQL.Append(strLanValor)
            strSQL.Append(", ")
            strSQL.Append(strLanVencedor)
            strSQL.Append(", '")
            strSQL.Append(LanData).Append("'")


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

    Public Function IncluirRetornaIncluido(ByVal strLeilaoCodigo As Int32, ByVal strLanValor As Double, _
                           ByVal strLanVencedor As Boolean, ByVal strUsCodigo As Int32, ByVal LanData As Date) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO LanceLeilao (")
            strSQL.Append("LeilaoCodigo,UsCodigo,LanValor,LanVencedor,LanData")
            strSQL.Append(") VALUES (")
            strSQL.Append(strLeilaoCodigo)
            strSQL.Append(",")
            strSQL.Append(strUsCodigo)
            strSQL.Append(",")
            strSQL.Append(strLanValor)
            strSQL.Append(", ")
            strSQL.Append(IIf(strLanVencedor, 1, 0))
            strSQL.Append(", Convert(DateTime,'")
            strSQL.Append(LanData).Append("',103)")
            strSQL.Append(");")
            strSQL.Append("Select * from LanceLeilao WHERE lanCodigo = @@Identity")


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

    Public Function Alterar(ByVal intLANCodigo As Integer, ByVal strUsCodigo As String, ByVal strLeilaoCodigo As String, _
                            ByVal strLanValor As Double, ByVal strLanVencedor As Boolean, ByVal LanData As Date _
                            ) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("LeilaoCodigo = ")
            strFields.Append(strLeilaoCodigo)
            strFields.Append(", LanValor = ")
            strFields.Append(strLanValor)
            strFields.Append(" ")
            strFields.Append(", UsCodigo = ")
            strFields.Append(strUsCodigo)
            strFields.Append(",")
            strFields.Append(", LanVencedor = ")
            strFields.Append(strLanVencedor)
            strFields.Append(", LanData = '")
            strFields.Append(LanData).Append("'")





            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE LanceLeilao SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE LANCodigo = ")
                strSQL.Append(intLANCodigo)


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

    Public Function AlterarVencedor(ByVal intECodigo As Integer, ByVal strLanVencedor As Boolean, Optional ByVal blnIsIgual As Boolean = False) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização

            strFields.Append(" LanVencedor = ")
            strFields.Append(IIf(strLanVencedor, 1, 0))
            strFields.Append("")


            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE LanceLeilao SET ")
                strSQL.Append(strFields.ToString)

                If blnIsIgual Then
                    strSQL.Append(" WHERE LANCodigo = ")
                Else
                    strSQL.Append(" WHERE LANCodigo <> ")
                End If

                strSQL.Append(intECodigo)



                'Executando instrução Update
                'Utilizando a variável que contém a conexão atualmente selecionada
                mdaAcessos = New daAcessos.daAcessos
                AlterarVencedor = mdaAcessos.Execute(strSQL.ToString)

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
    Public Function Excluir(ByVal intECodigo As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM LanceLeilao")
            strSQL.Append(" WHERE LANCodigo = ")
            strSQL.Append(intECodigo)

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
            strSQL.Append(" SELECT * FROM LanceLeilao ")

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
