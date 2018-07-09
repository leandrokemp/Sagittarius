<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucLogin.ascx.vb" Inherits="UserControl_Login_wucLogin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<h1 align="center" class="title">
    <strong style="font-size: 70px">Identificação</strong></h1>
<p>
<br />
</p>
<table align="center" style="height: 300px; width: 494px" >
    <tr align="center">
        <td align="center">
            <asp:Login align="center" ID="Login1" runat="server" BackColor="#F7F6F3" 
                BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                CssClass="BoxLogin" DestinationPageUrl="~/Interfaces/Default.aspx" 
                OnAuthenticate="Login1_Authenticate" 
                CFailureText="Usuário ou senha inválidos." Font-Names="Verdana" 
                Font-Size="0.8em" ForeColor="#333333" Height="120px" Width="133px" >
                <TextBoxStyle Font-Size="0.8em" />
                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <LayoutTemplate>
                    <table align="center" border="0" cellpadding="4" cellspacing="0" 
                        style="border-collapse:collapse; height: 228px; width: 326px;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" align="center" 
                                    style="height: 223px; width: 331px">
                                    <tr>
                                        <td align="center" colspan="2" 
                                            
                                            style="color:Black;background-color:#5D7B9D;font-size:2em; font-weight:bold;">
                                            &nbsp;<b><label ID="TitCad2">L</label></b>ogin</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                                                Font-Size="Large">Usuário:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Font-Size="Medium" SkinID="Login" 
                                                Width="205px" Height="29px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="Usuário obrigatório." 
                                                ToolTip="Usuário obrigatório." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                             <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                            ID="vce2" TargetControlID="UserNameRequired" runat="server">
                                            </cc1:ValidatorCalloutExtender>                    
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                                                Font-Size="Large">Senha:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" SkinID="Login" 
                                                Width="205px" Height="29px" Font-Size="Medium">&gt;</asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                ControlToValidate="Password" ErrorMessage="Senha obrigatória." 
                                                ToolTip="Senha obrigatória." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                            ID="vcePasswor" TargetControlID="PasswordRequired" runat="server">
                                            </cc1:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text=" Lembrar-me" 
                                                Font-Size="Medium" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
                                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                                Font-Names="Verdana" Font-Size="Medium" ForeColor="#284775" Height="32px" 
                                                style="margin-left: 0px" Text="Entrar" ValidationGroup="Login1" Width="97px" />
                                            <asp:Button ID="btnResgistrar" runat="server" BackColor="#FFFBFF" 
                                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Registrar" 
                                                Font-Names="Verdana" Font-Size="Medium" ForeColor="#284775" Height="32px" 
                                                style="margin-left: 0px" Text="Registrar-se" Width="125px" 
                                                onclick="btnResgistrar_Click" />
                                                
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                    ForeColor="White" />
            </asp:Login>
        </td>
    </tr>
</table>



 