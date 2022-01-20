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
Imports Microsoft.VisualBasic
Public Class Host_CamSurveyRO
    Inherits System.Web.UI.Page

    Dim reffnumber As String
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Public sQuery As String
    Dim oComm As New clsCommon
    Dim var_userid As String
    Dim isphototaken As String
    Dim varakses As String
    Dim sur As String
    Dim cekreffnumber As String
    Dim ceknationalid As String
    Dim cekname As String
    Dim cekbirthdate As String
    Dim cektempatlahirdebitur As String
    Dim cekmobile As String
    Dim cekvaruserid As String
    Dim reffnumberacak As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblactivity.Text = "View Data"
            userid.Text = Session("userid")
            branchid.Text = Session("branchid")
            reffnumber = Decrypt(HttpUtility.UrlDecode(Request.QueryString("reID")))
            reffnumberacak = Request.QueryString("reID")
            varakses = Session("akses")
        End If
        TabSelector(5)
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
    Private Function TabSelector(ByVal Tabno As Byte) As Byte
        Dim sHTML As String
        Dim tabnoselect As Byte
        Dim gotopage As String
        tabnoselect = Tabno
        gotopage = "reID=" & reffnumberacak & "&branchid=" & Session("branchid") & "&applicationid=" & Request.QueryString("applicationid") & "&assetseqno=" & Request.QueryString("assetseqno")
        sHTML = "<table width='793px' height='32px' cellpadding=0 cellspacing=0 border=0><tr>"
        If tabnoselect = 1 Then
            sHTML = sHTML & "<td width='190px' style='background-image:Images/Tab_on130.png;'><a class='urlImgOn' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Identitas Calon Debitur</a></td>"
        Else
            If varakses = "CA" Then
                sHTML = sHTML & "<td width='190px'><a href='Host_IndentitasCadebCA.aspx?" & gotopage & "' class='urlImg' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Identitas Calon Debiturl</a></td>"
            ElseIf varakses = "BM" Then
                sHTML = sHTML & "<td width='190px'><a href='Host_IndentitasCadebBM.aspx?" & gotopage & "' class='urlImg' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Identitas Calon Debiturl</a></td>"
            Else
                sHTML = sHTML & "<td width='190px'><a href='Host_IndentitasCadebRO.aspx?" & gotopage & "' class='urlImg' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Identitas Calon Debiturl</a></td>"
            End If
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 9 Then
            sHTML = sHTML & "<td width='100px' style='background-image:Images/Tab_on.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Score List</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='Host_ScorelistRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Score List</a></td>"
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 2 Then
            sHTML = sHTML & "<td width='100px' style='background-image:Images/Tab_on.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Cust. Related Data</a></td>"
        Else
            sHTML = sHTML & "<td width='100px'><a href='Host_CustRelatedDataRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Cust. Related Data</a></td>"
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 3 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Asset & Showroom</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='Host_AssetnShowroomRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Asset & Showroom</a></td>"
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 4 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Survey</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='Host_SurveyRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Survey</a></td>"
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 5 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;CAM Survey</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='Host_CamSurveyRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;CAM Survey</a></td>"
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 6 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='Host_CalculatorRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator</a></td>"
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 7 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator Refund</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='Host_CalculatorRefundRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator Refund</a></td>"
        End If
        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 8 Then
            sHTML = sHTML & "<td width='70px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Catatan Docpro</a></td>"
        Else
            sHTML = sHTML & "<td width='70px'><a href='Host_CatatanDocproRO.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Catatan Docpro</a></td>"
        End If
        sHTML = sHTML & "</tr></table>"
        tdtabdisplay.InnerHtml = sHTML
    End Function
End Class