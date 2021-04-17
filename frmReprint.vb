Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmReprint
    Public SQL As New SQLControl
    Private Sub frmReprint_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        LoadBillNo()

    End Sub


    Private Sub cmdShow_Click(sender As Object, e As EventArgs) Handles cmdShow.Click
        If cmbBillNo.Text = "" Then
            MsgBox("Choose Bill No to print.")
            Exit Sub
        Else
            LoadReport()
        End If

    End Sub

    Private Sub LoadReport()

        Dim paramStoreNo As New ReportParameter("BillNo", cmbBillNo.Text)
        Dim reportparameters() As ReportParameter = {paramStoreNo}
        dtsReceiptTableAdapter.Fill(Me.CafeDS.dtsReceipt, cmbBillNo.Text)
        Me.rptvwReceipt.LocalReport.SetParameters(reportparameters)
        Me.rptvwReceipt.SetDisplayMode(DisplayMode.PrintLayout)
        Me.rptvwReceipt.ZoomMode = ZoomMode.Percent
        Me.rptvwReceipt.ZoomPercent = 90

        Me.rptvwReceipt.RefreshReport()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        LoadBillNo()
    End Sub

    Private Sub LoadBillNo()

        cmbBillNo.Items.Clear()
        SQL.AddParam("@BillDate", DateTimePicker1.Text)

        SQL.ExecQuery("SELECT BillNo FROM CafeBill WHERE BillShortDate = @BillDate;")
        If SQL.HasException = True Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows
            cmbBillNo.Items.Add(r("BillNo").ToString)
        Next

    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        LoadBillNo()
    End Sub
End Class