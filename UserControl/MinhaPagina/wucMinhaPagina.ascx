<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucMinhaPagina.ascx.vb"
    Inherits="UserControl_MinhaPagina_wucMinhaPagina" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../LanceLeilao/wucListarLeilao.ascx" TagName="wucListarLeilao"
    TagPrefix="uc1" %>
<div>
    <h2>
        Dados Cadastrais</h2>
    Para edidar seus dados cadastrais
    <asp:LinkButton ID="btnAlterarDados" runat="server">Clique aqui</asp:LinkButton>
</div>
<br />
<br />
<div id="divEmpresaGeradora" runat="server">
    <h2>
        Veja de quais leilões sua empresa Criou</h2>
    <uc1:wucListarLeilao ID="wucListarLeilao1Geradora" runat="server" />
    <br />
    Para abrir um novo leilão basta clicar&nbsp;
    <asp:LinkButton runat="server" ID="btnIrLeilao">aqui</asp:LinkButton>
</div>
<div id="divEmpresaReceptora" runat="server">
    <h2>
        Veja de quais leilões sua empresa participou</h2>
    <uc1:wucListarLeilao ID="wucListarLeilao1Receptora" runat="server" />
    <br />
    Veja se existe algum leilão aberto e participe dele clicando&nbsp;
    <asp:LinkButton runat="server" ID="btnIrLance">Aqui</asp:LinkButton>
</div>
<div id="divEmpresaTerceira" runat="server">
    Para ver as requisições de sacos de coleta feitas pelos clientes
    <asp:HyperLink Text="Clique aqui" NavigateUrl="~/Interfaces/Requisicao/Default.aspx"
        runat="server"></asp:HyperLink>
</div>
<div id="divPopulaPessoafisica" runat="server">
    <h2>
        Solite novos sacos de coleta</h2>
    Para solicitar novos sacos para coleta
    <asp:LinkButton ID="btnSolicitarSacos" runat="server">Clique aqui</asp:LinkButton>
</div>
