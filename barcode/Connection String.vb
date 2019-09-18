Imports System.Data.Odbc
Imports Microsoft.Win32
Module Connection_String
    Public gIcon As System.Drawing.Icon
    Public usercode As String
    Public employee_name As String
    'Dim constring As String = "DRIVER={MySQL ODBC 3.51 Driver};" _
    '                & "SERVER=localhost;" _
    '                & "DATABASE=counter;" _
    '                & "UID=Edarwin;" _
    '                & "PWD=edarwin;"
    Public strUsername As String = ""
    Public constring As String = "DSN=FactorySystem;"
    'Public constring As String = "DSN=FactorySystem;DATABASE=FactorySystem;UID=root;PWD=123456789"
    'Public constring As String = "DSN=FactorySystem;DATABASE=FactorySystem;UID=root;PWD=password"
    Public loadConnection As New OdbcConnection(constring)
    Public dataAdapter As OdbcDataAdapter
    Public sqlSelect As String
    Public ds As New DataSet()
    Public ds1 As New DataSet()
    Public ds2 As New DataSet()
    Public ds3 As New DataSet()
    Public ds4 As New DataSet()
    Public ds5 As New DataSet()
    Public ds6 As New DataSet()
    Public transaction As OdbcTransaction
    Public command As New OdbcCommand
    Public strPassword As String = ""
    Public CurrentUID As String = ""
    Public OrgCode As String = ""
    Public OrgName As String = ""
    Public levelNumber As String = ""

End Module
