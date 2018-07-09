
Partial Class UserControl_RegulametoBeneficio_wucCadastrarRegulamentoBeneficio
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintRegulamentoBeneficio As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuRegulamentoBeneficio As buCadastros.buRegulamentoBeneficio

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





                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintRegulamentoBeneficio
                mintRegulamentoBeneficio = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True

                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintRegulamentoBeneficio = Convert.ToInt32(Request.QueryString("Excluir"))
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


            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintRegulamentoBeneficio = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintRegulamentoBeneficio = Convert.ToInt32(Request.QueryString("Excluir"))
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
        Dim dsRegulamentoBeneficio As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbuRegulamentoBeneficio = New buCadastros.buRegulamentoBeneficio
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("RegBeneCodigo = ")
            strWhere.Append(mintRegulamentoBeneficio)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsRegulamentoBeneficio = clsbuRegulamentoBeneficio.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsRegulamentoBeneficio.Tables(0).Rows.Count > 0 Then




                txtDescricao.Text = dsRegulamentoBeneficio.Tables(0).Rows(0)("RegBeneDescricao").ToString
               

                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then

                    txtDescricao.Enabled = False
                   
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then

                    txtDescricao.Enabled = True
                   

                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsRegulamentoBeneficio = Nothing
            clsbuRegulamentoBeneficio = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try
            clsbuRegulamentoBeneficio = New buCadastros.buRegulamentoBeneficio
            If clsbuRegulamentoBeneficio.Alterar(mintRegulamentoBeneficio, Trim(txtDescricao.Text), DateAndTime.Now.ToShortDateString()) Then


                lblAcao.Text = "Alteração"
                lblTextoAcao.Text = "Benefício Alterado com Sucesso"

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
            clsbuRegulamentoBeneficio = New buCadastros.buRegulamentoBeneficio

            If clsbuRegulamentoBeneficio.Incluir(Trim(txtDescricao.Text), DateAndTime.Now.ToString("dd/MM/yyyy")) Then


                lblAcao.Text = "Inclusão"
                lblTextoAcao.Text = "Benefício Incluido com Sucesso"
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)
            Else

                MsgBox(MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Excluir()
        Try

            clsbuRegulamentoBeneficio = New buCadastros.buRegulamentoBeneficio
            If clsbuRegulamentoBeneficio.Excluir(mintRegulamentoBeneficio) Then
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Benefício Excluido com Sucesso"
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

End Class
