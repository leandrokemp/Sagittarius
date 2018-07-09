<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_ConsultaElearning_Default" %>

<%@ Register src="../../UserControl/ConsultaElearning/wucListarElearning.ascx" tagname="wucListarElearning" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



    <uc1:wucListarElearning ID="wucListarElearning1" runat="server" />



</asp:Content>