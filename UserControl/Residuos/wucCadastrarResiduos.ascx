<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarResiduos.ascx.vb"
    Inherits="UserControl_Residuos_WebUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
    <table id="TABLE1" width="100%" class="tabelaResiduo" style="margin-top: 4px">
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
                <asp:Label ID="lblNome" runat="server" Width="120px" CssClass="texto" Text="Nome:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtNome" TabIndex="3" runat="server" Width="245px" CssClass="TextoControles"
                                    MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtNome" runat="server"
                                    ErrorMessage="O campo Nome é obrigatório" ControlToValidate="txtNome" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="vceNome" TargetControlID="rfvtxtNome" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                Ponto KG</td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <asp:TextBox ID="txtPontoKG" runat="server" MaxLength="50" Width="71px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblHabilitado" runat="server" Width="120px" Text="Habilitado:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:CheckBox ID="txtHabilitado" runat="server" />
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
