
Partial Class UserControl_Home_wucHome
    Inherits System.Web.UI.UserControl
    Dim clsbuNoticias As buCadastros.buNoticias
    Dim clsbuElearning As buCadastros.buElearning
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            PopulaDados(" NotCodigo in(select top 10 NotCodigo from Noticias)", True)
            ePopulaDados(" eCodigo in(select top 10 eCodigo from Elearning)", True)

        Else
            'Tratamento de consulta da grid, fazendo com que o usuário possa clicar em qualquer local da linha desejada.
            If (Request("__EVENTTARGET").ToUpper = "CONSULTAR") And IsNumeric(Request("__EVENTARGUMENT")) Then
                dgwDados_Consultar(Request("__EVENTARGUMENT"))
            End If
            If (Request("__EVENTTARGET").ToUpper = "CONSULTAR") And IsNumeric(Request("__EVENTARGUMENT")) Then
                GVElearning_Consultar(Request("__EVENTARGUMENT"))
            End If
        End If
    End Sub


    ''' <summary>
    ''' Função que é utilizada para controlar a consulta da GridView.
    ''' </summary>
    Protected Sub dgwDados_Consultar(ByVal intCodigo As Integer)
        Dim strAux As Text.StringBuilder

        Try

            strAux = New StringBuilder
            strAux.Append("../Interfaces/ConsultaNoticias/Default_Edit.aspx?")
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
                e.Row.Cells(idx).ToolTip = "Cosultar"
            Next
            e.Row.Style("cursor") = "hand"
        End If
    End Sub

    Protected Sub PopulaDados(ByVal strWhere As String, ByVal blnShowState As Boolean, Optional ByVal strOrdem As String = "")
        Dim dsCliente As Data.DataSet
        Dim strAux As StringBuilder
        Try
            'Deixa a tela com apenas o UserSelect visível.

            dgwDados.Visible = False
            'pnlGrid.Visible = False

            clsbuNoticias = New buCadastros.buNoticias()
            dsCliente = clsbuNoticias.Consultar(strWhere, strOrdem)

            If dsCliente.Tables(0).Rows.Count > 0 Then


                dgwDados.Visible = True
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True

                If blnShowState Then


                    'Mostra a quantidade de registros encontrados
                    strAux = New StringBuilder
                    strAux.Append("registros encontrados")
                    strAux.Append(": ")
                    strAux.Append(dsCliente.Tables(0).Rows.Count.ToString)
                End If



                'Carrega o GridView
                With dgwDados
                    .DataSource = dsCliente
                    .DataBind()
                End With
            Else
                dgwDados.Visible = False
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsCliente = Nothing
            clsbuNoticias = Nothing
            strAux = Nothing
        End Try
    End Sub

    Protected Sub GVElearning_Consultar(ByVal intECodigo As Integer)
        Dim strAux As Text.StringBuilder

        Try

            strAux = New StringBuilder
            strAux.Append("../Interfaces/ConsultaElearning/Default_Edit.aspx?")
            strAux.Append("Consultar=")
            strAux.Append(GVElearning.DataKeys(intECodigo).Value.ToString)

            Response.Redirect(strAux.ToString, False)


        Catch ex As Exception
            Throw ex
        Finally
            strAux = Nothing
        End Try
    End Sub

    Protected Sub GVElearning_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GVElearning.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            'Quando o mouse passa sobre a linha da gridview, as mesma fica cinza.
            For idx As Integer = 0 To DirectCast(sender, GridView).Columns.Count - 2
                e.Row.Cells(idx).Attributes.Add("onclick", "__doPostBack('CONSULTAR', " & e.Row.RowIndex & ")")
                e.Row.Cells(idx).ToolTip = "Cosultar"
            Next
            e.Row.Style("cursor") = "hand"
        End If
    End Sub
    Protected Sub ePopulaDados(ByVal strWhere As String, ByVal blnShowState As Boolean, Optional ByVal strOrdem As String = "")
        Dim dsCliente As Data.DataSet
        Dim strAux As StringBuilder
        Try
            'Deixa a tela com apenas o UserSelect visível.

            GVElearning.Visible = False
            'pnlGrid.Visible = False

            clsbuElearning = New buCadastros.buElearning()
            dsCliente = clsbuElearning.Consultar(strWhere, strOrdem)

            If dsCliente.Tables(0).Rows.Count > 0 Then


                GVElearning.Visible = True
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True

                If blnShowState Then
                    'Mostra a quantidade de registros encontrados
                    strAux = New StringBuilder
                    strAux.Append("registros encontrados")
                    strAux.Append(": ")
                    strAux.Append(dsCliente.Tables(0).Rows.Count.ToString)
                End If

                'Carrega o GridView
                With GVElearning
                    .DataSource = dsCliente
                    .DataBind()
                End With
            Else
                GVElearning.Visible = False
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsCliente = Nothing
            clsbuElearning = Nothing
            strAux = Nothing
        End Try
    End Sub
End Class
