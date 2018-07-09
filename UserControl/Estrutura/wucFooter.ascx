<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucFooter.ascx.cs" Inherits="UserControls_Estrutura_wucFooter" %>
<div class="ConteudoFooter">
    <p>
        © Todos os direitos reservados</p>
    <ul class="RedesSociais">
        <li><span>Acompanhe:</span></li>
        <li class="Orkut">
            <asp:HyperLink runat="server" ToolTip="Orkut" NavigateUrl="#">Orkut</asp:HyperLink>
        </li>
        <li class="Facebook">
            <asp:HyperLink ID="HyperLink1" runat="server" ToolTip="Facebook" NavigateUrl="#">Facebook</asp:HyperLink>
        </li>
        <li class="Twitter">
            <asp:HyperLink ID="HyperLink2" runat="server" ToolTip="Twitter" NavigateUrl="#">Twitter</asp:HyperLink>
        </li>
    </ul>
</div>
