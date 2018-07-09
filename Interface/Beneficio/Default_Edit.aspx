<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default_Edit.aspx.vb" MasterPageFile="~/Interfaces/MasterPage.master" Inherits="Interfaces_Beneficio_Default" %>


<%@ Register src="../../UserControl/Beneficio/wucListarBeneficio.ascx" tagname="WebListarBeneficio" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <uc2:WebListarBeneficio ID="WebListarBeneficio1" runat="server" />
</asp:Content>