<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarE-Learning.ascx.vb"
    Inherits="UserControl_e_learning_wucCadastrarE_Learning" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Upload/wucUpload.ascx" TagName="wucUpload" TagPrefix="uc1" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
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
                                    ID="vcePasswor" TargetControlID="rfvtxtNome" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblDescricao" runat="server" Width="120px" Text="Descricao:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtDescricao" TabIndex="5" runat="server" Width="640px" CssClass="TextoControles"
                                    MaxLength="1000" Height="284px" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvTxtDescricao" runat="server"
                                    ErrorMessage="O campo Descricao é obrigatório" ControlToValidate="txtDescricao"
                                    ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender2" TargetControlID="rfvTxtDescricao" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: super; height: 2px; text-align: right">
                <asp:Label ID="lblVideo" runat="server" Width="120px" CssClass="texto" Text="Video:">
                </asp:Label>
            </td>
            <td style="vertical-align: middle; height: 2px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtVideo" TabIndex="3" runat="server" Width="453px" CssClass="TextoControles"
                                    MaxLength="100"></asp:TextBox>
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
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtData" ToolTip="date" TabIndex="5" runat="server" Width="114px" CssClass="TextoControles"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtData" runat="server"
                                    ErrorMessage="O campo Data é obrigatório" ControlToValidate="txtData" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender1" TargetControlID="rfvtxtData" runat="server">
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
