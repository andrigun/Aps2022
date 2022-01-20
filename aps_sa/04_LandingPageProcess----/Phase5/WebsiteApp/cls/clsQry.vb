Imports System.Data
Imports System.Data.SqlClient

Public Class clsQry
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)

    Public Function getListCamSurvey(ByVal currPage As Integer, ByVal rowPerPage As Integer,
      ByRef totalPage As Integer, ByVal reffnumber As String) As DataSet

		Dim oDs6 As Object
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec usp_qry_CAMsurvey_BNFMOSS '" & reffnumber & "'"
        oDs6 = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet)

        Return oDs6

    End Function
    Public Function getListCalcuRefundDis(ByVal currPage As Integer, ByVal rowPerPage As Integer,
      ByRef totalPage As Integer, ByVal reffnumber As String) As DataSet

		Dim oDs6 As Object
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec uspRefundDisBurse '" & reffnumber & "'"
        oDs6 = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet)

        Return oDs6

	End Function
    Public Function loadCalculatorRefund(ByVal dfcId As Integer) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec uspRefundMax '" & dfcId & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function
	Public Function loadCalculatorCredit_tes(ByVal dfcid As Integer) As DataSet
        Dim oDs As Object
        Dim oData As New ClsData
		Dim sCmd As String
		Dim iErrNo

		sCmd = "exec displaydatacalculator '" & dfcid & "'"
		oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
		Return oDs

	End Function

    Public Function loadCalculatorCredit(ByVal dfcId As Integer) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec displaydatacalculator '" & dfcId & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function

    Public Function loadCalculatorCreditHistory(ByVal dfcId As Integer) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec displaydatacalculatorHistory '" & dfcId & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function

    Public Function inserttempRequestSurvey(ByVal reffnumber As String, ByVal usrid As String) As String
        Dim oData As New ClsData
        Dim sCmd As String
        Dim sMsg As String = ""
        Dim nEffected As Integer

        sCmd = "exec inserttempRequestSurvey '" & reffnumber & "', '" & usrid & "'"

        nEffected = oData.executeQuery(sCmd, ClsData.ReturnType.NonQueryExecute)

        If nEffected <> 0 Then
            Return "Sukses submit temp lock Survey"
        Else
            Return "Gagal submit temp lock Survey"
        End If

    End Function

    Public Function getDataRequestSurvey(ByVal reffnumber As String) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        sCmd = "exec getBlockByCA '" & reffnumber & "'"

        oDs = oData.ExecuteQuerydisplaydatapagedetailreview(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function
End Class
