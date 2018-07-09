<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucConsultaNoticias.ascx.vb" Inherits="UserControl_ConsultarNoticias_wucConsultaNoticias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Upload/wucUpload.ascx" TagName="wucUpload" TagPrefix="uc1" %>
<%@ Register src="../ConsultaElearning/wucExibeVideo.ascx" tagname="wucExibeVideo" tagprefix="uc2" %>

<style type="text/css">
    .style1
    {
        width: 261px;
    }
    .style2
    {
        width: 334px;
    }
    .style3
    {
        width: 790px;
    }
</style>

<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Yellow" 
            style="text-align: center" Text="Consulta Notícias"></asp:Label>
    </p>
    <table id="TABLE1" width="100%" class="tabelaDescricao" 
        style="margin-top: auto; height: 100%;">
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:ImageButton ID="btnRetornar" runat="server" ImageUrl="~/Imagem/retornar.png" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                &nbsp;</td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                &nbsp;</td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 778px">
                    <tbody>
                        <tr>
                            <td class="style2">
                                <h1>
                                <asp:Literal ID="ltrNome" runat="server"></asp:Literal>
                                </h1>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Literal ID="ltrData" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                &nbsp;</td>
            <td style="vertical-align: middle; text-align: left">
                <table>
                    <tbody>
                        <tr>
                            <td class="style1">
                                <asp:Image ID="Image1" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                &nbsp;</td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 921px">
                    <tbody>
                        <tr>
                            <td class="style3">
                                <asp:Literal ID="ltrDescricao" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                &nbsp;</td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Ver Video" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</fieldset>
<div id="ModalMsg" style="display: none; text-align: center;">
    <h2>
        <asp:Label ID="lblAcao" runat="server" CssClass="texto"></asp:Label>
    </h2>
    <h3>
        <asp:Label ID="lblTextoAcao" runat="server" CssClass="texto"> </asp:Label>
    </h3>
    <br />
    <br />
    <asp:Button ID="btnACAO" OnClick="btnACAO_Click" SkinID="Pequeno" runat="server"
        Text="OK" />
</div>
<div id="ModalNotVideo" style="display: none; height: auto; width: auto; text-align: center;">
 
    <uc2:wucExibeVideo ID="wucExibeVideo1" runat="server" />

</div>
<div class="clear">
</div>