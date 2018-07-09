Imports System
Imports System.Data

''' <summary>
''' Classe para tratar a camada de dados da tabela Usuarios.
''' </summary>

Public Class dbUsuarios

    'Private mdaAcessos As daAcessos
    Private mdaAcessos As daAcessos.daAcessos


    'Vari�vel que receber� a string de conex�o atualmente selecionada
    Private strConexao As String

    Public Function ConsultarRelacionamentoUserID(ByVal strWhere As String) As DataSet
        'realiza a consulta na tabela USUARIOS para verificar se um usID 
        ' faz parte de um grID

        Dim strSQL As System.Text.StringBuilder

        Try
            strSQL = New System.Text.StringBuilder

            'Montando instru��o Select
            strSQL.Append("SELECT COUNT (*) AS qtdeReg ")
            strSQL.Append("FROM usuarios WHERE ")
            strSQL.Append(strWhere)

            'Executando instru��o Select
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
            'mdaAcessos = New daAcessos
            ConsultarRelacionamentoUserID = mdaAcessos.Retrieve(strSQL.ToString)

        Catch ex As Exception
            Throw ex
        Finally
            'mdaAcessos = Nothing
            strSQL = Nothing
        End Try
    End Function

    Public Function IncluirRetornaIncluido(ByVal strusNome As String, ByVal strusLogin As String, _
                            ByVal strUsEmail As String, ByVal strUsEndereco As String, ByVal cnpj As String, ByVal telefone As String) As DataSet

        Dim strSQL As New System.Text.StringBuilder
        Dim strAux As New System.Text.StringBuilder
        Try

            'Montando instru��o de inser��o
            strSQL.Append("INSERT INTO Usuarios (")
            strSQL.Append("usNome,usLogin,usEmail,usEndereco,usCnpj,usTelefone")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strusNome)
            strSQL.Append("','")
            strSQL.Append(strusLogin)
            strSQL.Append("', '")
            strSQL.Append(strUsEmail)
            strSQL.Append("', '")
            strSQL.Append(strUsEndereco)
            strSQL.Append("','")
            strSQL.Append(cnpj)
            strSQL.Append("','")
            strSQL.Append(telefone)
            strSQL.Append("'")


            strSQL.Append(");")
            strSQL.Append("Select * from USuarios WHERE usCodigo = @@Identity")


            'Executando a instru��o de inser��o
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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
    Public Function Incluir(ByVal strusNome As String, ByVal strusLogin As String, _
                            ByVal strUsEmail As String, ByVal strUsEndereco As String, ByVal cnpj As String, ByVal telefone As String) As Boolean

        Dim strSQL As New System.Text.StringBuilder
        Try

            'Montando instru��o de inser��o
            strSQL.Append("INSERT INTO Usuarios (")
            strSQL.Append("usNome,usLogin,usEmail,usEndereco,usCnpj,usTelefone")
            strSQL.Append(") VALUES ('")
            strSQL.Append(strusNome)
            strSQL.Append("','")
            strSQL.Append(strusLogin)
            strSQL.Append("', '")
            strSQL.Append(strUsEmail)
            strSQL.Append("', '")
            strSQL.Append(strUsEndereco)
            strSQL.Append("','")
            strSQL.Append(cnpj)
            strSQL.Append("','")
            strSQL.Append(telefone)
            strSQL.Append("'")
            strSQL.Append(");")

            'Executando a instru��o de inser��o
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

    Public Function Alterar(ByVal intIDUsuario As Integer, ByVal strEmail As String, ByVal strusNome As String, _
                            ByVal strusLogin As String, ByVal strEndereco As String, ByVal cnpj As String, ByVal telefone As String _
                            ) As Boolean

        Dim strSQL As System.Text.StringBuilder
        Dim strFields As System.Text.StringBuilder

        Try
            strFields = New System.Text.StringBuilder

            'Montando instru��o de atualiza��o
            strFields.Append("usNome = '")
            strFields.Append(strusNome)
            strFields.Append("', usLogin = '")
            strFields.Append(strusLogin)
            strFields.Append("'")
            strFields.Append(", usEndereco = '")
            strFields.Append(strEndereco)
            strFields.Append("'")
            strFields.Append(", usEmail = '")
            strFields.Append(strEmail)
            strFields.Append("'")

            strFields.Append(", usCnpj = '")
            strFields.Append(cnpj)
            strFields.Append("'")

            strFields.Append(", usTelefone = '")
            strFields.Append(telefone)
            strFields.Append("'")


     

            If strFields.ToString.Length > 0 Then
                'Montando instru��o Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Usuarios SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE usCodigo = ")
                strSQL.Append(intIDUsuario)


                'Executando instru��o Update
                'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

            'Montando instru��o de atualiza��o
            strFields.Append("UserId = '")
            strFields.Append(strUserID)
            strFields.Append("'")




            If strFields.ToString.Length > 0 Then
                'Montando instru��o Update
                strSQL = New System.Text.StringBuilder
                strSQL.Append("UPDATE Usuarios SET ")
                strSQL.Append(strFields.ToString)
                strSQL.Append(" WHERE usCodigo = ")
                strSQL.Append(intIDUsuario)


                'Executando instru��o Update
                'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

            'Montando instru��o Insert
            strSQL.Append("DELETE FROM Usuarios")
            strSQL.Append(" WHERE usCODIGO = ")
            strSQL.Append(intIDUsuario)

            'Executando instru��o insert
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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

            'Montando instru��o Select
            strSQL.Append(" SELECT u.*, ar.*, amp.IsApproved FROM Usuarios u left join aspnet_UsersInRoles aur on aur.Userid = u.userid left join aspnet_roles ar on ar.RoleID = aur.RoleId left join aspnet_membership amp on amp.userid = u.userid  ")

            If Trim(strWhere) <> "" Then
                strSQL.Append(" WHERE ")
                strSQL.Append(strWhere)
            End If

            If Trim(strOrdem) <> "" Then
                strSQL.Append(" ORDER BY ")
                strSQL.Append(strOrdem)
            End If

            'Executando instru��o Select
            'Utilizando a vari�vel que cont�m a conex�o atualmente selecionada
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
