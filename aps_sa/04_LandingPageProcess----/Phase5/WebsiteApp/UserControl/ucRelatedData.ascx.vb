Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Data
Imports System.Data.SqlClient

Public Class ucRelatedData
	Inherits System.Web.UI.UserControl
	Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
	Public sQuery As String
	Dim oComm As New clsCommon
	Dim nRowList As Integer
	Dim reffnumber As String
	Dim orderNoConfins As String
	Dim surveyIvalue As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDs As DataSet
        Dim oLoad As New ClsApp
        Dim OComm As New clsCommon
        Dim nRow, x As Integer
        Dim sTable As String = ""
        Dim reltype1 As String = ""
        Dim reltype2 As String = ""

        If Not Me.IsPostBack Then
            reffnumber = Decrypt(HttpUtility.UrlDecode(Request.QueryString("reID")))
        Else
            reffnumber = ""
        End If

        oDs = oLoad.displaydatacustomerrelated(reffnumber)
        nRow = oDs.Tables(0).Rows.Count - 1

        If oDs.Tables(0).Rows.Count <> 0 Then
            sTable = sTable & " <table border = '0'  align='left' style='width:780px;border-collapse:collapse;'>"
            With oDs.Tables(0)
                For x = 0 To nRow
                    If reltype1 <> .Rows(x).Item("RelatedType") Then
                        reltype2 = reltype1
                        reltype1 = .Rows(x).Item("RelatedType")
                        sTable = sTable & "<tr><td colspan=3><b><u>" & .Rows(x).Item("RelatedType") & "</b></u></td></tr>"
                    End If
                    sTable = sTable & "<tr><td width=250px valign='top'>"
                    sTable = sTable & "<table><tr><td>&#8226;&nbsp;</td><td>Nama : " & .Rows(x).Item("nama") & "</td></tr>"
                    sTable = sTable & "<tr><td>&nbsp;</td><td>NIK : " & .Rows(x).Item("nik") & "</td></tr>"
                    sTable = sTable & "<tr><td>&nbsp;</td><td>Tgl. Lahir : " & .Rows(x).Item("TglLahir") & "</td></tr>"
                    sTable = sTable & "<tr><td>&nbsp;</td><td>Mobile : " & .Rows(x).Item("mobile") & "</td></tr>"
                    sTable = sTable & "</table>"
                    sTable = sTable & "</td><td width=340px valign='top'>"
                    sTable = sTable & "<Table Class='tablescoring'>"
                    sTable = sTable & "<tr>"
                    sTable = sTable & "<td width='120px' Class='tablescoringhead'>Scoring Name</td>"
                    sTable = sTable & "<td width='100px' Class='tablescoringhead'>Result</td>"
                    sTable = sTable & "<td width='100px' Class='tablescoringhead'>Decision</td>"
                    sTable = sTable & "</tr>"
                    sTable = sTable & "<tr>"
                    sTable = sTable & "<td Class='tablescoringtd'>E-KTP</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("E_KTP_Result") & "</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("E_KTP_Decision") & "</td>"
                    sTable = sTable & "</tr>"
                    sTable = sTable & "<tr>"
                    sTable = sTable & "<td Class='tablescoringtd'>APPI</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("APPI_Result") & "</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("APPI_Decision") & "</td>"
                    sTable = sTable & "</tr>"
                    sTable = sTable & "<tr>"
                    sTable = sTable & "<td Class='tablescoringtd'>SLIK</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("SLIK_Result") & "</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("SLIK_Decision") & "</td>"
                    sTable = sTable & "</tr>"
                    sTable = sTable & "<tr>"
                    sTable = sTable & "<td Class='tablescoringtd'>Pefindo</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("Pefindo_Result") & "</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("Pefindo_Decision") & "</td>"
                    sTable = sTable & "</tr>"
                    sTable = sTable & "<tr>"
                    sTable = sTable & "<td Class='tablescoringtd'>Telco</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("Telco_Result") & "</td>"
                    sTable = sTable & "<td Class='tablescoringtd'>" & .Rows(x).Item("Telco_Decision") & "</td>"
                    sTable = sTable & "</tr>"
                    sTable = sTable & "</table><br>"
                    sTable = sTable & "</td><td valign='top' width='190px'>Final Decision : " & .Rows(x).Item("finaldecision") & "</td></tr>"
                Next
            End With
            sTable = sTable & "</table>"
            viewrelationship.InnerHtml = sTable
        Else
            sTable = "<table><tr>"
            sTable = sTable & "<td width='800px'><br>(Informasi Customer Related Data Belum Tersedia)</td>"
            sTable = sTable & "</tr></table>"
            viewrelationship.InnerHtml = sTable
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
	End Function

End Class