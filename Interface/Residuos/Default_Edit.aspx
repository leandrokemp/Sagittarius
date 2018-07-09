<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default_Edit.aspx.vb" Inherits="Interfaces_Residuos_Default_Edit" %>


<%@ Register src="../../UserControl/Residuos/wucCadastrarResiduos.ascx" tagname="wucCadastrarResiduos" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



    <uc1:wucCadastrarResiduos ID="wucCadastrarResiduos1" runat="server" />



</asp:Content>
