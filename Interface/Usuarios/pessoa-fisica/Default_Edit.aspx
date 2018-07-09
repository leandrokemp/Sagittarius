<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default_Edit.aspx.vb" Inherits="PortalReciclagem_Interfaces_Usuarios_Default_Edit" %>

<%@ Register Src="../../../UserControl/Usuarios/pessoa-fisica/wucCadastrarUsuarios.ascx"
    TagName="wucCadastrarUsuarios" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <uc1:wucCadastrarUsuarios ID="wucCadastrarUsuarios1" runat="server" />
</asp:Content>
