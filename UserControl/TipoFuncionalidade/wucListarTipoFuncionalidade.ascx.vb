﻿
Partial Class UserControl_TipoFuncionalidade_wucListarTipoFuncionalidade
    Inherits System.Web.UI.UserControl
    Dim clsbuTipoFuncionalidade As buSeguranca.buTipoFuncionalidade
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
                e.Row.Cells(idx).ToolTip = "Consultar/Alterar"
            Next
           
            e.Row.Style("cursor") = "hand"
        End If
    End Sub
    Protected Sub dgwDados_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgwDados.RowDeleting
        Dim strAux As StringBuilder
        Try

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


            clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade()
            dsCliente = clsbuTipoFuncionalidade.Consultar(strWhere, strOrdem)

            If dsCliente.Tables(0).Rows.Count > 0 Then


                dgwDados.Visible = True


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
                dgwDados.Visible = False

            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsCliente = Nothing
            clsbuTipoFuncionalidade = Nothing
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

    Private Function MontaFiltro() As String
        Dim strWhere As Text.StringBuilder
        Dim blnIgual As Boolean = False
        Dim blnContem As Boolean = False
        Try
            strWhere = New Text.StringBuilder

            If cboEnumerdor.SelectedValue <> "todos" Then


                Select Case (cboOpcoes.SelectedValue)
                    Case "nome"
                        strWhere.Append("Descricao ")
                End Select

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

            MontaFiltro = strWhere.ToString

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Dim strWhere As String
        Try

            'Monta o Filtro da Tela
            strWhere = MontaFiltro()



            'Posiciona na primeira página do Grid
            dgwDados.PageIndex = 0

            'Chama o método para preencher o datagrid com os dados
            PopulaDados(strWhere, True)

            'Metodo para deixar as colunas da grid com formatação de BackGround padrão.
            For idx As Integer = 0 To dgwDados.Columns.Count - 1
                dgwDados.Columns(idx).HeaderStyle.BackColor = Drawing.Color.Transparent
            Next

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
End Class
