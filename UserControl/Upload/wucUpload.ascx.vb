Imports System.Globalization
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class UserControl_Upload_wucUpload
    Inherits System.Web.UI.UserControl
    Enum enumTIPO_UPLOAD
        MP3
        SWF
        IMG
        FLV
        SWF_IMG
        GENERIC
        PDF
        PDF_OR_DOC
    End Enum


    Public Property TIPO_UPLOAD() As enumTIPO_UPLOAD
        Get
            Return CType(Session("enumTIPO_UPLOAD"), enumTIPO_UPLOAD)
        End Get
        Set(ByVal value As enumTIPO_UPLOAD)
            Session("enumTIPO_UPLOAD") = value
        End Set
    End Property

    Public Property PathFisico() As String
        Get
            Return CType(Session("PathFisico"), String)
        End Get
        Set(ByVal value As String)
            Session("PathFisico") = value
        End Set
    End Property

    Public Property PathVirtual() As String
        Get
            Return CType(Session("PathVirtual"), String)
        End Get
        Set(ByVal value As String)
            Session("PathVirtual") = value
        End Set
    End Property


    Public Property NomeArquivo() As String
        Get
            Return CType(Session("NomeArquivo"), String)
        End Get
        Set(ByVal value As String)
            Session("NomeArquivo") = value
            PopulaImagem()
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return CType(Session("Width"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("Width") = value
        End Set
    End Property
    Public Property Height() As Integer
        Get
            Return CType(Session("Height"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("Height") = value
        End Set
    End Property

    Public Property Obrigatorio() As Boolean
        Get
            Return CType(Session("Obrigatorio"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("Obrigatorio") = value
        End Set
    End Property
    Public Property ValidationGroup() As String
        Get
            Return CType(Session("ValidationGroup"), String)
        End Get
        Set(ByVal value As String)
            Session("ValidationGroup") = value
        End Set
    End Property

    Public Property ThumbWidth() As Integer
        Get
            Return CType(Session("ThumbWidth"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("ThumbWidth") = value
        End Set
    End Property

    Protected Sub chkLogotipo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLogotipo.CheckedChanged
        flUpload.Visible = chkLogotipo.Checked
        If ((Me.TIPO_UPLOAD.Equals(enumTIPO_UPLOAD.IMG)) Or ((Me.TIPO_UPLOAD.Equals(enumTIPO_UPLOAD.SWF_IMG)) And (Not Me.NomeArquivo.EndsWith(".swf")))) Then
            imgLogotipo.Visible = Not chkLogotipo.Checked
        End If
        lblTipoArquivo.Visible = chkLogotipo.Checked
        rfvObrigatorio.Enabled = IIf(Me.Obrigatorio, chkLogotipo.Checked, False)
        lblNomeArquivo.Visible = Not chkLogotipo.Checked
    End Sub
    Private Sub SetTIPO(ByVal enumTIPO As enumTIPO_UPLOAD, ByVal blnExiste As Boolean)

        If (enumTIPO.Equals(enumTIPO_UPLOAD.FLV)) Then
            rveflUpload.ValidationExpression = "^.*(\.[Ff][Ll][Vv])$"
            lblTipoArquivo.Text = "Somente arquivos FLV."

        ElseIf (enumTIPO.Equals(enumTIPO_UPLOAD.SWF)) Then
            rveflUpload.ValidationExpression = "^.*(\.[Ss][Ww][Ff])"
            lblTipoArquivo.Text = "Somente arquivos SWF."

        ElseIf (enumTIPO.Equals(enumTIPO_UPLOAD.MP3)) Then

            rveflUpload.ValidationExpression = "^.*(\.[Mm][Pp][3])"
            lblTipoArquivo.Text = "Somente arquivos MP3."


        ElseIf (enumTIPO.Equals(enumTIPO_UPLOAD.PDF)) Then

            rveflUpload.ValidationExpression = "^.*(\.[Pp][Dd][Ff])"
            lblTipoArquivo.Text = "Somente arquivos PDF."

        ElseIf (enumTIPO.Equals(enumTIPO_UPLOAD.PDF_OR_DOC)) Then

            rveflUpload.ValidationExpression = "^.*(\.[Pp][Dd][Ff]|\.[Dd][Oo][Cc])"
            lblTipoArquivo.Text = "Somente arquivos PDF ou DOC."


        ElseIf (enumTIPO.Equals(enumTIPO_UPLOAD.GENERIC)) Then

            rveflUpload.Enabled = False
            lblTipoArquivo.Visible = False


        ElseIf (enumTIPO.Equals(enumTIPO_UPLOAD.IMG)) Then

            If (Me.Height <> 100000) Then
                lblTipoArquivo.Text = "Somente arquivos JPG / GIF / PNG. Dimensões: " & Me.Width & " x " & Me.Height
            Else
                lblTipoArquivo.Text = "Somente arquivos JPG / GIF / PNG. Dimensões: " & Me.Width & " x Ilimitado"
            End If
            rveflUpload.ValidationExpression = "^.*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"
            imgLogotipo.ImageUrl = Me.PathVirtual & Me.NomeArquivo
            imgLogotipo.Visible = blnExiste

        ElseIf ((enumTIPO.Equals(enumTIPO_UPLOAD.SWF_IMG))) Then

            rveflUpload.ValidationExpression = "^.*\\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG]|[pP][nN][gG]|[sS][wW][fF])$"
            lblTipoArquivo.Text = "Somente arquivos SWF ou JPG / GIF / PNG com dimensões  " & Me.Width & " x " & Me.Height
            If (Me.Height = 100000) Then
                lblTipoArquivo.Text = "Somente arquivos SWF ou JPG / GIF / PNG com dimensões  " & Me.Width & " x Ilimitado"
            End If
            If ((blnExiste) And (Not Me.NomeArquivo.EndsWith(".swf"))) Then

                imgLogotipo.ImageUrl = Me.PathVirtual & Me.NomeArquivo
                imgLogotipo.Visible = blnExiste
            End If
        Else
            Throw New Exception("É necessário setar o Tipo de Upload na declaração do controle")
        End If

    End Sub

    Private Sub PopulaImagem()
        Dim blnExiste As Boolean = System.IO.File.Exists(Me.PathFisico & Me.NomeArquivo)
        SetTIPO(Me.TIPO_UPLOAD, blnExiste)
        chkLogotipo.Visible = blnExiste
        chkLogotipo.Checked = Not blnExiste
        If (blnExiste) Then
            lblNomeArquivo.Text = Me.NomeArquivo
        End If

        lblNomeArquivo.Visible = blnExiste
        flUpload.Visible = Not blnExiste
        lblTipoArquivo.Visible = Not blnExiste

        If Me.Obrigatorio And Not blnExiste Then
            rfvObrigatorio.Enabled = Not blnExiste
        Else
            rfvObrigatorio.Enabled = Me.Obrigatorio
        End If

    End Sub

    Public Function ArquivoAlterado() As Boolean

        If (flUpload.HasFile) Then

            If ((chkLogotipo.Checked) Or (Not chkLogotipo.Visible)) Then
                Return True
            End If
        ElseIf Not flUpload.HasFile And Me.Obrigatorio = False And chkLogotipo.Checked Then
            Return True
        End If



        Return False
    End Function


    Public Function SalvarUpload(ByVal strNomeArquivo As String) As String
        If (flUpload.HasFile) Then
            Dim ArquivoInfo As System.IO.FileInfo = New System.IO.FileInfo(flUpload.FileName)
            Dim strDataHora As String = DateTime.Now.ToString("ddMMyyyyhhmmss")
            Dim strRetorno As String = strNomeArquivo & "_" & strDataHora & "_" & RemoveAcentos(ArquivoInfo.Name.Replace(" ", "_"))
            If ((Me.TIPO_UPLOAD.Equals(enumTIPO_UPLOAD.IMG)) Or ((Me.TIPO_UPLOAD.Equals(enumTIPO_UPLOAD.SWF_IMG)) And (Not ArquivoInfo.Name.EndsWith(".swf")))) Then
                If (UploadImagem(CType(4194304, Integer), flUpload, Me.PathFisico, strRetorno, Me.Width, Me.Height, Color.White)) Then
                    Return strRetorno
                End If
            Else

                If (UploadFile(CType(4194304, Integer), flUpload, Me.PathFisico, strRetorno)) Then
                    Return strRetorno
                End If
            End If
        End If

        Return ""
    End Function


    Public Function RemoveAcentos(ByVal strTexto As String) As String
        strTexto = strTexto.Normalize(NormalizationForm.FormD)
        Dim sb As StringBuilder = New StringBuilder

        For Each c As Char In strTexto.ToCharArray()
            If (CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark) Then

                sb.Append(c)
            End If
        Next


        Return sb.ToString()
    End Function



    '    /// <summary>
    '    /// Metodo para upload de arquivos
    '    /// </summary>
    '    /// <param name="intMaxSize">Tamanho máximo do arquivo para upload</param>
    '    /// <param name="fuFile">FileUpload com o arquivo</param>
    '    /// <param name="strPath">Caminho para salvar o arquivo</param>
    '    /// <param name="strName">Nome do arquivo a ser salvo</param>
    '    /// <returns>Resultado da operação</returns>
    Public Function UploadFile(ByVal intMaxSize As Integer, ByVal fuFile As FileUpload, ByVal strPath As String, ByVal strName As String) As Boolean

        If (fuFile.PostedFile.ContentLength < intMaxSize) Then

            If (fuFile.HasFile) Then

                fuFile.SaveAs(strPath & strName)
            End If

        Else

            Return False
        End If

        Return True
    End Function


    Public Function UploadImagem(ByVal intMaxSize As Integer, ByVal fuFile As FileUpload, ByVal strPath As String, ByVal strName As String, ByVal intWidth As Integer, ByVal intHeight As Integer, ByVal Background As Color) As Boolean

        If (Background.Equals(Color.Empty) = True) Then
            Background = Color.Transparent

        End If

        If (fuFile.PostedFile.ContentLength < intMaxSize) Then

            If (fuFile.HasFile) Then

                Dim imgOrinal As System.Drawing.Image = System.Drawing.Image.FromStream(fuFile.PostedFile.InputStream)
                Dim imgFile As System.Drawing.Image = ResizeImage(imgOrinal, intWidth, intHeight, Background)
                imgFile.Save(strPath & strName)
            End If

        Else

            Return False
        End If

        Return True
    End Function

    Private Function Resize(ByVal hpfImagem As HttpPostedFile, ByVal intMaxWidth As Integer, ByVal intMaxHeight As Integer) As System.Drawing.Image

        Dim imgOriginal As System.Drawing.Image = System.Drawing.Image.FromStream(hpfImagem.InputStream)
        Dim imgNew As System.Drawing.Image = imgOriginal

        If ((imgOriginal.Width > intMaxWidth) Or (imgOriginal.Height > intMaxHeight)) Then
            imgNew = ResizeImage(imgNew, intMaxWidth, intMaxHeight)
        End If

        Return imgNew
    End Function


    Private Function ResizeImage(ByVal imgOriginal As System.Drawing.Image, ByVal intMaxWidth As Integer, ByVal intMaxHeight As Integer) As System.Drawing.Image

        Dim intWidth As Integer = intMaxWidth
        Dim intHeight As Integer = intMaxHeight

        Dim intOriginalWidth As Integer = imgOriginal.Width
        Dim intOriginalHeight As Integer = imgOriginal.Height

        Dim dblpercentW As Double
        Dim dblpercentH As Double


        dblpercentW = (CType(intMaxWidth, Double) / CType(intOriginalWidth, Double))
        dblpercentH = (CType(intMaxHeight, Double) / CType(intOriginalHeight, Double))


        If (dblpercentH < dblpercentW) Then

            intWidth = CType(intOriginalWidth * dblpercentH, Integer)
        Else
            intHeight = CType(intOriginalHeight * dblpercentW, Integer)
        End If


        Dim newPic As Bitmap = New Bitmap(intWidth, intHeight, PixelFormat.Format32bppPArgb)
        newPic.SetResolution(imgOriginal.HorizontalResolution, imgOriginal.VerticalResolution)

        Dim g As Graphics = Graphics.FromImage(newPic)

        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.DrawImage(imgOriginal, New Rectangle(0, 0, intWidth, intHeight), New Rectangle(0, 0, intOriginalWidth, intOriginalHeight), GraphicsUnit.Pixel)

        Return newPic
    End Function


    Private Function ResizeImage(ByVal imgOriginal As System.Drawing.Image, ByVal intMaxWidth As Integer, ByVal intMaxHeight As Integer, ByVal Background As Color) As System.Drawing.Image


        Dim intWidth As Integer = intMaxWidth
        Dim intHeight As Integer = intMaxHeight

        Dim intOriginalWidth As Integer = imgOriginal.Width
        Dim intOriginalHeight As Integer = imgOriginal.Height

        Dim dblpercentW As Double
        Dim dblpercentH As Double


        dblpercentW = (CType(intMaxWidth, Double) / CType(intOriginalWidth, Double))
        dblpercentH = (CType(intMaxHeight, Double) / CType(intOriginalHeight, Double))


        If (dblpercentH < dblpercentW) Then

            intWidth = CType(intOriginalWidth * dblpercentH, Integer)
        Else
            intHeight = CType(intOriginalHeight * dblpercentW, Integer)
        End If


        If ((intMaxWidth > intOriginalWidth) And (intMaxHeight > intOriginalHeight)) Then

            intWidth = intOriginalWidth
            intHeight = intOriginalHeight
        End If

        Dim intPosX = 0
        Dim intPosY = 0


        intPosX = (intMaxWidth / 2) - (intWidth / 2)
        intPosY = (intMaxHeight / 2) - (intHeight / 2)

        Dim newPic As Bitmap = New Bitmap(intMaxWidth, intMaxHeight, PixelFormat.Format32bppPArgb)
        newPic.SetResolution(imgOriginal.HorizontalResolution, imgOriginal.VerticalResolution)



        Dim g As Graphics = Graphics.FromImage(newPic)

        g.Clear(Background)
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.DrawImage(imgOriginal, New Rectangle(intPosX, intPosY, intWidth, intHeight), New Rectangle(0, 0, intOriginalWidth, intOriginalHeight), GraphicsUnit.Pixel)


        Return newPic
    End Function
End Class
