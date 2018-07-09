<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default_Edit.aspx.vb" MasterPageFile="~/Interfaces/MasterPage.master"
    Inherits="Interfaces_Beneficio_Default" %>

<%@ Register src="../../../UserControl/RegulametoBeneficio/wucCadastrarRegulamentoBeneficio.ascx" tagname="wucCadastrarRegulamentoBeneficio" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <uc1:wucCadastrarRegulamentoBeneficio ID="wucCadastrarRegulamentoBeneficio1" 
        runat="server" />
</asp:Content>
