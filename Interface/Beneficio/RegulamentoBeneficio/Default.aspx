<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" MasterPageFile="~/Interfaces/MasterPage.master" Inherits="Interfaces_Beneficio_Default2" %>








<%@ Register src="../../../UserControl/RegulametoBeneficio/wucListarRegulamentoBeneficiol.ascx" tagname="wucListarRegulamentoBeneficiol" tagprefix="uc1" %>








<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    
    <uc1:wucListarRegulamentoBeneficiol ID="wucListarRegulamentoBeneficiol1" 
        runat="server" />
    
    </asp:Content>