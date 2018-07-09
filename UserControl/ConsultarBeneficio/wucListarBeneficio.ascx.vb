
Partial Class UserControl_ConsultarBeneficio_WebUserControl
    Inherits System.Web.UI.UserControl
    Dim clsbuRegulamentoBeneficios As buCadastros.buRegulamentoBeneficio

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
   


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulaDados("", True)
        End If
    End Sub
End Class
