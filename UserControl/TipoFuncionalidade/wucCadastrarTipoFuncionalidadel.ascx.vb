
Partial Class UserControl_TipoFuncionalidade_wucCadastrarTipoFuncionalidadel
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintTipoFuncionalidade As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuTipoFuncionalidade As buSeguranca.buTipoFuncionalidade

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
                'esse item é passado da pagina de consulta e é jogado na variavel mintTipoFuncionalidade
                mintTipoFuncionalidade = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintTipoFuncionalidade = Convert.ToInt32(Request.QueryString("Excluir"))
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
                mintTipoFuncionalidade = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintTipoFuncionalidade = Convert.ToInt32(Request.QueryString("Excluir"))
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
            'validação dos campos
            If txtNome.Text = String.Empty Then

                MsgBox("Você não pode inserir um registro em branco", MsgBoxStyle.OkOnly, "AVISO")
            ElseIf txtNome.Text = String.Empty Then
                MsgBox("O campo Nome tem preenchimento obrigatorio", MsgBoxStyle.OkOnly, "AVISO")
            Else
                'verifica qual a operaçao o usuario esta realizando para saber qual açao executar
                If mblnExcluir Then
                    Excluir()
                ElseIf mblnIncluir Then
                    Incluir()
                ElseIf mblnAlterar Or mblnConsultar Then
                    Alterar()
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ExibeDados()
        Dim dsTipoFuncionalidade As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("TipoFuncionalidade.tipofuncCodigo = ")
            strWhere.Append(mintTipoFuncionalidade)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsTipoFuncionalidade = clsbuTipoFuncionalidade.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsTipoFuncionalidade.Tables(0).Rows.Count > 0 Then
                txtNome.Text = dsTipoFuncionalidade.Tables(0).Rows(0)("Descricao").ToString
                txtUrl.Text = dsTipoFuncionalidade.Tables(0).Rows(0)("Url").ToString


                ' txtDescricao.Text = dsTipoFuncionalidade.Tables(0).Rows(0)("cliEnd").ToString

                'verifica o tipo de operaçao que esta sendo executada
                'caso seja consulta ou exclusão os text ficarão travados
                If mblnExcluir Or mblnConsultar Then
                    txtNome.Enabled = False
                    txtUrl.Enabled = False
                    'caso seja de alteração os text são desbloquiados para que o usuario posso altera-los
                ElseIf mblnAlterar Then
                    txtNome.Enabled = True
                    txtUrl.Enabled = True


                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dsTipoFuncionalidade = Nothing
            clsbuTipoFuncionalidade = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try

            clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
            If clsbuTipoFuncionalidade.Alterar(txtNome.Text, mintTipoFuncionalidade, txtUrl.Text) Then
                If MsgBox("Registro Alterado com sucesso", MsgBoxStyle.OkOnly, "ALTERACAO") = MsgBoxResult.Ok Then
                    RedirecionaPagina()
                End If

            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Incluir()
        Try

            clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
            If clsbuTipoFuncionalidade.Incluir(txtNome.Text, txtUrl.Text) Then
                If MsgBox("Registro Incluido com sucesso", MsgBoxStyle.OkOnly, "INCLUSAO") = MsgBoxResult.Ok Then
                    RedirecionaPagina()
                End If

            End If

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub Excluir()
        Dim dsData As Data.DataSet

        Try

            clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade

            dsData = clsbuTipoFuncionalidade.ConsultarRelacionamento(mintTipoFuncionalidade)
            If dsData.Tables(0).Rows.Count = 0 Then


                clsbuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
                If clsbuTipoFuncionalidade.Excluir(mintTipoFuncionalidade) Then
                    If MsgBox("Registro Excluido com sucesso", MsgBoxStyle.OkOnly, "DELECAO") = MsgBoxResult.Ok Then
                        RedirecionaPagina()
                    End If

                End If
            Else
                If MsgBox("A funcionalidade esta relaciona a algum Grupo", MsgBoxStyle.OkOnly, "DELECAO") = MsgBoxResult.Ok Then
                    RedirecionaPagina()
                End If
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
        Dim strAux As Text.StringBuilder

        Try
            'se for uma exclusão ou uma cosulta (alteração) apos realizada a operação
            'a pagina será para a tela de consulta
            If mblnExcluir Or mblnConsultar Or mblnAlterar Or mblnIncluir Then
                Response.Redirect("Default.aspx?")

                'caso seja uma inclusão ela será redirecionada para ela mesmo

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
