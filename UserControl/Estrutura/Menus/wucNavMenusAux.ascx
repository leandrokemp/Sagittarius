<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucNavMenusAux.ascx.vb"
    Inherits="UserControl_Estrutura_Menus_wucNavMenusAux" %>
<asp:ListView ID="lsvProdutosFamilia" runat="server" DataKeyNames="FuncCodigo" GroupItemCount="1"
    OnItemCommand="lsvProdutosFamilia_ItemCommand">
    <LayoutTemplate>
        <ul id="groupPlaceholderContainer" runat="server">
            <div id="groupPlaceholder" runat="server">
            </div>
        </ul>
    </LayoutTemplate>
    <GroupTemplate>
        <li class="Usuarios" id="itemPlaceholderContainer" runat="server">
            <div id="itemPlaceholder" runat="server">
            </div>
        </li>
    </GroupTemplate>
    <ItemTemplate>
        <asp:LinkButton ID="btndetahes" Text='<%#Eval("FuncNome") %>' CommandName="Detalhes"
            CommandArgument='<%# Eval("funcUrl") %>' runat="server" />
    </ItemTemplate>
</asp:ListView>
