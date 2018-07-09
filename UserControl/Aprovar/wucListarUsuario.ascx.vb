Imports FuncoesComuns.FuncoesComuns.MemberShips


Partial Class PortalReciclagem_UserControl_Aprovar_wucListarUsuario
    Inherits System.Web.UI.UserControl
    Dim clsbuUsuarioss As buSeguranca.buUsuarios
    Private clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            PopulaDados("", True)


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






            If strWhere <> "" Then

                strWhere = strWhere & " and isApproved=0 And ar.Roleid in('" & ConfigurationSettings.AppSettings("ROLE_EMPRESADOADORA").ToString & "','" & ConfigurationSettings.AppSettings("ROLE_RECEPTORA").ToString & "','" & ConfigurationSettings.AppSettings("ROLE_RECEPTORA").ToString & "')"

            Else

                strWhere = strWhere & " isApproved=0 And ar.RoleName in('" & ConfigurationSettings.AppSettings("ROLE_EMPRESADOADORA").ToString & "','" & ConfigurationSettings.AppSettings("ROLE_RECEPTORA").ToString & "','" & ConfigurationSettings.AppSettings("ROLE_RECEPTORA").ToString & "')"

            End If


            strOrdem = "  case when amp.IsApproved = 1 then 1 when amp.IsApproved = 0 then 2 else 0 end "

            clsbuUsuarioss = New buSeguranca.buUsuarios()
            dsCliente = clsbuUsuarioss.Consultar(strWhere, strOrdem)






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
            clsbuUsuarioss = Nothing
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
                        strWhere.Append("usNome ")

                End Select

                Select Case (cboEnumerdor.SelectedValue)
                    Case "igual"
                        strWhere.Append(" = '")
                        blnIgual = True
                    Case "contem"
                        strWhere.Append("like '%")
                        blnContem = True
                End Select



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


            'Just to tests

            'Dim dsDataAux As Data.DataSet

            'dsDataAux = New Data.DataSet


            'dsDataAux.Tables.Add("Usuarios")

            'dsDataAux.Tables("Usuarios").Columns.Add("usCodigo", GetType(Integer))
            'dsDataAux.Tables("Usuarios").Columns.Add("usNome", GetType(String))
            'dsDataAux.Tables("Usuarios").Columns.Add("usLogin", GetType(String))

            'dsDataAux.Tables("Usuarios").Rows.Add()
            'dsDataAux.Tables("Usuarios").Rows.Add()
            'dsDataAux.Tables("Usuarios").Rows.Add()

            'dsDataAux.Tables("Usuarios").Rows(0)("usCodigo") = 1
            'dsDataAux.Tables("Usuarios").Rows(0)("usNome") = "Nill"
            'dsDataAux.Tables("Usuarios").Rows(0)("usLogin") = "nill.pinheiro"


            'dsDataAux.Tables("Usuarios").Rows(1)("usCodigo") = 1
            'dsDataAux.Tables("Usuarios").Rows(1)("usNome") = "Nill"
            'dsDataAux.Tables("Usuarios").Rows(1)("usLogin") = "nill.pinheiro"

            'dsDataAux.Tables("Usuarios").Rows(2)("usCodigo") = 1
            'dsDataAux.Tables("Usuarios").Rows(2)("usNome") = "Nill"
            'dsDataAux.Tables("Usuarios").Rows(2)("usLogin") = "nill.pinheiro"
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

    Protected Sub cboOpcoes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpcoes.SelectedIndexChanged
        If cboOpcoes.SelectedValue.Equals("Grupo") Then
            txtOpcoes.Visible = False
            cboEnumerdor.Enabled = False
            cboEnumerdor.SelectedValue = "igual"
            cboGrupos.Visible = True

        Else

            txtOpcoes.Visible = True
            cboEnumerdor.Enabled = True
            cboGrupos.Visible = False


        End If


    End Sub

    ''' <summary>
    ''' Não USADO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Protected Sub chkAprovado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chkAprovar As CheckBox = CType(sender, CheckBox)
        Dim gvLinha As GridViewRow = CType(chkAprovar.NamingContainer, GridViewRow)
        Dim lblID As Label = CType(gvLinha.FindControl("lblID"), Label)

        clsbuUsuarioss = New buSeguranca.buUsuarios()

        Dim user As MembershipUser = Membership.GetUser(clsbuUsuarioss.Consultar(" u.usCodigo = " & lblID.Text).Tables(0).Rows(0)("usLogin").ToString)

        user.IsApproved = chkAprovar.Checked


        Membership.UpdateUser(user)


        lblAcao.Text = "Alteração"
        lblTextoAcao.Text = "Registro Alterado com Sucesso"

        clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
        clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)
        PopulaDados("", True)


    End Sub

    Protected Sub dgwDados_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles dgwDados.RowCommand

        If e.CommandName.Equals("Aprovar") Then


            Dim clsMemberShip As New FuncoesComuns.FuncoesComuns.MemberShips.MemberShipHelper

            clsMemberShip.UpdateIsApproved(True, e.CommandArgument.ToString)

            lblAcao.Text = "Aprovado"
            lblTextoAcao.Text = "A Empresa foi aprovada com Sucesso"

            clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
            clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px');", False)
            PopulaDados("", True)

        End If


    End Sub
End Class
