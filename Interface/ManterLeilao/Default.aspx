<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_ManterLeilao_Default" %>

<%@ Register src="../../UserControl/ManterLeilão/wucListarLeilao.ascx" tagname="wucListarLeilao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

    

   

    <uc1:wucListarLeilao ID="wucListarLeilao1" runat="server" />

    

   

</asp:Content>