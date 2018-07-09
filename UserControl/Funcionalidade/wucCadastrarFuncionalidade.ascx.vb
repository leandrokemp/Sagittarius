
Partial Class UserControl_Funcionalidade_wucCadastrarFuncionalidade
    Inherits System.Web.UI.UserControl
    'variavel global que é utilizada para saber qual item o usuario escolheu na tela de consulta
    Private mintFuncionalidades As Integer

    'variavel para ir para a camada aonde se monta as instruçoes sql
    Private clsbuFuncionalidades As buSeguranca.buFuncionalidades
    Private clsBuTipoFuncionalidade As buSeguranca.buTipoFuncionalidade
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
                populacboTipoFuncionalidade()
                'verifica se o usuario esta querendo Consultar (apartir do consultar ele poderá alterar)
            ElseIf Not IsNothing(Request.QueryString("Consultar")) Then
                'se ele quer consultar é preciso saber qual o item que ele esta querendo consultar
                'esse item é passado da pagina de consulta e é jogado na variavel mintFuncionalidades
                mintFuncionalidades = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
                populacboTipoFuncionalidade()
                'exibe os dados referentes ao item escolhido na tela de consulta
                ExibeDados()

            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then


                mintFuncionalidades = Convert.ToInt32(Request.QueryString("Excluir"))
                mblnExcluir = True
                btnConfirmar.Visible = True
                populacboTipoFuncionalidade()
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
                mintFuncionalidades = Request.QueryString("Consultar")
                mblnConsultar = True
                btnAlterar.Visible = True
            ElseIf Not IsNothing(Request.QueryString("Excluir")) Then
                mintFuncionalidades = Convert.ToInt32(Request.QueryString("Excluir"))
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
        Dim dsFuncionalidades As Data.DataSet
        Dim strWhere As Text.StringBuilder

        Try
            clsbuFuncionalidades = New buSeguranca.buFuncionalidades
            'Monta filtro de consulta.
            strWhere = New Text.StringBuilder
            strWhere.Append("funcCodigo = ")
            strWhere.Append(mintFuncionalidades)
            'consulta os dados referente ao item escolhido pelo usuario na tela de consulta
            dsFuncionalidades = clsbuFuncionalidades.Consultar(strWhere.ToString)
            'se realmente existir dados (tratamento padrão) então  os dados serão exibidos
            If dsFuncionalidades.Tables(0).Rows.Count > 0 Then
                txtNome.Text = dsFuncionalidades.Tables(0).Rows(0)("funcNome").ToString
                cboTipoFuncionalidade.SelectedValue = dsFuncionalidades.Tables(0).Rows(0)("TipoFuncCodigo").ToString
                txtUrl.Text = dsFuncionalidades.Tables(0).Rows(0)("funcUrl").ToString
                ' txtDescricao.Text = dsFuncionalidades.Tables(0).Rows(0)("cliEnd").ToString

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
            dsFuncionalidades = Nothing
            clsbuFuncionalidades = Nothing
            strWhere = Nothing
        End Try
    End Sub

    Private Sub Alterar()
        Try

            clsbuFuncionalidades = New buSeguranca.buFuncionalidades
            If clsbuFuncionalidades.Alterar(txtNome.Text, txtUrl.Text, CType(cboTipoFuncionalidade.SelectedValue, Integer), mintFuncionalidades) Then
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

            clsbuFuncionalidades = New buSeguranca.buFuncionalidades
            If clsbuFuncionalidades.Incluir(txtNome.Text, txtUrl.Text, CType(cboTipoFuncionalidade.SelectedValue, Integer)) Then
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

            clsbuFuncionalidades = New buSeguranca.buFuncionalidades

            dsData = clsbuFuncionalidades.ConsultarRelacionamento(mintFuncionalidades)
            If dsData.Tables(0).Rows.Count = 0 Then


                clsbuFuncionalidades = New buSeguranca.buFuncionalidades
                If clsbuFuncionalidades.Excluir(mintFuncionalidades) Then
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


            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' Função que popula a combo
    ''' </summary>
    ''' <remarks>Implementado por Nill Pinheiro</remarks>
    Public Sub populacboTipoFuncionalidade()
        Dim dsDados As Data.DataSet

        Try
            clsBuTipoFuncionalidade = New buSeguranca.buTipoFuncionalidade
            dsDados = clsBuTipoFuncionalidade.Consultar()

            cboTipoFuncionalidade.Items.Add("Selecione")
            cboTipoFuncionalidade.Items(0).Value = "-1"

            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1
                cboTipoFuncionalidade.Items.Add(dsDados.Tables(0).Rows(i)("Descricao").ToString)
                cboTipoFuncionalidade.Items(i + 1).Value = dsDados.Tables(0).Rows(i)("TipoFuncCodigo").ToString
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
