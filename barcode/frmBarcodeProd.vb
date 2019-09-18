#Region "#Usings"
Imports System
Imports System.Collections.Generic
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting.BarCode
Imports DevExpress.XtraReports.UI
' ...
#End Region ' #Usings

Public Class frmBarcodeProd
    Dim test1 As New XtraReport1
    Dim r1 As Integer = 0, r2 As Integer = 0
    Dim aktif As Boolean = False

    Private Sub loadBrand()
        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "select brand_id kd_style, brand_desc nm_style from m_brand" & _
                             " where brand_status='O' and brand_type='PM'"
        command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter.SelectCommand = command
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            cmbMerk.Properties.DataSource = ds.Tables(0).DefaultView
            cmbMerk.Properties.DisplayMember = "nm_style"
            cmbMerk.Properties.ValueMember = "kd_style"

            'loadStyle()

            aktif = True
        End If
    End Sub

    Private Sub loadStyle()
        If aktif Then
            If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

            command.Connection = loadConnection
            command.CommandText = "select style_id kd_style, style_description nm_style from m_style" & _
                                 " where style_status='O' and style_type='PM' and style_brand_id='" & cmbMerk.EditValue & "'"
            command.CommandTimeout = 10000
            Dim ds As New DataSet
            dataAdapter.SelectCommand = command
            dataAdapter.Fill(ds)
            loadConnection.Close()

            If ds.Tables(0).Rows.Count > 0 Then
                cmbStyle.Properties.DataSource = ds.Tables(0).DefaultView
                cmbStyle.Properties.DisplayMember = "nm_style"
                cmbStyle.Properties.ValueMember = "kd_style"
            End If
        End If
    End Sub

    Private Sub loadColor()
        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "select '' color_id, '' color_description union" +
                                        " select DISTINCT  color_id, color_description from m_item, m_color" +
                                        " where item_color_id=color_id and color_status='O' and item_style_id='" & _
                                        cmbStyle.EditValue & "'"
        command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter.SelectCommand = command
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            cmbWarna.Properties.DataSource = ds.Tables(0).DefaultView
            cmbWarna.Properties.DisplayMember = "color_description"
            cmbWarna.Properties.ValueMember = "color_id"
        End If
    End Sub

    Private Sub loadSize()
        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "select '' size_id, '' size_description union" +
                                           " select DISTINCT  size_id, size_description from m_item, m_size" +
                                           " where item_size_id=size_id and size_status='O' and item_style_id='" & _
                                           cmbStyle.EditValue & "'"
        command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter.SelectCommand = command
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            cmbSize.Properties.DataSource = ds.Tables(0).DefaultView
            cmbSize.Properties.DisplayMember = "size_description"
            cmbSize.Properties.ValueMember = "size_id"
        End If
    End Sub

    Private Sub getSPK()
        Dim fullSPK As String = ""
        Dim rPrint As Integer = 0

        'test1.Dispose()
        test1.DataSet1.Clear()
        test1.dtSPK.Clear()

        'test1.
        If cbRePrint.Checked = False Then
            fullSPK = txtSPKYear.Text & txtSPKMid.Text & txtSPKNum.Text
            rPrint = 0
        Else
            rPrint = 1
        End If

        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "call cetak_barcodeProd('" & fullSPK & "','" & rPrint & "','" & _
                                cmbMerk.Text & "','" & cmbStyle.Text & "','" & cmbWarna.Text & "','" & _
                                cmbSize.Text & "','" & txtQty.Text & "')"
        command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter.SelectCommand = command
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            dgResult.DataSource = ds.Tables(0).DefaultView
        End If

        If cbRePrint.Checked Then
            Dim index As DataRow
            For a = 0 To dgResult.Rows.Count - 1
                For b = 1 To dgResult(6, a).Value
                    With test1
                        index = .dtSPK.NewRow
                        index(0) = dgResult(0, a).Value
                        index(1) = dgResult(1, a).Value
                        index(2) = dgResult(2, a).Value
                        index(3) = dgResult(3, a).Value
                        index(4) = dgResult(4, a).Value
                        index(5) = dgResult(5, a).Value
                        index(6) = 1
                        index(7) = dgResult(7, a).Value
                        index(8) = dgResult(8, a).Value
                        .dtSPK.Rows.Add(index)
                    End With
                Next
            Next
        Else
            Dim index As DataRow
            For a = 0 To dgResult.Rows.Count - 1
                For b = 1 To dgResult(6, a).Value
                    With test1
                        index = .dtSPK.NewRow
                        index(0) = dgResult(0, a).Value
                        index(1) = dgResult(1, a).Value
                        index(2) = dgResult(2, a).Value
                        index(3) = dgResult(3, a).Value
                        index(4) = dgResult(4, a).Value
                        index(5) = dgResult(5, a).Value
                        index(6) = 1
                        index(7) = dgResult(7, a).Value
                        index(8) = dgResult(8, a).Value
                        .dtSPK.Rows.Add(index)
                    End With
                Next
            Next
            '      dataAdapter.Fill(test1.dtSPK)
        End If
    End Sub

    Private Sub tryPrint()
        getSPK()

        'MsgBox(test1.dtSPK.Rows.Count)
        genRndNum()
        test1.XrLabel14.Text = CStr(Now.ToString("yy") & r1 & Now.ToString("dd") & r2 & Now.ToString("MM"))
        'test1.DataSource = test1.dtSPK
        'test1.XrLblStyle.DataBindings.Add("Text", Nothing, "STYLE")

        txtSPKNum.Focus()
        txtSPKNum.Text = ""

        test1.CreateDocument()
        test1.ShowPreviewDialog()
    End Sub

    Private Sub genRndNum()
        r1 = Microsoft.VisualBasic.Right(CInt(Math.Ceiling(Rnd() * 10)), 1)
        r2 = Microsoft.VisualBasic.Right(CInt(Math.Ceiling(Rnd() * 10)), 1)
    End Sub

    'Private Sub report_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs)
    '    ' Create a bar code control.
    '    Dim barCode As XRBarCode = CreateEAN13BarCode("13245649842")

    '    ' Create a Detail band and add the bar code to it.
    '    CType(sender, XtraReport).Bands.Add(New DetailBand())
    '    CType(sender, XtraReport).Bands(BandKind.Detail).Controls.Add(barCode)
    'End Sub

    'Public Function CreateEAN13BarCode(ByVal BarCodeText As String) As XRBarCode
    '    ' Create a bar code control.
    '    Dim barCode As New XRBarCode()

    '    ' Set the bar code's type to EAN 13.
    '    barCode.Symbology = New EAN13Generator()

    '    ' Adjust the bar code's main properties.
    '    barCode.Text = BarCodeText
    '    barCode.Width = 275
    '    barCode.Height = 200

    '    Return barCode
    'End Function

    Private Sub frmBarcodeProd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'End
    End Sub

    Private Sub frmBarcodeProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSPKYear.Text = Now.ToString("yy")

        loadBrand()
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        If cbRePrint.Checked = False Then
            If txtSPKMid.Text = "" Or txtSPKNum.Text = "" Then
                MsgBox("Cek SPK Anda!", MsgBoxStyle.Critical)
                If txtSPKMid.Text = "" Then
                    txtSPKMid.Focus()
                Else
                    txtSPKNum.Focus()
                End If
                Exit Sub
            End If

            If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

            command.Connection = loadConnection
            command.CommandText = "select pro_status_production, prod_qty" & _
                                " from t_product_hdr, t_product_dtl" & _
                                " where pro_doc_no=prod_doc_no and pro_org_cd='" & OrgCode & "'"
            Dim ds As New DataSet
            dataAdapter.SelectCommand = command
            dataAdapter.Fill(ds)
            loadConnection.Close()

            If ds.Tables(0).Rows.Count > 0 Then
                'If ds.Tables(0).Rows(0)(0).ToString = "N" Then
                '    MsgBox("SPK ini belum selesai diproduksi", MsgBoxStyle.Information)
                'Else
                'FrmReportViewBarcodeProd.ShowDialog()
                tryPrint()
                'End If
            Else
                MsgBox("SPK tidak terdaftar", MsgBoxStyle.Information)
            End If
        Else
            If cmbMerk.Text = "" Then
                MsgBox("Pilih Merk!", MsgBoxStyle.Critical)
                cmbMerk.Focus()
                Exit Sub
            End If

            If cmbStyle.Text = "" Then
                MsgBox("Pilih Artikel!", MsgBoxStyle.Critical)
                cmbStyle.Focus()
                Exit Sub
            End If

            If cmbWarna.Text = "" Then
                MsgBox("Pilih Warna!", MsgBoxStyle.Critical)
                cmbWarna.Focus()
                Exit Sub
            End If

            If cmbSize.Text = "" Then
                MsgBox("Pilih Ukuran!", MsgBoxStyle.Critical)
                cmbSize.Focus()
                Exit Sub
            End If

            If txtQty.Text = 0 Then
                MsgBox("Isi Qty!", MsgBoxStyle.Critical)
                txtQty.Focus()
                Exit Sub
            End If

            'FrmReportViewBarcodeProd.ShowDialog()
            tryPrint()
        End If
    End Sub

    Private Sub cmbMerk_EditValueChanged(sender As Object, e As EventArgs) Handles cmbMerk.EditValueChanged
        If cmbMerk.Text <> "" Then
            loadStyle()
        End If
    End Sub

    Private Sub cbRePrint_CheckedChanged(sender As Object, e As EventArgs) Handles cbRePrint.CheckedChanged
        If cbRePrint.Checked Then
            Panel2.Enabled = False
            Panel3.Enabled = True
        Else
            Panel2.Enabled = True
            Panel3.Enabled = False
        End If
    End Sub

    Private Sub txtSPKNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSPKNum.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    '--------------------------------------------------------------PRINTING AREA-----------------------------------------------------------

    Private Sub txtSPKMid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSPKMid.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSPKYear_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSPKYear.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmbStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cmbStyle.EditValueChanged
        If cmbStyle.Text <> "" Then
            loadColor()
            loadSize()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub txtSPKMid_TextChanged(sender As Object, e As EventArgs) Handles txtSPKMid.TextChanged
        If txtSPKMid.TextLength = 4 Then
            txtSPKNum.Focus()
        End If
    End Sub

    Private Sub txtSPKYear_TextChanged(sender As Object, e As EventArgs) Handles txtSPKYear.TextChanged
        If txtSPKYear.TextLength = 2 Then
            txtSPKMid.Focus()
        End If
    End Sub

    Private Sub txtSPKNum_TextChanged(sender As Object, e As EventArgs) Handles txtSPKNum.TextChanged
        If txtSPKNum.TextLength = 4 Then
            btnCetak.Focus()
        End If
    End Sub
End Class