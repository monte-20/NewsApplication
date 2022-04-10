Imports FileWorxObjects

Public Class frmPhotos
    Private PhotoObj As ClsPhotos
    Public Sub New()
        InitializeComponent()
        PhotoObj = New ClsPhotos
    End Sub

    Public Sub New(obj As ClsPhotos)
        InitializeComponent()
        PhotoObj = obj
        TitleTextBox.Text = PhotoObj.Name
        DescriptionTextBox.Text = PhotoObj.Description
        PathTextBox.Text = PhotoObj.Photo
        showphoto(PhotoObj.Photo)
        BodyTextBox.Text = PhotoObj.Body
    End Sub

    Private Sub showphoto(path As String)
        Try
            Dim imageFileStream As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read)
            Dim readInImage As Image = Image.FromStream(imageFileStream)
            ImageBox.Image = readInImage
            imageFileStream.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowseBtn.Click
        Dim FileName As String = PhotoObj.BrowsePhoto
        If FileName <> String.Empty Then
            PathTextBox.Text = FileName
            showphoto(FileName)
        End If
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ValidateForm() Then
            SaveFormData()
            PhotoObj.Update()
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
        PhotoObj.Name = TitleTextBox.Text
        PhotoObj.Description = DescriptionTextBox.Text
        PhotoObj.Body = BodyTextBox.Text
        PhotoObj.Photo = PathTextBox.Text
    End Sub

    Private Function ValidateInfo(text As String) As Boolean
        Return text <> String.Empty
    End Function
End Class