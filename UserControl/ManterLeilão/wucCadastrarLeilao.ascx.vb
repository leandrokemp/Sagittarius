
Partial Class UserControl_ManterLeilão_WebUserControl
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintLeilao As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuLeilao As buCadastros.buLeilao

    Private clsFuncoesComuns As FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper


    'variaveis que indicarão qual é o tipo de operação que o usuario deseja realizar na tela edição
    Private mblnIncluir, mblnExcluir, mblnConsultar, mblnAlterar As Boolean
    ''' <summary>
    ''' Evento que é disparado quando a pagina é carregada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'verifica se é a primeira vez que esta sendo feito o refresh da pagina
        If Not IsPostBack Then

            'verifica se o usuario esta querendo incluir
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mblnIncluir = True
                btnConfirmar.Visible = True
                PopulaDropDownList()

                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintLeilao
                mintLeilao = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True

                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintLeilao = Convert.ToInt32(Request.QueryString("Excluir"))
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
                PopulaDropDownList()


            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintLeilao = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintLeilao = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
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
    Protected Sub btnAlterar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAlterar.Click
        Try
            mblnAlterar = True
            mblnConsultar = False
            mblnExcluir = False

            btnAlterar.Visible = False
            btnConfirmar.Visible = True

            ExibeDados()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
        Try

            If mblnExcluir Then
                Excluir()
            ElseIf mblnIncluir Then
                Incluir()
            ElseIf mblnAlterar Or mblnConsultar Then
                Alterar()
            End If

            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExibeDados()
        Dim dsLeilao As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            PopulaDropDownList()
            clsbuLeilao = New buCadastros.buLeilao
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("LeCodigo = ")
            strWhere.Append(mintLeilao)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsLeilao = clsbuLeilao.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsLeilao.Tables(0).Rows.Count > 0 Then



                txtQuantidade.Text = dsLeilao.Tables(0).Rows(0)("Lekg").ToString
                txtDataInicial.Text = dsLeilao.Tables(0).Rows(0)("LeDataInicio").ToString
                txtDataFinal.Text = dsLeilao.Tables(0).Rows(0)("LeDataFim").ToString
                txtLanceInicial.Text = dsLeilao.Tables(0).Rows(0)("LeLanceInicial").ToString


                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then
                    txtQuantidade.Enabled = False
                    txtDataInicial.Enabled = False
                    txtDataFinal.Enabled = False
                    txtLanceInicial.Enabled = False
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    txtQuantidade.Enabled = True
                    txtDataInicial.Enabled = True
                    txtDataFinal.Enabled = True
                    txtLanceInicial.Enabled = True

                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsLeilao = Nothing
            clsbuLeilao = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try
            clsbuLeilao = New buCadastros.buLeilao
            If clsbuLeilao.Alterar(mintLeilao, Convert.ToInt32(DropDownLeilao.SelectedValue), Convert.ToDouble(txtQuantidade.Text), Convert.ToDateTime(txtDataInicial.Text), Convert.ToDateTime(txtDataFinal.Text), Convert.ToDouble(txtLanceInicial.Text)) Then


                lblAcao.Text = "Alteração"
                lblTextoAcao.Text = "Leilão Alterada com Sucesso"

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
            clsbuLeilao = New buCadastros.buLeilao
            Dim dsDadosAux As Data.DataSet
            Dim clsUsuarioHelper As New FuncoesComuns.FuncoesComuns.MemberShips.UsuariosHelper
            dsDadosAux = clsbuLeilao.IncluirRetornaIncluido(Convert.ToInt32(DropDownLeilao.SelectedValue), Convert.ToDouble(txtQuantidade.Text), Convert.ToDateTime(txtDataInicial.Text), Convert.ToDateTime(txtDataFinal.Text), txtLanceInicial.Text, Convert.ToInt32(clsUsuarioHelper.RetornaUsuarioLogado.Tables(0).Rows(0)("usCodigo").ToString()))



            lblAcao.Text = "Inclusão"
            lblTextoAcao.Text = "Leilão Incluida com Sucesso"
            clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)
            
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Excluir()
        Try

            clsbuLeilao = New buCadastros.buLeilao
            If clsbuLeilao.Excluir(mintLeilao) Then
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Leilão Excluido com Sucesso"
                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)


            End If
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

            Response.Redirect("Default.aspx?")


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnACAO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnACAO.Click
        RedirecionaPagina()
    End Sub


    Public Sub PopulaDropDownList()

        Dim dsDados As Data.DataSet
        Dim clsresiduo As buCadastros.buResiduos

        Try
            clsresiduo = New buCadastros.buResiduos
            dsDados = clsresiduo.Consultar()

            DropDownLeilao.Items.Add("Selecione")
            DropDownLeilao.Items(0).Value = "-1"

            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1
                DropDownLeilao.Items.Add(dsDados.Tables(0).Rows(i)("ReNome").ToString)
                DropDownLeilao.Items(i + 1).Value = dsDados.Tables(0).Rows(i)("ReCodigo").ToString
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
