Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Namespace FuncoesComuns.JavaScript
    Public Class JavaScriptHelper
        ''' <summary>
        ''' Monta Alert ao Cliente
        ''' </summary>
        ''' <param name="strMessage">Mensagem a ser exibida</param>
        ''' <param name="blnAjax">Confirma se existe Update Panel na página</param>
        ''' <returns></returns>
        ''' 

        Public Sub Alert(ByVal strMessage As String)


            Dim context As HttpContext = HttpContext.Current

            Dim page As Page = CType(context.Handler, Page)

            Dim scm As ScriptManager = ScriptManager.GetCurrent(page)

            If (scm IsNot DBNull.Value) Then
                ScriptManager.RegisterStartupScript(page, GetType(Page), "Alert", MessageAlerta(strMessage), True)
            Else
                page.ClientScript.RegisterStartupScript(page.GetType(), "Alert", MessageAlerta(strMessage), True)
            End If
        End Sub


        ''' <summary>
        ''' Monta Confirm ao Cliente
        ''' </summary>
        ''' <param name="strMessage">Mensagem a ser exibida</param>
        ''' <returns></returns>
        Public Sub Comfirm(ByVal strMessage As String)

            Dim context As HttpContext = HttpContext.Current

            Dim page As Page = CType(context.Handler, Page)

            Dim scm As ScriptManager = ScriptManager.GetCurrent(page)

            If (scm IsNot DBNull.Value) Then
                ScriptManager.RegisterStartupScript(page, GetType(Page), "Confirm", MessageComfirm(strMessage), True)
            Else
                page.ClientScript.RegisterStartupScript(page.GetType(), "Confirm", MessageComfirm(strMessage), True)
            End If
        End Sub

        '''<summary>
        ''' Monta Mensagem ao Cliente
        ''' </summary>
        ''' <param name="strMessage">Mensagem a ser exibida</param>
        ''' <returns></returns>
        Public Sub Message(ByVal strTitle As String, ByVal strMessage As String, ByVal blnAjax As Boolean)

            Dim context As HttpContext = HttpContext.Current
            Dim page As Page = CType(context.Handler, Page)

            If (blnAjax = True) Then
                ScriptManager.RegisterStartupScript(page, GetType(Page), strTitle, "{" + strMessage + "}", True)
            Else
                page.ClientScript.RegisterStartupScript(page.GetType(), strTitle, "{" + strMessage + "}", True)
            End If
        End Sub



        Private Function MessageGeneric(ByVal strMensagem As String) As String

            Dim strMessage As String = "{0}"
            Return strMessage = String.Format(strMessage, strMensagem)
        End Function

        Private Function MessageAlerta(ByVal strMensagem As String) As String

            Dim strAlerta As String = "alert('{0}')"
            Return strAlerta = String.Format(strAlerta, strMensagem)
        End Function

        Private Function MessageComfirm(ByVal strMensagem As String) As String

            Dim strConfirm As String = "return confirm('{0}')"
            Return strConfirm = String.Format(strConfirm, strMensagem)
        End Function



        Public Sub setJavaScript(ByVal JavaScript As String)

            Dim Context As HttpContext = HttpContext.Current
            Dim Page As Page = CType(Context.Handler, Page)

            Dim Include As HtmlGenericControl = New HtmlGenericControl("script")
            Include.Attributes.Add("type", "text/javascript")
            Include.Attributes.Add("language", "javascript")
            Include.Attributes.Add("src", JavaScript)
            Page.Header.Controls.Add(Include)
        End Sub
    End Class
End Namespace


