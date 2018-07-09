<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarRequisicao.ascx.vb"
    Inherits="UserControl_RequisitarSacos_wucRequisitarSacos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Upload/wucUpload.ascx" TagName="wucUpload" TagPrefix="uc1" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Yellow" Style="text-align: center"
            Text="Solicitar Sacos Plásticos"></asp:Label>
    </p>
    <table id="TABLE1" width="100%" class="tabelaDescricao" style="margin-top: 4px">
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
            <td style="vertical-align: super; height: 2px; text-align: right">
                <asp:Label ID="lblQuantidade" runat="server" Width="120px" CssClass="texto" Text="Quantidade (unid):">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtQuantidade" TabIndex="3" runat="server" Width="147px" CssClass="TextoControles"
                                    MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtQuantidade" runat="server"
                                    ErrorMessage="O campo Quantidade é obrigatório" ControlToValidate="txtQuantidade"
                                    ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="vcePasswor" TargetControlID="rfvtxtQuantidade" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblData" runat="server" Width="120px" Text="Data:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 153px">
                    <tbody>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="lblData1" runat="server" Text="Data Sistema"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                &nbsp;
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
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
