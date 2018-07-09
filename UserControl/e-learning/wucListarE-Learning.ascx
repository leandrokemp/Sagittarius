<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarE-Learning.ascx.vb"
    Inherits="UserControl_e_learning_wucListarE_Learning" %>
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
<asp:Panel ID="pnlbtnNOvo" Style="text-align: left" runat="server">
    <asp:ImageButton ID="btnNovo" runat="server" ImageUrl="~/Imagem/novo.png" />
</asp:Panel>
<br />
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="ECodigo" PageSize="20" Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="ENome" HeaderText="Nome">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="EData" DataFormatString="{0:d}" HeaderText="Data" >
        <ItemStyle Width="10px" />
        </asp:BoundField>
        <asp:ButtonField ButtonType="Image" CommandName="Alterar" 
            ImageUrl="~/Imagem/edit-icon.gif" Text="Alterar" >
           <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
           <HeaderStyle Width="15px" Wrap="True" />
           </asp:ButtonField>
        <asp:ButtonField ButtonType="Image" CommandName="Delete" ImageUrl="~/Imagem/btnExcluir_2.gif"
            Text="Excluir">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
            <HeaderStyle Width="15px" Wrap="True" />
        </asp:ButtonField>
    </Columns>
</asp:GridView>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>
