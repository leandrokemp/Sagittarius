<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_Login_Default" %>

<%@ Register src="../../UserControl/Login/wucLogin.ascx" tagname="wucLogin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">


    <uc1:wucLogin ID="wucLogin1" runat="server" />


</asp:Content>
