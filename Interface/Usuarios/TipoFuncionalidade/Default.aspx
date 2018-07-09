<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default.aspx.vb" Inherits="PortalReciclagem_Interfaces_Usuarios_Default" %>


<%@ Register src="../../../UserControl/TipoFuncionalidade/wucListarTipoFuncionalidade.ascx" tagname="wucListarTipoFuncionalidade" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    
    <uc1:wucListarTipoFuncionalidade ID="wucListarTipoFuncionalidade1" 
        runat="server" />
    
</asp:Content>
