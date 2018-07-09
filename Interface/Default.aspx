<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_Default" %>


<%@ Register src="../UserControl/Home/wucHome.ascx" tagname="wucHome" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

  

    <uc1:wucHome ID="wucHome1" runat="server" />

  

</asp:Content>