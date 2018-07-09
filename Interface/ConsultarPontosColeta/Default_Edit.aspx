<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default_Edit.aspx.vb" Inherits="Interfaces_Pontos_de_Coleta_Default2" %>

<%@ Register Src="../../UserControl/PontosdeColeta/wucCadastrarpontosdecoleta.ascx"
    TagName="wucCadastrarpontosdecoleta" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <uc1:wucCadastrarpontosdecoleta ID="wucCadastrarpontosdecoleta1" runat="server" />
</asp:Content>
