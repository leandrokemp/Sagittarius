<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_ConsultaResiduos_Default" %>

<%@ Register src="../../UserControl/ConsultaResiduos/wucListarResiduos.ascx" tagname="wucListarResiduos" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">


    <uc2:wucListarResiduos ID="wucListarResiduos1" runat="server" />


</asp:Content>