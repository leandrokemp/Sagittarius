<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_ConsultaNoticias_Default" %>


<%@ Register src="../../UserControl/ConsultarNoticias/wucListarNoticias.ascx" tagname="wucListarNoticias" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



       
    <uc1:wucListarNoticias ID="wucListarNoticias1" runat="server" />



       
</asp:Content>