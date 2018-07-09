Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Beneficio.
''' </summary>
''' <remarks> 
''' Implementado em:13/06/2005 por: Rodrigo S. Teixeira.
''' Alterado em:25/11/2005 por: Karen Cristina Geraldo.
''' Alterado em: 28/08/2006 por: João Geraldo Vieira
''' </remarks>

Public Class dbBeneficio

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Variável que receberá a string de conexão atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela Beneficio para verificar se um usID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM Beneficio WHERE ")
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

    Public Function IncluirRetornaIncluido(ByVal strustipo_usuario As String, ByVal strustipo_residuo As String, _
                            ByVal strUsdescricao_beneficio As String, ByVal strUsEndereco As String) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Dim strAux As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Beneficio (")
            strSQL.Append("ustipo_usuario,usdescricao_beneficio,ustipo_residuo,usEndereco")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strustipo_usuario)
            strSQL.Append("','")
            strSQL.Append(strustipo_residuo)
            strSQL.Append("', '")
            strSQL.Append(strUsdescricao_beneficio)
            strSQL.Append("', '")
            strSQL.Append(strUsEndereco)
            strSQL.Append("'")

            strSQL.Append(");")
            strSQL.Append("Select * from Beneficio WHERE usCodigo = @@Identity")


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
    Public Function Incluir(ByVal strustipo_usuario As String, ByVal strustipo_residuo As String, _
                            ByVal strUsdescricao_beneficio As String, ByVal strUsEndereco As String) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instrução de inserção
            strSQL.Append("INSERT INTO Beneficio (")
            strSQL.Append("ustipo_usuario,usdescricao_beneficio,ustipo_residuo,usEndereco")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strustipo_usuario)
            strSQL.Append("','")
            strSQL.Append(strustipo_residuo)
            strSQL.Append("', '")
            strSQL.Append(strUsdescricao_beneficio)
            strSQL.Append("', '")
            strSQL.Append(strUsEndereco)
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

    Public Function Alterar(ByVal intIDUsuario As Integer, ByVal strdescricao_beneficio As String, ByVal strustipo_usuario As String, _
                            ByVal strustipo_residuo As String, ByVal strEndereco As String _
                            ) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("ustipo_usuario = '")
            strFields.Append(strustipo_usuario)
            strFields.Append("', ustipo_residuo = '")
            strFields.Append(strustipo_residuo)
            strFields.Append("'")
            strFields.Append(", usEndereco = '")
            strFields.Append(strEndereco)
            strFields.Append("'")
            strFields.Append(", usdescricao_beneficio = '")
            strFields.Append(strdescricao_beneficio)
            strFields.Append("'")





            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Beneficio SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE usCodigo = ")
                strSQL.Append(intIDUsuario)


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
    Public Function AlterarUserID(ByVal intIDUsuario As Integer, ByVal strUserID As String) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instrução de atualização
            strFields.Append("UserId = '")
            strFields.Append(strUserID)
            strFields.Append("'")




            If strFields.ToString.Length > 0 Then
                'Montando instrução Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Beneficio SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE usCodigo = ")
                strSQL.Append(intIDUsuario)


                'Executando instrução Update
                'Utilizando a variável que contém a conexão atualmente selecionada
                mdaAcessos = New daAcessos.daAcessos
                AlterarUserID = mdaAcessos.Execute(strSQL.ToString)

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


    Public Function Excluir(ByVal intIDUsuario As Integer) As Boolean
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Insert
            strSQL.Append("DELETE FROM Beneficio")
            strSQL.Append(" WHERE usCODIGO = ")
            strSQL.Append(intIDUsuario)

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
            strSQL.Append(" SELECT * FROM Beneficio ")

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

    ''' <summary> Método que faz a autenticação do usuário</summary>
    ''' <param name="strtipo_residuo"> tipo_residuo digitado pelo usuário</param>
    ''' <param name="strSenha" >Senha digitada pelo usuário</param>
    ''' <returns> DataSet com dados</returns>
    ''' <versao ID="1.0" RF="RS014" Data="01/09/2009" Desenvolvedor="Felipe Caron"> Criação do Método</versao>
    Public Function Validatipo_residuo(ByVal strtipo_residuo As String, ByVal strSenha As String) As DataSet
        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instrução Select
            strSQL.Append(" SELECT * FROM Beneficio ")
            strSQL.Append(" WHERE ustipo_residuo ='").Append(strtipo_residuo).Append("'")
            strSQL.Append(" AND usPassword ='").Append(strSenha).Append("'")

            'Verifica se foi encontrado algum usuário com o tipo_residuo e a senha fornecidos
            mdaAcessos = New daAcessos.daAcessos
            Validatipo_residuo = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try

    End Function


End Class
