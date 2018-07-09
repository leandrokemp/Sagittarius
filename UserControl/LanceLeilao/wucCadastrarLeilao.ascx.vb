Imports FuncoesComuns.FuncoesComuns.MemberShips

Partial Class UserControl_LanceLeilao_wucCadastrarLeilao
    Inherits System.Web.UI.UserControl
    Dim DsClsLeilao As Data.DataSet
    Dim mintUsuario As Integer
    Dim clsBuLanceLeilao As buCadastros.buLanceLeilao
    Dim clsBuLeilao As buCadastros.buLeilao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsFuncoesComuns As UsuariosHelper
        If Not IsPostBack Then



            'verifica se o usuario esta querendo incluir
            If Not IsNothing(Request.QueryString("Incluir")) Then

                clsFuncoesComuns = New UsuariosHelper
                clsBuLeilao = New buCadastros.buLeilao
                mintUsuario = clsFuncoesComuns.RetornaUsuarioLogado().Tables(0).Rows(0)("usCodigo")
                DsClsLeilao = clsBuLeilao.Consultar("LeCodigo = " & Request.QueryString("Incluir"))

                ExibeDados()

            End If
            'senão for a primeira vez que ocorre o refresh da pagina..
            'verifica novamente qual a operação que o usuario ta realizando
        Else
            'Como a variável global btnInclui, btnExcluir, btnAlterar e intID não guardam 
            'o valor, e ao invés de guardar em variável de sessão. Essa verificação é retomada.
            If Not IsNothing(Request.QueryString("Incluir")) Then

                clsFuncoesComuns = New UsuariosHelper
                clsBuLeilao = New buCadastros.buLeilao
                mintUsuario = clsFuncoesComuns.RetornaUsuarioLogado().Tables(0).Rows(0)("usCodigo")
                DsClsLeilao = clsBuLeilao.Consultar("LeCodigo = " & Request.QueryString("Incluir"))

                ExibeDados()



            End If

        End If
    End Sub
    Private Sub ExibeDados()

        Dim strWhere As Text.StringBuilder

        Try
            clsBuLeilao = New buCadastros.buLeilao

            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("LeilaoCodigo = ")
            strWhere.Append(DsClsLeilao.Tables(0).Rows(0)("LeCodigo"))



            'Descomentar
            lblLeiloeiro.Text = DsClsLeilao.Tables(0).Rows(0)("usNome").ToString
            lblCodigoLeilão.Text = DsClsLeilao.Tables(0).Rows(0)("LeCodigo").ToString
            lblResiduo.Text = DsClsLeilao.Tables(0).Rows(0)("ReNome").ToString
            lblDataLeilao.Text = Convert.ToDateTime(DsClsLeilao.Tables(0).Rows(0)("LeDataInicio")).ToString("dd/MM/yyyy")
            lblLanceInicial.Text = DsClsLeilao.Tables(0).Rows(0)("LeLanceInicial").ToString



            PopulaDados(strWhere.ToString, True)

            clsBuLanceLeilao = New buCadastros.buLanceLeilao

            'O botão de lance será exibido somente se a data de fim do 
            'leilao for maior que a data atual e se o usuario logado for diferente do usuario que criou o leilao
            txtDescricao.Visible = btnConfirmar.Visible = CType(Convert.ToDateTime(DsClsLeilao.Tables(0).Rows(0)("LeDataFim")) >= DateTime.Now, Boolean) And mintUsuario <> CType(DsClsLeilao.Tables(0).Rows(0)("usCodigo"), Integer)
        Catch ex As Exception
            Throw ex
        Finally
            clsBuLanceLeilao = Nothing
            strWhere = Nothing
        End Try
    End Sub


    Protected Sub dgwDados_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgwDados.RowDeleting
        Excluir(CType(dgwDados.DataKeys(e.RowIndex).Value, Integer))
    End Sub
    Private Sub Excluir(ByVal mintLanceExcluir As Integer)
        Try

            clsBuLanceLeilao = New buCadastros.buLanceLeilao
            clsBuLeilao = New buCadastros.buLeilao

            Dim dsDados As Data.DataSet



            dsDados = clsBuLanceLeilao.Consultar("LanValor in(select max(lanValor) from LanceLeilao where  LeilaoCodigo = " & DsClsLeilao.Tables(0).Rows(0)("LeCodigo") & ")")

            'se o lance a ser excluido for o maior para aquele leilao  e  o lance inicial não for 0 (doação) altera o lance vencedor
            If dsDados.Tables(0).Rows(0)("LanCodigo").Equals(mintLanceExcluir) And Not DsClsLeilao.Tables(0).Rows(0)("LeLanceInicial").Equals(0) Then
                dsDados = clsBuLanceLeilao.Consultar("LanValor in(select max(lanValor) from LanceLeilao where LanCodigo <> " & mintLanceExcluir & " and  LeilaoCodigo = " & DsClsLeilao.Tables(0).Rows(0)("LeCodigo") & ")")

                If Not dsDados.Tables(0).Rows.Count = 0 Then
                    clsBuLanceLeilao.AlterarVencedor(dsDados.Tables(0).Rows(0)("lanCodigo"), True, False)
                End If
            End If


            If clsBuLanceLeilao.Excluir(mintLanceExcluir) Then
                lblAcao.Text = "Exclusão"
                lblTextoAcao.Text = "Lance Excluido com Sucesso"
                Dim clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
                clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)
            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Protected Sub dgwDados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgwDados.PageIndexChanging
        dgwDados.PageIndex = e.NewPageIndex
        PopulaDados("", True)
    End Sub
    Protected Sub PopulaDados(ByVal strWhere As String, ByVal blnShowState As Boolean, Optional ByVal strOrdem As String = "")
        Dim dsLeilao As Data.DataSet
        Dim strAux As StringBuilder
        Try
            'Deixa a tela com apenas o UserSelect visível.

            dgwDados.Visible = False
            'pnlGrid.Visible = False



            clsBuLanceLeilao = New buCadastros.buLanceLeilao
            dsLeilao = clsBuLanceLeilao.Consultar(strWhere, strOrdem)
            If dsLeilao.Tables(0).Rows.Count > 0 Then


                dgwDados.Visible = True
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True

                If blnShowState Then

                    'Verifica a permissão do botão Excluir

                    lblTotalRegistros.Visible = True

                    'Mostra a quantidade de registros encontrados
                    strAux = New StringBuilder
                    strAux.Append("registros encontrados")
                    strAux.Append(": ")
                    strAux.Append(dsLeilao.Tables(0).Rows.Count.ToString)
                    lblTotalRegistros.Text = strAux.ToString
                End If



                'Carrega o GridView
                With dgwDados
                    .DataSource = dsLeilao
                    .DataBind()
                End With
            Else

                lblTotalRegistros.Visible = False
                ' dgwDados.Visible = False
                'pnlGrid.ScrollBars = ScrollBars.None
                'pnlGrid.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsLeilao = Nothing

            strAux = Nothing
        End Try
    End Sub

    Protected Sub dgwDados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgwDados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim gvrLinha As Data.DataRowView = CType(e.Row.DataItem, Data.DataRowView)
            Dim clsMemberShipeHelperAux As New FuncoesComuns.FuncoesComuns.MemberShips.MemberShipHelper

            'Será possível excluir um lance somente se o leilão ainda estiver ativo e (For o dono do leilao, ou dono do lance ou administrador)
            e.Row.Cells(2).Controls(0).Visible = CType(Convert.ToDateTime(DsClsLeilao.Tables(0).Rows(0)("LeDataFim")) >= DateTime.Now, Boolean) And (Convert.ToInt32(gvrLinha("usCodigo")).Equals(mintUsuario) Or clsMemberShipeHelperAux.IsThisUsuario(ConfigurationManager.AppSettings("ROLE_ADMINISTRADOR"))) Or Me.DsClsLeilao.Tables(0).Rows(0)("usCodigo").Equals(mintUsuario)
        End If
    End Sub

    Private Sub Incluir()
        Try

            Dim clsFuncoesComuns = New FuncoesComuns.FuncoesComuns.JavaScript.JavaScriptHelper
            Dim DsDados As Data.DataSet

            Dim blnIsVencedor As Boolean
            clsBuLanceLeilao = New buCadastros.buLanceLeilao
            clsBuLeilao = New buCadastros.buLeilao

            'Caso o lance inicial do leilão seja 0 (doação) o lance dado pelo usuario não entrará como vencedor, pois será o donod
            'do leilão quer irá indicar quem foi o vencedor ou não.
            'Caso o lance inicial não seja 0, então o lance dado pelo usuario (sempre o maior) entrará como o Vencedor até o momento.
            blnIsVencedor = Not DsClsLeilao.Tables(0).Rows(0)("LeLanceInicial").Equals(0)

            DsDados = clsBuLanceLeilao.IncluirRetornaIncluido(DsClsLeilao.Tables(0).Rows(0)("LeCodigo"), Convert.ToDouble(txtDescricao.Text), mintUsuario, blnIsVencedor, DateTime.Now)



            clsBuLanceLeilao = New buCadastros.buLanceLeilao
            clsBuLanceLeilao.AlterarVencedor(DsDados.Tables(0).Rows(0)("LanCodigo"), False, False)

            lblAcao.Text = "Inclusão"
            lblTextoAcao.Text = "Seu lance foi Incluido com Sucesso"
            clsFuncoesComuns.Message("ModalMsg", "showModal('ModalMsg','400px','400px')", False)


            txtDescricao.Text = String.Empty
            PopulaDados("Lecodigo = " & DsClsLeilao.Tables(0).Rows(0)("LeCodigo"), True)



        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
        Try

            If Page.IsValid Then '' verifica se o lance dado está sendo o maior (caso o lance inicial do leilão não seja 0 (doação))

                Incluir()
            End If

        Catch ex As Exception


        End Try
    End Sub

    Protected Sub btnRetornar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRetornar.Click
        Response.Redirect("~/Interfaces/LanceLeilao/Default.aspx?")
    End Sub
    ''' <summary>
    ''' verifica se o lance dado está sendo o maior (caso o lance inicial do leilão não seja 0 (doação))
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="args"></param>
    ''' <remarks></remarks>
    Protected Sub cvLanceValidador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvLanceValidador.ServerValidate
        Try

            clsBuLanceLeilao = New buCadastros.buLanceLeilao
            clsBuLeilao = New buCadastros.buLeilao
            Dim dsDados As Data.DataSet


            dsDados = clsBuLanceLeilao.Consultar("LanValor in(select max(lanValor) from LanceLeilao where  LeilaoCodigo = " & DsClsLeilao.Tables(0).Rows(0)("LeCodigo") & ")")
            If Not dsDados.Tables(0).Rows.Count = 0 Then



                If DsClsLeilao.Tables(0).Rows(0)("LeLanceInicial").Equals(0) Or Convert.ToDouble(txtDescricao.Text) > dsDados.Tables(0).Rows(0)("LanValor") Then
                    args.IsValid = True
                Else
                    args.IsValid = False
                End If

            Else


                If DsClsLeilao.Tables(0).Rows(0)("LeLanceInicial").Equals(0) Then
                    args.IsValid = True
                ElseIf DsClsLeilao.Tables(0).Rows(0)("LeLanceInicial") < Convert.ToDouble(txtDescricao.Text) Then
                    args.IsValid = True
                Else
                    args.IsValid = False
                End If


            End If


        Catch ex As Exception
            Throw ex
        Finally
            clsBuLanceLeilao = Nothing
        End Try
    End Sub
    ''' <summary>
    ''' Click criado apenas para causar um post na tela e sumir com o Modal
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnACAO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnACAO.Click

    End Sub
End Class
