<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarLeilao.ascx.vb" Inherits="UserControl_ManterLeilão_WebUserControl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Upload/wucUpload.ascx" TagName="wucUpload" TagPrefix="uc1" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
    <p style="text-align: center">
        <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Yellow" 
            style="text-align: center" Text="Cadastrar Leilão"></asp:Label>
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
                <asp:Label ID="lblResíduo" runat="server" Width="120px" CssClass="texto" Text="Resíduo:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <asp:DropDownList ID="DropDownLeilao" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblQuantidade" runat="server" Width="120px" Text="Quantidade (Kg):"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtQuantidade" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvTxtQuantidade" runat="server"
                                    ErrorMessage="O campo Quantidade (Kg) é obrigatório" ControlToValidate="txtQuantidade"
                                    ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender2" TargetControlID="rfvTxtQuantidade" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                <asp:Label ID="lblDataInicial" runat="server" Width="120px" CssClass="texto" Text="Data de Início:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtDataInicial" tooltip="date" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="50" style="margin-top: 0px"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtDataInicial" runat="server"
                                    ErrorMessage="O campo Data de Início é obrigatório" ControlToValidate="txtDataInicial" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender3" TargetControlID="rfvtxtDataInicial" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblDataFinal" runat="server" Width="120px" Text="Encerramento:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtDataFinal" tooltip="date" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtDataFinal" runat="server"
                                    ErrorMessage="O campo Encerramento é obrigatório" ControlToValidate="txtDataFinal" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender1" TargetControlID="rfvtxtDataFinal" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblLanceInicial" runat="server" Width="120px" Text="Lance Inicial:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtLanceInicial" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtLanceInicial" runat="server"
                                    ErrorMessage="O campo Lance Incial é obrigatório" ControlToValidate="txtLanceInicial" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender4" TargetControlID="rfvtxtLanceInicial" runat="server">
                                </cc1:ValidatorCalloutExtender>
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