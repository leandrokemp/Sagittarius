Imports FuncoesComuns.FuncoesComuns.MemberShips

Partial Class UserControl_GruposXFuncionalidades_wucListarGruposXFuncionalidade
    Inherits System.Web.UI.UserControl

    Dim clsbuGrupos As buSeguranca.buGrupos
    Dim clsbuGruposxFuncionalidades As buSeguranca.buGruposxFuncionalidades
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            populacboGrupo()

        End If
    End Sub


   
    Protected Sub dgwDados_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgwDados.RowDeleting
        Dim strAux As StringBuilder
        Try

            strAux = New StringBuilder
            strAux.Append("Default_Edit.aspx?")
            strAux.Append("Excluir=")
            strAux.Append(dgwDados.DataKeys(e.RowIndex).Value.ToString)
            strAux.Append("&SelectedRoleExcluir='")
            strAux.Append(cboGrupos.SelectedValue).Append("'")

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


            clsbuGruposxFuncionalidades = New buSeguranca.buGruposxFuncionalidades()
            dsCliente = clsbuGruposxFuncionalidades.Consultar(strWhere, strOrdem)

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
            clsbuGruposxFuncionalidades = Nothing
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

            If cboGrupos.SelectedValue <> "-1" Then
                strWhere.Append("gxf.roleID = '")
                strWhere.Append(cboGrupos.SelectedValue).Append("'")
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


            If strWhere.ToString <> "" Then



                'Posiciona na primeira página do Grid
                dgwDados.PageIndex = 0

                'Chama o método para preencher o datagrid com os dados
                PopulaDados(strWhere, True)

                'Metodo para deixar as colunas da grid com formatação de BackGround padrão.
                For idx As Integer = 0 To dgwDados.Columns.Count - 1
                    dgwDados.Columns(idx).HeaderStyle.BackColor = Drawing.Color.Transparent
                Next

                Session("WhereUtilizadoNaConsulta") = strWhere
            Else
                MsgBox("Selecione um grupo", MsgBoxStyle.OkOnly, "AVISO")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        Dim strAux As StringBuilder
        Try

            If cboGrupos.SelectedValue <> "-1" Then

          

                strAux = New StringBuilder
                strAux.Append("Default_Edit.aspx?")
                strAux.Append("Incluir=True")
                strAux.Append("&SelectedRoleIncluir='")
                strAux.Append(cboGrupos.SelectedValue).Append("'")

                Response.Redirect(strAux.ToString, False)
            Else
                MsgBox("Selecione um grupo", MsgBoxStyle.OkOnly, "AVISO")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Função que popula a combo
    ''' </summary>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Public Sub populacboGrupo()
        Dim dsDados As Data.DataSet

        Try
            Dim clsMemberShipHelper As MemberShipHelper = New MemberShipHelper

            dsDados = clsMemberShipHelper.GetRolesAllInformation()






            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1
                cboGrupos.Items.Add(dsDados.Tables(0).Rows(i)("RoleName").ToString)
                cboGrupos.Items(i).Value = dsDados.Tables(0).Rows(i)("RoleId").ToString
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
