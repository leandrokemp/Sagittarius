<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarTipoFuncionalidadel.ascx.vb"
    Inherits="UserControl_TipoFuncionalidade_wucCadastrarTipoFuncionalidadel" %>
<table id="TABLE1" width="450" class="tabelaLogin" style="margin-top: 4px">
    <tr>
        <td>
        </td>
        <td align="left">
            <asp:ImageButton ID="btnRetornar" runat="server" ImageUrl="~/Imagem/retornar.png" />
            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/Imagem/alterar.png"
                Visible="False" />
            <asp:ImageButton ID="btnConfirmar" runat="server" ImageUrl="~/Imagem/confirmar.png"
                Visible="False" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="lblNome" runat="server" Text="Nome:" CssClass="texto" Width="64px"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="txtNome" Enabled="True" runat="server" CssClass="TextoControles"
                Width="200px"></asp:TextBox>&nbsp;
        </td>
    </tr>
      <tr>
        <td style="text-align: right">
            <asp:Label ID="lblUrl" runat="server" Text="URL:" CssClass="texto" Width="64px"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="txtUrl" Enabled="True" runat="server" CssClass="TextoControles"
                Width="200px"></asp:TextBox>&nbsp;
        </td>
    </tr>
</table>
