Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
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

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class BM_Postback
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function displayDataPageStatus(ByVal Akses As String, ByVal BranchId As String, ByVal Str2 As String, ByVal Str3 As String, ByVal page As Integer, ByVal OrderBy As String, ByVal AscDesc As String) As String
        Dim sTable As String
        Dim xStr As String
        Dim Script, strFinal As String
        sTable = ""
        xStr = ""
        Script = "$(document).ready(function() {" & xStr & "})"
        strFinal = Script & "__" & sTable
        Return strFinal
    End Function

    <WebMethod()>
    Public Function displayDataPageStatusList(ByVal Akses As String, ByVal StatusId As String, ByVal SearchName As String, ByVal BranchId As String, ByVal page As Integer, ByVal OrderBy As String, ByVal AscDesc As String, ByVal filtering1 As String, ByVal filtering2 As String, ByVal filtering3 As String) As String
        Dim iTotalPageList, iTotalRowList, iCurrPageList As Integer
        'atur paging di sini
        Dim iRowPerPageList As Integer = ConfigurationSettings.AppSettings("rowperpage")
        Dim nColList As Byte
        Dim nRowList As Integer
        Dim sTableList, tdRowList As String
        Dim iNoList As Integer
        Dim oDs, oDsList As DataSet
        Dim oLoad, oLoadList As New ClsApp
        Dim OComm, OCommList As New clsCommon
        Dim xStrList As String
        Dim ScriptList, strFinalList As String
        iCurrPageList = page
        Dim statusname As String

        If (StatusId <> "allstatus" And StatusId <> "") Then
            oDs = oLoad.displaystatusname(StatusId)
            statusname = oDs.Tables(0).Rows(0).Item("statusname")
        End If
        oDsList = oLoadList.displayDataPageStatusList(Akses, StatusId, SearchName, BranchId, iCurrPageList, iRowPerPageList, iTotalPageList, iTotalRowList, OrderBy, AscDesc, filtering1, filtering2, filtering3)
        nColList = oDsList.Tables(0).Columns.Count - 1
        nRowList = oDsList.Tables(0).Rows.Count - 1
        sTableList = ""
        With oDsList.Tables(0)
            sTableList = sTableList & "<table  class='tablegrid' cellSpacing='1' cellPadding='2'  border='0' width='1350px' style='border-collapse:collapse;'>"
            sTableList = sTableList & "<tr style='height:40px;'>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='300px'><b>Sumber Data</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('sumberdata','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('sumberdata','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='450px'><b>Status</b></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='400px'><b>Status Date</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('statusdate','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('statusdate','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='210px'><b>Cabang</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('cabang','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('cabang','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='400px' valign='middle'><b>Name</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('name','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('name','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;' align='center' width='160px'><b>Nationality Id.</b></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='150px'><b>Mobile</b></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='230px'><b>PIC</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('docpro','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('docpro','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='450px'><b>Submit Survey</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('submitsurvey','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('submitsurvey','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='230px'><b>Status Fast Track</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('fasttrack','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('fasttrack','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='400px'><b>Created Date</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('createdate','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('createdate','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='150px'><b>Order No. (Confins)</b></td>"
            sTableList = sTableList & "<td class='tablegrid2' style='background-color:#65BC82; color:#fff;'  align='center' width='400px'><b>Asset Type</b>&nbsp;&nbsp;&nbsp;<a style='cursor:pointer;' onclick=""sortinglist('jenisasset','asc')""><img src=""../images/sortasc.png"" style="" border-width:1px;"" /></a> <a style='cursor:pointer;' onclick=""sortinglist('jenisasset','desc')""><img src=""../images/sortdesc.png"" style="" border-width:1px;"" /></a></td>"
            sTableList = sTableList & "<tr>"
            iNoList = (iCurrPageList - 1) * iRowPerPageList
            If nRowList >= 0 Then
                For x = 0 To nRowList
                    If x Mod 2 = 1 Then tdRowList = "tdganjil" Else tdRowList = "tdgenap" ''ubah warna perbaris
                    sTableList = sTableList & "<tr>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("sumberdata") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("statusname") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' align='center' >&nbsp;" & .Rows(x).Item("statusdate") & " (" & .Rows(x).Item("statustime") & ")</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("office_name") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' ><a style='cursor:pointer;' onclick=""openreview('" & LTrim(RTrim(.Rows(x).Item("reffnumber"))) & "')""><u>" & .Rows(x).Item("name") & "</u></a></td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("nationalid") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("mobile") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("docpro") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("survey_submit_date") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("isfasttrack") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' align='center' >&nbsp;" & .Rows(x).Item("createddate") & " (" & .Rows(x).Item("createdtime") & ")</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' >&nbsp;" & .Rows(x).Item("orderno_confins") & "</td>"
                    sTableList = sTableList & "<td class='" & tdRowList & "' valign='top' align='center' >&nbsp;" & .Rows(x).Item("jenisasset") & "</td>"
                    sTableList = sTableList & "</tr>"
                Next
            Else
                sTableList = sTableList & "<tr><td colspan='12'><center>Data dengan status '" & statusname & "' tidak tersedia</center></td></tr>"
            End If
            sTableList = sTableList & "</table>"
        End With

        'atur paging di sini - START
        '' generate page list
        Dim iPageDivSize As Integer = ConfigurationSettings.AppSettings("rowperpage")
        Dim iPageDiv As Integer
        Dim selisihPage As Integer
        Dim iBeginDivPage As Integer, iEndDivPage As Integer
        Dim sPageList As String = ""
        Dim PageMin, PagePlus As Integer

        ' get page division
        selisihPage = iCurrPageList - iPageDivSize
        If selisihPage < 1 Then
            iBeginDivPage = 1
            iEndDivPage = iPageDivSize
        Else
            iPageDiv = CInt(Math.Ceiling(CDbl(selisihPage) / iPageDivSize)) + 1      'CInt((selisihPage / iPageDivSize) + 0.4)
            iBeginDivPage = (iPageDiv * iPageDivSize) - iPageDivSize + 1
            iEndDivPage = iPageDiv * iPageDivSize
        End If
        If iBeginDivPage > iPageDivSize Then
            ' diplay prev 10 page
            sPageList = sPageList & "<a class='pageLink' href=""javascript:gotoPage(" & iBeginDivPage - 1 & ")"">&lt; 10 Prev Page</a>&nbsp;&nbsp;"
        End If
        For x = iBeginDivPage To iCurrPageList - 1
            sPageList = sPageList & "<a class='pageLink' href=""javascript:gotoPage(" & x & ")"">" & x & "</a>&nbsp;&nbsp;"
        Next
        sPageList = sPageList & "<a class='pageActive' href=""javascript:gotoPage(" & iCurrPageList & ")"">" & iCurrPageList & "</a>&nbsp;&nbsp;"
        For x = iCurrPageList + 1 To IIf(iEndDivPage > iTotalPageList, iTotalPageList, iEndDivPage)
            sPageList = sPageList & "<a class='pageLink' href=""javascript:gotoPage(" & x & ")"">" & x & "</a>&nbsp;&nbsp;"
        Next
        If iEndDivPage < iTotalPageList Then
            ' diplay next 10 page
            sPageList = sPageList & "<a class='pageLink' href=""javascript:gotoPage(" & iEndDivPage + 1 & ")"">10 Next Page &gt;</a>&nbsp;&nbsp;"
        End If
        '--- end of generate page list
        PageMin = IIf((page - 1) = 0, 1, (page - 1))
        PagePlus = IIf((page + 1) = (iTotalPageList + 1), iTotalPageList, (page + 1))
        sTableList = sTableList & "<table cellspacing='0' cellpadding='0' border=0 style='border-collapse: collapse;margin:1; background-color:#ffcc00;' width='1350px'>"
        If nRowList >= 0 Then
            sTableList = sTableList & "<tr height=28px style='background-color:#65BC82; color:#fff;'>"
            If (iTotalPageList > 1) Then
                sTableList = sTableList & "<td width=30% valign='middle'>&nbsp;&nbsp;<img src='../css/Images/butkiri1.gif' alt='1' onclick=""gotoPage('1')"" style='cursor:pointer;'/>&nbsp;" &
                                "<img src='../css/Images/butkiri.gif' class='aClass' alt='" & PageMin & "' onclick=""gotoPage(" & PageMin & ")"" style='cursor:pointer;'/>&nbsp;&nbsp;" &
                                "<img src='../css/Images/butkanan.gif' class='aClass' alt='" & PagePlus & "' onclick=""gotoPage(" & PagePlus & ")"" style='cursor:pointer;'/>&nbsp;" &
                                "<img src='../css/Images/butkanan1.gif' class='aClass' alt='" & iTotalPageList & "' onclick=""gotoPage(" & iTotalPageList & ")"" style='cursor:pointer;'/></td>"
            Else
                sTableList = sTableList & "<td width=30% valign='middle'>&nbsp;&nbsp;</td>"
            End If
            sTableList = sTableList & "<td align=right class='cssLabelTextReading' width=30%>"
            sTableList = sTableList & "Page " & iCurrPageList & " of " & iTotalPageList & ", "
            sTableList = sTableList & "Total " & iTotalRowList & " customer(s)  "
            sTableList = sTableList & "&nbsp;&nbsp;</td></tr></table>"
        Else
            sTableList = sTableList & "<tr height=28px style='background-color:#65BC82; color:#fff;'><td>&nbsp;</td></tr></table>"
        End If
        'atur paging di sini  - END
        ScriptList = "$(document).ready(function() {" & xStrList & "})"
        strFinalList = ScriptList & "__" & sTableList
        Return strFinalList
    End Function

    <WebMethod()>
    Public Function subApproval(ByVal setstatus As String, ByVal note As String, ByVal user As String, ByVal cabang As String, ByVal dataid As String, cancelid As String) As String
        Dim oData As Boolean
        Dim oLoad As New ClsApp
        Dim str As String

        oData = oLoad.save_setdatastatus(setstatus, note, user, cabang, dataid, cancelid)
        If oData = True Then
            str = "Update status data berhasil."
            If setstatus = "BMREQ" Then
                oData = oLoad.notif_to_CRA_rerequest(setstatus, note, user, cabang, dataid, "")
            End If
        Else
            str = "Update status data gagal."
        End If
        Return str
    End Function
End Class