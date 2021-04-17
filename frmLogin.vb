Public Class frmLogin
    ' Public Logged As String
    Private SQL As New SQLControl

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearText()
    End Sub


    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        If Not String.IsNullOrEmpty(txtUser.Text) AndAlso Not String.IsNullOrEmpty(txtPW.Text) Then
            CheckLogin(txtUser.Text, txtPW.Text)
        Else
            If MsgBox("Please input required fields.", vbOKCancel) = vbOK Then
                txtUser.Focus()
                Exit Sub
            Else
                End
            End If

        End If

    End Sub

    Private Sub ClearText()
        txtUser.Clear()
        txtPW.Clear()
        txtUser.Focus()

    End Sub

    Private Sub CheckLogin(Username As String, Password As String)
        SQL.AddParam("@User", Username)
        SQL.AddParam("@PW", Password)

        SQL.ExecQuery("SELECT UserName, Password FROM Dim_Users WHERE UserName = Lower(@User) and Password = @PW; ")

        If SQL.RecordCount < 1 Then
            If MsgBox("Access Denied!", MsgBoxStyle.RetryCancel) = vbRetry Then
                ClearText()
                Exit Sub
            End If
        Else
            MsgBox("Welcome to Cafe Emeterio!")
            '     Logged = txtUser.Text
            Me.Hide()
            frmMain.Show()

        End If

        If SQL.HasException(True) Then Exit Sub

    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        End
    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPW.Focus()
        End If
        'e.SuppressKeyPress = True

    End Sub

    Private Sub txtPW_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPW.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdLogin_Click(Nothing, Nothing)
        End If
        'e.SuppressKeyPress = True
    End Sub


End Class
