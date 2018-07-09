<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucUpload.ascx.vb" Inherits="UserControl_Upload_wucUpload" %>
<asp:CheckBox ID="chkLogotipo" runat="server" AutoPostBack="true" Text="Alterar arquivo"
    OnCheckedChanged="chkLogotipo_CheckedChanged" /><br />
<asp:FileUpload ID="flUpload" Width="373px" runat="server" />
<asp:RequiredFieldValidator ID="rfvObrigatorio" runat="server" ControlToValidate="flUpload"
    ErrorMessage="Arquivo Obrigatório" ValidationGroup="Cadastro" ToolTip="Arquivo Obrigatório">*</asp:RequiredFieldValidator>
<br />
<asp:Literal ID="lblTipoArquivo" runat="server" Text="" />
<asp:Literal ID="lblNomeArquivo" runat="server" Visible="False" />
<asp:Image ID="imgLogotipo" runat="server" Visible="False" ImageAlign="Middle" Width="80" />
<asp:RegularExpressionValidator ID="rveflUpload" runat="server" ControlToValidate="flUpload"
    Display="Dynamic" ErrorMessage="Arquivo do tipo inválido." ValidationExpression=""
    ValidationGroup="Cadastro" ToolTip="Arquivo do tipo inválido.">*</asp:RegularExpressionValidator>