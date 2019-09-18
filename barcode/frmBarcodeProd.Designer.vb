<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarcodeProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarcodeProd))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtSPKYear = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSPKMid = New System.Windows.Forms.TextBox()
        Me.txtSPKNum = New System.Windows.Forms.TextBox()
        Me.cbRePrint = New System.Windows.Forms.CheckBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.btnCetak = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSize = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbWarna = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbStyle = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMerk = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgResult = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.cmbSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWarna.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMerk.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Blue
        Me.Panel1.Controls.Add(Me.Label76)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(354, 45)
        Me.Panel1.TabIndex = 176
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.White
        Me.Label76.Location = New System.Drawing.Point(8, 9)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(306, 23)
        Me.Label76.TabIndex = 0
        Me.Label76.Text = "CETAK BARCODE PRODUKSI"
        '
        'txtSPKYear
        '
        Me.txtSPKYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPKYear.Location = New System.Drawing.Point(14, 11)
        Me.txtSPKYear.MaxLength = 2
        Me.txtSPKYear.Name = "txtSPKYear"
        Me.txtSPKYear.Size = New System.Drawing.Size(55, 38)
        Me.txtSPKYear.TabIndex = 0
        Me.txtSPKYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 31)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 31)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "."
        '
        'txtSPKMid
        '
        Me.txtSPKMid.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPKMid.Location = New System.Drawing.Point(94, 10)
        Me.txtSPKMid.MaxLength = 4
        Me.txtSPKMid.Name = "txtSPKMid"
        Me.txtSPKMid.Size = New System.Drawing.Size(99, 38)
        Me.txtSPKMid.TabIndex = 1
        Me.txtSPKMid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSPKNum
        '
        Me.txtSPKNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPKNum.Location = New System.Drawing.Point(218, 10)
        Me.txtSPKNum.MaxLength = 4
        Me.txtSPKNum.Name = "txtSPKNum"
        Me.txtSPKNum.Size = New System.Drawing.Size(100, 38)
        Me.txtSPKNum.TabIndex = 2
        Me.txtSPKNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbRePrint
        '
        Me.cbRePrint.AutoSize = True
        Me.cbRePrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRePrint.Location = New System.Drawing.Point(12, 122)
        Me.cbRePrint.Name = "cbRePrint"
        Me.cbRePrint.Size = New System.Drawing.Size(85, 17)
        Me.cbRePrint.TabIndex = 3
        Me.cbRePrint.Text = "Cetak Ulang"
        Me.cbRePrint.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(228, 93)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(55, 20)
        Me.txtQty.TabIndex = 4
        Me.txtQty.Text = "0"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCetak
        '
        Me.btnCetak.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCetak.Location = New System.Drawing.Point(12, 276)
        Me.btnCetak.Name = "btnCetak"
        Me.btnCetak.Size = New System.Drawing.Size(336, 67)
        Me.btnCetak.TabIndex = 5
        Me.btnCetak.Text = "CETAK"
        Me.btnCetak.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(289, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "psg"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtSPKYear)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtSPKMid)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtSPKNum)
        Me.Panel2.Location = New System.Drawing.Point(12, 51)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 63)
        Me.Panel2.TabIndex = 186
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.cmbSize)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.cmbWarna)
        Me.Panel3.Controls.Add(Me.txtQty)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.cmbStyle)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.cmbMerk)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(12, 146)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(336, 124)
        Me.Panel3.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(199, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "Qty"
        '
        'cmbSize
        '
        Me.cmbSize.EditValue = ""
        Me.cmbSize.Location = New System.Drawing.Point(78, 93)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbSize.Properties.LookAndFeel.SkinName = "Caramel"
        Me.cmbSize.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbSize.Size = New System.Drawing.Size(115, 20)
        Me.cmbSize.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 194
        Me.Label7.Text = "Ukuran"
        '
        'cmbWarna
        '
        Me.cmbWarna.EditValue = ""
        Me.cmbWarna.Location = New System.Drawing.Point(78, 67)
        Me.cmbWarna.Name = "cmbWarna"
        Me.cmbWarna.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbWarna.Properties.LookAndFeel.SkinName = "Caramel"
        Me.cmbWarna.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbWarna.Size = New System.Drawing.Size(240, 20)
        Me.cmbWarna.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 192
        Me.Label6.Text = "Warna"
        '
        'cmbStyle
        '
        Me.cmbStyle.EditValue = ""
        Me.cmbStyle.Location = New System.Drawing.Point(78, 41)
        Me.cmbStyle.Name = "cmbStyle"
        Me.cmbStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbStyle.Properties.LookAndFeel.SkinName = "Caramel"
        Me.cmbStyle.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbStyle.Size = New System.Drawing.Size(240, 20)
        Me.cmbStyle.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 190
        Me.Label5.Text = "Artikel"
        '
        'cmbMerk
        '
        Me.cmbMerk.EditValue = ""
        Me.cmbMerk.Location = New System.Drawing.Point(78, 15)
        Me.cmbMerk.Name = "cmbMerk"
        Me.cmbMerk.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbMerk.Properties.LookAndFeel.SkinName = "Caramel"
        Me.cmbMerk.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmbMerk.Size = New System.Drawing.Size(240, 20)
        Me.cmbMerk.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 188
        Me.Label4.Text = "Merk"
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Location = New System.Drawing.Point(354, 51)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.Size = New System.Drawing.Size(461, 291)
        Me.dgResult.TabIndex = 187
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 349)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(336, 67)
        Me.Button1.TabIndex = 188
        Me.Button1.Text = "TUTUP"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmBarcodeProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(354, 423)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgResult)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCetak)
        Me.Controls.Add(Me.cbRePrint)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBarcodeProd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FACTORY SYSTEM"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.cmbSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWarna.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMerk.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents txtSPKYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSPKMid As System.Windows.Forms.TextBox
    Friend WithEvents txtSPKNum As System.Windows.Forms.TextBox
    Friend WithEvents cbRePrint As System.Windows.Forms.CheckBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents btnCetak As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSize As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbWarna As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbStyle As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMerk As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
