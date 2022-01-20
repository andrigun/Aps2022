Imports System.Data
Imports System.Data.SqlClient

Public Class clsQry
    Public sqlcon As New SqlConnection(ConfigurationManager.ConnectionStrings("Con").ConnectionString)
    Public Function getDataList(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer) As DataSet
        Dim oDs As DataSet
        Dim oData As New ClsData
        Dim sCmd As String

        'Dim susernamevar As String = Session("ses_username").ToString()


        sCmd = "select ps_tbJenisSurat.jenissurat, nosurat, perihal, tglsurat, iscancel, isnull(attachment,'') as attachment, ps_tbJenisSurat.jenissuratid from ps_surat WITH (NOLOCK) " & _
        "left join ps_tbJenisSurat on ps_surat.jenissuratid = ps_tbJenisSurat.jenissuratid ) "




        oDs = oData.ExecuteQuery(sCmd, ClsData.ReturnType.Paging, 1, 10, 0)
        Return oDs
    End Function

    Public Function getListRemHead(ByVal currPage As Integer, ByVal rowPerPage As Integer, _
    ByRef totalPage As Integer, Optional ByVal divisionID As String = "", _
    Optional ByVal reminderNumber As String = "", Optional ByVal subject As String = "", _
    Optional ByVal remType As String = "") As DataSet


        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo


        'sCmd = "select rm.reminderID, dv.divisionName, rm.Subject, rt.reminderTypeName, rm.StartDate, " & _
        '        "rm.DueDate, rm.DueMonth from ReminderMaster rm  " & _
        '        "join Division dv on dv.divisionID = rm.divisionID " & _
        '        "join ReminderType rt on rt.reminderType = rm.ReminderType " & _
        '        "where rm.isactive = '1' and rm.divisionID like '%" & divisionID & "%' and rm.reminderID like '%" & reminderNumber & "%' and rm.subject like '%" & subject "%' and rt.reminderTypeID like '%" & remType "%'"

        sCmd = " exec selListReminder '" & reminderNumber & "','" & divisionID & "','" & subject & "','" & remType & "'"
        'sCmd = " exec selListReminder '" & reminderNumber & "','" & divisionID & "','" & subject & "','" & remType & "','" & sDivision & "'"

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)


        Return oDs

    End Function
    Public Function getListRemDetail(ByVal currPage As Integer, ByVal rowPerPage As Integer, _
    ByRef totalPage As Integer, Optional ByVal reminderNumber As String = "") As DataSet


        Dim oDs6 As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo


        'sCmd = "select ReminderID, ReminderSeqno, ReminderDate, Receipent, ReceipentCC, " & _
        '        "usrInst, dtminst from ReminderDetail  " & _
        '"where isactive ='1' and ReminderID  like '%" & reminderNumber & "%'"

        sCmd = " exec selListDetail '" & reminderNumber & "'"


        oDs6 = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)


        Return oDs6

    End Function
    Public Function getListRemHistoryRe(ByVal currPage As Integer, ByVal rowPerPage As Integer, _
    ByRef totalPage As Integer, Optional ByVal reminderNumber As String = "", Optional ByVal reminderSeqNo As String = "", _
    Optional ByVal fromDate As String = "", Optional ByVal thruDate As String = "") As DataSet


        Dim oDs6 As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo


        'sCmd = "select ReminderID, ReminderSeqno, Seqno, SendDate " & _
        '        "from ReminderHistory  " & _
        '"where ReminderID  like '%" & reminderNumber & "%' and ReminderSeqno like '%" & reminderSeqNo & "%'"

        sCmd = " exec selRemHistory '" & reminderNumber & "','" & reminderSeqNo & "','" & fromDate & "','" & thruDate & "'"


        oDs6 = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)


        Return oDs6

    End Function

    Public Function getSelRemMaster(ByVal remID As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        'sCmd = "exec  Cam_getDetailCamHeader  '" & szCamId & "'"

        'sCmd = "select rm.reminderID, rm.divisionID, dv.divisionName, rm.Subject, rm.content, rt.reminderTypeName, rm.StartDate, " & _
        '"rm.DueDate, rm.DueMonth, rm.usrInst, rm.ReminderType  from ReminderMaster rm  " & _
        '"join Division dv on dv.divisionID = rm.divisionID  " & _
        '"join ReminderType rt on rt.reminderType = rm.ReminderType and rm.isactive = 1" & _
        '"where rm.reminderID = '" & remID & "' "

        sCmd = "exec selRemMaster '" & remID & "'"

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function
    Public Function getSelRemDetail(ByVal remID As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        sCmd = "select ReminderID, ReminderSeqno from reminderDetail where reminderID = '" & remID & "' and isactive ='1' "

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function

    Public Function getSelshed(ByVal reID As String, ByVal remSeqNo As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo


        'sCmd = "select ReminderSeqno, ReminderDate, Receipent, ReceipentCC from ReminderDetail where ReminderID = '" & reID & "' and ReminderSeqno = '" & seqNo & "'"
        sCmd = "exec selRemCklikDetail '" & reID & "','" & remSeqNo & "'"



        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function

    Public Function getSelRep(ByVal reID As String, ByVal remSeqNo As String, ByVal seqNo As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        '  MsgBox("tes " + seqNo)
        'sCmd = "select ReminderSeqno, ReminderDate, Receipent, ReceipentCC from ReminderDetail where ReminderID = '" & reID & "' and ReminderSeqno = '" & seqNo & "'"
        sCmd = "exec selRemCklikHistory '" & reID & "','" & remSeqNo & "','" & seqNo & "'"



        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function

    Public Function getEmailListDetail(ByVal Email As String, ByVal reminID As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        sCmd = "exec selRemEmailDetail '" & Email & "','" & reminID & "'"

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function
    Public Function _getData(ByVal AgreementNo As String, ByVal NoKTP As String, ByVal TTL As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo

        sCmd = "exec spGetCustomerDetailLocal '" & AgreementNo & "','" & NoKTP & "','" & TTL & "'"

        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function
    Public Function getData(ByVal AgreementNo As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo

        sCmd = "exec spGetCustomerDetailLocal '" & AgreementNo & "' "

        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function

    Public Function checkuserRequest(ByVal userid As String) As DataSet

        Dim oDs As Object
        Dim oData As New ClsData
        Dim sCmd As String
        Dim iErrNo

        'sCmd = "select Agreementno from TblRequestLog where Agreementno='" & AgreementNo & "' and status='NEW'"
        sCmd = "exec spcheckuserRequest '" & userid & "'"
        oDs = oData.executeQuery(sCmd, ClsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function


    Public Function getDataCekAgrm(ByVal AgreementNo As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        'sCmd = "select Agreementno from TblRequestLog where Agreementno='" & AgreementNo & "' and status='NEW'"
        sCmd = "exec getDataPengRes '" & AgreementNo & "'"
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function

    Public Function getDataParameter(ByVal parameter As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        sCmd = "select agrmntNo, id_no, birth_dt from TblMasterKey where parameter='" & parameter & "'"

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function


    Public Function getReqNo(ByVal branchid As String, ByVal month As String, ByVal year As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        sCmd = "select * from TbmasterSeq where branch='" & branchid & "' and month='" & month & "' and year='" & year & "'"

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function
    Public Function getIDRequesLog(ByVal requestNo As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        sCmd = "select isnull(ID,1)  from TblRequestLog where RequestNo='" & requestNo & "'"

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function

    Public Function getDatabyAgrmnt(ByVal AgreementNo As String) As DataSet

        Dim oDs As Object
        Dim oData As New clsData
        Dim sCmd As String
        Dim iErrNo

        'sCmd = "exec  Cam_getDetailCamHeader  '" & szCamId & "'"

        'sCmd = "select rm.reminderID, rm.divisionID, dv.divisionName, rm.Subject, rm.content, rt.reminderTypeName, rm.StartDate, " & _
        '"rm.DueDate, rm.DueMonth, rm.usrInst, rm.ReminderType  from ReminderMaster rm  " & _
        '"join Division dv on dv.divisionID = rm.divisionID  " & _
        '"join ReminderType rt on rt.reminderType = rm.ReminderType and rm.isactive = 1" & _
        '"where rm.reminderID = '" & remID & "' "

        sCmd = "exec spGetDatabyAgrmnt '" & AgreementNo & "'"

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.DataSet, iErrNo)

        Return oDs

    End Function


End Class
