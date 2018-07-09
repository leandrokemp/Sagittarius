Imports FuncoesComuns.FuncoesComuns.FlashHelper
Partial Class UserControl_Estrutura_wucTvFlash
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim clsFlashHelper As FlashHelper = New FlashHelper

            litBanner.Text = clsFlashHelper.GetScript("http://localhost:1215/PortalReciclagem/util/imagens/flash/bannner", "980", "250", "", True, False, False)
        End If
    End Sub
End Class
