<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CetakBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SPKFinishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TutupAplikasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CetakBarcodeToolStripMenuItem, Me.SPKFinishToolStripMenuItem, Me.TutupAplikasiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(723, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CetakBarcodeToolStripMenuItem
        '
        Me.CetakBarcodeToolStripMenuItem.Name = "CetakBarcodeToolStripMenuItem"
        Me.CetakBarcodeToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.CetakBarcodeToolStripMenuItem.Text = "Cetak Barcode"
        '
        'SPKFinishToolStripMenuItem
        '
        Me.SPKFinishToolStripMenuItem.Name = "SPKFinishToolStripMenuItem"
        Me.SPKFinishToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.SPKFinishToolStripMenuItem.Text = "SPK Finish"
        '
        'TutupAplikasiToolStripMenuItem
        '
        Me.TutupAplikasiToolStripMenuItem.Name = "TutupAplikasiToolStripMenuItem"
        Me.TutupAplikasiToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.TutupAplikasiToolStripMenuItem.Text = "Tutup Aplikasi"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 370)
        Me.ControlBox = False
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Utama"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CetakBarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SPKFinishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TutupAplikasiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
