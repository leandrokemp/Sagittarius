<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarGruposXFuncionalidade.ascx.vb"
    Inherits="UserControl_GruposXFuncionalidade_wucCadastrarGruposXFuncionalidade" %>
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
            &nbsp;
            <asp:DropDownList ID="cboTipoFuncionalidade" runat="server" Width="150px">
            </asp:DropDownList>
        </td>
    </tr>
</table>
