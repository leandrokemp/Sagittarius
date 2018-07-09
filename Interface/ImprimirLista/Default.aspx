<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_ImprimirLista_Default" %>

<%@ Register src="../../UserControl/ImprimirLista/wucListarRequisicao.ascx" tagname="wucListarRequisicao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

   
   

    <uc1:wucListarRequisicao ID="wucListarRequisicao1" runat="server" />

   
   

</asp:Content>