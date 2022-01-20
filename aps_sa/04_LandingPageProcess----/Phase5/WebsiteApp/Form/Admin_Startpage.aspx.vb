Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Data
Imports System.Data.SqlClient
Public Class Admin_Startpage
    Inherits System.Web.UI.Page
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Public sQuery As String
    Dim oComm As New clsCommon
    Dim nRowList As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'settimeout in minute
        Session.Timeout = 3600
        If Not IsPostBack Then
            txtUserID.Value = Session("userid")
            txtBranchId.Value = Session("branchid")
            txtAccess.Value = Session("akses")
            userid.Text = Session("userid")
            branchid.Text = Session("branchid")
            If Session("userid") = "" Then
                Exit Sub
            End If
            currentTime.Text = DateTime.Now.ToLongTimeString
            Dim nRow, x As Integer
            Dim sTable As String
            Dim akses As String
            Dim branchid2 As String
            Dim Str2 As String '= "Admin"
            Dim Str3 As String = ""
            Dim orderby As String = ""
            Dim ascdesc As String = ""
            akses = txtAccess.Value
            Str2 = txtAccess.Value
            branchid2 = txtBranchId.Value
            currentTime.Text = DateTime.Now.ToLongTimeString
            sQuery = "exec displaydatapagestatus '" & akses & "','" & branchid2 & "', '" & Str2 & "','" & Str3 & "'"
            Dim oAdapter As New SqlDataAdapter(sQuery, sqlconapps)
            Dim oDs2 As New DataSet
            oAdapter.Fill(oDs2, "DataSet")
            nRow = oDs2.Tables(0).Rows.Count - 1
            sTable = ""
            sTable = sTable & " <table border = '0'  align='left' style='width:1200px;border-collapse:collapse;'>"
            With oDs2.Tables(0)
                For x = 0 To nRow
                    If (x = 0 Or x = 8 Or x = 16 Or x = 24) Then
                        sTable = sTable & "<tr>"
                    End If
                    If .Rows(x).Item("progress") = 0 Then
                        sTable = sTable & "<td width=1200px><a style='cursor:pointer;' class='buttonlink' onclick=""openstatuslist('" & LTrim(RTrim(.Rows(x).Item("statusid"))) & "')"">" & .Rows(x).Item("statusname") & " :<br><center>" & .Rows(x).Item("jmlstatus") & "</center></a></td>"
                    ElseIf .Rows(x).Item("progress") > 0 Then
                        sTable = sTable & "<td width=1200px><a style='cursor:pointer;' class='buttonlinkAdd' onclick=""openstatuslist('" & LTrim(RTrim(.Rows(x).Item("statusid"))) & "')"">" & .Rows(x).Item("statusname") & " :<br><center>" & .Rows(x).Item("jmlstatus") & "<br>(Up : " & .Rows(x).Item("progress") & ")</center></a></td>"
                    ElseIf .Rows(x).Item("progress") < 0 Then
                        sTable = sTable & "<td width=1200px><a style='cursor:pointer;' class='buttonlinkMin' onclick=""openstatuslist('" & LTrim(RTrim(.Rows(x).Item("statusid"))) & "')"">" & .Rows(x).Item("statusname") & " :<br><center>" & .Rows(x).Item("jmlstatus") & "<br>(Down : " & .Rows(x).Item("progress") & ")</center></a></td>"
                    End If
                    If (x = 7 Or x = 15 Or x = 23) Then
                        sTable = sTable & "</tr>"
                    End If
                Next
            End With
            sTable = sTable & "</table>"
            Dynamic_Panel.InnerHtml = sTable
            If sqlconapps.State = ConnectionState.Open Then
                sqlconapps.Close()
            End If
        End If
        Exit Sub
    End Sub
    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                 &H65, &H64, &H76, &H65, &H64, &H65,
                 &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
    Protected Sub btnredirect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnredirect.Click
        Response.Redirect(String.Format("Host_IndentitasCadebRO.aspx?isviewinvho=0&reID={0}&view=info", HttpUtility.UrlEncode(Encrypt(txtdataid.Value))))
        Exit Sub
    End Sub
    Private Sub MessageBox(ByVal strMsg As String)
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                             & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Page.Controls.Add(lbl)
        Exit Sub
    End Sub
    Protected Sub refreshTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim nRow, x As Integer
        Dim sTable As String
        Dim akses As String
        Dim branchid As String
        Dim Str2 As String '= "Admin"
        Dim Str3 As String = ""
        Dim orderby As String = ""
        Dim ascdesc As String = ""
        akses = txtAccess.Value
        Str2 = txtAccess.Value
        branchid = txtBranchId.Value
        currentTime.Text = DateTime.Now.ToLongTimeString
        sQuery = "exec displaydatapagestatus '" & akses & "','" & branchid & "', '" & Str2 & "','" & Str3 & "'"
        Dim oAdapter As New SqlDataAdapter(sQuery, sqlconapps)
        Dim oDs2 As New DataSet
        oAdapter.Fill(oDs2, "DataSet")
        nRow = oDs2.Tables(0).Rows.Count - 1
        sTable = ""
        sTable = sTable & " <table border = '0'  align='left' style='width:1200px;border-collapse:collapse;'>"
        With oDs2.Tables(0)
            For x = 0 To nRow
                If (x = 0 Or x = 8 Or x = 16 Or x = 24) Then
                    sTable = sTable & "<tr>"
                End If
                If .Rows(x).Item("progress") = 0 Then
                    sTable = sTable & "<td width=1200px><a style='cursor:pointer;' class='buttonlink' onclick=""openstatuslist('" & LTrim(RTrim(.Rows(x).Item("statusid"))) & "')"">" & .Rows(x).Item("statusname") & " :<br><center>" & .Rows(x).Item("jmlstatus") & "</center></a></td>"
                ElseIf .Rows(x).Item("progress") > 0 Then
                    sTable = sTable & "<td width=1200px><a style='cursor:pointer;' class='buttonlinkAdd' onclick=""openstatuslist('" & LTrim(RTrim(.Rows(x).Item("statusid"))) & "')"">" & .Rows(x).Item("statusname") & " :<br><center>" & .Rows(x).Item("jmlstatus") & "<br>(Up : " & .Rows(x).Item("progress") & ")</center></a></td>"
                ElseIf .Rows(x).Item("progress") < 0 Then
                    sTable = sTable & "<td width=1200px><a style='cursor:pointer;' class='buttonlinkMin' onclick=""openstatuslist('" & LTrim(RTrim(.Rows(x).Item("statusid"))) & "')"">" & .Rows(x).Item("statusname") & " :<br><center>" & .Rows(x).Item("jmlstatus") & "<br>(Down : " & .Rows(x).Item("progress") & ")</center></a></td>"
                End If
                If (x = 7 Or x = 15 Or x = 23) Then
                    sTable = sTable & "</tr>"
                End If
            Next
        End With
        sTable = sTable & "</table>"
        Dynamic_Panel.InnerHtml = sTable
        If sqlconapps.State = ConnectionState.Open Then
            sqlconapps.Close()
        End If
    End Sub
End Class