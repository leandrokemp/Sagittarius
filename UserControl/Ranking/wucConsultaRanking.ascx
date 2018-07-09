<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucConsultaRanking.ascx.vb" Inherits="UserControl_Ranking_wucConsultaRanking" %>




      <h3>Ranking</h3>
      <p>
          <asp:DropDownList ID="cboranking" runat="server">
          </asp:DropDownList>
          <asp:Button ID="btnOK" runat="server" Text="OK" />
      </p>

      <asp:label id="Message"
        forecolor="Red"
        runat="server"/>

      <br/>    

      <asp:gridview id="AuthorsGridView" 
        autogeneratecolumns="true" 
        runat="server">
      </asp:gridview>
