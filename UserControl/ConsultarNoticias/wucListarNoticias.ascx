<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarNoticias.ascx.vb" Inherits="UserControl_ConsultarNoticias_WebUserControl" %>
<p style="text-align: center">
    <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Yellow" 
        style="text-align: center" Text="Consultar Notícias"></asp:Label>
</p>
<table>
    <tr>
        <td>
            <asp:DropDownList ID="cboOpcoes" runat="server" Width="110px" 
                AutoPostBack="True">
                <asp:ListItem Value="nome">Titulo</asp:ListItem>
                <asp:ListItem Value="Data">Data</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="cboEnumerdor" runat="server" Width="100px">
                <asp:ListItem Value="todos">Todos</asp:ListItem>
                <asp:ListItem>igual</asp:ListItem>
                <asp:ListItem Value="contem">Contem</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td runat="server" id="tdOpcoes">
            <asp:TextBox ID="txtOpcoes" runat="server" Width="132px"></asp:TextBox>
        </td>
        <td runat="server" id="tdData" visible="false">
            De<asp:TextBox ID="txtDataDe" runat="server" Width="66px"></asp:TextBox>
            &nbsp; Ate<asp:TextBox ID="txtDataAte" runat="server" Width="66px"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Imagem/ok.png" />
        </td>
    </tr>
</table>
<br />
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="NotCodigo" PageSize="20" Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="NotNome" HeaderText="Título">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="NotData" DataFormatString="{0:d}" HeaderText="Data" >
       
        <ControlStyle BorderWidth="10px" />
       
        <ItemStyle Width="10px" />
        </asp:BoundField>
       
    </Columns>
</asp:GridView>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>