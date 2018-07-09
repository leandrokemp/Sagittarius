<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_Usuarios_Aprovar_Default" %>

<%@ Register src="../../../UserControl/Aprovar/wucListarUsuario.ascx" tagname="wucListarUsuario" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
   
    <uc1:wucListarUsuario ID="wucListarUsuario1" runat="server" />
   
</asp:Content>
