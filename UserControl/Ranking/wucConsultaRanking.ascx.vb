Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlCommand
Imports System.Web
Imports System.Configuration

Partial Class UserControl_Ranking_wucConsultaRanking
    Inherits System.Web.UI.UserControl


    'Private clsbuFuncionalidades As buSeguranca.buFuncionalidades
    Private clsranking As buCadastros.buRanking
    ''' <summary>
    ''' Função que popula a combo
    ''' </summary>
    ''' <remarks>Implementado por Renato Matsumoto</remarks>
    Public Sub populacboranking()
        Dim dsDados As Data.DataSet

        Try
            clsranking = New buCadastros.buRanking
            dsDados = clsranking.Consultar(" Habilitado='Sim' ")

            cboranking.Items.Add("Selecione")
            cboranking.Items(0).Value = "-1"

            For i As Integer = 0 To dsDados.Tables(0).Rows.Count - 1
                cboranking.Items.Add(dsDados.Tables(0).Rows(i)("NomeRanking").ToString)
                cboranking.Items(i + 1).Value = dsDados.Tables(0).Rows(i)("NomeView").ToString
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            populacboranking()

        End If
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

        clsranking = New buCadastros.buRanking
        AuthorsGridView.DataSource = clsranking.ConsultarRank(cboranking.SelectedValue)
        AuthorsGridView.DataBind()

    End Sub

End Class
