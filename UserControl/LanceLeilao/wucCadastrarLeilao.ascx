<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarLeilao.ascx.vb"
    Inherits="UserControl_LanceLeilao_wucCadastrarLeilao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<fieldset style="vertical-align: middle; text-align: Center; width: 100%; border-style: inset;">
    <table id="TABLE1" width="100%" class="tabelaDescricao" style="margin-top: 4px">
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnRetornar" runat="server" ImageUrl="~/Imagem/retornar.png" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td colspan="2" align="center">
                            Leiloeiro:
                            <asp:Label ID="lblLeiloeiro" runat="server"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            Código do Leilão:
                            <asp:Label ID="lblCodigoLeilão" runat="server"></asp:Label>
                        </td>
                        <td>
                            Residuo Leiloado:
                            <asp:Label ID="lblResiduo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            Data de abertura Leilão:
                            <asp:Label ID="lblDataLeilao" runat="server"></asp:Label>
                        </td>
                        <td>
                            Lance Inicial:
                            <asp:Label ID="lblLanceInicial" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="LanCodigo" PageSize="10" EmptyDataText="Nenhum registro encontrado"
        Width="665px" CssClass="GridView">
        <Columns>
            <asp:BoundField DataField="lanValor" HeaderText="Valor do Lance" />
            <asp:BoundField DataField="lanData" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}"
                HtmlEncode="False" />
            <asp:ButtonField ButtonType="Image" CommandName="Delete" ImageUrl="~/Imagem/btnExcluir_2.gif"
                Text="Excluir">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" Wrap="False" />
                <HeaderStyle Width="15px" Wrap="True" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
            Style="vertical-align: middle; text-align: left" Visible="False" Width="100%"></asp:Label>
    </div>
    <table id="TABLE2" width="100%" class="tabelaDescricao" style="margin-top: 4px">
        <tr>
            <td style="vertical-align: middle; text-align: right">
                <asp:Label ID="lblDescricao" runat="server" Text="De seu Lance aqui:"></asp:Label>
            </td>
            <td style="vertical-align: middle; height: 8px; text-align: left">
                <table style="width: 260px">
                    <tbody>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtDescricao" TabIndex="5" runat="server" Width="100px" CssClass="TextoControles"
                                    MaxLength="5"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="True" ID="rfvTxtDescricao" runat="server"
                                    ErrorMessage="O campo Descricao é obrigatório" ControlToValidate="txtDescricao"
                                    ValidationGroup="Cadastro">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvLanceValidador" ValidationGroup="Cadastro" ControlToValidate="txtDescricao"
                                    runat="server" ErrorMessage="O valor do seu lance deve ser maior que o ultimo lance dado.">*</asp:CustomValidator>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender2" TargetControlID="rfvTxtDescricao" runat="server">
                                </cc1:ValidatorCalloutExtender>
                                <cc1:ValidatorCalloutExtender HighlightCssClass="MaskedEditError" Enabled="true"
                                    ID="ValidatorCalloutExtender1" TargetControlID="cvLanceValidador" runat="server">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                            <td align="right">
                                <asp:ImageButton ID="btnConfirmar" runat="server" ImageUrl="~/Imagem/DarLance.png"
                                    ValidationGroup="Cadastro" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</fieldset>
<div id="ModalMsg" style="display: none; text-align: center;">
    <h2>
        <asp:Label ID="lblAcao" runat="server" CssClass="texto"></asp:Label>
    </h2>
    <h3>
        <asp:Label ID="lblTextoAcao" runat="server" CssClass="texto"> </asp:Label>
    </h3>
    <br />
    <br />
    <asp:Button ID="btnACAO" OnClick="btnACAO_Click" SkinID="Pequeno" runat="server"
        Text="OK" />
</div>
