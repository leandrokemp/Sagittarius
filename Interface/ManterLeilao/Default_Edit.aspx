<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default_Edit.aspx.vb" Inherits="Interfaces_ManterLeilao_Default2" %>


<%@ Register src="../../UserControl/ManterLeilão/wucCadastrarLeilao.ascx" tagname="wucCadastrarLeilao" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

 

   

    <uc1:wucCadastrarLeilao ID="wucCadastrarLeilao1" runat="server" />

 

   

</asp:Content>