
Partial Class UserControl_RequisitarSacos_wucRequisitarSacos
    Inherits System.Web.UI.UserControl

    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintRequisicao As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuRequisicao As buCadastros.buRequisicao

    Private clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper


    'variaveis que indicarão qual é o tipo de operação que o usuario deseja realizar na tela edição
    Private mblnIncluir, mblnExcluir, mblnConsultar, mblnAlterar As Boolean
    Private mstrMinhaPagina As String
    ''' <summary>
    ''' Evento que é disparado quando a pagina é carregada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Implementado por Douglas Valverde</remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verifica se é a primeira vez que esta sendo feito o refresh da pagina
        If Not IsPostBack Then

            'verifica se o usuario esta querendo incluir
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mstrMinhaPagina = IIf(Not String.IsNullOrEmpty(Request.QueryString("MinhaPagina")), Convert.ToBoolean(Request.QueryString("MinhaPagina")), "")

                mblnIncluir = True
                btnConfirmar.Visible = True


                lblData1.Text = Date.Now.ToString




                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintRequisicao
                mintRequisicao = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True

                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintRequisicao = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True

                ExibeDados()


            End If
            'senão for a primeira vez que ocorre o refresh da pagina..
            'verifica novamente qual a operação que o usuario ta realizando
        Else
            'Como a variável global btnInclui, btnExcluir, btnAlterar e intID não guardam 
            'o valor, e ao invés de guardar em variável de sessão. Essa verificação é retomada.
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mblnIncluir = True
                btnConfirmar.Visible = True
                mstrMinhaPagina = IIf(Not String.IsNullOrEmpty(Request.QueryString("MinhaPagina")), Convert.ToBoolean(Request.QueryString("MinhaPagina")), "")

            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintRequisicao = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintRequisicao = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
            End If


        End If
    End Sub

    Protected Sub btnRetornar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRetornar.Click
        Try
            'retorna para a tela de consulta
            If String.IsNullOrEmpty(mstrMinhaPagina) Then
                Response.Redirect("Default_Usuario.aspx")
            Else
                Response.Redirect("../../MinhaPagina/" & mstrMinhaPagina)
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Protected Sub btnAlterar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAlterar.Click
        Try
            mblnAlterar = True
            mblnConsultar = False


            btnAlterar.Visible = False
            btnConfirmar.Visible = True

            ExibeDados()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
        Try

            If mblnIncluir Then
                Incluir()
            ElseIf mblnAlterar Or mblnConsultar Then
                Alterar()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExibeDados()
        Dim dsRequisicao As Data.DataSet
        Dim strWhere As Text.StringBuilder
        Dim datasistema As Date


        Try
            clsbuRequisicao = New buCadastros.buRequisicao
            'Monta filtro de consulta.
            datasistema = DateTime.Now
            strWhere = New Text.StringBuilder
            strWhere.Append("ReqCodigo = ")
            strWhere.Append(mintRequisicao)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsRequisicao = clsbuRequisicao.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsRequisicao.Tables(0).Rows.Count > 0 Then



                txtQuantidade.Text = dsRequisicao.Tables(0).Rows(0)("ReqQuantidade").ToString
                lblData1.Text = datasistema.ToString

                


                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then
                    txtQuantidade.Enabled = False
                    lblData1.Enabled = False
                    
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    txtQuantidade.Enabled = True
                    lblData1.Enabled = True

                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsRequisicao = Nothing
            clsbuRequisicao = Nothing
            strWhere = Nothing
            datasistema = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try
            clsbuRequisicao = New buCadastros.buRequisicao
            If clsbuRequisicao.Alterar(mintRequisicao, Convert.ToInt32(txtQuantidade.Text)) Then


                lblAcao.Text = "Alteração"
                lblTextoAcao.Text = "Requisição Alterada com Sucesso"

                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)
            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Incluir()
        Try

            clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper

            Dim clsUsuarioHelper As New FuncoesComuns.FuncoesComuns.MemberShips.UsuariosHelper




            clsbuRequisicao = New buCadastros.buRequisicao
            Dim dsDadosAux As Data.DataSet
            dsDadosAux = clsbuRequisicao.IncluirRetornaIncluido(Convert.ToInt32(txtQuantidade.Text), Convert.ToInt32(clsUsuarioHelper.RetornaUsuarioLogado.Tables(0).Rows(0)("usCodigo").ToString()), Convert.ToDateTime(lblData1.Text))


            lblAcao.Text = "Inclusão"
            lblTextoAcao.Text = "Solicitação Incluida com Sucesso"
            clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)




        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    ''' <summary>
    ''' Função que irá redirecionar a pagina para ela mesma ou para a tela de consulta
    ''' </summary>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Private Sub RedirecionaPagina()


        Try

            'retorna para a tela de consulta
            If String.IsNullOrEmpty(mstrMinhaPagina) Then
                Response.Redirect("Default_Usuario.aspx")
            Else
                Response.Redirect("../../MinhaPagina/" & mstrMinhaPagina)
            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnACAO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnACAO.Click
        RedirecionaPagina()
    End Sub

End Class
