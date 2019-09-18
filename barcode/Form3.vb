Public Class Form3

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim nilaieven As Integer = 0, nilaiodd As Integer = 0
        ''MsgBox(TextBox1.Text.Length)
        'For i = 0 To TextBox1.Text.Length - 1 Step 1
        '    If i Mod 2 = 0 Then
        '        nilaieven += CInt(TextBox1.Text(i).ToString)
        '    Else
        '        nilaiodd += CInt(TextBox1.Text(i).ToString)
        '    End If
        'Next
        'Dim z As Int16, aa As Object
        'z = 3 * nilaiodd + nilaieven
        'For i = z To z + 10 Step 1
        '    aa = i / 10
        '    If InStr(aa, ".") Then
        '        'do nothing
        '    Else
        '        aa = aa * 10
        '        Exit For
        '    End If
        'Next
        'Dim nilaiakhir As Integer
        'nilaiakhir = aa - z
        'MsgBox(nilaiakhir)
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SPKFinishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SPKFinishToolStripMenuItem.Click
        frmSPKFinish.ShowDialog()
    End Sub

    Private Sub CetakBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
        frmBarcodeProd.ShowDialog()
    End Sub

    Private Sub TutupAplikasiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TutupAplikasiToolStripMenuItem.Click
        End
    End Sub
End Class