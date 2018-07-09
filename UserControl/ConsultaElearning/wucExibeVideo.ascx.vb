
Partial Class UserControl_ConsultaElearning_wucExibeVideo
    Inherits System.Web.UI.UserControl
    Public Property URL() As String
        Get
            Return CType(Session("PathVirtual"), String)
        End Get
        Set(ByVal value As String)
            Session("PathVirtual") = value
            PopulaDados()

        End Set
    End Property

    Public Sub PopulaDados()
        Dim clsvideo As New FuncoesComuns.FuncoesComuns.Video.VideoHelper
        Dim clsvideoAux As New FuncoesComuns.FuncoesComuns.Video.VideoHelper

        ltrVideo.Text = clsvideo.GetObjectVideo(clsvideoAux.GetCodVideo(Me.URL), "500", "500")
        Session("PathVirtual") = Nothing


    End Sub
End Class
