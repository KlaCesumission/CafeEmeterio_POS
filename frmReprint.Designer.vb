<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReprint
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
        Me.rptvwReceipt = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dtsReceiptTableAdapter = New CafeEmeterioPOS.CafeDSTableAdapters.dtsReceiptTableAdapter()
        Me.cmdShow = New System.Windows.Forms.Button()
        Me.cmbBillNo = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdRefresh = New System.Windows.Forms.Button()
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
        'rptvwReceipt
        '
        ReportDataSource1.Name = "dtsReceipt"
        ReportDataSource1.Value = Me.dtsReceiptBindingSource
        Me.rptvwReceipt.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvwReceipt.LocalReport.ReportEmbeddedResource = "CafeEmeterioPOS.rptReceipt.rdlc"
        Me.rptvwReceipt.Location = New System.Drawing.Point(12, 95)
        Me.rptvwReceipt.Name = "rptvwReceipt"
        Me.rptvwReceipt.Size = New System.Drawing.Size(425, 599)
        Me.rptvwReceipt.TabIndex = 2
        '
        'dtsReceiptTableAdapter
        '
        Me.dtsReceiptTableAdapter.ClearBeforeFill = True
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdShow.Location = New System.Drawing.Point(268, 21)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(80, 58)
        Me.cmdShow.TabIndex = 5
        Me.cmdShow.Text = "Show Receipt"
        Me.cmdShow.UseVisualStyleBackColor = False
        '
        'cmbBillNo
        '
        Me.cmbBillNo.FormattingEnabled = True
        Me.cmbBillNo.Location = New System.Drawing.Point(91, 55)
        Me.cmbBillNo.Name = "cmbBillNo"
        Me.cmbBillNo.Size = New System.Drawing.Size(154, 24)
        Me.cmbBillNo.TabIndex = 6
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(91, 27)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(154, 22)
        Me.DateTimePicker1.TabIndex = 7
        Me.DateTimePicker1.Value = New Date(2021, 4, 17, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Bill No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Bill Date"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.cmdRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdRefresh.Location = New System.Drawing.Point(357, 21)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(80, 58)
        Me.cmdRefresh.TabIndex = 10
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'frmReprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 694)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.cmbBillNo)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.rptvwReceipt)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReprint"
        Me.Text = "Cafe Emeterio"
        CType(Me.dtsReceiptBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CafeDS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rptvwReceipt As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtsReceiptBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CafeDS As CafeEmeterioPOS.CafeDS
    Friend WithEvents dtsReceiptTableAdapter As CafeEmeterioPOS.CafeDSTableAdapters.dtsReceiptTableAdapter
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmbBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
