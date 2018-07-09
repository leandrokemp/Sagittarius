
Partial Class UserControl_PontosdeColeta_WebUserControl
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintID As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbupontosdecoleta As buCadastros.buPontosdeColeta
    Private clsResiduos As buCadastros.buResiduos
    Private clsIDResiduos As buCadastros.buPontosdeColeta
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
                'esse item é passado da pagina de consulta e é jogado na variavel mintID
                mintID = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True

                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintID = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True


                ExibeDados()

            End If


        Else
            'Como a variável global btnInclui, btnExcluir, btnAlterar e intID não guardam 
            'o valor, e ao invés de guardar em variável de sessão. Essa verificação é retomada.
            If Not IsNothing(Request.QueryString("Incluir")) Then
                mblnIncluir = True
                btnConfirmar.Visible = True


            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                mintID = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintID = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
            End If

        End If


    End Sub


    Public Sub PopulaUploadIncluir()
        Try
            wucUpload1.PathFisico = ConfigurationSettings.AppSettings("PATH_FISICO").ToString
            wucUpload1.PathVirtual = ConfigurationSettings.AppSettings("PATH_VIRTUAL").ToString
            wucUpload1.TIPO_UPLOAD = UserControl_Upload_wucUpload.enumTIPO_UPLOAD.IMG
            wucUpload1.Width = 20
            wucUpload1.Height = 20
            wucUpload1.NomeArquivo = ""
            wucUpload1.Obrigatorio = False
        Catch ex As Exception
            Throw ex
        End Try
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
            'validação dos campos Antiga....agora é feito via ajax
            'If txtID.Text = String.Empty And txtLatitude.Text = String.Empty And txtSenha.Text = String.Empty _
            'And rblRoles.SelectedValue = "-1" Then

            '    MsgBox("Você não pode inserir um registro em branco", MsgBoxStyle.OkOnly, "AVISO")
            'ElseIf txtID.Text = String.Empty Then
            '    MsgBox("O campo ID tem preenchimento obrigatorio", MsgBoxStyle.OkOnly, "AVISO")
            'Else
            'verifica qual a operaçao o usuario esta realizando para saber qual açao executar


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
        Dim dsID As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbupontosdecoleta = New buCadastros.buPontosdeColeta
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("pcCodigo = ")
            strWhere.Append(mintID)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsID = clsbupontosdecoleta.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsID.Tables(0).Rows.Count > 0 Then
                Dim strAux1() As String = Roles.GetRolesForUser(dsID.Tables(0).Rows(0)("pcLatitude").ToString)

                txtLatitude.Text = dsID.Tables(0).Rows(0)("pcLatitude").ToString
                txtLongitude.Text = dsID.Tables(0).Rows(0)("pcLongitude").ToString
                txtDescricao.Text = dsID.Tables(0).Rows(0)("pcDescricao").ToString




                wucUpload1.PathFisico = ConfigurationSettings.AppSettings("PATH_FISICO").ToString
                wucUpload1.PathVirtual = ConfigurationSettings.AppSettings("PATH_VIRTUAL").ToString
                wucUpload1.TIPO_UPLOAD = UserControl_Upload_wucUpload.enumTIPO_UPLOAD.IMG
                wucUpload1.Width = 20
                wucUpload1.Height = 20
                wucUpload1.NomeArquivo = dsID.Tables(0).Rows(0)("pcImagem").ToString
                wucUpload1.Obrigatorio = False


                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then

                    txtLatitude.Enabled = False

                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then

                    txtLatitude.Enabled = True

                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsID = Nothing
            clsbupontosdecoleta = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try



            clsbupontosdecoleta = New buCadastros.buPontosdeColeta
            If clsbupontosdecoleta.Alterar(mintID, txtLongitude.Text, Trim(txtLatitude.Text), txtDescricao.Text) Then

                If (wucUpload1.ArquivoAlterado() = True) Then
                    clsbupontosdecoleta = New buCadastros.buPontosdeColeta

                    clsbupontosdecoleta.AlterarImagem(mintID, wucUpload1.SalvarUpload(mintID.ToString()))


                End If
                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                lblAcao.Text = "Inclusão"
                lblTextoAcao.Text = "Ponto de Coleta Incluido com Sucesso"
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
            clsbupontosdecoleta = New buCadastros.buPontosdeColeta
            Dim dsDadosAux As Data.DataSet
            dsDadosAux = clsbupontosdecoleta.IncluirRetornaIncluido(txtLatitude.Text, txtLongitude.Text, txtDescricao.Text, "")

            If dsDadosAux.Tables(0).Rows.Count > 0 Then


                If (wucUpload1.ArquivoAlterado() = True) Then
                    clsbupontosdecoleta = New buCadastros.buPontosdeColeta

                    clsbupontosdecoleta.AlterarImagem(CType(dsDadosAux.Tables(0).Rows(0)("pcCodigo"), Integer), wucUpload1.SalvarUpload(mintID.ToString()))


                End If




                lblAcao.Text = "Inclusão"
                lblTextoAcao.Text = "Ponto de Coleta Incluido com Sucesso"
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

            clsbupontosdecoleta = New buCadastros.buPontosdeColeta
            If clsbupontosdecoleta.Excluir(mintID, txtLatitude.Text) Then
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Ponto de Coleta Excluido com Sucesso"
                clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)


            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

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
