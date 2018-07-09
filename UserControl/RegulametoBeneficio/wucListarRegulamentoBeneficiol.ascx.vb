
Partial Class UserControl_RegulametoBeneficio_wucListarRegulamentoBeneficiol
    Inherits System.Web.UI.UserControl
    Dim clsbuRegulamentoBeneficios As buCadastros.buRegulamentoBeneficio
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            PopulaDados("", True)
        Else
            'Tratamento de consulta da grid, fazendo com que o usuário possa clicar em qualquer local da linha desejada.
            If (Request("__EVENTTARGET").ToUpper = "CONSULTAR") And IsNumeric(Request("__EVENTARGUMENT")) Then
                dgwDados_Consultar(Request("__EVENTARGUMENT"))
            End If
        End If
    End Sub


    ''' <summary>
    ''' Função que é utilizada para controlar a consulta da GridView.
    ''' </summary>
    ''' <remarks> Implementado em 19/06/2009 por Nill Pinheiro
    '''             .</remarks>
    Protected Sub dgwDados_Consultar(ByVal intCodigo As Integer)
        Dim strAux As Text.StringBuilder

        Try

            strAux = New StringBuilder
            strAux.Append("Default_Edit.aspx?")
            strAux.Append("Consultar=")
            strAux.Append(dgwDados.DataKeys(intCodigo).Value.ToString)

            Response.Redirect(strAux.ToString, False)


        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing
        End Try
    End Sub
    Protected Sub dgwDados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgwDados.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            'Quando o mouse passa sobre a linha da gridview, as mesma fica cinza.
            For idx As Integer = 0 To DirectCast(sender, GridView).Columns.Count - 2
                e.Row.Cells(idx).Attributes.Add("onclick", "__doPostBack('CONSULTAR', " & e.Row.RowIndex & ")")
                e.Row.Cells(idx).ToolTip = "Cosultar/Alterar"
            Next
            e.Row.Style("cursor") = "hand"
        End If
    End Sub
    Protected Sub dgwDados_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgwDados.RowDeleting
        Dim strAux As StringBuilder

        Try
            strAux = New StringBuilder




            strAux = New StringBuilder
            strAux.Append("Default_Edit.aspx?")
            strAux.Append("Excluir=")
            strAux.Append(dgwDados.DataKeys(e.RowIndex).Value.ToString)




            Response.Redirect(strAux.ToString, False)

        Catch ex As Exception

        Finally
            strAux = Nothing
        End Try
    End Sub
    Protected Sub PopulaDados(ByVal strWhere As String, ByVal blnShowState As Boolean, Optional ByVal strOrdem As String = "")
        Dim dsCliente As Data.DataSet
        Dim strAux As StringBuilder
        Try
            'Deixa a tela com apenas o UserSelect visível.

            dgwDados.Visible = False
            'pnlGrid.Visible = False



            clsbuRegulamentoBeneficios = New buCadastros.buRegulamentoBeneficio
            dsCliente = clsbuRegulamentoBeneficios.Consultar(strWhere, strOrdem)






            If dsCliente.Tables(0).Rows.Count > 0 Then


                dgwDados.Visible = True
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True

                If blnShowState Then

                    'Verifica a permissão do botão Excluir


                    lblTotalRegistros.Visible = True

                    'Mostra a quantidade de registros encontrados
                    strAux = New StringBuilder
                    strAux.Append("registros encontrados")
                    strAux.Append(": ")
                    strAux.Append(dsCliente.Tables(0).Rows.Count.ToString)
                    lblTotalRegistros.Text = strAux.ToString
                End If



                'Carrega o GridView
                With dgwDados
                    .DataSource = dsCliente
                    .DataBind()
                End With
            Else

                lblTotalRegistros.Visible = False
                ' dgwDados.Visible = False
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsCliente = Nothing
            clsbuRegulamentoBeneficios = Nothing
            strAux = Nothing
        End Try
    End Sub

    ''' <summary> Função que popula os dados referentes a nova página. </summary>
    ''' <remarks> Implementado em 22/07/2009 por Nill Pinheiro. </remarks>
    Protected Sub dgwDados_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgwDados.PageIndexChanged
        Dim strOrderBy As String
        Dim colColecao As Collection
        Try

            'Popula os dados da busca realizada para a referente página do GridView            
            PopulaDados(Session("WhereUtilizadoNaConsulta"), False)
        Catch ex As Exception
            Throw ex
        Finally
            strOrderBy = Nothing
            colColecao = Nothing
        End Try
    End Sub

    ''' <summary> Função que controla a paginação, mas não popula os dados. </summary>
    ''' <remarks> Implementado em 22/07/2009 por Nill Pinheiro. </remarks>
    Protected Sub dgwDados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgwDados.PageIndexChanging

        'Direciona para a próxima pagina.
        dgwDados.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Dim strWhere As String
        Try

            'Monta o Filtro da Tela
            strWhere = MontaFiltro()



            'Posiciona na primeira página do Grid
            dgwDados.PageIndex = 0

            'Chama o método para preencher o datagrid com os dados
            PopulaDados(strWhere, True)


            'Just to tests

            'Dim dsDataAux As Data.DataSet

            'dsDataAux = New Data.DataSet


            'dsDataAux.Tables.Add("RegulamentoBeneficio")

            'dsDataAux.Tables("RegulamentoBeneficio").Columns.Add("usCodigo", GetType(Integer))
            'dsDataAux.Tables("RegulamentoBeneficio").Columns.Add("usNome", GetType(String))
            'dsDataAux.Tables("RegulamentoBeneficio").Columns.Add("usLogin", GetType(String))

            'dsDataAux.Tables("RegulamentoBeneficio").Rows.Add()
            'dsDataAux.Tables("RegulamentoBeneficio").Rows.Add()
            'dsDataAux.Tables("RegulamentoBeneficio").Rows.Add()

            'dsDataAux.Tables("RegulamentoBeneficio").Rows(0)("usCodigo") = 1
            'dsDataAux.Tables("RegulamentoBeneficio").Rows(0)("usNome") = "Nill"
            'dsDataAux.Tables("RegulamentoBeneficio").Rows(0)("usLogin") = "nill.pinheiro"


            'dsDataAux.Tables("RegulamentoBeneficio").Rows(1)("usCodigo") = 1
            'dsDataAux.Tables("RegulamentoBeneficio").Rows(1)("usNome") = "Nill"
            'dsDataAux.Tables("RegulamentoBeneficio").Rows(1)("usLogin") = "nill.pinheiro"

            'dsDataAux.Tables("RegulamentoBeneficio").Rows(2)("usCodigo") = 1
            'dsDataAux.Tables("RegulamentoBeneficio").Rows(2)("usNome") = "Nill"
            'dsDataAux.Tables("RegulamentoBeneficio").Rows(2)("usLogin") = "nill.pinheiro"
            'dgwDados.DataSource = dsDataAux
            'dgwDados.DataBind()


            Session("WhereUtilizadoNaConsulta") = strWhere
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Dim strAux As StringBuilder
        Try



            strAux = New StringBuilder
            strAux.Append("Default_Edit.aspx?")
            strAux.Append("Incluir=True")

            Response.Redirect(strAux.ToString, False)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function MontaFiltro() As String
        Dim strWhere As Text.StringBuilder
        Dim blnIgual As Boolean = False
        Dim blnContem As Boolean = False
        Try
            strWhere = New Text.StringBuilder

            If cboEnumerdor.SelectedValue <> "todos" Then


                Select Case (cboOpcoes.SelectedValue)
                    Case "nome"
                        strWhere.Append("RegBeneDescricao ")
                    Case "Data"

                        If txtDataAte.Text <> String.Empty And txtDataDe.Text <> String.Empty Then

                            strWhere.Append("(RegBeneData >= ")
                            strWhere.Append(txtDataDe.Text)
                            strWhere.Append(" AND ")
                            strWhere.Append("RegBeneData <= ")
                            strWhere.Append(txtDataAte.Text).Append(")")

                        Else
                            If txtDataDe.Text <> String.Empty Then
                                strWhere.Append("RegBeneData >= ")
                                strWhere.Append(txtDataDe.Text)
                            End If

                            If txtDataAte.Text <> String.Empty Then
                                strWhere.Append("RegBeneData <= ")
                                strWhere.Append(txtDataAte.Text)
                            End If

                        End If
                End Select

                If cboOpcoes.SelectedValue <> "Data" Then


                    Select Case (cboEnumerdor.SelectedValue)
                        Case "igual"
                            strWhere.Append(" = '")
                            blnIgual = True
                        Case "contem"
                            strWhere.Append("like '%")
                            blnContem = True
                    End Select

                    strWhere.Append(Trim(txtOpcoes.Text))

                    If blnIgual Then
                        strWhere.Append("'")
                    ElseIf blnContem Then
                        strWhere.Append("%'")
                    End If
                Else
                    strWhere.Append("")

                End If


            End If

            MontaFiltro = strWhere.ToString

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub cboOpcoes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpcoes.SelectedIndexChanged
        If cboOpcoes.SelectedValue = "nome" Then
            tdOpcoes.Visible = True
            tdData.Visible = False
            cboEnumerdor.Enabled = True
        Else
            tdOpcoes.Visible = False
            tdData.Visible = True
            cboEnumerdor.SelectedValue = "igual"
            cboEnumerdor.Enabled = False
        End If
    End Sub
End Class
