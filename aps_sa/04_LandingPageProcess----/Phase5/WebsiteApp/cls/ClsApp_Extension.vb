Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Class ServiceHeader_Extension : Inherits SoapHeader
	Public usernameWS As String
	Public PasswordWS As String
End Class

Public Class ClsApp_Extension
	Inherits System.Web.Services.WebService
	Public secheader As ServiceHeader
	Dim sErrDesc As String
	Dim ErrDesc As String
	Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)

	<WebMethod(EnableSession:=True)>
	Public Function display_DataUs(ByVal pUs As String, ByVal pPw As String, ByVal pStr As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String = ""
		GlobalVariables.GlobaUserName_var = "abc"
		GlobalVariables.GlobalUserPass_var = pPw

		Dim r As New System.Text.RegularExpressions.Regex("^[a-zA-Z _.0-9]+$")
		If (r.IsMatch(pUs) = True And r.IsMatch(pPw) = True) Then
			sCmd = "exec display_LoginAccess_UserWeb '" & pUs & "', '" & pPw & "','" & pStr & "'"
		End If
		oDs = oData.executeQuerydisplay_DataUser(sCmd, ClsData.ReturnType.DataSet)
		With oDs.Tables(0)
			GlobalVariables.GlobaUserName = .Rows(0).Item("UserName")
			GlobalVariables.GlobalBranchId = .Rows(0).Item("BranchFullName")
			GlobalVariables.GlobalBranchFullName = .Rows(0).Item("BranchID")
			GlobalVariables.GlobalUserPass = .Rows(0).Item("pass")
		End With
		Return oDs
	End Function

	Public Function displayCamSurvey(ByVal orderNo As String, ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totPage As Integer, ByRef totRow As Integer, ByVal orderBy As String, ByVal AscDesc As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

        sCmd = "exec usp_qry_CAMsurvey_BNFMOSS '" & orderNo & "'"
		oDs = oData.ExecuteQueryPaging(sCmd, ClsData.ReturnType.Paging, currPage, rowPerPage, totPage, totRow)

		Return oDs
	End Function

    Public Function displaydatasurveyurutan(ByVal str As String) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec displaydatasurveyurutan '" & str & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function

    Public Function displaydatapagesurvey(ByVal str As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

		sCmd = "exec displaydatapagesurvey '" & str & "'"

		oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
		Return oDs
	End Function

	'calculator
	Public Function displaydatacalculator(ByVal str As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

		sCmd = "exec displaydatacalculator '" & str & "'"

		oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
		Return oDs
	End Function
	'load data survey I
	Public Function displaydatasurveyInII(ByVal str As String, ByVal str2 As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

		sCmd = "exec usp_qry_survey_BNFMOSS '" & str & "','" & str2 & "'"

		oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
		Return oDs
	End Function
	Public Function displaydatasurveyurutan(ByVal dfcId As Integer, ByVal noOrderConfins As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

		sCmd = "exec getdatasurveyurutan '" & dfcId & "','" & noOrderConfins & "'"

		oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
		Return oDs
	End Function


End Class
