Imports System.Text


Namespace FuncoesComuns.Adapter
    Public Class AdapterHelper
        '''<summary>
        ''' Trata o texto retirado de um campo multiline.
        ''' </summary>
        '''<param name="strTexto">texto que será tratado</param>
        ''' <returns>o texto tratado</returns>
        Public Function GetTextMultiline(ByVal strTexto As String) As String
            Return IIf(String.IsNullOrEmpty(strTexto), strTexto, "<p>" & strTexto.Replace("\n", "<br />") & "</p>")
        End Function
        ''' <summary>
        ''' Coloca o texto no campo multiline
        ''' </summary>
        ''' <param name="strTexto"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetTextMultiline(ByVal strTexto As String) As String
            Return IIf(String.IsNullOrEmpty(strTexto), strTexto, "<p>" & strTexto.Replace("<br />", "\n") & "</p>")
        End Function
    End Class
End Namespace