Imports Microsoft.VisualBasic
Imports System.Data

Public Class buResiduos
    Dim clsdbResiduos As dbCadastros.dbResiduos

    Public Function Incluir(ByVal strReNome As String, ByVal dblRePontoKG As Double, ByVal BlnHabilitado As Boolean) As Boolean

        Dim dsResiduo As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intResiduo As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbResiduos = New dbCadastros.dbResiduos
            'dbResiduos ja é iniciado logo que a classe buResiduo é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("ReNome='")
            strAux.Append(strReNome)
            strAux.Append("'")
           
            dsConsulta = clsdbResiduos.Consultar(strAux.ToString)

            'Verifica se não existe o Nome
            If dsConsulta.Tables(0).Rows.Count = 0 Then



                If clsdbResiduos.Incluir(strReNome, dblRePontoKG, BlnHabilitado) Then
                    Return True
                End If

            Else


            End If

        Catch ex As Exception
            Throw ex
        Finally
            dsResiduo = Nothing
            strWhere = Nothing
            intResiduo = Nothing
        End Try
    End Function
    Public Function IncluirRetornaIncluido(ByVal strReNome As String, ByVal dblRePontoKG As Double, ByVal blnHabilitado As Boolean) As DataSet

        Dim dsResiduo As DataSet
        Dim strWhere, strAux As Text.StringBuilder
        Dim intResiduo As Integer
        Dim dsConsulta As Data.DataSet

        Try
            clsdbResiduos = New dbCadastros.dbResiduos
            'dbResiduos ja é iniciado logo que a classe buResiduo é iniciada

            'monta filtro
            strAux = New Text.StringBuilder
            strAux.Append("ReNome='")
            strAux.Append(strReNome)
            strAux.Append("'")

            dsConsulta = clsdbResiduos.Consultar(strAux.ToString)

            'Verifica se não existe o Nome
            If dsConsulta.Tables(0).Rows.Count = 0 Then
                IncluirRetornaIncluido = clsdbResiduos.IncluirRetornaIncluido(strReNome, dblRePontoKG, blnHabilitado)
            Else
                IncluirRetornaIncluido = New DataSet
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dsResiduo = Nothing
            strWhere = Nothing
            intResiduo = Nothing
        End Try
    End Function

    Public Function Alterar(ByVal intIDResiduo As Integer, ByVal strReNome As String, _
                            ByVal dblRePontoKG As Double, ByVal blnHabilitado As Boolean) As Boolean

        Dim dsResiduo As Data.DataSet
        Dim strWhere As Text.StringBuilder


        Try
            strWhere = New Text.StringBuilder
            strWhere.Append(" Residuos.ReNome ='")
            strWhere.Append(strReNome)
            strWhere.Append("'")
            strWhere.Append(" and Residuos.REcodigo <> ").Append(intIDResiduo)

            clsdbResiduos = New dbCadastros.dbResiduos

            dsResiduo = Consultar(strWhere.ToString)
            If dsResiduo.Tables(0).Rows.Count > 0 Then

                'Já existe um registro com a mesmo Nome.

                'Retorno da mensagem de Validação.

                'Obter termo referente à validação.


                Return False
            End If






            'Utilizando a variável que contém a conexão atualmente selecionada

            clsdbResiduos = New dbCadastros.dbResiduos

            'altera as informacoes na tabela Residuo
            If clsdbResiduos.Alterar(intIDResiduo, _
                                   strReNome, dblRePontoKG, _
                                   blnHabilitado) Then
                Return True

            End If
        Catch ex As Exception
            Throw ex
        Finally

            'clsdbResiduos = Nothing
            dsResiduo = Nothing
            strWhere = Nothing
        End Try
    End Function
    Public Function Excluir(ByVal intIDResiduo As Integer) As Boolean
        Dim strAux As Text.StringBuilder
        Dim clsbuUsuariosResiduos As buSeguranca.buUsuariosResiduos
        Dim dsAux As Data.DataSet = New Data.DataSet
        Try

            clsbuUsuariosResiduos = New buSeguranca.buUsuariosResiduos
            dsAux = clsbuUsuariosResiduos.ConsultarRelacionamentoUserID("ReCodigo = " & intIDResiduo)

            If Convert.ToInt32(dsAux.Tables(0).Rows(0)("qtdeReg").ToString()) = 0 Then

                'Dispara a ação de exclusão do residuo
                'Utilizando a variável que contém a conexão atualmente selecionada
                clsdbResiduos = New dbCadastros.dbResiduos
                Excluir = clsdbResiduos.Excluir(intIDResiduo)
            Else

                Excluir = False
            End If

            

        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing

        End Try
    End Function

    ''' <summary>
    ''' Função que efetua uma consulta na tabela Residuos.
    ''' </summary>
    ''' <returns>
    ''' Retorna um Dataset com os dados selecionados.
    ''' </returns>
    ''' <remarks> 
    ''' </remarks>
    Public Function Consultar(Optional ByVal strWhere As String = "", Optional ByVal strOrdem As String = "") As DataSet
        Try
            'Utilizando a variável que contém a conexão atualmente selecionada
            clsdbResiduos = New dbCadastros.dbResiduos
            Consultar = clsdbResiduos.Consultar(strWhere, strOrdem)
        Catch ex As Exception
            Throw ex
        Finally
            strWhere = Nothing
        End Try
    End Function
End Class
