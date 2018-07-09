<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master" CodeFile="Default.aspx.vb" Inherits="Interfaces_RegistrarPesoResiduo_Default" %>


<%@ Register src="../../UserControl/RegistrarPeso/wucRegistraPeso.ascx" tagname="wucRegistraPeso" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

   

    <uc1:wucRegistraPeso ID="wucRegistraPeso1" runat="server" />

   

</asp:Content>
