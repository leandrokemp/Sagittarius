<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_Residuos_Default" %>


<%@ Register src="../../UserControl/Residuos/wucListarResiduos.ascx" tagname="wucListarResiduos" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



    <uc1:wucListarResiduos ID="wucListarResiduos1" runat="server" />



</asp:Content>