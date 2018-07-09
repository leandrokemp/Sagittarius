<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default_Edit.aspx.vb" Inherits="Interfaces_Noticias_Default_Edit" %>

<%@ Register src="../../UserControl/Noticias/wucCadastrarNoticias.ascx" tagname="wucCadastrarNoticias" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
   
    
   
    <uc1:wucCadastrarNoticias ID="wucCadastrarNoticias1" runat="server" />
   
    
   
</asp:Content>