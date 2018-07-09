<%@ Control Language="VB" AutoEventWireup="false" 
CodeFile="wucRegistraPeso.ascx.vb" Inherits="UserControl_RegistrarPeso_wucRegistraPeso" %>

<style type="text/css">
    .style1
    {
        width: 35px;
    }
</style>

<p align="center" style="font-size: large; font-weight: bold">
    Registrar Peso Resíduo</p>
    <br />
<table align="center">
    <tr>
        <td>
            Consultar usuário:
                <table>
                <tr>
                    <td>
                        <asp:DropDownList ID="cboOpcoes" runat="server" Width="110px">
                        <asp:ListItem Value="nome">Nome</asp:ListItem>
                        <asp:ListItem Value="Codigo">Codigo</asp:ListItem>
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

                <asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="usCodigo" PageSize="6" EmptyDataText="Nenhum registro encontrado"
                Width="440px" CssClass="GridView" Height="16px">
                <Columns>
                    <asp:BoundField DataField="usCodigo" HeaderText="Codigo" />
                    <asp:BoundField DataField="usNome" HeaderText="Nome" >
                        <HeaderStyle Width="305px" />
                    </asp:BoundField>   
                    <asp:CommandField SelectText="Selecionar" ShowSelectButton="True" />
                </Columns>
                </asp:GridView>
                <br />
                Selecione o resíduo:
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="cboResiduo" runat="server" Width="338px">
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/Imagem/ok.png" Height="19px" />
                         
    
                        </td>
                    </tr>
                </table>


        </td> 
        <td class="style1"></td>
    <td id=" " align="center">
    
     
    
        <%--Código do usuário:
        <br />
        <asp:TextBox ID="txtCodUsu" runat="server"></asp:TextBox>
        <br />
        <br />--%>
        <br />
        <table>
                    <tr>
                        <td>
                           Código
                            <br />
                            <asp:TextBox ID="txtCodUsu" runat="server" Width="43px" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            Nome do usuário:
                            <br />
                            <asp:TextBox ID="txtNomeUsu" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
        </table>      
        <br />
        <table>
                    <tr>
                        <td>
                           Cód.:
                            <br />
                            <asp:TextBox ID="txtcodresiduo" runat="server" Width="43px" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                           Resíduo:
                            <br />
                            <asp:TextBox ID="txtresiduo" runat="server" Width="147px" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            Digite o peso:
                            <br />
                            <asp:TextBox ID="txtpeso" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
        </table>  
        
        <br />
        &nbsp;<asp:ImageButton ID="btnConfirmar" runat="server" 
                ImageUrl="~/Imagem/confirmar.png" ValidationGroup="Cadastro" />
        
                         
    </td>
    </tr>
</table>
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