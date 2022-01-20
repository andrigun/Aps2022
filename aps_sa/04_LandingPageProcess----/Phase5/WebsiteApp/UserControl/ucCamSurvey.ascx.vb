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
Public Class ucCamSurvey
    Inherits System.Web.UI.UserControl
    Dim reffnumber As String
    Dim oDs As DataSet
    Dim oQry As clsQry
    Dim iCurrPage As Integer
    Dim iRowPerPage As Integer = 100
    Dim iTotalPage As Integer
    Dim orderNoConfins As String
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oLoad As New ClsApp_Extension
        Dim nRowList As Integer
        Dim x As Integer

        If Not Me.IsPostBack Then
            reffnumber = Decrypt(HttpUtility.UrlDecode(Request.QueryString("reID")))
        Else
            reffnumber = ""
        End If

        Dim oDsur As DataSet
        oDsur = oLoad.displaydatapagesurvey(reffnumber)
        With oDsur.Tables(0)
            nRowList = oDsur.Tables(0).Rows.Count
            nRowList = oDsur.Tables(0).Rows.Count - 1
            If oDsur.Tables(0).Rows.Count <> 0 Then
                orderNoConfins = .Rows(x).Item("orderNo_Confins")
            Else
            End If
        End With
        loadImei(orderNoConfins)
    End Sub
    Private Sub loadImei(orderNoConfins)
        oQry = New clsQry
        oDs = oQry.getListCamSurvey(iCurrPage, iRowPerPage, iTotalPage, orderNoConfins)
        generateDataList()
    End Sub
    Private Sub generateDataList()
        Dim nCol, y As Byte
        Dim nRow, x As Integer
        Dim sTable As String
        Dim sTable2 As String
        Dim Ksng As String = ""
        Dim iNo As Integer
        Dim id As String = ""

        nCol = oDs.Tables(0).Columns.Count - 1
        nRow = oDs.Tables(0).Rows.Count - 1
        sTable = ""
        sTable = "<table border='1' style='cell-spacing:0; cell-padding:0; border-collapse:collapse;border-color:cornflowerblue;border-width:thin;'>" &
                "<thead><tr style='background-color:cornflowerblue; font-weight:bold;color:#fff'>" &
                "  <th  class='w3-border judul' width='3%' align='left'>No. </th> " &
                 " <th   class='w3-border judul' width='27%' align='left'>Question</th>" &
                 " <th  class='w3-border judul' width='35%' align='left'>Survey I</th>" &
                 " <th  class='w3-border judul' width='35%' align='left'>Survey II</th>" &
                 "</tr></thead>"
        iNo = (iCurrPage - 1) * iRowPerPage
        If nRow <> -1 Then
            For x = 0 To nRow
                With oDs.Tables(0)
                    sTable = sTable & "<tr onclick=""rowClickPhone('" & .Rows(x).Item(0) & "','" & .Rows(x).Item(0) & "')"" >"
                    sTable = sTable & "<td class='w3-border detail' align='left' width='3%'>" & x + 1 & "</td>"
                    sTable = sTable & "<td class='w3-border detail' align='left' width='27%'>" & .Rows(x).Item(0) & "</td>"
                    sTable = sTable & "<td class='w3-border detail' align='left' width='35%' style='word-break: break-all'>" & .Rows(x).Item(1) & "</td>"
                    sTable = sTable & "<td class='w3-border detail' align='left' width='35%' style='word-break: break-all'>" & .Rows(x).Item(2) & "</td>"
                End With
                sTable = sTable & "</tr>"
            Next
        Else
            sTable = sTable & "<td colspan='4' class='w3-border detail' align='center'><font color='red'>Belum Dilakukan Survey</font></td>"
        End If
        txtRowCount.Value = x
        sTable = sTable & "</table>"
        divList.InnerHtml = sTable
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
    End Function
End Class