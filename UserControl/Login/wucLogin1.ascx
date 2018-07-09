<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucLogin1.ascx.vb" Inherits="UserControl_Login_wucLogin1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div class="login">
    <div class="clogin">
        <asp:Label ID="lblConta" Text="Digite os dados de sua conta" runat="server" SkinID="TitleLogin"></asp:Label>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Interfaces/Default.aspx"
            OnAuthenticate="Login1_Authenticate" CssClass="BoxLogin">
            <LayoutTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:&nbsp;</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UserName" runat="server" SkinID="Login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="Usuário obrigatório." ToolTip="Usuário obrigatório." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="vce2" TargetControlID="UserNameRequired" runat="server">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:&nbsp;</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" SkinID="Login"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="Senha obrigatória." ToolTip="Senha obrigatória." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                ID="vcePasswor" TargetControlID="PasswordRequired" runat="server">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </table>
                <span>
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                </span>
                <div>
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1" />
                    <asp:Button ID="btnLembrarSenha" runat="server" Text="Nova senha" OnClick="btnLembrarSenha_Click"
                        Visible="False" />
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
</div>
