Imports WebsiteApp.ClsData
Imports System.Web.UI.Page

Public Class clsUser
    Private _db_server As String = ConfigurationSettings.AppSettings("ServerAAM")
    Private _db_name As String = ConfigurationSettings.AppSettings("DatabaseAAM")
	Private _user_id As String = ConfigurationSettings.AppSettings("UserIdAAM")
	Private _pwd As String = ConfigurationSettings.AppSettings("PasswordAAM")

	Public Function getUserNameIfValid(ByVal userID As String, ByVal userEncrypted As String, Optional ByRef msg As String = "") As String
		Dim oData As New ClsData
		Dim sCmd As String
		sCmd = "exec getUserNameIfValid '" & userID & "', '" & userEncrypted & "'"
		Return oData.ExecuteQueryUserInfo(oData.getConnection(_db_server, _user_id, _pwd, _db_name), sCmd, ReturnType.oneColumn)
	End Function

	Public Function getUserInformation(ByVal userID As String) As DataSet
		Dim oData As New ClsData
		Dim sCmd As String
		sCmd = "select u.userName, ui.branchid, b.branchName, ui.jobpositionid, isnull(ug.groupid,'') as groupid, u.userid " &
						"from msuser u " &
						"left join userInformation ui on ui.userID = u.userID " &
						"left join msBranch b on ui.branchID = b.branchID " &
						"left join userGroup ug on u.userid = ug.userid and ug.groupid in ('06500', '06501', '06502', '06503') " &
						"where u.userID = '" & userID & "'"
		Return oData.ExecuteQueryUserInfo(oData.getConnection(_db_server, _user_id, _pwd, _db_name), sCmd, ClsData.ReturnType.DataSet)
		oData = Nothing
	End Function

    Public Function getGroupId(ByVal userID As String, ByVal groupID As String, Optional ByRef msg As String = "") As Boolean
        Dim oData As New ClsData
        Dim sCmd As String
        Dim sGroupID As String
        sCmd = "exec getGroupId '" & userID & "', '" & groupID & "'"
        sGroupID = oData.ExecuteQueryUserBranch(oData.getConnection(_db_server, _user_id, _pwd, _db_name), sCmd, ReturnType.oneColumn)
        If sGroupID = "" Or IsDBNull(sGroupID) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function getGroupIdBranch__xxx(ByVal userID As String, ByVal groupID As String, Optional ByRef msg As String = "") As Boolean
        Dim oData As New ClsData
        Dim sCmd As String
        Dim sGroupID As String
        sCmd = "exec getGroupId '" & userID & "', '" & groupID & "'"
        sGroupID = oData.ExecuteQueryUserBranch(oData.getConnection(_db_server, _user_id, _pwd, _db_name), sCmd, ReturnType.oneColumn)
        If sGroupID = "" Or IsDBNull(sGroupID) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function getUserDataBranch(ByVal userID As String, ByVal groupID As String) As DataSet
		Dim oData As New ClsData
		Dim sCmd As String
		sCmd = "select u.userName, ui.branchid, b.branchName, ui.jobpositionid " &
						"from msuser u " &
						"left join userInformation ui on ui.userID = u.userID " &
						"left join msBranch b on ui.branchID = b.branchID " &
						"where u.userID = '" & userID & "'"
		Return oData.ExecuteQueryUserBranch(oData.getConnection(_db_server, _user_id, _pwd, _db_name), sCmd, ClsData.ReturnType.DataSet)
		oData = Nothing
	End Function

	Public Function getGroupIdBranch(ByVal userID As String, ByVal groupID As String) As DataSet
		Dim oData As New ClsData
		Dim sCmd As String
		sCmd = "exec getGroupId '" & userID & "', '" & groupID & "'"
		Return oData.ExecuteQueryUserBranch(oData.getConnection(_db_server, _user_id, _pwd, _db_name), sCmd, ClsData.ReturnType.DataSet)
		oData = Nothing
	End Function

End Class