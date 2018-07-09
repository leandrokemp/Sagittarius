
Partial Class Interfaces_ConsultarPontosColeta_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            Dim strLatitudeLongitude As StringBuilder
            Dim dsAux As Data.DataSet
            Dim clsBuPontosColeta As buCadastros.buPontosdeColeta

            clsBuPontosColeta = New buCadastros.buPontosdeColeta

            dsAux = clsBuPontosColeta.Consultar()
            Dim strMaps As StringBuilder = New StringBuilder


            strMaps.Append("<script type='text/javascript'> ")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("var map;")
            strMaps.Append(Environment.NewLine)
            strMaps.Append(" function initialize() {")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("var myLatlng = new google.maps.LatLng(-15.623037,-49.394531);")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("var myOptions = {")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("zoom: 4,")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("center: myLatlng,")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("mapTypeId: google.maps.MapTypeId.ROADMAP")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("}")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("map = new google.maps.Map(document.getElementById(""map_canvas""), myOptions);")
            strMaps.Append(Environment.NewLine)
            strMaps.Append(Environment.NewLine)
            For Each dr As Data.DataRow In dsAux.Tables(0).Rows

                strLatitudeLongitude = New StringBuilder

                strLatitudeLongitude.Append(dr("pcLatitude").ToString()).Append(",").Append(dr("pcLongitude"))


                If (Not String.IsNullOrEmpty(dr("pcImagem"))) Then
                    strMaps.Append(" var image= '").Append(ConfigurationManager.AppSettings("PATH_VIRTUAL")).Append(dr("pcImagem").ToString()).Append("';")
                End If

                strMaps.Append(Environment.NewLine)
                strMaps.Append("myLatLng = new google.maps.LatLng(" & strLatitudeLongitude.ToString & ");")
                strMaps.Append(Environment.NewLine)
                strMaps.Append("var beachMarker = new google.maps.Marker({")
                strMaps.Append(Environment.NewLine)
                strMaps.Append("position: myLatLng,")
                strMaps.Append(Environment.NewLine)
                strMaps.Append("  map: map,")

                If (Not String.IsNullOrEmpty(dr("pcImagem"))) Then
                    strMaps.Append(Environment.NewLine)
                    strMaps.Append("icon: image, ")
                End If
              
                strMaps.Append(Environment.NewLine)
                strMaps.Append("title:""" & dr("pcDescricao") & """")
                strMaps.Append(Environment.NewLine)
                strMaps.Append(" });")
                strMaps.Append(Environment.NewLine)

            Next
            strMaps.Append("}")
            strMaps.Append(Environment.NewLine)
            strMaps.Append(" initialize();")
            strMaps.Append(Environment.NewLine)
            strMaps.Append("</script>")




            Page.ClientScript.RegisterStartupScript(Me.GetType, "teste", strMaps.ToString)



        End If



    End Sub
End Class
