<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default_Edit.aspx.vb" Inherits="PortalReciclagem_Interfaces_Usuarios_Default_Edit" %>

<%@ Register src="../../../UserControl/TipoFuncionalidade/wucCadastrarTipoFuncionalidadel.ascx" tagname="wucCadastrarTipoFuncionalidadel" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

    <uc1:wucCadastrarTipoFuncionalidadel ID="wucCadastrarTipoFuncionalidadel1" 
        runat="server" />

</asp:Content>
