Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Namespace FuncoesComuns.FlashHelper
    Public Class FlashHelper
        Public Function GetScript(ByVal PathFlash As String, ByVal Width As String, ByVal Height As String, ByVal FlashVars As String, ByVal Transparent As Boolean, ByVal NoScale As Boolean, ByVal bln100Percent As Boolean) As String



            Dim flash As StringBuilder = New StringBuilder()

            flash.Append("<script type='text/javascript'>" + Environment.NewLine)
            flash.Append("AC_FL_RunContent(" + Environment.NewLine)
            flash.Append("'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0'," + Environment.NewLine)
            If (bln100Percent) Then

                flash.Append("'width','" + "100%" + "'," + Environment.NewLine)
                flash.Append("'height','" + "100%" + "'," + Environment.NewLine)

            Else

                flash.Append("'width','" + Width + "'," + Environment.NewLine)
                flash.Append("'height','" + Height + "'," + Environment.NewLine)
            End If
            flash.Append("'src','" + PathFlash + "'," + Environment.NewLine)
            flash.Append("'quality','high'," + Environment.NewLine)
            flash.Append("'pluginspage','http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash'," + Environment.NewLine)
            flash.Append("'movie','" + PathFlash + "'," + Environment.NewLine)

            If (Transparent = True) Then
                flash.Append("'wmode','transparent' ,")
            End If

            If (NoScale = True) Then
                flash.Append("'SCALE','noscale',")
            End If

            flash.Append("'FlashVars','" + FlashVars + "'" + Environment.NewLine)
            flash.Append(")" + Environment.NewLine)
            flash.Append("</script>" + Environment.NewLine)

            Return flash.ToString()
        End Function
    End Class
End Namespace


