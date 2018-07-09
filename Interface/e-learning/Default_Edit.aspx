<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default_Edit.aspx.vb" Inherits="PortalReciclagem_Interfaces_Usuarios_Default_Edit" %>



<%@ Register src="../../UserControl/e-learning/wucCadastrarE-Learning.ascx" tagname="wucCadastrarE" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
   
    <uc1:wucCadastrarE ID="wucCadastrarE1" runat="server" />
   
</asp:Content>