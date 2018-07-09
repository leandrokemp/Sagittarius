Imports System.Configuration


Partial Class UserControl_e_learning_wucCadastrarE_Learning
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintElearning As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuElearning As buCadastros.buElearning

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

                PopulaUploadIncluir()



                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintElearning
                mintElearning = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True

                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintElearning = Convert.ToInt32(Request.QueryString("Excluir"))
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
                mintElearning = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintElearning = Convert.ToInt32(Request.QueryString("Excluir"))
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



                txtNome.Text = dsElearning.Tables(0).Rows(0)("eNome").ToString
                txtDescricao.Text = dsElearning.Tables(0).Rows(0)("eDescricao").ToString
                txtData.Text = dsElearning.Tables(0).Rows(0)("eData").ToString
                txtVideo.Text = dsElearning.Tables(0).Rows(0)("eVideo").ToString



                wucUpload1.PathFisico = ConfigurationSettings.AppSettings("PATH_FISICO").ToString
                wucUpload1.PathVirtual = ConfigurationSettings.AppSettings("PATH_VIRTUAL").ToString
                wucUpload1.TIPO_UPLOAD = UserControl_Upload_wucUpload.enumTIPO_UPLOAD.IMG
                wucUpload1.Width = 500
                wucUpload1.Height = 500
                wucUpload1.NomeArquivo = dsElearning.Tables(0).Rows(0)("EImagem").ToString
                wucUpload1.Obrigatorio = False



                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then
                    txtNome.Enabled = False
                    txtDescricao.Enabled = False
                    txtData.Enabled = False
                    txtVideo.Enabled = False
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    txtNome.Enabled = True
                    txtDescricao.Enabled = True
                    txtData.Enabled = True
                    txtVideo.Enabled = True

                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsElearning = Nothing
            clsbuElearning = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Dim dsDadosAux As Data.DataSet
        Try
            clsbuElearning = New buCadastros.buElearning
            If clsbuElearning.Alterar(mintElearning, txtNome.Text, Trim(txtDescricao.Text), txtVideo.Text.Trim(), Convert.ToDateTime(txtData.Text)) Then


                If (wucUpload1.ArquivoAlterado() = True) Then
                    clsbuElearning = New buCadastros.buElearning

                    clsbuElearning.AlterarImagem(CType(dsDadosAux.Tables(0).Rows(0)("ECodigo"), Integer), wucUpload1.SalvarUpload(mintElearning.ToString()))


                End If


                lblAcao.Text = "Alteração"
                lblTextoAcao.Text = "Registro Alterado com Sucesso"

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
            clsbuElearning = New buCadastros.buElearning
            Dim dsDadosAux As Data.DataSet
            dsDadosAux = clsbuElearning.IncluirRetornaIncluido(txtNome.Text, Trim(txtDescricao.Text), "", txtVideo.Text.Trim(), Convert.ToDateTime(txtData.Text))

            If dsDadosAux.Tables(0).Rows.Count > 0 Then


                If (wucUpload1.ArquivoAlterado() = True) Then
                    clsbuElearning = New buCadastros.buElearning

                    clsbuElearning.AlterarImagem(CType(dsDadosAux.Tables(0).Rows(0)("ECodigo"), Integer), wucUpload1.SalvarUpload(mintElearning.ToString()))


                End If




                lblAcao.Text = "Inclusão"
                lblTextoAcao.Text = "Registro Incluido com Sucesso"
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

            clsbuElearning = New buCadastros.buElearning
            If clsbuElearning.Excluir(mintElearning, txtDescricao.Text) Then
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Registro Excluido com Sucesso"
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

    Public Sub PopulaUploadIncluir()
        Try
            wucUpload1.PathFisico = ConfigurationSettings.AppSettings("PATH_FISICO").ToString
            wucUpload1.PathVirtual = ConfigurationSettings.AppSettings("PATH_VIRTUAL").ToString
            wucUpload1.TIPO_UPLOAD = UserControl_Upload_wucUpload.enumTIPO_UPLOAD.IMG
            'wucUpload1.Width = 400
            'wucUpload1.Height = 400
            wucUpload1.NomeArquivo = ""
            wucUpload1.Obrigatorio = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnACAO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnACAO.Click
        RedirecionaPagina()
    End Sub
End Class
