Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.WebControls.ListControl
Imports System.Web.UI.WebControls.ListBox
Partial Public Class welcome
	Inherits System.Web.UI.Page
	Public sUserID As String
	Public sUserEncrypted As String
	Public sUserName As String
	Dim sbranch As String
	Dim akses As String
	Dim applicationid As String = "065"
	Dim usergroup As String
	Dim isUserBPCD As Boolean
	Dim isUserCA As Boolean
	Dim isUserCustomerCare As Boolean
	Dim isUserBM As Boolean
	Dim isUserPublic As Boolean
	Dim oUser As New clsUser
	Dim oComm As New clsCommon
	Dim setview As String
	Dim branchid As String
	Dim branchname As String
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oUser As New clsUser
        sUserID = Request.Form("txtUserName")
        sUserEncrypted = Request.Form("txtUserEncrypted")

        ' INGAT UNTUK DI REMARK
        'sUserID = "h.sumanta"
        'sUserEncrypted = "AaBCtDEnFGaHImJKuLMsNOhP"

        ' sUserID = "aunul.khalik"
        '  sUserEncrypted = "AkBCiDElFGaHIhJKkLMlNOuPQnRSuTUaV"

        '  sUserID = "hara.simatupang"
        ' sUserEncrypted = "AgBCnDEaFGpHIuJKtLMaNOmPQiRSsTUaVWrXYaZaha"

        'sUserID = "agung.pratama"
        'sUserEncrypted = "AaBCmDEaFGtHIaJKrLMpNOgPQnRSuTUgVWaX"

        sUserName = oUser.getUserNameIfValid(sUserID, sUserEncrypted)

        If sUserName <> "" Then
            storeSessionInfo()
        End If


        'detect windows login --start
        ''sUserID = Replace(System.Web.HttpContext.Current.User.Identity.Name, "BDF\", "")
        ''sUserID = "h_.sumanta"
        ''storeSessionInfo()
        'detect windows login --end

        Exit Sub

	End Sub

    Private Sub storeSessionInfo()
        Dim oDs As New DataSet
        Dim sErrDesc As String = ""
        oDs = oUser.getGroupIdBranch(sUserID, applicationid)

        If oDs.Tables(0).Rows.Count <> 0 Then
            With oDs.Tables(0).Rows(0)
                usergroup = Trim(.Item(0))
                branchid = Trim(.Item(1))
                branchname = Trim(.Item(2))
            End With
        End If

        Session("userid") = sUserID
        Session("branchid") = branchid
        Session("branchname") = branchname

        If usergroup = "06500" Then '"BPCD"
            Session("akses") = "BPCD"
            Response.Redirect("./form/BPCD_StartPage.aspx")
        ElseIf usergroup = "06501" Then ' "CA"
            Session("akses") = "CA"
            Response.Redirect("./form/CA_StartPage.aspx")
        ElseIf usergroup = "06502" Then ' "CustomerCare"
            Session("akses") = "CustomerCare"
            Response.Redirect("./form/CC_StartPage.aspx")
        ElseIf usergroup = "06503" Then '"BM"
            Session("akses") = "BM"
            Response.Redirect("./form/BM_StartPage.aspx")
        ElseIf usergroup = "06504" Then '"Public"
            Session("akses") = "Public"
            Response.Redirect("./form/Public_StartPage.aspx")
        ElseIf usergroup = "06505" Then '"Admin"
            Session("akses") = "Admin"
            Response.Redirect("./form/Admin_StartPage.aspx")
        End If

        Exit Sub
    End Sub

    Private Sub MessageBox(ByVal strMsg As String)
		Dim lbl As New Label
		lbl.Text = "<script language='javascript'>" & Environment.NewLine _
							 & "window.alert(" & "'" & strMsg & "'" & ")</script>"
		Page.Controls.Add(lbl)
		Exit Sub
	End Sub

End Class