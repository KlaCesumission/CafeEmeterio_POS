<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.mnuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuPOS = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPOSMain = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReprintBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMaintenance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuStrip
        '
        Me.mnuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPOS, Me.mnuMaintenance, Me.mnuExit})
        Me.mnuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuStrip.Name = "mnuStrip"
        Me.mnuStrip.Size = New System.Drawing.Size(1182, 28)
        Me.mnuStrip.TabIndex = 1
        Me.mnuStrip.Text = "mnuStrip"
        '
        'mnuPOS
        '
        Me.mnuPOS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPOSMain, Me.mnuReprintBill})
        Me.mnuPOS.Name = "mnuPOS"
        Me.mnuPOS.Size = New System.Drawing.Size(48, 24)
        Me.mnuPOS.Text = "&POS"
        '
        'mnuPOSMain
        '
        Me.mnuPOSMain.Name = "mnuPOSMain"
        Me.mnuPOSMain.Size = New System.Drawing.Size(152, 24)
        Me.mnuPOSMain.Text = "P&OS Main"
        '
        'mnuReprintBill
        '
        Me.mnuReprintBill.Name = "mnuReprintBill"
        Me.mnuReprintBill.Size = New System.Drawing.Size(152, 24)
        Me.mnuReprintBill.Text = "Reprint &Bill"
        '
        'mnuMaintenance
        '
        Me.mnuMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUsers, Me.mnuMenu})
        Me.mnuMaintenance.Name = "mnuMaintenance"
        Me.mnuMaintenance.Size = New System.Drawing.Size(106, 24)
        Me.mnuMaintenance.Text = "&Maintenance"
        '
        'mnuUsers
        '
        Me.mnuUsers.Name = "mnuUsers"
        Me.mnuUsers.Size = New System.Drawing.Size(152, 24)
        Me.mnuUsers.Text = "Users"
        '
        'mnuMenu
        '
        Me.mnuMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCategory, Me.mnuItems})
        Me.mnuMenu.Name = "mnuMenu"
        Me.mnuMenu.Size = New System.Drawing.Size(152, 24)
        Me.mnuMenu.Text = "Menu"
        '
        'mnuCategory
        '
        Me.mnuCategory.Name = "mnuCategory"
        Me.mnuCategory.Size = New System.Drawing.Size(138, 24)
        Me.mnuCategory.Text = "Category"
        '
        'mnuItems
        '
        Me.mnuItems.Name = "mnuItems"
        Me.mnuItems.Size = New System.Drawing.Size(138, 24)
        Me.mnuItems.Text = "Items"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(45, 24)
        Me.mnuExit.Text = "&Exit"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.mnuStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuStrip
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafe Emeterio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuStrip.ResumeLayout(False)
        Me.mnuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuPOS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPOSMain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReprintBill As System.Windows.Forms.ToolStripMenuItem
End Class
