Imports FuncoesComuns.FuncoesComuns.MemberShips

Public Class UserControl_Estrutura_Menus_wucNavMenusAux
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Public Sub PopulaDados(ByVal TipoFamilia As Integer)

        Dim clsFuncionalidade As buSeguranca.buFuncionalidades
        Dim strWhere As StringBuilder = New StringBuilder

        strWhere.Append("TipoFuncCodigo= ").Append(TipoFamilia)
        clsFuncionalidade = New buSeguranca.buFuncionalidades
        lsvProdutosFamilia.DataSource = clsFuncionalidade.Consultar(strWhere.ToString())
        lsvProdutosFamilia.DataBind()
    End Sub





    Protected Sub lsvProdutosFamilia_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lsvProdutosFamilia.ItemCommand
        If e.CommandName = "Detalhes" Then

            Response.Redirect(e.CommandArgument.ToString)

        End If



    End Sub
End Class
