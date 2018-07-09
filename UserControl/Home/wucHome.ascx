<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucHome.ascx.vb" Inherits="UserControl_Home_wucHome" %>
<%@ Register Src="~/UserControl/Login/wucLogin1.ascx" TagName="wucLogin" TagPrefix="uc1" %>
<div id="content">
    <div id="left" style="float: left; width: 50%">
        <div id="welcome">
            <p>
                <strong>Proposta </strong><br />
                Ser uma nova referência na internet para reciclagem,<br />
                possibilitando que as empresas e usuários domésticos, após <br /> 
                se cadastrarem, possam acessar o e-Learning, onde irão aprender <br />
                sobre os diversos tipos de resíduos recicláveis e <br />
                receber benefícios pela reciclagem. As empresas <br />
                poderão, além disso, comprar e vender resíduos (Leilão de Resíduos) <br />
                provenientes da produção que não serão mais úteis para uma <br />
                empresa, mas que podem ser indispensáveis para outra.</p>
            <p>
                <br />
                <br />
                <strong>Porque Utilizar o Portal Reciclagem? </strong> <br />
                O Portal disponibiliza quatro tipos de perfis de usuários: <br />
                - <b>Visitante:</b> Este perfil pode consultar as notícias de <br />
                reciclagem no site, além de também poder aprender mais <br /> 
                sobre reciclagem com o Elearning. Também pode consultar <br />
                os pontos de coleta de lixo mais proximos de sua casa, <br />
                sem precisar se cadastrar no portal. <br />
                - <b>Empresa (Geradora/Receptora de Resíduos):</b> Este perfil <br />
                tem acesso a todas as funcionalidades do portal, entre elas <br /> 
                o Leilão de Resíduos, que permite que as empresas comprem <br /> 
                e/ou vendam resíduos provinientes da produção industrial. <br />
                - <b>Pessoa Física:</b> Este perfil tem como uma das principais
                funcionalidades, a possibilidade de o usuário acumular pontos <br />
                com a reciclagem, ou seja, quanto mais reciclar, mais pontos <br />
                recebe. Esses pontos podem ser utilizados para benefício dos <br /> 
                usuários que os possui, como por exemplo descontos no IPVA, IPTU. <br />
                </p>
            <!--<img id="photo_compagny" src="../../Imagem/company-xhdzy.jpg" width="180" height="120"
                alt="company xhdzy" title="photo_compagny" />-->
            <div class="clear">
            </div>
        </div>
    </div>
    <div id="right" style="float: right; width: 50%">
        <div style="border: solid">
            <uc1:wucLogin ID="wucLogin1" runat="server" />
        </div>
        <div>
            <h1>
                Notícias</h1>
            <p>
<asp:GridView ID="dgwDados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="NotCodigo" Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="NotNome" HeaderText="Título">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="NotData" DataFormatString="{0:d}" HeaderText="Data" >
       
        <ItemStyle Width="30px" />
        </asp:BoundField>
       
    </Columns>
</asp:GridView>
            <a href="../Interfaces/ConsultaNoticias/Default.aspx" class="link_right">Todas as Notícias >></a>
            <div class="clear">
            </div>
            <h1>
                Elearning</h1>
<asp:GridView ID="GVElearning" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="ECodigo" Width="665px" CssClass="GridView">
    <Columns>
        <asp:BoundField DataField="ENome" HeaderText="Nome">
            <HeaderStyle Width="305px" />
        </asp:BoundField>
        <asp:BoundField DataField="EData" DataFormatString="{0:d}" HeaderText="Data" >
        
        <ItemStyle Width="30px" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
            </p>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</div>
