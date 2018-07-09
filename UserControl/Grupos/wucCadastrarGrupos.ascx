<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucCadastrarGrupos.ascx.vb" Inherits="PortalReciclagem_UserControl_Grupos_wucCadastrarGrupos" %>
 <table style="background-color: White; height: 100%; width: 715px; text-align: center">
        <tr>
            <td colspan="3" style="background-image: url(Imagem/Layout/fundo_pags.jpg); background-repeat: no-repeat;
                background-position-y: top; background-position-x: right; height: 398px; vertical-align: top">
                <table width="100%" style="text-align: center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:Panel ID="pnlRegiao" runat="server">
                                <fieldset style="vertical-align: middle; text-align: Center; width: 450px; border-style: inset;">
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
                                                <asp:TextBox ID="txtNome" Enabled="True" runat="server" CssClass="TextoControles"
                                                    Width="200px"></asp:TextBox>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>