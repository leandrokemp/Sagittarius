
Partial Class UserControl_ConsultaElearning_wucConsultaElearning
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintElearning As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuElearning As buCadastros.buElearning

    Private clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper


    'variaveis que indicarão qual é o tipo de operação que o usuario deseja realizar na tela edição
    Private mblnConsultar As Boolean
    ''' <summary>
    ''' Evento que é disparado quando a pagina é carregada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verifica se é a primeira vez que esta sendo feito o refresh da pagina
        If Not IsPostBack Then

            'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            If Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintElearning
                mintElearning = Request.QueryString("Consultar")
                mblnConsultar = True

                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()
            End If
            'senão for a primeira vez que ocorre o refresh da pagina..
            'verifica novamente qual a operação que o usuario ta realizando
        Else
            'Como a variável global btnInclui, btnExcluir, btnAlterar e intID não guardam 
            'o valor, e ao invés de guardar em variável de sessão. Essa verificação é retomada.

            If Not IsNothing(Request.QueryString("Consultar")) Then
                mintElearning = Request.QueryString("Consultar")
                mblnConsultar = True
            End If
        End If
    End Sub

    Protected Sub btnRetornar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRetornar.Click
        Try
            'retorna para a tela de consulta
            Response.Redirect("Default.aspx")
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub ExibeDados()
        Dim dsElearning As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbuElearning = New buCadastros.buElearning
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("ECodigo = ")
            strWhere.Append(mintElearning)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsElearning = clsbuElearning.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsElearning.Tables(0).Rows.Count > 0 Then



                ltrNome.Text = dsElearning.Tables(0).Rows(0)("eNome").ToString
                ltrDescricao.Text = dsElearning.Tables(0).Rows(0)("eDescricao").ToString
                ltrData.Text = dsElearning.Tables(0).Rows(0)("eData").ToString

                Image1.ImageUrl = ConfigurationSettings.AppSettings("PATH_VIRTUAL").ToString & dsElearning.Tables(0).Rows(0)("eImagem").ToString

                Session("video") = dsElearning.Tables(0).Rows(0)("eVideo").ToString
                Button1.Visible = Not dsElearning.Tables(0).Rows(0)("eVideo").ToString.Equals("")


            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsElearning = Nothing
            clsbuElearning = Nothing
            strWhere = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' Função que irá redirecionar a pagina para ela mesma ou para a tela de consulta
    ''' </summary>
    Private Sub RedirecionaPagina()


        Try

            Response.Redirect("Default.aspx?")


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnACAO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnACAO.Click
        RedirecionaPagina()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        wucExibeVideo1.URL = Session("video").ToString
        clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
        clsFuncoesComuns.Message("ModalVideo", "showModal('ModalVideo','500px','500px')", False)

    End Sub
End Class
