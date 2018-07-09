<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default.aspx.vb" Inherits="PortalReciclagem_Interfaces_Usuarios_Default" %>

<%@ Register src="../../../UserControl/GruposXFuncionalidade/wucListarGruposXFuncionalidade.ascx" tagname="wucListarGruposXFuncionalidade" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <uc1:wucListarGruposXFuncionalidade ID="wucListarGruposXFuncionalidade1" 
        runat="server" />
</asp:Content>
