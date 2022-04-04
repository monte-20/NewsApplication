Imports FileWorxObjects

Public Class frmNews


    Private news As ClsNews
    Private Shared categoryData As List(Of ClsNews.Categories) = [Enum].GetValues(GetType(ClsNews.Categories)).Cast(Of ClsNews.Categories)().ToList()

    Sub New()
        InitializeComponent()
        CategoryCombo.DataSource = categoryData
        news = New ClsNews
    End Sub

    Public Sub New(news As ClsNews)
        InitializeComponent()
        Dim categoryData As List(Of ClsNews.Categories) = [Enum].GetValues(GetType(ClsNews.Categories)).Cast(Of ClsNews.Categories)().ToList()
        CategoryCombo.DataSource = categoryData
        Me.news = news
        TitleTextBox.Text = news.Title
        DescriptionTextBox.Text = news.Description
        Dim cat = DirectCast([Enum].Parse(GetType(ClsNews.Categories), news.Category), ClsNews.Categories)
        CategoryCombo.SelectedIndex = categoryData.IndexOf(cat)
        BodyTextBox.Text = news.Body
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click

        If ValidateForm() Then
            SaveFormData()
            news.Update()
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub SaveFormData()
        news.Title = TitleTextBox.Text
        news.Description = DescriptionTextBox.Text
        Dim cat = DirectCast([Enum].Parse(GetType(ClsNews.Categories), CategoryCombo.Text), ClsNews.Categories)
        news.Category = cat
        news.Body = BodyTextBox.Text

    End Sub

    Private Function ValidateForm() As Boolean
        Return ValidateInfo(BodyTextBox.Text) AndAlso
           ValidateInfo(DescriptionTextBox.Text) AndAlso
           ValidateInfo(TitleTextBox.Text)
    End Function

    Private Function ValidateInfo(data As String) As Boolean

        Return data <> String.Empty

    End Function
End Class