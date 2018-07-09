
Partial Class UserControl_MinhaPagina_wucMinhaPagina
    Inherits System.Web.UI.UserControl

    Public Enum TipoUsuario
        EmpresaGeradora
        EmpresaReceptora
        EmpresaTerceira
        PessoaFisica
    End Enum

    Public Property Tipo() As TipoUsuario
        Get
            Return CType(Session("Tipo"), TipoUsuario)
        End Get
        Set(ByVal value As TipoUsuario)
            Session("Tipo") = value
        End Set
    End Property





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Tipo.Equals(TipoUsuario.PessoaFisica) Then
                PopulaPessoafisica()
            ElseIf Tipo.Equals(TipoUsuario.EmpresaTerceira) Then
                EmpresaTerceira()
            ElseIf Tipo.Equals(TipoUsuario.EmpresaReceptora) Then
                EmpresaReceptora()
            ElseIf Tipo.Equals(TipoUsuario.EmpresaGeradora) Then
                EmpresaGeradora()
            End If
        End If
    End Sub

    Public Sub EmpresaGeradora()
        ControlaVisible(False, False, True, False)
        Dim clsUsuarioHelper As New FuncoesComuns.FuncoesComuns.MemberShips.UsuariosHelper
        Dim strAux As New StringBuilder
        strAux.Append(" l.usCodigo = " & clsUsuarioHelper.RetornaUsuarioLogado.Tables(0).Rows(0)("usCodigo").ToString)

        wucListarLeilao1Geradora.PopulaDados(strAux.ToString, True)

    End Sub
    Public Sub EmpresaReceptora()
        ControlaVisible(False, True, False, False)

        Dim clsUsuarioHelper As New FuncoesComuns.FuncoesComuns.MemberShips.UsuariosHelper
        Dim strAux As New StringBuilder

        strAux.Append(" leCodigo in (select LeilaoCodigo from LanceLeilao where usCodigo = " & clsUsuarioHelper.RetornaUsuarioLogado.Tables(0).Rows(0)("usCodigo").ToString & ")")

        wucListarLeilao1Receptora.FromMinhaPagina = True
        wucListarLeilao1Receptora.PopulaDados(strAux.ToString, True)
    End Sub
    Public Sub EmpresaTerceira()
        ControlaVisible(False, False, False, True)
    End Sub
    Public Sub PopulaPessoafisica()
        ControlaVisible(True, False, False, False)


    End Sub

    Protected Sub btnAlterarDados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterarDados.Click
        Dim clsUsuarioHelper As FuncoesComuns.FuncoesComuns.MemberShips.UsuariosHelper
        clsUsuarioHelper = New FuncoesComuns.FuncoesComuns.MemberShips.UsuariosHelper
        Response.Redirect("../Usuarios/pessoa-fisica/Default_Edit.aspx?Consultar=" & clsUsuarioHelper.RetornaUsuarioLogado.Tables(0).Rows(0)("usCodigo").ToString & "&MinhaPagina=Default_" & Me.Tipo)

    End Sub

    Protected Sub btnSolicitarSacos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSolicitarSacos.Click
        Response.Redirect("../Requisicao/Default_Usuario.aspx?Incluir=true")
    End Sub

    Protected Sub ControlaVisible(ByVal blnPessoaFisica As Boolean, ByVal blnReceptora As Boolean, ByVal blnGeradorada As Boolean, ByVal blnTerceira As Boolean)
        divEmpresaGeradora.Visible = blnGeradorada
        divEmpresaReceptora.Visible = blnReceptora
        divPopulaPessoafisica.Visible = blnPessoaFisica
        divEmpresaTerceira.Visible = blnTerceira
    End Sub

    Protected Sub btnIrLance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIrLance.Click
        Session("FromMinhaPagina") = Nothing
        Response.Redirect("~/Interfaces/LanceLeilao/Default.aspx")
    End Sub

    Protected Sub btnIrLeilao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIrLeilao.Click
        Session("FromMinhaPaginas") = Nothing
        Response.Redirect("~/Interfaces/ManterLeilao/Default.aspx")
    End Sub
End Class
