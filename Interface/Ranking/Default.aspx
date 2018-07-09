<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_Ranking_Default" %>

<%@ Register src="../../UserControl/Ranking/wucListarRanking.ascx" tagname="wucListarRanking" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

    <uc1:wucListarRanking ID="wucListarRanking1" runat="server" />

</asp:Content>