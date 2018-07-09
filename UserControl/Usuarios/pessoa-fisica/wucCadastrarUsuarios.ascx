<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarUsuarios.ascx.vb"
    Inherits="PortalReciclagem_UserControl_Usuarios_wucCadastrarUsuarios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<asp:ValidationSummary ID="vmCadastro" ValidationGroup="Cadastro" runat="server" />--%>
<table id="TABLE1" width="100%" class="tabelaLogin" style="margin-top: 4px">
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
                            <asp:RadioButtonList ID="rblRoles" runat="server" AutoPostBack="True">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </tbody>
            </table>
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
            <asp:Label ID="lblLogin" runat="server" Width="120px" Text="Login:"></asp:Label>
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLogin" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvTxtLogin" runat="server"
                                ErrorMessage="O campo Login é obrigatório" ControlToValidate="txtLogin" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="ValidatorCalloutExtender2" TargetControlID="rfvTxtLogin" runat="server">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: super; height: 2px; text-align: right">
            <asp:Label ID="lblEmail" runat="server" Width="120px" CssClass="texto" Text="E-Mail:">
            </asp:Label>
        </td>
        <td style="vertical-align: middle; height: 2px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtEmail" TabIndex="3" runat="server" Width="245px" CssClass="TextoControles"
                                MaxLength="30"></asp:TextBox>
                            <asp:RegularExpressionValidator ControlToValidate="txtEmail" ID="revEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                runat="server" ErrorMessage="Digite um e-mail valido">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvtxtEmail" runat="server"
                                ErrorMessage="O campo E-Mail é obrigatório" ControlToValidate="txtEmail" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="ValidatorCalloutExtender5" TargetControlID="rfvtxtEmail" runat="server">
                            </cc1:ValidatorCalloutExtender>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="vceemail" TargetControlID="revEmail" runat="server">
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
    <tr>
        <td style="vertical-align: middle; text-align: right">
            <asp:Label ID="lblFone" runat="server" Width="120px" Text="Fone:"></asp:Label>
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFone" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                MaxLength="13"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
    <tr id="trCnpj" runat="server" visible="false">
        <td style="vertical-align: middle; text-align: right">
            <asp:Label ID="lblCnpj" runat="server" Width="120px" Text="Cnpj:"></asp:Label>
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtCnpj" TabIndex="5" runat="server" Width="170px" CssClass="TextoControles"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvcnpj" runat="server" ErrorMessage="O Campo Cnpj é Obrigatório"
                                ControlToValidate="txtCnpj" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="ValidatorCalloutExtender6" TargetControlID="rfvcnpj" runat="server">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
</table>
<table id="tbchkSenha" runat="server" width="100%" class="tabelaLogin" style="margin-top: 4px">
    <tr>
        <td style="vertical-align: middle; width: 190px; height: 8px; text-align: right">
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkAlterarSenha" AutoPostBack="true" Text="Alterar Senha" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
</table>
<table id="tbSenha" runat="server" width="100%" class="tabelaLogin" style="margin-top: 4px"
    visible="false">
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
                                ControlToValidate="txtSenha" ValidationGroup="Cadastro" Enabled="False">*</asp:RequiredFieldValidator>
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
                                ControlToValidate="txtConfirmaSenha" ValidationGroup="Cadastro" Enabled="False">*</asp:RequiredFieldValidator>
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
<table id="divResiduos" runat="server" width="100%" class="tabelaLogin" style="margin-top: 4px">
    <tr>
        <td style="vertical-align: middle; width: 190px; height: 8px; text-align: right">
        </td>
        <td style="vertical-align: middle; height: 8px; text-align: left">
            <table style="width: 260px">
                <tbody>
                    <tr>
                        <td>
                            <asp:GridView ID="gvwResiduos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="ReCodigo" PageSize="20" EmptyDataText="Nenhum registro encontrado"
                                Width="380px">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelecionar" ToolTip="Selecionar" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nome do Residuo">
                                        <ItemTemplate>
                                            <asp:Literal runat="server" ID="litNome" Text='<%# Eval("ReNome") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ImageButton ID="btnAdicionar" ImageUrl="~/Imagem/confirmar.png" runat="server" />
                            <asp:GridView ID="gvwAdicionados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="ReCodigo" PageSize="20" EmptyDataText="Nenhum registro encontrado"
                                Width="380px">
                                <Columns>
                                    <asp:BoundField DataField="ReNome" HeaderText="Nome do Residuo" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Delete" ImageUrl="~/Imagem/btnExcluir_2.gif"
                                        Text="Excluir">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" Wrap="False" />
                                        <HeaderStyle Width="15px" Wrap="True" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
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
