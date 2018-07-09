<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default_Edit.aspx.vb" Inherits="Interfaces_ImprimirLista_Default_Edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p style="text-align: center">
    <asp:Label ID="lblRequisicao" runat="server" Font-Size="Larger" ForeColor="Yellow"
        Style="text-align: center" Text="Lista para Imprimir"></asp:Label>
</p>
<br />
<asp:GridView ID="dgwDados" runat="server" AutoGenerateColumns="False"
    DataKeyNames="reqCodigo" PageSize="20" Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="usCodigo" HeaderText="Código do Usuário">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="ReqData" HeaderText="Data de Requisição" 
            DataFormatString="{0:d}" />
        <asp:TemplateField HeaderText="Atendido">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" Checked='<%#  Convert.ToBoolean(Eval("ReqAtendido")) %>'
                    Enabled="False" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div>
    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
        Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
</div>
    </div>
    </form>
</body>
</html>
