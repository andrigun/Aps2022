Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ClsRes

    Dim sErrDesc As String = ""

    'LoadListAps(sPksNo, sSupplier, RequestFrom, RequestTo, Agreementno, AprDateFrom, AprDateTo)
    Public Function LoadListAps(ByVal sPksNo As String, ByVal sSupplier As String,
                                ByVal RequestFrom As String, ByVal RequestTo As String,
                                 ByVal AprDateFrom As String,
                                ByVal AprDateTo As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spLoadListAps  '" & sPksNo & "' ,  '" & sSupplier & "'  , "
        sCmd += " '" & RequestFrom & "' ,  '" & RequestTo & "' ,   "
        sCmd += " '" & AprDateFrom & "' ,  '" & AprDateTo & "' "

        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs

    End Function
    Public Function GetAPSDetailByAPSid(RequestID) As DataSet
        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spGetAPSDetailByAPSid  '" & RequestID & "'   "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs
    End Function
    Public Function ViewAgreementCard(ByVal agreementno As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spViewAgreementCard  '" & agreementno & "'   "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs

    End Function
    Public Function GetCustomerDetail(ByVal Inquirydate As String, ByVal AgreementNo As String,
                                      ByVal NoKTP As String, ByVal TTL As String,
                                       ByVal Signature As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spGetCustomerDetail  '" & Inquirydate & "'  , '" & AgreementNo & "' , '" & NoKTP & "' , '" & TTL & "' , '" & Signature & "'  "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs

    End Function
    Public Function LoadListAgreementRestructure(ByVal BranchId As String, ByVal Requestno As String, ByVal Customer As String,
                                          ByVal RequestFrom As String, ByVal RequestTo As String,
                                                 ByVal sStatus As String, ByVal Agreementno As String,
                                                 ByVal AprDateFrom As String, ByVal AprDateTo As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spLoadListAgreementRestructure2  '" & BranchId & "'  ,'" & Requestno & "' ,'" & Customer & "' , '" & RequestFrom & "' , '" & RequestTo & "'  , '" & sStatus & "'  , '" & Agreementno & "'  "
        sCmd += ", '" & AprDateFrom & "' , '" & AprDateTo & "' "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs

    End Function
    Public Function GetCustomerDetailByRequestID(ByVal RequestID As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spGetCustomerDetailByRequestID  '" & RequestID & "'  "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs

    End Function
    Public Function GetCustomerFilesByRequestID(ByVal RequestID As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spGetCustomerFilesByRequestID  '" & RequestID & "'  "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs

    End Function

    Public Function GetApprovalDetail(RequestID, KomiteID) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spGetApprovalDetail  '" & RequestID & "'  , '" & KomiteID & "'  "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs
    End Function
    Public Function CancelRequestRestructure(RequestID, Userid)
        Dim oDs As String
        Dim oData As New ClsData
        Dim sCmd As String
        'Dim oComm As New clsCommon

        sCmd = " exec spCancelRequestRestructure '" & RequestID & "'  ,  '" & Userid & "'   "

        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.oneColumn)

        Return oDs

    End Function
    Public Function InsertApprovalDetail(ByVal ApprovalID As String, ByVal RequestID As String, ByVal KomiteID As String, ByVal Userid As String,
                                         ByVal OVP As String, ByVal ApprovalStatus As String, ByVal Comment As String,
                                         ByVal usrUpd As String) As String

        Dim oDs As String
        Dim oData As New ClsData
        Dim sCmd As String
        'Dim oComm As New clsCommon

        sCmd = " exec spInsertApprovalDetail '" & ApprovalID & "'  ,  '" & RequestID & "'  ,  '" & KomiteID & "'  , '" & Userid & "' , '" & OVP & "'  , "
        sCmd += " '" & ApprovalStatus & "'  , '" & Comment & "' , '" & usrUpd & "'  "

        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.oneColumn)

        Return oDs

    End Function
    Public Function GetApprovalDetailByRequestID(RequestID) As DataSet
        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo = 0

        sCmd = "exec spGetApprovalDetailByRequestID  '" & RequestID & "'   "
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)
        Return oDs
    End Function

End Class
