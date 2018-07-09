<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarGruposXFuncionalidade.ascx.vb"
    Inherits="UserControl_GruposXFuncionalidades_wucListarGruposXFuncionalidade" %>
<table>
    <tr>
        <td>
            <asp:DropDownList ID="cboGrupos" TabIndex="2" runat="server" Width="251px" CssClass="TextoControles">
            </asp:DropDownList>
        </td>
        <td>
            <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Imagem/ok.png" />
        </td>
    </tr>
</table>
<asp:Panel ID="pnlbtnNOvo" Style="text-align: left" runat="server">
    <asp:ImageButton ID="btnNovo" runat="server" ImageUrl="~/Imagem/novo.png" />
</asp:Panel>
<br />
<%--    <asp:Panel ID="pnlGrid" runat="server" ScrollBars="Horizontal" Style="vertical-align: top;
                                            text-align: center" Visible="true" Width="665px" Direction="LeftToRight">--%>
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="TipoFuncCodigo" PageSize="20" Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="Descricao" HeaderText="Funcionalidade" />
        <asp:ButtonField ButtonType="Image" CommandName="Alterar" 
            ImageUrl="~/Imagem/edit-icon.gif" Text="Alterar" >
           <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" Wrap="False" />
           <HeaderStyle Width="15px" Wrap="True" />
           </asp:ButtonField>
        <asp:ButtonField ButtonType="Image" CommandName="Delete" ImageUrl="~/Imagem/btnExcluir_2.gif"
            Text="Excluir">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" Wrap="False" />
            <HeaderStyle Width="15px" Wrap="True" />
        </asp:ButtonField>
    </Columns>
</asp:GridView>
<%--     </asp:Panel>--%>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>
