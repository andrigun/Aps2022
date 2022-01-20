Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Web.Mail
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports System.Web.Services.WebService
Imports System.Net
Imports System.Net.HttpRequestHeader
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ucCatatanDocpro
    Inherits System.Web.UI.UserControl
    Dim reffnumber As String
    Dim varuserid As String
    Dim varcabang As String
    Dim varakses As String
    Dim varstatus As String
    Dim varstatusbefore As String
    Dim vartbdstatusid As String
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Public sQueryUpdate As New SqlCommand()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As Integer
        Dim oLoad As New ClsApp
        Dim OComm As New clsCommon
        Dim nRowList As Integer
        Dim sTableList, tdRowList As String

        reffnumber = Session("reffnumber")
        txtUserId.Value = Session("userid")
        txtCabang.Value = Session("branchid")
        varuserid = Session("userid")
        varcabang = Session("branchid")
        varakses = Session("akses")

        ''###############################
        'varuserid = "a"
        'varakses = "BPCD"
        ''userid.Text = "usr.testing"
        ''branchid.Text = "801"
        'txtUserId.Value = "usr.testing"
        'txtCabang.Value = "801"
        'reffnumber = "34151"
        'Session("reffnumber") = reffnumber
        ''#################################

        savingdata.Visible = False

        If Not Me.IsPostBack Then
            Dim oDsur As DataSet
            oDsur = oLoad.displaycatatandocpro(reffnumber) 'masih hardcore
            nRowList = oDsur.Tables(0).Rows.Count - 1
            sTableList = ""
            With oDsur.Tables(0)
                If .Rows.Count <> 0 Then
                    txtCustomerName.Text = .Rows(x).Item("firstName")
                    txtProspectNo.Text = .Rows(x).Item("prospectno")
                    txtOrderNo.Text = .Rows(x).Item("orderNo_Confins")
                    txtNamaSupplier.Text = .Rows(x).Item("NamaSupplier")
                    txtAssetType.Text = .Rows(x).Item("AssetType")
                    varstatus = .Rows(x).Item("logstatus")
                    vartbdstatusid = .Rows(x).Item("tbdstatusid")
                Else
                    txtCustomerName.Text = ""
                    txtProspectNo.Text = ""
                    txtOrderNo.Text = ""
                    txtNamaSupplier.Text = ""
                    txtAssetType.Text = ""
                End If
                If (vartbdstatusid = "RDNAP" Or vartbdstatusid = "NAP") Then
                    If (varakses = "Admin") Then
                        Button2.Visible = True
                        txtnotes.ReadOnly = False
                        txtlabelnotes.Text = "Return Notes"
                        txttitikdua.Text = ":"
                        btnrespond.Visible = False
                    Else
                        Button2.Visible = False
                        btnrespond.Visible = False
                        txtnotes.Visible = False
                        txttitikdua.Visible = False
                        txtlabelnotes.Visible = False
                    End If
                ElseIf vartbdstatusid = "RTDPO" Then
                    If (varakses = "BM" Or varakses = "CA" Or varakses = "Admin") Then
                        txtnotes.ReadOnly = False
                        Button2.Visible = False
                        btnrespond.Visible = True
                        txtlabelnotes.Text = "Respond Notes"
                        txttitikdua.Text = ":"
                    Else
                        Button2.Visible = False
                        btnrespond.Visible = False
                        txtnotes.Text = .Rows(x).Item("lognote")
                        txtnotes.ReadOnly = True
                        txtlabelnotes.Text = "Return Notes"
                        txttitikdua.Text = ":"
                    End If
                ElseIf vartbdstatusid = "BRRSP" Then
                    If (varakses = "Admin") Then
                        Button2.Visible = True
                        txtnotes.ReadOnly = False
                        btnrespond.Visible = False
                        txtlabelnotes.Text = "Return Notes"
                        txttitikdua.Text = ":"
                    Else
                        Button2.Visible = False
                        btnrespond.Visible = False
                        txtnotes.Text = .Rows(x).Item("lognote")
                        txtlabelnotes.Text = "Respond Notes"
                        txtnotes.ReadOnly = True
                        txttitikdua.Text = ":"
                    End If
                Else
                    Button2.Visible = False
                    btnrespond.Visible = False
                    txtnotes.Visible = False
                    txtlabelnotes.Visible = False
                    txttitikdua.Visible = False
                End If

                sTableList = sTableList & "<table  class='tablegrid' cellSpacing='1' cellPadding='2'  border='0' width='930px' style='border-collapse:collapse;'>"
                sTableList = sTableList & "<tr style='height:40px;'>"
                sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;' align='center' width='130px'><b>Status</b></td>"
                sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;' align='center' width='170px'><b>Status Date</b</td>"
                sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;' align='center' width='100px'><b>User</b></td>"
                sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;' align='center' width='500px'><b>User Notes</b></td>"
                sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;' align='center' width='30px'><b>Branch Id.</b></td>"
                sTableList = sTableList & "<tr>"
                If .Rows(x).Item("loghistoryid") <> 0 Then
                    For x = 0 To nRowList
                        If x Mod 2 = 1 Then tdRowList = "tdganjil" Else tdRowList = "tdgenap" ''ubah warna perbaris
                        sTableList = sTableList & "<tr>"
                        sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("logstatus") & "</td>"
                        sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' align='center' >&nbsp;" & .Rows(x).Item("logstatusdate") & " (" & .Rows(x).Item("logstatustime") & ")</td>"
                        sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("loguserid") & "</td>"
                        sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("lognote") & "</td>"
                        sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("logbranchid") & "</td>"
                        sTableList = sTableList & "</tr>"

                    Next
                Else
                    sTableList = sTableList & "<tr><td colspan='4'><center>History Return tidak tersedia</center></td></tr>"
                End If
                sTableList = sTableList & "</table>"
            End With
            viewcekduplikat.InnerHtml = sTableList
        End If
        Exit Sub
    End Sub
    Private Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
        Exit Function
    End Function
    Protected Sub OnConfirm(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        On Error GoTo errHandle
        Dim lbl As New Label
        Dim bIsSuspend As Boolean
        Dim sErrDesc As String = ""
        Dim varnotes As String
        Dim confirmValue As String = Request.Form("confirm_value")
        Dim a As String
        Dim oData As Boolean
        Dim oLoad As New ClsApp
        Dim str As String
        varnotes = txtnotes.Text

        If confirmValue = "Yes" Then
            savingdata.Visible = False
            Button2.Visible = False
            txtnotes.ReadOnly = True
            Dim oDs As New DataSet
            Dim sQuery As String
            sQuery = "select reffnumber, statusid from tbldetail where reffnumber =" & reffnumber
            Dim nRowList As Integer
            Dim oAdapter As New SqlDataAdapter(sQuery, sqlconapps)
            Dim oDsmar As New DataSet
            oAdapter.Fill(oDsmar, "DataSet")
            nRowList = oDsmar.Tables(0).Rows.Count - 1
            If nRowList >= 0 Then
                varstatusbefore = oDsmar.Tables(0).Rows(0).Item(1)
            End If
            oData = oLoad.save_setdatastatusdocpro("RTDPO", varnotes, varuserid, varcabang, reffnumber, varstatusbefore)  'isi status before di sini
            If oData = True Then
                str = "Update status data berhasil."
            Else
                str = "Update status data gagal."
            End If
        Else
            a = "no"
        End If
errHandle:
        Exit Sub
    End Sub
    Protected Sub OnRespondBranch(ByVal sender As Object, ByVal e As EventArgs) Handles btnrespond.Click
        On Error GoTo errHandle
        Dim lbl As New Label
        Dim bIsSuspend As Boolean
        Dim sErrDesc As String = ""
        Dim varnotes As String
        Dim confirmValue As String = Request.Form("confirm_value")
        Dim a As String
        Dim oData As Boolean
        Dim oLoad As New ClsApp
        Dim str As String
        varnotes = txtnotes.Text

        If confirmValue = "Yes" Then
            savingdata.Visible = False
            Button2.Visible = False
            btnrespond.Visible = False
            txtnotes.ReadOnly = True
            Dim oDs As New DataSet
            Dim sQuery As String
            sQuery = "Select top 1 startpointid, reffnumber, status, dtminsert " &
                "From tblhistoryreturnprocessstartpoint " &
                "Where reffnumber =" & reffnumber & " Order By startpointid desc"
            Dim nRowList As Integer
            Dim oAdapter As New SqlDataAdapter(sQuery, sqlconapps)
            Dim oDsmar As New DataSet
            oAdapter.Fill(oDsmar, "DataSet")
            nRowList = oDsmar.Tables(0).Rows.Count - 1
            If nRowList >= 0 Then
                varstatusbefore = oDsmar.Tables(0).Rows(0).Item(2)
            End If
            oData = oLoad.save_setdatastatusdocpro("BRRSP", varnotes, varuserid, varcabang, reffnumber, varstatusbefore)
            If oData = True Then
                str = "Update status data berhasil."
            Else
                str = "Update status data gagal."
            End If
        Else
            a = "no"
        End If
errHandle:
        Exit Sub
    End Sub
End Class