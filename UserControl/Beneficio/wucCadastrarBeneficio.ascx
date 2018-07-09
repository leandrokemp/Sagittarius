<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarBeneficio.ascx.vb" Inherits="UserControl_Beneficio_WebUserControl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
    <table id="TABLE1" width="100%" class="tabelatipo_residuo" style="margin-top: 4px">
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
                <asp:Label ID="lblGrupo" runat="server" Width="120px" CssClass="texto" Text="Grupo:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td style="width: 260px">
                                <asp:RadioButtonList ID="rblRoles" runat="server">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                <asp:Label ID="lbltipo_usuario" runat="server" Width="120px" CssClass="texto" Text="tipo_usuario:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txttipo_usuario" TabIndex="3" runat="server" Width="245px" CssClass="TextoControles"
                                    MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxttipo_usuario" runat="server"
                                    ErrorMessage="O campo tipo_usuario é obrigatório" ControlToValidate="txttipo_usuario" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="vcePasswor" TargetControlID="rfvtxttipo_usuario" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lbltipo_residuo" runat="server" Width="120px" Text="tipo_residuo:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txttipo_residuo" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvTxttipo_residuo" runat="server"
                                    ErrorMessage="O campo tipo_residuo é obrigatório" ControlToValidate="txttipo_residuo" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender2" TargetControlID="rfvTxttipo_residuo" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                <asp:Label ID="lbldescricao_residuo" runat="server" Width="120px" CssClass="texto" Text="E-Mail:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtdescricao_residuo" TabIndex="3" runat="server" Width="245px" CssClass="TextoControles"
                                    MaxLength="30"></asp:TextBox>
                                <asp:RegularExpressionValidator ControlToValidate="txtdescricao_residuo" ID="revdescricao_residuo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    runat="server" ErrorMessage="Digite um e-mail valido">*</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtdescricao_residuo" runat="server"
                                    ErrorMessage="O campo E-Mail é obrigatório" ControlToValidate="txtdescricao_residuo" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender5" TargetControlID="rfvtxtdescricao_residuo" runat="server">
                                </cc1:ValidatorCalloutExtender>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="vcedescricao_residuo" TargetControlID="revdescricao_residuo" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblEndereco" runat="server" Width="120px" Text="Endereço:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEndereco" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtEndereco" runat="server"
                                    ErrorMessage="O campo Endereco é obrigatório" ControlToValidate="txtEndereco"
                                    ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender1" TargetControlID="rfvtxtEndereco" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
    <table id="tbchkSenha" runat="server">
        <tr>
            <td style="vertical-align: super; height: 2px;" colspan="2">
                <asp:CheckBox ID="chkAlterarSenha" AutoPostBack="true" Text="Alterar Senha" runat="server" />
            </td>
        </tr>
    </table>
    <table id="tbSenha" runat="server" visible="false">
        <tr>
            <td style="vertical-align: middle; height: 8px; text-align: right">
                <asp:Label ID="lblSenha" runat="server" Width="120px" CssClass="texto" Text="Senha:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtSenha" TabIndex="6" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="20" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtSenha" runat="server" ErrorMessage="O campo Senha é obrigatório"
                                    ControlToValidate="txtSenha" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender3" TargetControlID="rfvtxtSenha" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblConfirmaSenha" runat="server" Width="120px" CssClass="texto" Text="Confirma Senha:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtConfirmaSenha" TabIndex="7" runat="server" Width="170px" CssClass="TextoControles"
                                    MaxLength="20" Enabled="True" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtConfirmaSenha" runat="server" ErrorMessage="O campo Confirmar Senha é obrigatório"
                                    ControlToValidate="txtConfirmaSenha" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender4" TargetControlID="rfvtxtConfirmaSenha" runat="server">
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
