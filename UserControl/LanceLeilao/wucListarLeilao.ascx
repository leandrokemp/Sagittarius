<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarLeilao.ascx.vb"
    Inherits="UserControl_LanceLeilao_wucListarLeilao" %>
<p style="text-align: center">
    <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Yellow" Style="text-align: center"
        Text="Listar Leilões"></asp:Label>
</p>
<table>
    <tr>
        <td>
            <asp:DropDownList ID="cboOpcoes" runat="server" AutoPostBack="True" Width="110px">
                <asp:ListItem Value="nome">Titulo</asp:ListItem>
                <asp:ListItem Value="Data">Data</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="cboEnumerdor" runat="server" Width="100px">
                <asp:ListItem Value="todos">Todos</asp:ListItem>
                <asp:ListItem>Contem</asp:ListItem>
                <asp:ListItem Value="Entre">Entre</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td id="tdOpcoes" runat="server">
            <asp:TextBox ID="txtOpcoes" runat="server" Width="132px"></asp:TextBox>
        </td>
        <td id="tdData" runat="server" visible="false">
            Data de Início<asp:TextBox ID="txtDataDe" runat="server" Width="66px"></asp:TextBox>
            &nbsp; Data de fim<asp:TextBox ID="txtDataAte" runat="server" Width="66px"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Imagem/ok.png" />
        </td>
    </tr>
</table>
<br />
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    CssClass="GridView" DataKeyNames="LeCodigo" PageSize="20" Width="665px">
    <Columns>
        <asp:BoundField DataField="ReNome" HeaderText="Resíduo">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="LeDataInicio" DataFormatString="{0:d}" HeaderText="Data de Inicio"
            HtmlEncode="False" HtmlEncodeFormatString="False" >
        <ItemStyle Width="10px" />
        </asp:BoundField>
        <asp:BoundField DataField="LeDataFim" DataFormatString="{0:d}" HeaderText="Data de Fim"
            HtmlEncode="False" HtmlEncodeFormatString="False" >
        <ItemStyle Width="10px" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>
