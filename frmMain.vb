Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub mniExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        End
    End Sub


    Private Sub mnuPOSMain_Click(sender As Object, e As EventArgs) Handles mnuPOSMain.Click
        frmPOS.Show()
    End Sub

    Private Sub mnuReprintBill_Click(sender As Object, e As EventArgs) Handles mnuReprintBill.Click
        frmReprint.Show()

    End Sub
End Class