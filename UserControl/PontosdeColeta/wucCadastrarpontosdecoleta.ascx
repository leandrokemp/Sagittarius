<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarpontosdecoleta.ascx.vb"
    Inherits="UserControl_PontosdeColeta_WebUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Upload/wucUpload.ascx" TagName="wucUpload" TagPrefix="uc1" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<table id="TABLE1" width="100%" class="tabelaPontosdecoleta" style="margin-top: 4px">
    <tr>
        <td>
        </td>
        <td align="left">
            <asp:ImageButton ID="btnRetornar" runat="server" ImageUrl="~/Imagem/retornar.png" />
            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/Imagem/alterar.png" Visible="False" />
            <asp:ImageButton ID="btnConfirmar" runat="server" ImageUrl="~/Imagem/confirmar.png"
                Visible="False" ValidationGroup="Cadastro" />
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right">
            <asp:Label ID="lblDescricao" runat="server" Width="120px" Text="Descrição:"></asp:Label>
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDescricao" TextMode="MultiLine" TabIndex="5" Height="95px" runat="server"
                                Width="170px" CssClass="TextoControles" MaxLength="250"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtDescricao" runat="server"
                                ErrorMessage="O campo Latitude é obrigatório" ControlToValidate="txtDescricao"
                                ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="ValidatorCalloutExtender1" TargetControlID="rfvtxtDescricao" runat="server">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right">
            <asp:Label ID="lblLatitude" runat="server" Width="120px" Text="Latitude:"></asp:Label>
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLatitude" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvTxtLatitude" runat="server"
                                ErrorMessage="O campo Latitude é obrigatório" ControlToValidate="txtLatitude"
                                ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="ValidatorCalloutExtender2" TargetControlID="rfvTxtLatitude" runat="server">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: super; height: 2px; text-align: right">
            <asp:Label ID="lblLongitude" runat="server" Width="120px" CssClass="texto" Text="Longitude:">
            </asp:Label>
        </td>
        <td style="vertical-align: middle; height: 2px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLongitude" TabIndex="3" runat="server" Width="245px" CssClass="TextoControles"
                                MaxLength="30"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtLongitude" runat="server"
                                ErrorMessage="O campo Longitude é obrigatório" ControlToValidate="txtLongitude"
                                ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="ValidatorCalloutExtender5" TargetControlID="rfvtxtLongitude" runat="server">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right">
            <asp:Label ID="lblImagem" runat="server" Width="120px" Text="Imagem:"></asp:Label>
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <uc1:wucUpload ID="wucUpload1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
</table>
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
