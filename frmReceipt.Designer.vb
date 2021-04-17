<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceipt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dtsReceiptBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CafeDS = New CafeEmeterioPOS.CafeDS()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.rptvwReceipt = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dtsReceiptTableAdapter = New CafeEmeterioPOS.CafeDSTableAdapters.dtsReceiptTableAdapter()
        CType(Me.dtsReceiptBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CafeDS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtsReceiptBindingSource
        '
        Me.dtsReceiptBindingSource.DataMember = "dtsReceipt"
        Me.dtsReceiptBindingSource.DataSource = Me.CafeDS
        '
        'CafeDS
        '
        Me.CafeDS.DataSetName = "CafeDS"
        Me.CafeDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtBillNo
        '
        Me.txtBillNo.Enabled = False
        Me.txtBillNo.Location = New System.Drawing.Point(12, 12)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(87, 22)
        Me.txtBillNo.TabIndex = 1
        '
        'rptvwReceipt
        '
        ReportDataSource1.Name = "dtsReceipt"
        ReportDataSource1.Value = Me.dtsReceiptBindingSource
        Me.rptvwReceipt.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvwReceipt.LocalReport.ReportEmbeddedResource = "CafeEmeterioPOS.rptReceipt.rdlc"
        Me.rptvwReceipt.Location = New System.Drawing.Point(12, 40)
        Me.rptvwReceipt.Name = "rptvwReceipt"
        Me.rptvwReceipt.Size = New System.Drawing.Size(435, 621)
        Me.rptvwReceipt.TabIndex = 2
        '
        'dtsReceiptTableAdapter
        '
        Me.dtsReceiptTableAdapter.ClearBeforeFill = True
        '
        'frmReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 662)
        Me.Controls.Add(Me.rptvwReceipt)
        Me.Controls.Add(Me.txtBillNo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReceipt"
        Me.Text = "Thank you, come again!"
        CType(Me.dtsReceiptBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CafeDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents rptvwReceipt As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtsReceiptBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CafeDS As CafeEmeterioPOS.CafeDS
    Friend WithEvents dtsReceiptTableAdapter As CafeEmeterioPOS.CafeDSTableAdapters.dtsReceiptTableAdapter
End Class
