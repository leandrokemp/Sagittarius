Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports FuncoesComuns.FuncoesComuns.FlashHelper.FlashHelper
Imports System.Net
Imports System.IO
Imports System.Xml
Imports System.Configuration


Namespace FuncoesComuns.Video
    Public Class VideoHelper

        ''' <summary>
        ''' Pega o object do vídeo
        ''' </summary>
        ''' <param name="strLinkVideo">Recebe o link do vídeo</param>
        ''' <param name="strWidth">Recebe a largura do vídeo</param>
        ''' <param name="strHeight">Recebe a altura do vídeo</param>
        ''' <returns>Retorna o object do vídeo</returns>
        Public Function GetObjectVideo(ByVal strCodVideo As String, ByVal strWidth As String, ByVal strHeight As String) As String


            Dim video As StringBuilder = New StringBuilder()


            'video.Append("<object width=\" & strWidth & " \ "" height=\" & strHeight & " \ "">")
            'video.Append("<param name=\""movie\"" value=\""http://www.youtube.com/v/" & strCodVideo & "?f=videos&\""></param>")
            'video.Append("<param name=\""allowFullScreen\"" value=\""true\""></param>")
            'video.Append("<param name=\""allowscriptaccess\"" value=\""always\""></param>")
            'video.Append("<embed src=\""http://www.youtube.com/v/""" & strCodVideo & "?f=videos&\"" type=\""application/x-shockwave-flash\"" allowscriptaccess=\""always\"" allowfullscreen=\""true\"" width=\""" & strWidth & "" \ " height=\""" & strHeight & "" \ "></embed>")
            video.Append("<object width=""470"" height=""310""><param name=""movie"" value=""http://www.youtube.com/v/" & strCodVideo & """></param><param name=""allowFullScreen"" value=""true""></param><param name=""allowscriptaccess"" value=""always""></param><embed src=""http://www.youtube.com/v/" & strCodVideo & """ type=""application/x-shockwave-flash""allowscriptaccess=""always"" allowfullscreen=""true"" width=""470"" height=""310""></embed></object>")



            Return video.ToString()
        End Function

        ''' <summary>
        ''' Verifica se o link do vídeo do youtube é válido
        ''' </summary>
        ''' <param name="strLink">Recebe o link do video</param>
        ''' <returns>Retorna um boolean</returns>
        Public Function ValidateLinkYoutube(ByVal strLink As String) As Boolean
            ''http://www.youtube.com/watch?v=xM4o46TcKAE
            Return (strLink.Contains(ConfigurationManager.AppSettings.Get("LINK_VIDEO_YOUTUBE")) Or strLink.Contains("http://br.youtube.com/watch?v="))
        End Function


        ''' <summary>
        ''' Pega o código do vídeo
        ''' </summary>
        ''' <param name="strLinkYoutube">Recebe o link do video do youtube</param>
        ''' <returns>Retorna uma string com o código do vídeo</returns>
        Public Function GetCodVideo(ByVal strLinkYoutube As String) As String
            '' Montando link para imagem thumb do vídeo
            Dim strUrl As String = strLinkYoutube.Replace(ConfigurationManager.AppSettings.Get("LINK_VIDEO_YOUTUBE"), "")

            Return strUrl.Split("&")(0)
        End Function
        ''' <summary>
        ''' Retorna a URL do vídeo
        ''' </summary>
        ''' <param name="strLinkYoutube">Código do Vídeo no Youtube</param>
        ''' <returns></returns>
        Public Function GetURLByCodVideo(ByVal strCodVideo As String) As String
            Return ConfigurationManager.AppSettings.Get("LINK_VIDEO_YOUTUBE") + strCodVideo
        End Function



        ''' <summary>
        ''' Pega o link da imagem thumb do vídeo
        ''' </summary>
        ''' <param name="strLinkYoutube">Recebe o link do vídeo</param>
        ''' <returns>Retorna o link do thumb</returns>
        Public Function GetLinkThumb(ByVal strCodVideo As String) As String
            Return ConfigurationManager.AppSettings.Get("LINK_THUMB_YOUTUBE").Replace("{CodVideo}", strCodVideo)
        End Function
        ''' <summary>
        ''' Pega o link do XML do vídeo
        ''' </summary>
        ''' <param name="strLinkYoutube"></param>
        ''' <returns></returns>
        Public Function GetLinkXML(ByVal strLinkYoutube As String) As String
            Return ConfigurationManager.AppSettings.Get("LINK_XML_YOUTUBE") & GetCodVideo(strLinkYoutube)
        End Function
        ''' <summary>
        ''' Pega o link do script do vídeo
        ''' </summary>
        ''' <param name="strLinkYoutube">Recebe o link do vídeo</param>
        ''' <returns>Retorna o link do script do vídeo</returns>
        Public Function GetLinkScript(ByVal strCodVideo As String) As String
            Return ConfigurationManager.AppSettings.Get("LINK_SCRIPT_YOUTUBE") & strCodVideo + "&hl=pt-br&fs=1"
        End Function



        ''' <summary>
        ''' Pega o título e a descrição do vídeo
        ''' </summary>
        ''' <param name="clsClienteVideo">Recebe uma instância da classe ClienteVideoTO</param>
        ''' <returns>Retorna uma instância da classe ClienteVideoTO</returns>
        Public Function GetTituloVideo(ByVal url As String) As String



            ''Pego o XML do vídeo
            Dim WebCliente As WebClient = New WebClient()
            Dim XmlStream As Stream = WebCliente.OpenRead(Me.GetLinkXML(url))
            Dim xmlDoc As XmlDocument = New XmlDocument()
            xmlDoc.Load(XmlStream)

            Dim XmlElemento As XmlElement = xmlDoc.DocumentElement


            Dim strTiulo As String = ""


            ''//Procuro o título, a descrição e a duração do vídeo
            For Each node As XmlNode In XmlElemento.ChildNodes
                If (node.Name = "title") Then
                    strTiulo = IIf(Not String.IsNullOrEmpty(node.InnerText), node.InnerText, "")

                End If

            Next

            Return strTiulo
        End Function

        ''' <summary>
        ''' Pega o script pra exibir o vídeo
        ''' </summary>
        ''' <param name="strLinkVideo">Recebe o link do vídeo</param>
        ''' <param name="intWidth">Recebe a largura do vídeo</param>
        ''' <param name="intHeight">Recebe a altura do vídeo</param>
        ''' <param name="blnAutoPlay">Recebe um boolean se autoplay</param>
        ''' <param name="blnAbreVideosRelacionados">Recebe um boolean se vídeos relacionados</param>
        ''' <returns>Retorna o script pra exibir o vídeo</returns>
        Public Function GetScriptByLink(ByVal strCodVideo As String, ByVal strWidth As String, ByVal strHeight As String, ByVal blnAutoPlay As Boolean, ByVal blnAbreVideosRelacionados As Boolean) As String
            Dim strLinkPadrao As String = GetLinkScript(strCodVideo)
            If (blnAutoPlay) Then

                strLinkPadrao = strLinkPadrao + "&autoplay=1"
                If (blnAbreVideosRelacionados) Then
                    strLinkPadrao = strLinkPadrao + "&rel=1"
                Else
                    strLinkPadrao = strLinkPadrao + "&rel=0"
                End If
            End If

            Dim clsFuncoes As FlashHelper.FlashHelper


            clsFuncoes = New FlashHelper.FlashHelper


            Return clsFuncoes.GetScript(strLinkPadrao, strWidth, strHeight, "", False, False, False)
        End Function



    End Class
End Namespace