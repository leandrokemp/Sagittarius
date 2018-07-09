Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Text
Imports System.Net.Mail
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Net.Configuration
Imports System.Net
Imports System.IO


Namespace FuncoesComuns.Email
    Public Class EmailHelper

        Public Function EnviarEmailEsqueciMinhaSenha(ByVal Email As String, ByVal Nome As String, ByVal Strmensagem As String, ByVal strAssunto As String) As Boolean



            Dim smtpSection As SmtpSection = CType(ConfigurationManager.GetSection("system.net/mailSettings/smtp"), SmtpSection)

            Dim message As MailMessage = New System.Net.Mail.MailMessage()
            message.From = New System.Net.Mail.MailAddress(smtpSection.From)



            ' Dim html As System.IO.StreamReader = New System.IO.StreamReader(ConfigurationSettings.AppSettings("PathFile") + "/Util/Email/template_esqueceu_senha.html", System.Text.Encoding.Default)
            ' Dim Mensagem As String = html.ReadToEnd()
            Dim Mensagem As String
            ' Mensagem = Mensagem.ToString().Replace("{Usuario}", user.UserName)
            'Mensagem = Mensagem.ToString().Replace("{Senha}", PassWord)

            Mensagem = Strmensagem


            message.To.Add(Email.ToString())
            message.Subject = strAssunto
            message.IsBodyHtml = True
            message.Body = Mensagem

            Dim ssl As Boolean = False
            If (ConfigurationManager.AppSettings.Get("MailSSL").Equals("1")) Then


                ssl = True
            End If


            Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
            smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials
            smtp.Credentials = New System.Net.NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password)
            smtp.EnableSsl = ssl
            smtp.Port = smtpSection.Network.Port

            smtp.Send(message)
            Return True
        End Function




        Public Function EnviarEmailFaleConoscoComercial(ByVal strMail As String, ByVal strMsg As String) As Boolean



            Dim MailMessage As MailMessage = New MailMessage()
            Try


                Dim SmtpClient As SmtpClient = New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings.Get("SMTP"))
                SmtpClient.UseDefaultCredentials = True
                If (ConfigurationManager.AppSettings.Get("SMTP_AUTHENTICATE")) Then
                    SmtpClient.Credentials = New NetworkCredential(ConfigurationManager.AppSettings.Get("SMTP_USER"), ConfigurationManager.AppSettings.Get("SMTP_PASSWORD"))
                End If




                '' MailAddress MailBCC = new System.Net.Mail.MailAddress(NameFile.File.Email.MAIL_BCC(), NameFile.File.Email.NAME_BCC());

                Dim MailFrom As MailAddress = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("MAIL_FROM"), ConfigurationManager.AppSettings.Get("NAME_FROM"))
                ''MailAddress MailFrom = new System.Net.Mail.MailAddress("nill@starcorp.com.br", "Nill");

                Dim MailTo As MailAddress = New System.Net.Mail.MailAddress(strMail, "Caros")
                ''MailAddress MailTo = new System.Net.Mail.MailAddress("nill@starcorp.com.br", "Nill");

                MailMessage = New MailMessage(MailFrom, MailTo)

                ''if (String.IsNullOrEmpty(MailBCC.Address) == false)
                ''  MailMessage.Bcc.Add(MailBCC);

                MailMessage.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1")
                MailMessage.Subject = ConfigurationManager.AppSettings.Get("Assunto")
                MailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1")

                MailMessage.Body = strMsg
                SmtpClient.Send(MailMessage)
                Return True



            Catch ex As Exception
                Return False
            Finally
                MailMessage.Dispose()

            End Try


        End Function


    End Class
End Namespace