<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucNavMenus.ascx.vb"
    Inherits="UserControl_Estrutura_Menus_wucNavMenus" %>
<%@ Register Src="wucNavMenusAux.ascx" TagName="wucNavMenusAux" TagPrefix="uc1" %>
<%--<ul class="NavMenus">
    <li class="Cadastros" title="Cadastros">
        <asp:HyperLink ID="HyperLink1" runat="server" Text="Cadastros" ToolTip="Cadastros">Cadastros</asp:HyperLink>
        <ul>
            <li class="Usuarios" title="Usuarios">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Interfaces/Usuarios/pessoa-fisica/Default.aspx"
                    ToolTip="Usuarios">Usuarios</asp:HyperLink>
            </li>
            <li class="Usuarios" title="Usuarios">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Interfaces/e-learning/Default.aspx"
                    ToolTip="Usuarios">E-Learning</asp:HyperLink>
            </li>
        </ul>
    </li>
</ul>--%>
<div class="ContainerBusca">
    <asp:ListView ID="lsvTipoFuncionalidade" runat="server" DataKeyNames="tipoFuncCodigo"
        GroupItemCount="1" OnItemDataBound="lsvTipoFuncionalidade_ItemDataBound">
        <LayoutTemplate>
            <ul id="groupPlaceholderContainer" class="NavMenus" runat="server">
                <div id="groupPlaceholder" runat="server">
                </div>
            </ul>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <div id="d1" runat="server">
                <strong>Nenhum registro encontrado.</strong>
            </div>
        </EmptyDataTemplate>
        <GroupTemplate>
            <li id="itemPlaceholderContainer" runat="server">
                <div id="itemPlaceholder" runat="server">
                </div>
            </li>
        </GroupTemplate>
        <ItemTemplate>
            <asp:LinkButton ID="btndetahes" Text='<%#Eval("descricao") %>' PostBackUrl='<%#Eval("url") %>'
                CommandName="Detalhes" runat="server" />
            <uc1:wucNavMenusAux ID="wucNavMenusAux1" runat="server" />
            <div class="Clear">
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
