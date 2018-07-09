<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucListarGrupos.ascx.vb" Inherits="PortalReciclagem_UserControl_Grupos_wucListarGrupos" %>
<table style="background-color: White; height: 100%; width: 715px; text-align: center">
        <tr>
            <td colspan="3" style="background-image: url(Imagem/Layout/fundo_pags.jpg); background-repeat: no-repeat;
                background-position-y: top; background-position-x: right; height: 398px; vertical-align: top">
                <table width="100%" style="text-align: center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:Panel ID="pnlRegiao" runat="server">
                                <table border="0" style="width: 100%">
                                    <tr>
                                        <td class="texto" style="width: 100%;">
                                            <fieldset style="vertical-align: middle; text-align: Center; width: 660px; border-style: inset;">
                                                <asp:Panel runat="server" ID="pnlControles" CssClass="tabelaLogin" Style="border-bottom: gainsboro 2px ridge">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="cboOpcoes" runat="server" Width="110px">
                                                                    <asp:ListItem Value="nome">Nome</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="cboEnumerdor" runat="server" Width="100px">
                                                                    <asp:ListItem Value="todos">Todos</asp:ListItem>
                                                                    <asp:ListItem>igual</asp:ListItem>
                                                                    <asp:ListItem Value="contem">Contem</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtOpcoes" runat="server" Width="132px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnOk" runat="server" ImageUrl="~/Imagem/ok.png" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </fieldset>
                                            <asp:Panel ID="pnlbtnNOvo" Style="text-align: left" runat="server">
                                                <asp:ImageButton ID="btnNovo" runat="server" ImageUrl="~/Imagem/novo.png" />
                                            </asp:Panel>
                                            <br />
                                            <asp:Panel ID="pnlGrid" runat="server" ScrollBars="Horizontal" Style="vertical-align: top;
                                                text-align: center" Visible="false" Width="665px" Direction="LeftToRight">
                                                <asp:Label ID="lblSemRegistro" runat="server" CssClass="Erro" Style="vertical-align: middle;
                                                    text-align: center" Visible="False">Nenhum registro foi encontrado.</asp:Label><asp:GridView
                                                        ID="dgwDados" runat="server" AllowPaging="True" AlternatingRowStyle-BackColor="#E0E0E0"
                                                        AutoGenerateColumns="False" DataKeyNames="grpCodigo" EnableTheming="True" FooterStyle-BackColor="White"
                                                        FooterStyle-Font-Overline="False" FooterStyle-ForeColor="#000066" FooterStyle-HorizontalAlign="Center"
                                                        HeaderStyle-BackColor="LightGray" HeaderStyle-CssClass="texto" HeaderStyle-ForeColor="Black"
                                                        HeaderStyle-HorizontalAlign="Left" PagerSettings-Mode="Numeric" PagerSettings-NextPageText="Próxima >> "
                                                        PagerSettings-PreviousPageText=" << Anterior" PagerStyle-ForeColor="White" PagerStyle-HorizontalAlign="Right"
                                                        PageSize="20" RowStyle-CssClass="TextoControles" RowStyle-HorizontalAlign="Left"
                                                        Width="665px" AllowSorting="True" GridLines="Vertical" CssClass="BordaGrid">
                                                        <Columns>
                                                            <asp:BoundField DataField="grpNome" HeaderText="Nome">
                                                                <HeaderStyle Width="305px" />
                                                            </asp:BoundField>
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
                                                        <PagerSettings NextPageText="Pr&#243;xima &gt;&gt; " PreviousPageText=" &lt;&lt; Anterior" />
                                                        <FooterStyle BackColor="White" Font-Overline="False" ForeColor="#000066" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="LinhasGrid" HorizontalAlign="Left" />
                                                        <PagerStyle ForeColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Navegacao" />
                                                        <HeaderStyle BackColor="White" CssClass="texto" ForeColor="Black" HorizontalAlign="Center"
                                                            Font-Bold="True" Height="15px" />
                                                        <AlternatingRowStyle BackColor="DimGray" />
                                                    </asp:GridView>
                                            </asp:Panel>
                                            <asp:Label ID="lblTotalRegistros" runat="server" CssClass="texto" Font-Bold="False"
                                                Style="vertical-align: middle; text-align: left" Visible="False" Width="100%">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>