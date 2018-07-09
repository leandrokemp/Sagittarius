<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarUsuario.ascx.vb"
    Inherits="PortalReciclagem_UserControl_Aprovar_wucListarUsuario" %>
<table>
    <tr>
        <td>
            <asp:DropDownList ID="cboOpcoes" runat="server" Width="110px" AutoPostBack="True">
                <asp:ListItem Value="nome">Nome</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="cboEnumerdor" runat="server" Width="100px">
                <asp:ListItem Value="todos">Todos</asp:ListItem>
                <asp:ListItem>igual</asp:ListItem>
                <asp:ListItem Value="contem">Contem</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:TextBox ID="txtOpcoes" runat="server" Width="132px"></asp:TextBox>
            <asp:DropDownList ID="cboGrupos" runat="server" Visible="False">
            </asp:DropDownList>
        </td>
        <td>
            <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Imagem/ok.png" />
        </td>
    </tr>
</table>
<asp:Panel ID="pnlbtnNOvo" Style="text-align: left" runat="server">
    <asp:ImageButton ID="btnNovo" runat="server" ImageUrl="~/Imagem/novo.png" />
</asp:Panel>
<br />
<%--    <asp:Panel ID="pnlGrid" runat="server" ScrollBars="Horizontal" Style="vertical-align: top;
                                            text-align: center" Visible="true" Width="665px" Direction="LeftToRight">--%>
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="usCODIGO" PageSize="20" EmptyDataText="Nenhum registro encontrado"
    Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="usNome" HeaderText="Nome">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="usLogin" HeaderText="Login" />
        <asp:BoundField DataField="RoleName" HeaderText="Grupo" />
        <asp:TemplateField>
        <ItemTemplate>
        <asp:LinkButton runat="server" ID="btnAprovar" CommandArgument='<%# Eval("usLogin") %>' CommandName="Aprovar">Aprovar</asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<%--     </asp:Panel>--%>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>
<div id="ModalMsg" style="display: none; text-align: center;">
    <h2>
        <asp:Label ID="lblAcao" runat="server" CssClass="texto"></asp:Label>
    </h2>
    <h3>
        <asp:Label ID="lblTextoAcao" runat="server" CssClass="texto"> </asp:Label>
    </h3>
    <br />
    <br />
    <asp:Button ID="btnACAO" SkinID="Pequeno" runat="server" Text="OK" />
</div>
