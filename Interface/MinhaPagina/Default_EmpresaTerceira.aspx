<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default_EmpresaTerceira.aspx.vb" Inherits="Interfaces_MinhaPagina_Default_EmpresaTerceira" %>

<%@ Register Src="../../UserControl/MinhaPagina/wucMinhaPagina.ascx" TagName="wucMinhaPagina"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <uc1:wucMinhaPagina ID="wucMinhaPagina1" Tipo="EmpresaTerceira" runat="server" />
</asp:Content>
