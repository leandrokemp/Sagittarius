<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarFuncionalidade.ascx.vb"
    Inherits="UserControl_Funcionalidade_wucCadastrarFuncionalidade" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table id="TABLE1" class="tabelaLogin" style="margin-top: 4px" width="450">
    <tr>
        <td>
        </td>
        <td align="left">
            <asp:ImageButton ID="btnRetornar" runat="server" ImageUrl="~/Imagem/retornar.png" />
            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/Imagem/alterar.png" Visible="False" />
            <asp:ImageButton ID="btnConfirmar" ValidationGroup="Cadastro" runat="server" ImageUrl="~/Imagem/confirmar.png"
                Visible="False" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label1" runat="server" CssClass="texto" Text="Tipo de Funcionalidade:"
                Width="64px"></asp:Label>
        </td>
        <td style="width: 260px">
            <asp:DropDownList ID="cboTipoFuncionalidade" runat="server" Width="251px" CssClass="TextoControles">
            </asp:DropDownList>
            <asp:RequiredFieldValidator Display="None" SetFocusOnError="True" ID="rfvcboTipoFuncionalidade" runat="server"
                ErrorMessage="O campo Nome é obrigatório" ControlToValidate="cboTipoFuncionalidade" ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                ID="vcePasswor" TargetControlID="rfvcboTipoFuncionalidade" runat="server">
            </cc1:ValidatorCalloutExtender>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="lblNome" runat="server" CssClass="texto" Text="Nome:" Width="64px"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="txtNome" runat="server" CssClass="TextoControles" Enabled="True"
                Width="200px"></asp:TextBox>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="lblUrl" runat="server" CssClass="texto" Text="Url:" Width="64px"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="txtUrl" runat="server" CssClass="TextoControles" Enabled="True"
                Width="200px"></asp:TextBox>
            &nbsp;
        </td>
    </tr>
</table>
