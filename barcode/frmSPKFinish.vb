Public Class frmSPKFinish
    Dim selesai As Boolean = False

    Private Sub frmSPKFinish_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getSPK()

        dgSPK.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite

        dgHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.AntiqueWhite
        txtSPKYear.Text = Now.ToString("yy")
    End Sub

    Private Sub getSPK()
        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "select pro_doc_no SPK, pro_so_no SP from t_product_hdr where pro_status_production='N' order by pro_doc_no"
        command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter.SelectCommand = command
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            dgSPK.DataSource = ds.Tables(0).DefaultView
            dgSPK.Columns(1).ReadOnly = True
            dgSPK.Columns(2).ReadOnly = True
        End If
    End Sub

    Private Sub dgSPK_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgSPK.CellValidating

    End Sub

    Private Sub dgSPK_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgSPK.CellValueChanged

    End Sub

    Private Sub dgSPK_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgSPK.CurrentCellDirtyStateChanged
        If dgSPK.Rows.Count > 0 Then
            If dgSPK.CurrentCell.ColumnIndex = 0 Then
                If dgSPK.CurrentRow.Cells(0).Value = True Then
                    getProd(dgSPK.CurrentRow.Index)
                Else
                    For a = dgSPKDtl.Rows.Count - 1 To 0 Step -1
                        If dgSPK.CurrentRow.Cells("spk").Value = dgSPKDtl(0, a).Value Then
                            dgSPKDtl.Rows.RemoveAt(a)
                        End If
                    Next
                End If

                dgSPK.EndEdit()
            End If
        End If
    End Sub

    Private Sub getProd(x As Integer)
        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "select prod_doc_no, prod_item_cd, prod_qty from t_product_dtl, m_item" & _
                            " where prod_item_cd = item_code and prod_doc_no='" & _
                            dgSPK("spk", x).Value & "' order by prod_doc_no"
        command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter.SelectCommand = command
        dataAdapter.Fill(ds)
        loadConnection.Close()

        Dim index As Integer = 0
        If ds.Tables(0).Rows.Count > 0 Then
            For a = 0 To ds.Tables(0).Rows.Count - 1
                dgSPKDtl.Rows.Add()
                index = dgSPKDtl.Rows.Count - 1
                dgSPKDtl(0, index).Value = ds.Tables(0).Rows(a)(0).ToString
                dgSPKDtl(1, index).Value = ds.Tables(0).Rows(a)(1).ToString
                dgSPKDtl(2, index).Value = ds.Tables(0).Rows(a)(2).ToString
                dgSPKDtl(3, index).Value = dgSPK(2, x).Value
            Next
        End If
    End Sub

    Private Sub getProd1(fSPK As String)
        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "select prod_doc_no, prod_item_cd, prod_qty, pro_so_no" & _
                            " from t_product_hdr, t_product_dtl, m_item" & _
                            " where prod_item_cd = item_code and prod_doc_no='" & fSPK & _
                            "' and pro_doc_no=prod_doc_no and pro_status_production='N' order by prod_doc_no "
        command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter.SelectCommand = command
        dataAdapter.Fill(ds)
        loadConnection.Close()

        Dim index As Integer = 0
        If ds.Tables(0).Rows.Count > 0 Then
            For a = 0 To ds.Tables(0).Rows.Count - 1
                dgSPKDtl.Rows.Add()
                index = dgSPKDtl.Rows.Count - 1
                dgSPKDtl(0, index).Value = ds.Tables(0).Rows(a)(0).ToString
                dgSPKDtl(1, index).Value = ds.Tables(0).Rows(a)(1).ToString
                dgSPKDtl(2, index).Value = ds.Tables(0).Rows(a)(2).ToString
                dgSPKDtl(3, index).Value = ds.Tables(0).Rows(a)(3).ToString
            Next

            selesai = False
        Else
            MsgBox("No SPK " & fSPK & " sudah selesai", MsgBoxStyle.Information)
            selesai = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'End
        Me.Dispose()
    End Sub

    Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click
        'If dgSPK.Rows.Count > 0 Then
        '    Dim adaData As Boolean = False
        '    For a = 0 To dgSPK.Rows.Count - 1
        '        If dgSPK(0, a).Value = True Then
        '            adaData = True
        '            Exit For
        '        End If
        '    Next

        '    If adaData = False Then
        '        MsgBox("Tidak ada SPK yg dicentang", MsgBoxStyle.Information)
        '    Else
        '        updateSPK
        '    End If
        'Else
        '    MsgBox("Tidak ada data", MsgBoxStyle.Information)
        'End If

        Dim adaData As Boolean = False
        Dim str As String = ""
        str = txtSPKYear.Text & txtSPKMid.Text & txtSPKNum.Text
        If dgHistory.Rows.Count > 0 Then
            For a = 0 To dgHistory.Rows.Count - 1
                If dgHistory(0, a).Value = str Then
                    adaData = True

                    Exit For
                End If
            Next

            If adaData Then
                MsgBox("No SPK ini sudah selesai", MsgBoxStyle.Information)
            Else
                updateSPK2()

                If selesai Then
                    Exit Sub
                End If

                dgHistory.Rows.Add()
                dgHistory(0, dgHistory.Rows.Count - 1).Value = str

                txtSPKMid.Text = ""
                txtSPKNum.Text = ""
                dgSPKDtl.Rows.Clear()

                txtSPKMid.Focus()
            End If
        Else
            updateSPK2()

            If selesai Then
                Exit Sub
            End If

            dgHistory.Rows.Add()
            dgHistory(0, dgHistory.Rows.Count - 1).Value = str

            txtSPKMid.Text = ""
            txtSPKNum.Text = ""
            dgSPKDtl.Rows.Clear()

            txtSPKMid.Focus()
        End If
    End Sub

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

    'Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
    '    If Asc(e.KeyChar) <> 8 Then
    '        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    Private Sub updateSPK2()
        Try
            Dim str As String = ""
            str = txtSPKYear.Text & txtSPKMid.Text & txtSPKNum.Text

            getProd1(str)

            If selesai Then
                Exit Sub
            End If

            loadConnection.Open()
            transaction = loadConnection.BeginTransaction

            command.Connection = loadConnection
            command.Transaction = transaction



            command.CommandText = "update t_product_hdr set pro_status_production='Y'" & _
                                    " where pro_doc_no='" & str & "'"
            command.CommandTimeout = 10000
            command.ExecuteNonQuery()

            'ToolStripProgressBar1.Value = 0
            'ToolStripProgressBar1.Minimum = 0
            'ToolStripProgressBar1.Maximum = dgSPKDtl.Rows.Count

            For b = 0 To dgSPKDtl.Rows.Count - 1
                command.CommandText = "insert into s_stock_movement set `move_level_number`='" & levelNumber & _
                                                        "', `move_org_cd`='" & OrgCode & "', move_item_id='" & dgSPKDtl(1, b).Value & _
                                                        "', move_txn_type='34', move_txn_date=now(),move_txn_no='" & dgSPKDtl(0, b).Value & _
                                                        "', move_reff_no='" & dgSPKDtl(3, b).Value & "', move_cost_unit='0" & _
                                                        "', move_qty='" & Format(dgSPKDtl(2, b).Value, "General Number") & _
                                                        "', move_qty2=0, move_landed_cost='0" & _
                                                        "', create_date=now(), create_by='" & CurrentUID & _
                                                        "', mod_date=now(), mod_by='" & CurrentUID & "',move_supplier_id=''"
                command.CommandTimeout = 10000
                command.ExecuteNonQuery()

                command.CommandText = "select * from s_stock_master where stock_item_code='" & dgSPKDtl(1, b).Value & "'"
                command.CommandTimeout = 10000
                Dim ds0 As New DataSet
                dataAdapter.SelectCommand = command
                dataAdapter.Fill(ds0)

                If ds0.Tables(0).Rows.Count > 0 Then
                    command.CommandText = "update s_stock_master set stock_qty=stock_qty+" & _
                                        Format(dgSPKDtl(2, b).Value, "General Number") & _
                                        ", stock_landed_cost=0" & _
                                        ", mod_by='" & CurrentUID & "', mod_date=now(), tag_no=0" & _
                                        " where stock_item_code='" & dgSPKDtl(1, b).Value & "'"
                    command.CommandTimeout = 10000
                    command.ExecuteNonQuery()
                Else
                    'command.CommandText = "insert into s_stock_master (select '" & levelNumber & "','" & OrgCode & _
                    '                        "', item_code," & AVGCOST & _
                    '                        "," & Format(dgResult(a, dgResult.CurrentRow.Index).Value, "General Number") & _
                    '                        ",'','" & CurrentUID & "',now(),'" & CurrentUID & "',now(), 0, 0 from m_item, m_size where item_style_id='" & _
                    '                        ds.Tables(0).Rows(0)("style_id").ToString & "' and item_color_id='" & _
                    '                        ds.Tables(0).Rows(0)("color_id").ToString & "' and item_size_id=size_id and size_description='" & _
                    '                        dgResult.Columns(a).HeaderText & "')"
                    command.CommandText = "insert into s_stock_master set `stock_level_number`='" & levelNumber & _
                                                    "',`stock_org_cd`='" & OrgCode & _
                                                    "',`stock_item_code`='" & dgSPKDtl(1, b).Value & _
                                                    "',`stock_qty`=" & Format(dgSPKDtl(2, b).Value, "General Number") & _
                                                    ",`stock_qty2`='0" & _
                                                    "',`stock_supplier_id`='" & _
                                                    "',`create_by`='" & CurrentUID & "',`create_date`=now()" & _
                                                    ",`mod_by`='" & CurrentUID & "',`mod_date`=now()" & _
                                                    ",`stock_landed_cost`='0'"
                    command.CommandType = CommandType.Text
                    command.CommandTimeout = 10000
                    command.ExecuteNonQuery()
                End If

                'For a = 0 To dgSPKDtl.Rows.Count - 1
                'If dgSPK(0, a).Value = True Then

                'cek tiap spk di suspect SP udah diproduksi apa belum
                command.CommandText = "select * from t_product_hdr where pro_status_production='N' and pro_so_no='" & _
                                    dgSPKDtl(3, b).Value & "';"
                command.CommandTimeout = 10000
                Dim DNS As New DataSet
                dataAdapter.SelectCommand = command
                dataAdapter.Fill(DNS)

                If DNS.Tables(0).Rows.Count = 0 Then
                    command.CommandText = "update t_sales_order_hdr set so_flag='PR' where so_doc_no='" & dgSPKDtl(3, b).Value & "'"
                    command.CommandTimeout = 10000
                    command.ExecuteNonQuery()
                    'End If
                End If
                'Next

                'ToolStripProgressBar1.Value += 1
            Next

            transaction.Commit()
            MsgBox("Selesai")
        Catch ex As System.Exception
            MsgBox(ex.Message)
            transaction.Rollback()
        Finally
            loadConnection.Close()
            'Me.Dispose()
        End Try
    End Sub

    Private Sub updateSPK()
        Try
            loadConnection.Open()
            transaction = loadConnection.BeginTransaction

            command.Connection = loadConnection
            command.Transaction = transaction

            For a = 0 To dgSPK.Rows.Count - 1
                If dgSPK(0, a).Value = True Then
                    command.CommandText = "update t_product_hdr set pro_status_production='Y'" & _
                                        " where pro_doc_no='" & dgSPK(1, a).Value & "'"
                    command.CommandTimeout = 10000
                    command.ExecuteNonQuery()
                End If
            Next

            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = dgSPKDtl.Rows.Count

            For b = 0 To dgSPKDtl.Rows.Count - 1
                command.CommandText = "insert into s_stock_movement set `move_level_number`='" & levelNumber & _
                                                        "', `move_org_cd`='" & OrgCode & "', move_item_id='" & dgSPKDtl(1, b).Value & _
                                                        "', move_txn_type='34', move_txn_date=now(),move_txn_no='" & dgSPKDtl(0, b).Value & _
                                                        "', move_reff_no='" & dgSPKDtl(3, b).Value & "', move_cost_unit='0" & _
                                                        "', move_qty='" & Format(dgSPKDtl(2, b).Value, "General Number") & _
                                                        "', move_qty2=0, move_landed_cost='0" & _
                                                        "', create_date=now(), create_by='" & CurrentUID & _
                                                        "', mod_date=now(), mod_by='" & CurrentUID & "',move_supplier_id=''"
                command.CommandTimeout = 10000
                command.ExecuteNonQuery()

                command.CommandText = "select * from s_stock_master where stock_item_code='" & dgSPKDtl(1, b).Value & "'"
                command.CommandTimeout = 10000
                Dim ds0 As New DataSet
                dataAdapter.SelectCommand = command
                dataAdapter.Fill(ds0)

                If ds0.Tables(0).Rows.Count > 0 Then
                    command.CommandText = "update s_stock_master set stock_qty=stock_qty+" & _
                                        Format(dgSPKDtl(2, b).Value, "General Number") & _
                                        ", stock_landed_cost=0" & _
                                        ", mod_by='" & CurrentUID & "', mod_date=now(), tag_no=0" & _
                                        " where stock_item_code='" & dgSPKDtl(1, b).Value & "'"
                    command.CommandTimeout = 10000
                    command.ExecuteNonQuery()
                Else
                    'command.CommandText = "insert into s_stock_master (select '" & levelNumber & "','" & OrgCode & _
                    '                        "', item_code," & AVGCOST & _
                    '                        "," & Format(dgResult(a, dgResult.CurrentRow.Index).Value, "General Number") & _
                    '                        ",'','" & CurrentUID & "',now(),'" & CurrentUID & "',now(), 0, 0 from m_item, m_size where item_style_id='" & _
                    '                        ds.Tables(0).Rows(0)("style_id").ToString & "' and item_color_id='" & _
                    '                        ds.Tables(0).Rows(0)("color_id").ToString & "' and item_size_id=size_id and size_description='" & _
                    '                        dgResult.Columns(a).HeaderText & "')"
                    command.CommandText = "insert into s_stock_master set `stock_level_number`='" & levelNumber & _
                                                    "',`stock_org_cd`='" & OrgCode & _
                                                    "',`stock_item_code`='" & dgSPKDtl(1, b).Value & _
                                                    "',`stock_qty`=" & Format(dgSPKDtl(2, b).Value, "General Number") & _
                                                    ",`stock_qty2`='0" & _
                                                    "',`stock_supplier_id`='" & _
                                                    "',`create_by`='" & CurrentUID & "',`create_date`=now()" & _
                                                    ",`mod_by`='" & CurrentUID & "',`mod_date`=now()" & _
                                                    ",`stock_landed_cost`='0'"
                    command.CommandType = CommandType.Text
                    command.CommandTimeout = 10000
                    command.ExecuteNonQuery()
                End If

                For a = 0 To dgSPK.Rows.Count - 1
                    If dgSPK(0, a).Value = True Then
                        'cek tiap spk di suspect SP udah diproduksi apa belum
                        command.CommandText = "select * from t_product_hdr where pro_status_production='N' and pro_so_no='" & _
                                            dgSPK(2, a).Value & "';"
                        command.CommandTimeout = 10000
                        Dim DNS As New DataSet
                        dataAdapter.SelectCommand = command
                        dataAdapter.Fill(DNS)

                        If DNS.Tables(0).Rows.Count = 0 Then
                            command.CommandText = "update t_sales_order_hdr set so_flag='PR' where so_doc_no='" & dgSPK(2, a).Value & "'"
                            command.CommandTimeout = 10000
                            command.ExecuteNonQuery()
                        End If
                    End If
                Next

                ToolStripProgressBar1.Value += 1
            Next

            transaction.Commit()
            MsgBox("Selesai")
        Catch ex As System.Exception
            MsgBox(ex.Message)
            transaction.Rollback()
        Finally
            loadConnection.Close()
            Me.Dispose()
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtSP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSP.KeyPress
        Select Case e.KeyChar
            Case "0"c To "9"c ' digits allowed
            Case ChrW(Keys.Back) ' backspace allowed for deleting (Delete key automatically overrides)
            Case ChrW(Keys.Enter) ' backspace allowed for deleting (Delete key automatically overrides)
                If Len(txtSP.Text) < 9 Then
                    MsgBox("Format No SP tidak sesuai")
                Else
                    Dim baris As Integer = 0
                    For a = 0 To dgSPK.Rows.Count - 1
                        If dgSPK(2, a).Value = txtSP.Text Then
                            baris = baris + 1
                        End If
                    Next

                    ToolStripProgressBar1.Value = 0
                    ToolStripProgressBar1.Minimum = 0
                    ToolStripProgressBar1.Maximum = baris
                    For a = 0 To dgSPK.Rows.Count - 1
                        If dgSPK(2, a).Value = txtSP.Text Then
                            dgSPK(0, a).Value = True

                            getProd(a)

                            ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1
                            dgSPK.CurrentCell = dgSPK.Item(0, a)
                        End If
                    Next
                End If
            Case Else ' everything else ....
                e.Handled = True ' .... and it's just like you never pressed a key at all
                'SendKeys.Send("0")
        End Select
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSP.TextChanged

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub txtSPKYear_TextChanged(sender As Object, e As EventArgs) Handles txtSPKYear.TextChanged
        If txtSPKYear.TextLength = 2 Then
            txtSPKMid.Focus()
        End If
    End Sub

    Private Sub txtSPKMid_TextChanged(sender As Object, e As EventArgs) Handles txtSPKMid.TextChanged
        If txtSPKMid.TextLength = 4 Then
            txtSPKNum.Focus()
        End If
    End Sub

    Private Sub txtSPKNum_TextChanged(sender As Object, e As EventArgs) Handles txtSPKNum.TextChanged
        If txtSPKNum.TextLength = 4 Then
            btnFinish.Focus()
        End If
    End Sub
End Class