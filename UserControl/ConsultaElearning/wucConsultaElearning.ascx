<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucConsultaElearning.ascx.vb"
    Inherits="UserControl_ConsultaElearning_wucConsultaElearning" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Upload/wucUpload.ascx" TagName="wucUpload" TagPrefix="uc1" %>
<%@ Register Src="wucExibeVideo.ascx" TagName="wucExibeVideo" TagPrefix="uc2" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
    <table id="TABLE1" width="100%" class="tabelaDescricao" style="margin-top: 4px; height: 177px;">
        <tr>
            <td class="style1">
            </td>
            <td align="left" class="style1">
                <asp:ImageButton ID="btnRetornar" runat="server" ImageUrl="~/Imagem/retornar.png" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; text-align: right" class="style2">
            </td>
            <td style="vertical-align: middle; text-align: left" class="style2">
                <h1>
                    <asp:Literal ID="ltrNome" runat="server"></asp:Literal>
                </h1>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                &nbsp;
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <asp:Literal ID="ltrData" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                &nbsp;
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <asp:Image ID="Image1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                &nbsp;
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <asp:Literal ID="ltrDescricao" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                &nbsp;
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <asp:Button ID="Button1" runat="server" Text="Ver Video" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</fieldset>
<div id="ModalMsg" style="display: none; text-align: center;">
    <!--<object width="560" height="340"><param name="movie" value="http://www.youtube.com/v/7AnN_g_EI0k?fs=1&amp;hl=pt_BR&amp;color1=0x2b405b&amp;color2=0x6b8ab6"></param><param name="allowFullScreen" value="true"></param><param name="allowscriptaccess" value="always"></param><embed src="http://www.youtube.com/v/7AnN_g_EI0k?fs=1&amp;hl=pt_BR&amp;color1=0x2b405b&amp;color2=0x6b8ab6" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="560" height="340"></embed></object>-->
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
<div id="ModalVideo" style="display: none; height: auto; width: auto; text-align: center;">
    <uc2:wucExibeVideo ID="wucExibeVideo1" runat="server" />
</div>
