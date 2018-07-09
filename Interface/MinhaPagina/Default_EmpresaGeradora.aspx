<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Interfaces/MasterPage.master"
    CodeFile="Default_EmpresaGeradora.aspx.vb" Inherits="Interfaces_MinhaPagina_Default_EmpresaGeradora" %>
<%@ Register src="../../UserControl/MinhaPagina/wucMinhaPagina.ascx" tagname="wucMinhaPagina" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <uc1:wucMinhaPagina ID="wucMinhaPagina1" Tipo="EmpresaGeradora" runat="server" />
</asp:Content>
