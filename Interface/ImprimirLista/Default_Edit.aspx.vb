
Partial Class Interfaces_ImprimirLista_Default_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dgwDados.DataSource = Session("Imprimir")
            dgwDados.DataBind()

        End If
    End Sub

End Class
