<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_Ranking_Consultar_Default" %>



<%@ Register src="../../../UserControl/Ranking/wucConsultaRanking.ascx" tagname="wucConsultaRanking" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



    <uc1:wucConsultaRanking ID="wucConsultaRanking1" runat="server" />



</asp:Content>
