<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" MasterPageFile="~/Interfaces/MasterPage.master" Inherits="Interfaces_ConsultarBeneficio_Default" %>


<%@ Register src="../../UserControl/ConsultarBeneficio/wucListarBeneficio.ascx" tagname="wucListarBeneficio" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



    <uc1:wucListarBeneficio ID="wucListarBeneficio1" runat="server" />



</asp:Content>