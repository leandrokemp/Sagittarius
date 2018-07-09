<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" MasterPageFile="~/Interfaces/MasterPage.master"
    Inherits="Interfaces_Pontos_de_Coleta_Default" %>



<%@ Register src="../../UserControl/PontosdeColeta/wucListarpontosdecoleta.ascx" tagname="wucListarpontosdecoleta" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    
    <uc1:wucListarpontosdecoleta ID="wucListarpontosdecoleta1" runat="server" />
    
</asp:Content>
