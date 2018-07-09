<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default_Edit.aspx.vb" Inherits="Interfaces_Ranking_Default_Edit" %>


<%@ Register src="../../UserControl/Ranking/wucCadastrarRanking.ascx" tagname="wucCadastrarRanking" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



    <uc1:wucCadastrarRanking ID="wucCadastrarRanking1" runat="server" />



</asp:Content>