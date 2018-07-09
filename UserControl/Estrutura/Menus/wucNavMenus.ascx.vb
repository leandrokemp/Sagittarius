Imports FuncoesComuns.FuncoesComuns.MemberShips
Imports System.Configuration
Partial Class UserControl_Estrutura_Menus_wucNavMenus
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub populaMenus()
        Dim strWhere As StringBuilder = New StringBuilder
        Dim clsUsuarioHelper As UsuariosHelper
        Dim clsFuncionalidades As buSeguranca.buTipoFuncionalidade
        Dim blnIsAdm As Boolean = False
        clsUsuarioHelper = New UsuariosHelper


        Dim user As MembershipUser = Membership.GetUser()


        If user IsNot Nothing Then

            Dim clsMemberShip As MemberShipHelper
            clsMemberShip = New MemberShipHelper

            For Each drAux As Data.DataRow In clsMemberShip.GetRolesJustName(user.UserName).Tables(0).Rows

                If drAux("RoleName").ToString().Equals(ConfigurationSettings.AppSettings("ROLE_ADMINISTRADOR").ToString) Then

                    blnIsAdm = True

                End If
            Next


            If blnIsAdm Then
                clsFuncionalidades = New buSeguranca.buTipoFuncionalidade
                lsvTipoFuncionalidade.DataSource = clsFuncionalidades.Consultar()
                lsvTipoFuncionalidade.DataBind()

            Else
                MontaMenusAux(strWhere.Append("u.Userid = '").Append(clsUsuarioHelper.RetornaUsuarioLogado().Tables(0).Rows(0)("userId").ToString()).Append("'").ToString())

            End If
        Else
            MontaMenusAux(strWhere.Append("ar.RoleName = '").Append(ConfigurationSettings.AppSettings("ROLE_USUARIOANONIMO").ToString).Append("'").ToString)
        End If




    End Sub
    Public Sub MontaMenusAux(ByVal strWhere As String)

        Dim clsFuncionalidades As buSeguranca.buTipoFuncionalidade
        Dim clsMemberShipHelper As MemberShipHelper


        Dim strWhereAux As StringBuilder = New StringBuilder
        Dim strWherAux2 As StringBuilder = New StringBuilder

        clsMemberShipHelper = New MemberShipHelper

        strWhereAux.Append("Roleid in('")
        For Each dr As Data.DataRow In clsMemberShipHelper.GetRolesAllInformation(strWhere.ToString()).Tables(0).Rows
            strWhereAux.Append(dr("Roleid").ToString()).Append("',")
        Next

        strWherAux2.Append(strWhereAux.ToString().Substring(0, strWhereAux.Length - 1)).Append(")")
        clsFuncionalidades = New buSeguranca.buTipoFuncionalidade
        lsvTipoFuncionalidade.DataSource = clsFuncionalidades.Consultar(strWherAux2.ToString())
        lsvTipoFuncionalidade.DataBind()



    End Sub
    Protected Sub lsvTipoFuncionalidade_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lsvTipoFuncionalidade.ItemDataBound
        If (e.Item.ItemType = ListViewItemType.DataItem) Then


            Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)

            Dim dsDataRow As Data.DataRowView = CType(dataItem.DataItem, Data.DataRowView)
            Dim uc As UserControl_Estrutura_Menus_wucNavMenusAux = CType(e.Item.FindControl("wucNavMenusAux1"), UserControl_Estrutura_Menus_wucNavMenusAux)
            uc.PopulaDados(CType(dsDataRow("TipoFuncCodigo"), Integer))
        End If
    End Sub




End Class
