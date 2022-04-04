Imports FileWorxObjects

Public Class frmPhotos
    Private photos As ClsPhotos
    Public Sub New()
        InitializeComponent()
        photos = New ClsPhotos
    End Sub

    Public Sub New(obj As ClsPhotos)
        InitializeComponent()
        photos = obj
        TitleTextBox.Text = photos.Title
        DescriptionTextBox.Text = photos.Description
        PathTextBox.Text = photos.Photo
        showphoto(photos.Photo)
        BodyTextBox.Text = photos.Body
    End Sub

    Private Sub showphoto(path As String)
        Using imageFileStream As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read)
            Dim readInImage As Image = Image.FromStream(imageFileStream)
            ImageBox.Image = readInImage
        End Using
    End Sub
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowseBtn.Click
        Dim FileName As String = photos.BrowsePhoto
        If FileName <> String.Empty Then
            PathTextBox.Text = FileName
            showphoto(FileName)
        End If
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ValidateForm() Then
            SaveFormData()

            photos.Update()
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function ValidateForm() As Boolean
        Return ValidateInfo(PathTextBox.Text) AndAlso
                    ValidateInfo(BodyTextBox.Text) AndAlso
                   ValidateInfo(DescriptionTextBox.Text) AndAlso
                   ValidateInfo(TitleTextBox.Text)
    End Function

    Private Sub SaveFormData()
        photos.Title = TitleTextBox.Text
        photos.Description = DescriptionTextBox.Text
        photos.Body = BodyTextBox.Text
        photos.Photo = PathTextBox.Text
    End Sub

    Private Function ValidateInfo(text As String) As Boolean
        Return text <> String.Empty
    End Function
End Class