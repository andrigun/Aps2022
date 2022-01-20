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

Public Class ServiceHeader : Inherits SoapHeader
    Public usernameWS As String
    Public PasswordWS As String
End Class

Public Class ClsApp
    Inherits System.Web.Services.WebService
    Public secheader As ServiceHeader
    Dim sErrDesc As String
    Dim ErrDesc As String
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)

    <WebMethod(enableSession:=True)> _
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

	'dipakai page
	Public Function displaydataPageStatus(ByVal Akses As String, ByVal BranchId As String, ByVal Str2 As String, ByVal Str3 As String, ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totPage As Integer, ByVal orderBy As String, ByVal AscDesc As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String
		sCmd = "exec displaydatapagestatus '" & Akses & "','" & BranchId & "', '" & Str2 & "','" & Str3 & "'"
		oDs = oData.ExecuteQueryPageStatus(sCmd, ClsData.ReturnType.Paging, currPage, 10000, 1)

		Return oDs
	End Function

	'dipakai
	Public Function displayDataPageStatusList(ByVal Akses As String, ByVal statusid As String, ByVal searchname As String, ByVal BranchID As String, ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totPage As Integer, ByRef totRow As Integer, ByVal orderBy As String, ByVal AscDesc As String, ByVal filtering1 As String, ByVal filtering2 As String, ByVal filtering3 As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

		If ((statusid = "allstatus") Or (statusid = "")) Then
			statusid = "%"
			If searchname = "" Then searchname = "%"
		End If

		sCmd = "exec displayDataPageStatusList_sortsupport '" & Akses & "','" & statusid & "', '" & searchname & "', '" & BranchID & "', '" & orderBy & "', '" & AscDesc & "', '" & filtering1 & "', '" & filtering2 & "', '" & filtering3 & "'"

		oDs = oData.ExecuteQueryPaging(sCmd, ClsData.ReturnType.Paging, currPage, rowPerPage, totPage, totRow)

		Return oDs
	End Function

    'dipakai page
    Public Function displaydatapagedetailreview(ByVal str As String) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec displaydatapagedetailreview_New '" & str & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function


    'dipakai page
    Public Function displaydatapagescorelist(ByVal str As String) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec displaydatapagescorelist '" & str & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function

    Public Function displaydropdownlistcancel(ByVal str As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

		sCmd = "exec displaycancelcause '" & str & "'"

		oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
		Return oDs
	End Function

	'dipakai untuk mendapatkan nama status berdasarkan statusid
	Public Function displaystatusname(ByVal str As String) As DataSet
		Dim oDs As DataSet
		Dim oData As New ClsData
		Dim sCmd As String

		sCmd = "exec displaystatusname '" & str & "'"

		oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
		Return oDs
	End Function

    Public Function save_setdatastatus(ByVal setstatus As String, ByVal note As String, ByVal user As String, ByVal cabang As String, ByVal dataid As String, ByVal cancelid As String) As String
        Dim oData As New ClsData
        If Not oData.openConnection Then
            Return False
            sErrDesc = "Database Connection Failed."
        End If
        oData.beginTrans()
        Try
            Dim sCmd As String
            sCmd = "exec savesetstatus '" & setstatus & "','" & note & "'," &
                                                    "'" & user & "','" & cabang & "','" & dataid & "','" & cancelid & "'"
            oData.oCommand.CommandType = CommandType.Text
            oData.oCommand.CommandText = sCmd
            oData.oCommand.ExecuteNonQuery()
            oData.commitTrans()
            oData.closeConnection()
            Return True
        Catch ex As Exception
            sErrDesc = "Source : " & ex.Source & " , Desc : " & ex.Message
            oData.rollbackTrans()
            oData.closeConnection()
            Return False
        End Try
    End Function

    Public Function notif_to_BM_dropdata(ByVal setstatus As String, ByVal note As String, ByVal user As String, ByVal cabang As String, ByVal dataid As String, ByVal cancelid As String) As String
		Dim oData As New ClsData
		If Not oData.openConnection Then
			Return False
			sErrDesc = "Database Connection Failed."
		End If
		oData.beginTrans()
		Try
			Dim sCmd As String
			sCmd = "exec notif_to_BM_dropdata '" & setstatus & "','" & note & "'," &
													"'" & user & "','" & cabang & "','" & dataid & "','" & cancelid & "'"
			oData.oCommand.CommandType = CommandType.Text
			oData.oCommand.CommandText = sCmd
			oData.oCommand.ExecuteNonQuery()
			oData.commitTrans()
			oData.closeConnection()
			Return True
		Catch ex As Exception
			sErrDesc = "Source : " & ex.Source & " , Desc : " & ex.Message
			oData.rollbackTrans()
			oData.closeConnection()
			Return False
		End Try
	End Function

	Public Function notif_to_CRA_rerequest(ByVal setstatus As String, ByVal note As String, ByVal user As String, ByVal cabang As String, ByVal dataid As String, ByVal cancelid As String) As String
		Dim oData As New ClsData
		If Not oData.openConnection Then
			Return False
			sErrDesc = "Database Connection Failed."
		End If
		oData.beginTrans()
		Try
			Dim sCmd As String
			sCmd = "exec notif_to_CRA_rerequest '" & setstatus & "','" & note & "'," &
													"'" & user & "','" & cabang & "','" & dataid & "','" & cancelid & "'"
			oData.oCommand.CommandType = CommandType.Text
			oData.oCommand.CommandText = sCmd
			oData.oCommand.ExecuteNonQuery()
			oData.commitTrans()
			oData.closeConnection()
			Return True
		Catch ex As Exception
			sErrDesc = "Source : " & ex.Source & " , Desc : " & ex.Message
			oData.rollbackTrans()
			oData.closeConnection()
			Return False
		End Try
	End Function

    Public Function displaydatacustomerrelated(ByVal str As String) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec displaydatacustomerrelated '" & str & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function

    Public Function displaycatatandocpro(ByVal str As String) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec displaycatatandocpro '" & str & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function

    'dipakai
    Public Function save_setdatastatusdocpro(ByVal setstatus As String, ByVal note As String, ByVal user As String, ByVal cabang As String, ByVal dataid As String, ByVal statusbefore As String) As String
        Dim oData As New ClsData
        Dim sCmd As String

        If Not oData.openConnection Then
            Return False
            sErrDesc = "Database Connection Failed."
        End If
        oData.beginTrans()
        Try

            sCmd = "exec savesetstatus '" & setstatus & "','" & note & "'," &
                                                    "'" & user & "','" & cabang & "','" & dataid & "','" & statusbefore & "'"
            oData.oCommand.CommandType = CommandType.Text
            oData.oCommand.CommandText = sCmd
            oData.oCommand.ExecuteNonQuery()
            oData.commitTrans()
            oData.closeConnection()
            Return True
        Catch ex As Exception
            sErrDesc = "Source : " & ex.Source & " , Desc : " & ex.Message
            oData.rollbackTrans()
            oData.closeConnection()
            Return False
        End Try
    End Function

End Class
