Imports FileWorxObjects

Public Class frmUser
    Private user As ClsUser

    Sub New()
        InitializeComponent()
        user = New ClsUser
    End Sub
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AcceptButton = SaveBtn
        CancelButton = CancelBtn

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If validateForm() Then
            saveData()
            user.Update()
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub saveData()
        user.Name = NameTextBox.Text
        user.Username = UsernameTextBox.Text
        user.Password = PasswordTextBox.Text
    End Sub

    Private Function validateForm() As Boolean
        Return ValidateInfo(NameTextBox.Text) AndAlso
            ValidateInfo(UsernameTextBox.Text) AndAlso
            ValidateInfo(PasswordTextBox.Text)
    End Function


    Private Function ValidateInfo(text As String) As Boolean
        Return text <> String.Empty
    End Function
End Class