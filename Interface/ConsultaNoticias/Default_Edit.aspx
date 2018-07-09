<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default_Edit.aspx.vb" Inherits="Interfaces_ConsultaNoticias_Default_Edit" %>



<%@ Register src="../../UserControl/ConsultarNoticias/wucConsultaNoticias.ascx" tagname="wucConsultaNoticias" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">




    <uc1:wucConsultaNoticias ID="wucConsultaNoticias1" runat="server" />




</asp:Content>