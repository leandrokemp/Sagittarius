<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Logoff.aspx.vb" MasterPageFile="~/Interfaces/MasterPage.master"
    Inherits="PortalReciclagem_Interfaces_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <table style="background-color: White; height: 100%; width: 715px; text-align: center">
        <tr>
            <td colspan="3" style="background-image: url(Imagem/Layout/fundo_pags.jpg); background-repeat: no-repeat;
                background-position-y: top; background-position-x: right; height: 398px; vertical-align: top">
                <table width="100%" style="text-align: center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="vertical-align: top; font-size: xx-large">
                            <asp:Panel ID="pnlRegiao" runat="server">
                                Logoff Realizado com sussesso
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton1"  runat="server" 
                                PostBackUrl="~/PortalReciclagem/Interfaces/Default.aspx">Click aqui para retornar a pagina de Login</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
