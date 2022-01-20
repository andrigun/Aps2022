Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Public Class ucRefund
    Inherits System.Web.UI.UserControl
    Dim reffnumber As String
    Dim iCurrPage As Integer
    Dim iRowPerPage As Integer = 100
    Dim iTotalPage As Integer
    Dim oQry As New clsQry
    Dim nRowList As Integer
    Dim x As Integer
    Dim oDs As DataSet
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            reffnumber = Decrypt(HttpUtility.UrlDecode(Request.QueryString("reID")))
        Else
            reffnumber = ""
        End If
        loadCalculatorRefundMax(reffnumber)
        loadCalculatorRefundDisburse(reffnumber)
    End Sub
    Private Sub loadCalculatorRefundDisburse(reffnumber)
        oQry = New clsQry
        oDs = oQry.getListCalcuRefundDis(iCurrPage, iRowPerPage, iTotalPage, reffnumber)
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

        ' Header
        sTable = "<table border='1' style='cell-spacing:0; cell-padding:0; border-collapse:collapse;border-color:cornflowerblue;border-width:thin;'>" &
                "<thead><tr style='background-color:cornflowerblue; font-weight:bold;color:#fff'>" &
                "  <th  class='w3-border judul' width='10px' align='left'>No. </th> " &
                 " <th   class='w3-border judul' width='200px' align='left'>PIC</th>" &
                 " <th  class='w3-border judul' width='200px' align='left'>Jabatan</th>" &
                 " <th  class='w3-border judul' width='200px' align='left'>Porsi</th>" &
                 " <th  class='w3-border judul' width='200px' align='left'>Disburse Amount</th>" &
                 "</tr></thead>"

        iNo = (iCurrPage - 1) * iRowPerPage
        'MsgBox(nRow)
        If nRow <> -1 Then
            For x = 0 To nRow
                With oDs.Tables(0)
                    sTable = sTable & "<tr >"
                    sTable = sTable & "<td class='w3-border detail' align='left' width='10px'>" & x + 1 & "</td>"
                    sTable = sTable & "<td class='w3-border detail' align='left' width='200px'>" & .Rows(x).Item(3) & "</td>"
                    sTable = sTable & "<td class='w3-border detail' align='left' width='200px'>" & .Rows(x).Item(4) & "</td>"
                    sTable = sTable & "<td class='w3-border detail' align='right' width='200px'>" & .Rows(x).Item(5) & "</td>"
                    sTable = sTable & "<td class='w3-border detail' align='right' width='200px'>" & .Rows(x).Item(6) & "</td>"

                End With
                sTable = sTable & "</tr>"
            Next
        Else
            sTable = sTable & "<td colspan='5' class='w3-border detail' align='center'><font color='red'>Data Belum Ada</font></td>"
        End If
        txtRowCount.Value = x
        sTable = sTable & "</table>"
        divList.InnerHtml = sTable
    End Sub
    Private Sub loadCalculatorRefundMax(reffnumber)
        Dim oDsur As DataSet
        oDsur = oQry.loadCalculatorRefund(reffnumber)
        With oDsur.Tables(0)
            nRowList = oDsur.Tables(0).Rows.Count
            nRowList = oDsur.Tables(0).Rows.Count - 1
            If oDsur.Tables(0).Rows.Count <> 0 Then
                txtRCustomerName.Text = .Rows(x).Item("custName")
                txtRProspectNo.Text = .Rows(x).Item("prospectNo")
                txtRCondition.Text = .Rows(x).Item("assetUsedNew")
                txtRNamaSupplier.Text = .Rows(x).Item("namaSupplier")
                txtRDAdmin.Text = .Rows(x).Item("refundAdmin_disburse")
                txtRDAsuransi.Text = .Rows(x).Item("refundAsuransi_disburse")
                txtRDBunga.Text = .Rows(x).Item("refundBunga_disburse")
                txtRDProvisi.Text = .Rows(x).Item("refundProvisi_disburse")
                txtRDTotal.Text = .Rows(x).Item("refundTOTAL_disburse")
                txtRHAdmin.Text = .Rows(x).Item("refundAdmin_hold")
                txtRHAsuransi.Text = .Rows(x).Item("refundAsuransi_hold")
                txtRHBunga.Text = .Rows(x).Item("refundBunga_hold")
                txtRHProvisi.Text = .Rows(x).Item("refundProvisi_hold")
                txtRHTotal.Text = .Rows(x).Item("refundTOTAL_hold")
            Else
            End If
        End With
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