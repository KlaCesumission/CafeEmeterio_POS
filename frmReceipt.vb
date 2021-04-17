Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmReceipt
    Public SQL As New SQLControl
    Private Sub frmReceipt_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadReport()

    End Sub
    Private Sub LoadReport()
        txtBillNo.Text = frmPOS.lblBillNo.Text

        Dim paramStoreNo As New ReportParameter("BillNo", txtBillNo.Text)
        Dim reportparameters() As ReportParameter = {paramStoreNo}
        dtsReceiptTableAdapter.Fill(Me.CafeDS.dtsReceipt, txtBillNo.Text)
        Me.rptvwReceipt.LocalReport.SetParameters(reportparameters)
        Me.rptvwReceipt.SetDisplayMode(DisplayMode.PrintLayout)
        Me.rptvwReceipt.ZoomMode = ZoomMode.Percent
        Me.rptvwReceipt.ZoomPercent = 90

        Me.rptvwReceipt.RefreshReport()

    End Sub

End Class