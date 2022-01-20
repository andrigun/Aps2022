Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail
Imports Microsoft.VisualBasic

Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.WebControls.ListControl
Imports System.Web.UI.WebControls.ListBox

Public Class ClsSendMail_SubmitCabang
    Public SmtpServer As String = ConfigurationSettings.AppSettings("SmtpServer")
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Public sender_sam As String = ConfigurationSettings.AppSettings("sender_sam")
    Public cp_sam1 As String = ConfigurationSettings.AppSettings("cp_sam1")
    Public cp_sam2 As String = ConfigurationSettings.AppSettings("cp_sam2")
    Public cp_sam3 As String = ConfigurationSettings.AppSettings("cp_sam3")
    Public cp_sam4 As String = ConfigurationSettings.AppSettings("cp_sam4")
    Public cp_sam5 As String = ConfigurationSettings.AppSettings("cp_sam5")
    Public sam_to As String = ConfigurationSettings.AppSettings("sam_to")
    Public sam_cc As String = ConfigurationSettings.AppSettings("sam_cc")
    Public sam_bcc As String = ConfigurationSettings.AppSettings("sam_bcc")
    Dim var_applicationid As String
    Dim var_assetseqno As Integer

    Dim oLoad As New ClsApp
    Dim fotocount As Integer

    Public Function SendMail(ByVal szSendTo As String, ByVal szSendFrom As String, ByVal szFromName As String, _
               ByVal notiftype As Integer, ByVal applicationid As String, ByVal assetseqno As String) As Boolean

        Dim oLoad As New ClsApp
        Dim oDs As New DataSet

        Dim sQuery As String

        var_applicationid = applicationid
        var_assetseqno = 5

		Dim isibody As String
        Dim konfis As String

        notiftype = 7

        If notiftype = 7 Then
            isibody = "<center><u><b><font style='font-family: Tahoma;font-size:large;'>" & ConfigurationSettings.AppSettings("annlelang") & "</font></b></u></center><br>"
        Else
            isibody = "<center><u><b><font style='font-family: Tahoma;font-size:large;'>" & ConfigurationSettings.AppSettings("annlangsung") & "</font></b></u></center><br>"
        End If

        isibody = isibody & "<table id='tbGrid1' cellSpacing='1' cellPadding='2'  border='0' width='853px' align='center'>"
        isibody = isibody & "<tr><td align='left' style='font-family: Tahoma;font-size:smaller;BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; BACKGROUND-COLOR: #e7e3e7;' colspan=3><b>INFORMASI ASSET</b></td></tr>"

        isibody = isibody & "<tr>"
        isibody = isibody & "<td style='width:22%;BACKGROUND-COLOR:#f4faff;font-family: Tahoma;font-size:smaller;'>Cabang</td><td>:</td>"
		isibody = isibody & "<td style='width:78%;BACKGROUND-COLOR:#ffffff;font-family: Tahoma;font-size:smaller;'>TESTING</td>"
		isibody = isibody & "</tr>"
        isibody = isibody & "</table><br>"

        'Holds message information.
        Dim mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()

        'Tidak perlu diubah-ubah (sama untuk live maupun testing)
        Dim SendFrom As String = sender_sam

        '!!!!!!! ATTENTION !!!!!!!!!!!
        '##### UNTUK APLIKASI REAL #########
        Dim SendTo As String = sam_to
        Dim SendCC As String = sam_cc
        Dim SendBCC As String = sam_bcc
        '##### UNTUK APLIKASI REAL #########

        mailMessage.From = New System.Net.Mail.MailAddress(SendFrom)
        mailMessage.To.Add(SendTo)
        mailMessage.CC.Add(SendCC)
        mailMessage.Bcc.Add(SendBCC)

        If notiftype = 7 Then
            mailMessage.Subject = ConfigurationSettings.AppSettings("annlelang")
        Else
            mailMessage.Subject = ConfigurationSettings.AppSettings("annlangsung")
        End If

        'Create two views, one text, one HTML.
        Dim plainTextView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString("body", Nothing, "text/plain")
        Dim htmlView As System.Net.Mail.AlternateView

        htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString("<html><body>" & isibody & "<br></body></html>", Nothing, "text/html")

        'Add two views to message.
        mailMessage.AlternateViews.Add(plainTextView)
        mailMessage.AlternateViews.Add(htmlView)

        'Send message
        Dim smtpClient As New System.Net.Mail.SmtpClient()
        smtpClient.Send(mailMessage)

        If sqlconapps.State = ConnectionState.Open Then
            sqlconapps.Close()
        End If

    End Function


    Sub cekfoto()
        If sqlconapps.State = ConnectionState.Closed Then
            sqlconapps.Open()
        End If
        Dim sQueryx As String
        sQueryx = "select distinct fotoid, fotodesc, isnull(fotofile,'') fotofile " & _
        "from mar_alamatpool_internal " & _
        "inner join mar_foto_internal on mar_alamatpool_internal.applicationid = mar_foto_internal.applicationid  and mar_alamatpool_internal.assetseqno=mar_foto_internal.assetseqno " & _
        "where mar_alamatpool_internal.branchid='" & Left(var_applicationid, 3) & "' and mar_alamatpool_internal.applicationid='" & var_applicationid & "' and mar_alamatpool_internal.assetseqno='" & var_assetseqno & "'" ' and fotoid<>null"

        Dim oAdapter As New SqlDataAdapter(sQueryx, sqlconapps)
        Dim oDsmar As New DataSet
        oAdapter.Fill(oDsmar, "DataSet")

        fotocount = oDsmar.Tables(0).Rows.Count

        If sqlconapps.State = ConnectionState.Open Then
            sqlconapps.Close()
        End If

    End Sub

    Public Function Terbilang(ByVal nilai As Long) As String
        Dim bilangan As String() = {"", "satu", "dua", "tiga", "empat", "lima", _
        "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas"}
        If nilai < 12 Then
            Return " " & bilangan(nilai)
        ElseIf nilai < 20 Then
            Return Terbilang(nilai - 10) & " belas"
        ElseIf nilai < 100 Then
            Return (Terbilang(CInt((nilai \ 10))) & " puluh") + Terbilang(nilai Mod 10)
        ElseIf nilai < 200 Then
            Return " seratus" & Terbilang(nilai - 100)
        ElseIf nilai < 1000 Then
            Return (Terbilang(CInt((nilai \ 100))) & " ratus") + Terbilang(nilai Mod 100)
        ElseIf nilai < 2000 Then
            Return " seribu" & Terbilang(nilai - 1000)
        ElseIf nilai < 1000000 Then
            Return (Terbilang(CInt((nilai \ 1000))) & " ribu") + Terbilang(nilai Mod 1000)
        ElseIf nilai < 1000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000))) & " juta") + Terbilang(nilai Mod 1000000)
        ElseIf nilai < 1000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000))) & " milyar") + Terbilang(nilai Mod 1000000000)
        ElseIf nilai < 1000000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000000))) & " trilyun") + Terbilang(nilai Mod 1000000000000)
        Else
            Return ""
        End If
    End Function

End Class
