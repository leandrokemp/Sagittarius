<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarRequisicao.ascx.vb"
    Inherits="UserControl_ImprimirLista_wucImprimirLista" %>
<p style="text-align: center">
    <asp:Label ID="lblRequisicao" runat="server" Font-Size="Larger" ForeColor="Yellow"
        Style="text-align: center" Text="Lista de Requisições"></asp:Label>
</p>
<table>
    <tr>
        <td>
            <asp:DropDownList ID="cboOpcoes" runat="server" Width="110px" AutoPostBack="True">
                <asp:ListItem Value="Data">Data</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="cboEnumerdor" runat="server" Width="100px">
                <asp:ListItem Value="todos">Todos</asp:ListItem>
                <asp:ListItem Value="Entre">Entre</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td runat="server" id="tdData" visible="true">
            De<asp:TextBox ID="txtDataDe" runat="server" Width="66px"></asp:TextBox>
            &nbsp; Ate<asp:TextBox ID="txtDataAte" runat="server" Width="66px"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Imagem/ok.png" />
        </td>
    </tr>
</table>
<asp:Panel ID="pnlbtImprimir" Style="text-align: left" runat="server">
    <asp:ImageButton ID="btnImprimir" runat="server" ImageUrl="~/Imagem/novo.png" />
</asp:Panel>
<br />
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="reqCodigo" PageSize="20" Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="usCodigo" HeaderText="Código do Usuário">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="ReqData" HeaderText="Data de Requisição" DataFormatString="{0:d}" />
        <asp:TemplateField HeaderText="Atendido">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("ReqAtendido")) %>'
                    Enabled="true" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>
