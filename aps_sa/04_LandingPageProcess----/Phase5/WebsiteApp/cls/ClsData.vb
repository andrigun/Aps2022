Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class ClsData
    Public oConn As New SqlConnection
    Public oTransaction As SqlTransaction
    Public oCommand As SqlCommand
    Public oConnApps As New SqlConnection
    Private _db_server As String = ConfigurationSettings.AppSettings("ServerAPP")
    Private _db_name As String = ConfigurationSettings.AppSettings("DatabaseAPP")
	Private _user_id As String = ConfigurationSettings.AppSettings("UserIdAPP")
	Private _pwd As String = ConfigurationSettings.AppSettings("PasswordAPP")

	'bagian ini harus ada
	Public Enum ReturnType
        DataReader = 0
        DataSet = 1
        NonQueryExecute = 2
        Paging = 3
        oneColumn = 4
    End Enum

    Public Function openConnection() As Boolean
        On Error GoTo errHandle
        Dim strDbconnection As String

		oConn.ConnectionString = "Server=" & _db_server & "; User ID=" & _user_id & "; Pwd=" & _pwd & "; Database=" & _db_name & ";connection timeout=3600;"

		oConn.Open()
        openConnection = True

        SqlConnection.ClearPool(oConn)
        Exit Function
errHandle:
        If oConn.State = ConnectionState.Open Then
            oConn.Close()
            Resume Next
        Else
            openConnection = False
        End If
    End Function

    Public Function getConnection(ByVal dbServer As String, ByVal userID As String, ByVal password As String, ByVal dbName As String) As SqlClient.SqlConnection
        On Error GoTo errHandle
        oConn.ConnectionString = "Server=" & dbServer & "; User ID=" & userID & "; Pwd=" & password & "; Database=" & dbName
        oConn.Open()
        Return oConn
        Exit Function
errHandle:
        Err.Raise(1000, , "Error Create Connection")
    End Function

    Public Sub closeConnection()
        oConn.Close()
    End Sub

	'dipakai
	Public Function executeQuerydisplay_DataUser(ByVal sQuery As String, ByVal nReadMode As ReturnType, Optional ByRef iErrNo As Long = 0) As Object
        On Error GoTo errHandle
        Select Case nReadMode
            Case ReturnType.DataReader
                ' for execute and get the datareader
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim oDataReader As SqlDataReader
                If openConnection() = True Then
                    oDataReader = oCmd.ExecuteReader()
                    Return oDataReader
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.DataSet
                Dim oAdapter As New SqlDataAdapter(sQuery, oConn)
                Dim oDs As New DataSet
                If openConnection() = True Then
                    oAdapter.Fill(oDs, "DataSet")
                    closeConnection()
                    executeQuerydisplay_DataUser = oDs
                    'Return oDs
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.NonQueryExecute
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim nAffected As Integer
                If openConnection() = True Then
                    nAffected = oCmd.ExecuteNonQuery()
                    closeConnection()
                    Return nAffected
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.oneColumn
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim oColumnReturn As Object
                If openConnection() = True Then
                    oCmd.CommandTimeout = 320
                    oColumnReturn = oCmd.ExecuteScalar
                    closeConnection()
                    Return oColumnReturn
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.Paging
        End Select
        Exit Function
errHandle:
        iErrNo = Err.Number
        Return Err.Description
    End Function

	'    ' ini dipakai
	Public Function ExecuteQuerydisplaydatapagedetailreview(ByVal szQuery As String, ByVal nReadMode As ReturnType, ByVal iCurrPage As Integer, ByVal iRowPerPage As Integer, ByRef iTotalPage As Integer) As Object
        On Error GoTo Err
        Select Case nReadMode
            Case ReturnType.Paging
                Dim oDataAdapter As New SqlDataAdapter(szQuery, oConn)
                Dim oDs As New DataSet
                Dim iTotalRow As Integer
                Dim iCurrIdx As Integer
                iCurrIdx = (iCurrPage * iRowPerPage) - iRowPerPage
                If openConnection() Then
                    ' get total page
                    oDataAdapter.Fill(oDs, "DataSet")
                    iTotalRow = oDs.Tables(0).Rows.Count
                    iTotalPage = CInt(Math.Ceiling(CDbl(iTotalRow) / iRowPerPage))
                    ' end of get total page
                    ' fill with real record
                    oDs = New DataSet
                    oDataAdapter.Fill(oDs, iCurrIdx, iRowPerPage, "DataSet")
                    closeConnection()
                    ExecuteQuerydisplaydatapagedetailreview = oDs
                    'Return objDataSet
                Else
                    Return "Problem in Database Connetion"
                End If
        End Select
        Exit Function
Err:
        Return Err.Description
    End Function

	'ini dipakai
	Public Function ExecuteQueryPageStatus(ByVal szQuery As String, ByVal nReadMode As ReturnType, ByVal iCurrPage As Integer, ByVal iRowPerPage As Integer, ByRef iTotalPage As Integer) As Object
        'Public Function ExecuteQuery(ByVal szQuery As String, ByVal nReadMode As ReturnType, ByVal iCurrPage As Integer, ByVal iRowPerPage As Integer, ByRef iTotalPage As Integer, ByRef iTotalRow As Integer) As Object
        On Error GoTo Err
        Select Case nReadMode
            Case ReturnType.Paging
                Dim oDataAdapter As New SqlDataAdapter(szQuery, oConn)
                Dim oDs As New DataSet
                Dim iTotalRow As Integer
                Dim iCurrIdx As Integer
                iCurrIdx = (iCurrPage * iRowPerPage) - iRowPerPage
                If openConnection() Then
                    ' get total page
                    oDataAdapter.Fill(oDs, "DataSet")
                    iTotalRow = oDs.Tables(0).Rows.Count
                    iTotalPage = CInt(Math.Ceiling(CDbl(iTotalRow) / iRowPerPage))
                    ' end of get total page
                    ' fill with real record
                    oDs = New DataSet
                    oDataAdapter.Fill(oDs, iCurrIdx, iRowPerPage, "DataSet")
                    closeConnection()
                    ExecuteQueryPageStatus = oDs
                    'Return objDataSet
                Else
                    Return "Problem in Database Connetion"
                End If
        End Select
        Exit Function
Err:
        Return Err.Description
    End Function

	'ini dipakai
	Public Function ExecuteQueryPaging(ByVal szQuery As String, ByVal nReadMode As ReturnType, ByVal iCurrPage As Integer, ByVal iRowPerPage As Integer, ByRef iTotalPage As Integer, ByRef iTotalRow As Integer) As Object
        On Error GoTo Err
        Select Case nReadMode
            Case ReturnType.Paging
                Dim oDataAdapter As New SqlDataAdapter(szQuery, oConn)
                Dim oDs As New DataSet
                'Dim iTotalRow As Integer
                Dim iCurrIdx As Integer
                iCurrIdx = (iCurrPage * iRowPerPage) - iRowPerPage
                If openConnection() Then
                    ' get total page
                    oDataAdapter.Fill(oDs, "DataSet")
                    iTotalRow = oDs.Tables(0).Rows.Count
                    iTotalPage = CInt(Math.Ceiling(CDbl(iTotalRow) / iRowPerPage))
                    ' end of get total page
                    ' fill with real record
                    oDs = New DataSet
                    oDataAdapter.Fill(oDs, iCurrIdx, iRowPerPage, "DataSet")
                    closeConnection()
                    ExecuteQueryPaging = oDs
                    'Return objDataSet
                Else
                    Return "Problem in Database Connetion"
                End If
        End Select
        Exit Function
Err:
        Return Err.Description
    End Function

    'ini dipakai unruk display user info
    Public Function ExecuteQueryUserInfo(ByVal par_oConn As SqlClient.SqlConnection, ByVal sQuery As String, ByVal nReadMode As ReturnType, Optional ByRef sErrNo As Long = 0) As Object
        On Error GoTo errHandle
        Select Case nReadMode
            Case ReturnType.DataReader
                ' for execute and get the datareader
                Dim oCmd As New SqlCommand(sQuery, par_oConn)
                Dim oDataReader As SqlDataReader
                oDataReader = oCmd.ExecuteReader()
                Return oDataReader
            Case ReturnType.DataSet
                Dim oAdapter As New SqlDataAdapter(sQuery, par_oConn)
                Dim oDs As New DataSet
                oAdapter.Fill(oDs, "DataSet")
                closeConnection()
                ExecuteQueryUserInfo = oDs
                'Return oDs
            Case ReturnType.NonQueryExecute
                Dim oCmd As New SqlCommand(sQuery, par_oConn)
                Dim nAffected As Integer
                nAffected = oCmd.ExecuteNonQuery()
                closeConnection()
                Return nAffected
            Case ReturnType.oneColumn
                Dim oCmd As New SqlCommand(sQuery, par_oConn)
                Dim oColumnReturn As Object
                oColumnReturn = oCmd.ExecuteScalar()
                closeConnection()
                Return oColumnReturn
            Case ReturnType.Paging
        End Select
        Exit Function

errHandle: sErrNo = Err.Number
        Return Err.Description
    End Function

    Public Function ExecuteQueryUserBranch(ByVal par_oConn As SqlClient.SqlConnection, ByVal sQuery As String, ByVal nReadMode As ReturnType, Optional ByRef sErrNo As Long = 0) As Object
        On Error GoTo errHandle
        Select Case nReadMode
            Case ReturnType.DataReader
                ' for execute and get the datareader
                Dim oCmd As New SqlCommand(sQuery, par_oConn)
                Dim oDataReader As SqlDataReader
                oDataReader = oCmd.ExecuteReader()
                Return oDataReader

            Case ReturnType.DataSet
                Dim oAdapter As New SqlDataAdapter(sQuery, par_oConn)
                Dim oDs As New DataSet

                oAdapter.Fill(oDs, "DataSet")
                closeConnection()
                ExecuteQueryUserBranch = oDs
                                'Return oDs

            Case ReturnType.NonQueryExecute
                Dim oCmd As New SqlCommand(sQuery, par_oConn)
                Dim nAffected As Integer
                nAffected = oCmd.ExecuteNonQuery()
                closeConnection()
                Return nAffected

            Case ReturnType.oneColumn
                Dim oCmd As New SqlCommand(sQuery, par_oConn)
                Dim oColumnReturn As Object
                oColumnReturn = oCmd.ExecuteScalar()
                closeConnection()
                Return oColumnReturn

            Case ReturnType.Paging
        End Select
        Exit Function

errHandle:
        sErrNo = Err.Number
        Return Err.Description
    End Function

	Public Function beginTrans() As Object
        If oConn.State <> ConnectionState.Open Then
            If openConnection() = False Then
                Return "Problem in Database Connection"
            End If
        End If
        oTransaction = oConn.BeginTransaction
        oCommand = oConn.CreateCommand
        oCommand.Transaction = oTransaction
    End Function

    Public Function commitTrans() As Object
        oTransaction.Commit()
    End Function

    Public Function rollbackTrans() As Object
        oTransaction.Rollback()
    End Function
    Public Function executeQuery(ByVal sQuery As String, ByVal nReadMode As ReturnType, Optional ByRef iErrNo As Long = 0) As Object
        On Error GoTo errHandle
        Dim strLine As String, filePath, fileName, fileExcel, link
        Dim objStreamWriter As StreamWriter
        Dim objFileStream As FileStream
        Dim nRandom As Random = New Random(DateTime.Now.Millisecond)

        Select Case nReadMode
            Case ReturnType.DataReader
                ' for execute and get the datareader
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim oDataReader As SqlDataReader
                If openConnection() = True Then
                    oDataReader = oCmd.ExecuteReader()
                    Return oDataReader
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.DataSet
                Dim oAdapter As New SqlDataAdapter(sQuery, oConn)
                Dim oDs As New DataSet
                If openConnection() = True Then
                    oAdapter.Fill(oDs, "DataSet")
                    closeConnection()
                    executeQuery = oDs
                    'Return oDs
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.NonQueryExecute
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim nAffected As Integer
                If openConnection() = True Then
                    nAffected = oCmd.ExecuteNonQuery()
                    closeConnection()
                    Return nAffected
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.oneColumn
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim oColumnReturn As Object
                If openConnection() = True Then
                    oColumnReturn = oCmd.ExecuteScalar()
                    closeConnection()
                    Return oColumnReturn
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.Paging

        End Select
        Exit Function

errHandle:
        iErrNo = Err.Number
        Return Err.Description
    End Function

    Public Function ExecuteQueryType3(ByVal sQuery As String, ByVal nReadMode As ReturnType, Optional ByRef iErrNo As Long = 0) As Object
        On Error GoTo errHandle
        Select Case nReadMode
            Case ReturnType.DataReader
                ' for execute and get the datareader
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim oDataReader As SqlDataReader
                If openConnection() = True Then
                    oDataReader = oCmd.ExecuteReader()
                    Return oDataReader
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.DataSet
                Dim oAdapter As New SqlDataAdapter(sQuery, oConnApps)
                Dim oDs As New DataSet
                If openConnection() = True Then
                    oAdapter.SelectCommand.CommandTimeout = 1800   'menambah lama time out
                    oAdapter.Fill(oDs, "DataSet")
                    closeConnection()
                    ExecuteQueryType3 = oDs
                    'Return oDs
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.NonQueryExecute
                Dim oCmd As New SqlCommand(sQuery, oConnApps)
                Dim nAffected As Integer
                If openConnection() = True Then
                    nAffected = oCmd.ExecuteNonQuery()
                    closeConnection()
                    Return nAffected
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.oneColumn
                Dim oCmd As New SqlCommand(sQuery, oConn)
                Dim oColumnReturn As Object
                If openConnection() = True Then
                    oColumnReturn = oCmd.ExecuteScalar()
                    closeConnection()
                    Return oColumnReturn
                Else
                    Return "Problem in Database Connection"
                End If
            Case ReturnType.Paging
        End Select

        Exit Function

errHandle:
        iErrNo = Err.Number
        Return Err.Description
    End Function

End Class
