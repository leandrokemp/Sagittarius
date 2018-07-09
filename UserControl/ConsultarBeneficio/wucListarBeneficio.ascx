<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarBeneficio.ascx.vb" Inherits="UserControl_ConsultarBeneficio_WebUserControl" %>

<table>
    <table>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td runat="server" id="tdOpcoes">
                &nbsp;</td>
            <td runat="server" id="tdData" visible="false">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</table>
<asp:Panel ID="pnlbtnNOvo" Style="text-align: left" runat="server">
</asp:Panel>
<br />
<%--    <asp:Panel ID="pnlGrid" runat="server" ScrollBars="Horizontal" Style="vertical-align: top;
                                            text-align: center" Visible="true" Width="665px" Direction="LeftToRight">--%>
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="RegBeneCodigo" PageSize="20" EmptyDataText="Nenhum registro encontrado"
    Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="RegBeneDescricao" HeaderText="Descrição" />
        <asp:BoundField DataField="RegBeneData" HeaderText="Data" 
            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" >
        <ItemStyle Width="10px" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<%--     </asp:Panel>--%>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>
