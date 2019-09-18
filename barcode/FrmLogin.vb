Imports System.Data.Odbc
Imports System.Text
Public Class FrmLogin
    Public userGroup As String = ""

    Private Function ceklogin() As Boolean
        sqlSelect = "select user_name,user_password,user_id, user_group from m_user where user_name = '" & TxtUsername.Text & _
                        "' and user_org_cd='" & cmbOrg.SelectedValue & "'"
        ds = New DataSet()
        loadConnection.Open()
        dataAdapter = New OdbcDataAdapter(sqlSelect, loadConnection)
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count = 0 Then
            Return False
        Else
            'strUsername = FrmVigenere.Decipher("ganteng", TxtPassword.Text)
            strUsername = (Me.TxtUsername.Text).ToUpper 'CStr(ds.Tables(0).Rows(0).Item(0))
            strPassword = CStr(ds.Tables(0).Rows(0).Item(1))
            'TextBox1.Text = Convert.ToBase64String(Encoding.ASCII.GetBytes(TxtPassword.Text))
            TxtPassword.Text = TxtPassword.Text
            CurrentUID = CStr(ds.Tables(0).Rows(0).Item(2))
            userGroup = ds.Tables(0).Rows(0)("user_group").ToString

            sqlSelect = "select MSP_ORG_CD,MSP_ORG_NAME FROM M_SETUP_parameter "
            ds = New DataSet()
            loadConnection.Open()
            dataAdapter = New OdbcDataAdapter(sqlSelect, loadConnection)
            dataAdapter.Fill(ds)
            loadConnection.Close()
            'FrmMaster.ToolStripStatusLabel3.Text = cmbOrg.Text
            'frm
            'OrgCode = CStr(ds.Tables(0).Rows(0).Item(0))
            'OrgName = CStr(ds.Tables(0).Rows(0).Item(1))
            'OrgCode = cmbOrg.SelectedValue
            'TxtPassword.Text = Convert.ToBase64String(Encoding.ASCII.GetBytes(TxtPassword.Text))
            If Me.TxtPassword.Text <> strPassword Then
                Return False
            Else
                'MsgBox(TxtPassword.Text + " " & strPassword)
                Return True
            End If
        End If
    End Function

    Private Sub getOrg()
        If loadConnection.State = ConnectionState.Closed Then loadConnection.Open()

        command.Connection = loadConnection
        command.CommandText = "select msp_org_cd from m_setup_parameter"
        dataAdapter = New OdbcDataAdapter(command.CommandText, loadConnection)
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            OrgCode = ds.Tables(0).Rows(0)(0).ToString
        End If
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'gIcon = My.Resources.vigano_remix
        'Me.Icon = gIcon
        'If Date.Now >= "17-FEB-2014" Then
        '    MsgBox("Program sudah tidak dapat digunakan, hubungi TIM IT anda!!")
        '    End
        'End If
        getOrg()
        loadOrg()
        'Me.cmbOrg.Focus()
        cmbOrg.Enabled = False
    End Sub

    Private Sub loadOrg()
        If loadConnection.State = ConnectionState.Closed Then
            loadConnection.Open()
        End If

        Dim sql As String = "select org_code, org_name from m_organization" & _
                            " where org_status='O' order by org_code"
        'command.CommandText = "select org_code, org_name from m_organization order by org_code"
        'command.CommandTimeout = 10000
        Dim ds As New DataSet
        dataAdapter = New OdbcDataAdapter(sql, loadConnection)
        dataAdapter.Fill(ds)
        loadConnection.Close()

        If ds.Tables(0).Rows.Count > 0 Then
            cmbOrg.DataSource = ds.Tables(0).DefaultView
            cmbOrg.DisplayMember = "ORG_NAME"
            cmbOrg.ValueMember = "ORG_CODE"

            cmbOrg.SelectedValue = OrgCode
        End If
    End Sub

    Private Sub TxtUsername_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUsername.TextChanged
        'Me.TxtUsername.Text = UCase(TxtUsername.Text)
        TxtUsername.SelectionStart = Len(TxtUsername.Text)
    End Sub

    Private Sub TxtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword.KeyPress
        If e.KeyChar = Chr(13) And Not Me.TxtPassword.Text.Trim = "" Then
            Me.OK.Focus()
        End If
    End Sub

    Private Sub Cancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub OK_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If cmbOrg.Text = "" Then
            MsgBox("Organisasi tidak boleh kosong")
            cmbOrg.Focus()
            Exit Sub
        End If

        If Me.TxtUsername.Text = "" Then
            MsgBox("Nama Tidak Boleh Kosong")
            Me.TxtUsername.Focus()
            'ElseIf Me.TxtPassword.Text = "" Then
            '    MsgBox("Password Tidak Boleh Kosong")
            '    Me.TxtPassword.Focus()
        Else
            If Me.ceklogin = False Then
                MsgBox("Nama Atau Password salah")
                Me.TxtUsername.Clear()
                Me.TxtPassword.Clear()
                Me.TxtUsername.Focus()
            Else
                'FrmMaster.lblUserName.Text = TxtUsername.Text.ToUpper
                Me.Hide()
                'FrmMaster.ShowDialog()
                'frmBarcodeProd.ShowDialog()
                Form3.ShowDialog()

                'Form3.ShowDialog()
            End If
        End If
    End Sub

    Private Sub FrmLogin_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'If MsgBox("Apakah anda yakin ingin menutup halaman ini??", MsgBoxStyle.YesNo) = MsgBoxResult.No Then e.Cancel = True
    End Sub

    Private Sub cmbOrg_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbOrg.Validating
        If cmbOrg.Text <> "" Then
            Dim ada As Boolean = False
            For a = 0 To cmbOrg.Items.Count - 1
                If cmbOrg.Text = cmbOrg.Items(a)("org_name").ToString Then
                    ada = True
                    Exit For
                End If
            Next

            If ada = True Then
                If loadConnection.State = ConnectionState.Closed Then
                    loadConnection.Open()
                End If

                Dim sql As String = "select org_level_number from m_organization where org_code='" & cmbOrg.SelectedValue & "'"
                'command.CommandText = "select level_number from m_organization where org_code='" & cmbOrg.SelectedValue & "'"
                'command.CommandTimeout = 10000
                Dim ds As New DataSet
                dataAdapter = New OdbcDataAdapter(sql, loadConnection)
                'dataAdapter.SelectCommand = command
                dataAdapter.Fill(ds)
                loadConnection.Close()

                If ds.Tables(0).Rows.Count > 0 Then
                    levelNumber = ds.Tables(0).Rows(0)(0).ToString
                End If
            Else
                MsgBox("Silakan memilih Organisasi yang ada")
                cmbOrg.Text = ""
                e.Cancel = True
            End If
        End If
    End Sub
End Class
