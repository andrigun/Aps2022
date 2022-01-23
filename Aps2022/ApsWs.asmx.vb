Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.WebService
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services.ScriptServiceAttribute
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Net
Imports System.IO
Imports System.Web.UI.Page
'Imports System.Web.Http

Imports System.Web.HttpContext

Imports System.Net.WebClient

Imports System.ComponentModel
Imports System.Net.HttpRequestHeader

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Schema
Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Json
Imports System.Collections.Generic
Imports System.Linq
Imports System.Configuration
'Imports System.ServiceModel.Web
Imports System.Text

Imports System.Security.Cryptography

'Imports iTextSharp
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf
'Imports iTextSharp.text.BaseColor
'Imports iTextSharp.pdfa
'Imports iTextSharp.text.api
Imports System.Diagnostics

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class ApsWs
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function LoadListAps(ByVal sPksNo As String, ByVal sSupplier As String, ByVal RequestFrom As String, ByVal RequestTo As String, ByVal AprDateFrom As String, ByVal AprDateTo As String) As String
        Try
            Dim rawresponse As String = ""
            Dim sResult As String = ""
            Dim sTable As String = ""

            Dim oDs As New DataSet
            Dim oLoad As New ClsRes
            'Dim nCol As Byte
            Dim nCol, nRow, x As Integer
            Dim i, j As Integer

            oDs = oLoad.LoadListAps(sPksNo, sSupplier, RequestFrom, RequestTo, AprDateFrom, AprDateTo)
            nCol = oDs.Tables(0).Columns.Count - 1
            nRow = oDs.Tables(0).Rows.Count - 1

            'PKSid , supplierName, plafon, tglMulaiAPS, tglBerakhirAPS
            sTable = sTable & " <table cellpadding='0' cellspacing='0' border='0' class='display' id='example'> "
            sTable += " <thead><tr>"
            '"<TD field='row_num' > No.</TD>" &
            sTable += "<TD field='PKSid' > PKS Number</TD>" &
                    "<TD field='supplierName' > supplier Name</TD>" &
                    "<TD field='plafon' > plafon</TD>" &
                    "<TD field='tglMulaiAPS' > Start Date </TD>" &
                    "<TD field='tglBerakhirAPS' > End Date</TD>" &
                    "<TD > Action </TD>" &
                    " </tr></thead>"

            With oDs.Tables(0)
                'sTable += "<table  class='tablegrid' cellSpacing='1' cellPadding='2'  border='1' width='95%'  >"
                sTable = sTable & "<tbody> "
                For x = 0 To nRow
                    sTable += "<tr>"
                    'sTable += "<td>" & x + 1 & "</td>"
                    sTable += "<td>" & .Rows(x).Item(0) & "</td>"
                    sTable += "<td>" & .Rows(x).Item(1) & "</td>"
                    sTable += "<td>" & .Rows(x).Item(2) & "</td>"
                    sTable += "<td>" & .Rows(x).Item(3) & "</td>"
                    sTable += "<td >" & .Rows(x).Item(4).ToString() & "</td>"

                    sTable += "<td  >"
                    sTable += "<a style='cursor:pointer;font-size:12px' onclick=""ViewData('" & EncryptText(HttpUtility.UrlDecode(.Rows(x).Item(0).ToString)) & "' )"" id='btnApproval' ><font color='blue'>View</font></a>&nbsp;&nbsp;&nbsp"

                    'sTable += "<a style='cursor:pointer;font-size:12px' onclick=""callApproval('" & EncryptText(HttpUtility.UrlDecode(.Rows(x).Item(6).ToString)) & "','" & EncryptText(HttpUtility.UrlDecode(.Rows(x).Item(7).ToString)) & "')"" id='btnApproval' ><font color='blue'>Approval</font></a>&nbsp;&nbsp;&nbsp"
                    'sTable += "<a style='cursor:pointer;font-size:12px' onclick=""ViewApproval ('" & EncryptText(HttpUtility.UrlDecode(.Rows(x).Item(2).ToString)) & "','" & EncryptText(HttpUtility.UrlDecode(.Rows(x).Item(6).ToString)) & "' )"" id='btnPrintOut' ><font color='Green'>Print </font></a>"
                    sTable += "</td>"


                    sTable += "</tr>"
                Next
                sTable = sTable & "</tbody>"
                'sTable += "</table>"
            End With

            Dim Script As String = ""
            Dim xStr As String = ""

            sTable += " </table>"
            'sTable += "<input type = 'button'  onclick='PrintDiv();' value='Print' />"
            Script = "$(document).ready(Function() {" &
                        xStr &
              "})"
            sResult = Script & "__" & sTable

            Return sResult
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    <WebMethod>
    Public Function GetTopUpHistorybyReqID(ByVal RequestID As String) As String
        Try
            Dim rawresponse As String = ""
            Dim sResult As String = ""
            Dim sTable As String = ""

            Dim oDs As New DataSet
            Dim oLoad As New ClsRes
            'Dim nCol As Byte
            Dim nCol, nRow, x As Integer
            Dim i, j As Integer

            oDs = oLoad.GetTopUpHistorybyReqID(RequestID)
            nCol = oDs.Tables(0).Columns.Count - 1
            nRow = oDs.Tables(0).Rows.Count - 1
            sTable += " <table class='comicGreen'> "
            sTable += " <thead><tr>"
            sTable += "<TD field='topUpID' > Top ID</TD>"
            sTable += "<TD field='topUpno' > Top Seqno</TD>"
            sTable += "<TD field='tgltopup' > tgltopup</TD>"
            sTable += "<TD field='tglMulaiAPS' > Tanggal Mulai</TD>"
            sTable += "<TD field='tglBerakhirAPS' > Tgl Berakhir  </TD>"
            sTable += "<TD field='plafon' > plafon  </TD>"
            sTable += "<TD field='totalSalesUnit' > total SalesUnit  </TD>"
            sTable += "<TD field='totalPencairan' > total Pencairan </TD>"
            sTable += "<TD field='penalty' > penalty </TD>"
            sTable += "<TD field='sisasaldo' > sisa saldo </TD>"
            sTable += "<TD field='metodePlafonCode' > metodePlafonCode </TD>"

            sTable += " </tr></thead>"

            With oDs.Tables(0)
                sTable = sTable & "<tbody> "
                For x = 0 To nRow
                    sTable += "<tr>"
                    For i = 0 To 10 'nCol
                        sTable += "<td>" & .Rows(x).Item(i) & "</td>"
                    Next

                    'sTable += "<td>" & .Rows(x).Item(2) & "</td>"
                    'sTable += "<td>" & .Rows(x).Item(3) & "</td>"
                    'sTable += "<td>" & .Rows(x).Item(4) & "</td>"
                    'sTable += "<td>" & .Rows(x).Item(5) & "</td>"
                    'sTable += "<td>" & .Rows(x).Item(6) & "</td>"
                    'sTable += "<td>" & .Rows(x).Item(7) & "</td>"
                    'sTable += "<td>" & .Rows(x).Item(1) & "</td>"


                    sTable += "</td> </tr>"
                    Next


                    sTable = sTable & "</tbody>"
            End With
            sTable += "</tbody></table>"
            sResult = sTable


            sResult = sTable
            Return sResult

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    <WebMethod>
    Public Function GetAPSDetailByAPSid(ByVal RequestID As String)
        Try
            Dim rawresponse As String = ""
            Dim sResult As String = ""
            Dim sTable As String = ""

            Dim oDs As New DataSet
            Dim oLoad As New ClsRes
            'Dim nCol As Byte
            Dim nCol, nRow, x As Integer
            Dim i, j As Integer

            oDs = oLoad.GetAPSDetailByAPSid(RequestID)
            nCol = oDs.Tables(0).Columns.Count - 1
            nRow = oDs.Tables(0).Rows.Count - 1
            If nRow >= 0 Then

                With oDs.Tables(0)
                    sTable += " <table class='comicGreen'> <tbody>"
                    sTable += " <tr   >" &
                        "<TD field='PKSid' > PKSid </TD><td>" & .Rows(0).Item(1) & "</td>" &
                        "<TD field='SupplierGroupShowroom' > SupplierGroupShowroom</TD><td>" & .Rows(0).Item(2) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='supplierName' > supplierName</TD><td>" & .Rows(0).Item(4) & "</td>" &
                        "<TD field='topUpno'  > top Up Seqno</TD><td> " & .Rows(0).Item(5) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='plafon' > plafon</TD><td>" & .Rows(0).Item(6) & "</td>" &
                        "<TD field='plafonOrigin'  > plafonOrigin</TD><td> " & .Rows(0).Item(7) & "</td></tr>"


                    sTable += "<tr class='bottom-border' > <TD field='tglMulaiAPS' > Tgl Mulai APS</TD><td>" & .Rows(0).Item(8) & "</td>" &
                        "<TD field='tglBerakhirAPS'  > Tgl Berakhir APS</TD><td> " & .Rows(0).Item(9) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='tgltopup'  >Tgl Topup</TD><td  >" & .Rows(0).Item(10) & "</td> " &
                     "<TD field='tglJatuhTempoTopup'  > Tgl Jatuh Tempo </TD><td> " & .Rows(0).Item(11) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='durasiTopUp' > Durasi TopUp</TD><td>" & .Rows(0).Item(12) & "</td>" &
                        "<TD field='isHolding'  > isHolding</TD><td> " & .Rows(0).Item(13) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='metodePlafonCode' > Metode PlafonCode</TD><td>" & .Rows(0).Item(14) & "</td>" &
                        "<TD field='pengurangCode'  > pengurangCode</TD><td> " & .Rows(0).Item(15) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='totalSalesUnit' > Total SalesUnit</TD><td>" & .Rows(0).Item(16) & "</td>" &
                        "<TD field='totalPencairan'  > Total Pencairan</TD><td> " & .Rows(0).Item(17) & "</td></tr>"


                    sTable += "<tr class='bottom-border' > <TD field='penalty'> penalty</TD><td>" & .Rows(0).Item(18) & "</td>" &
                        "<TD field='nexTopUp'  > Next TopUp</TD><td> " & .Rows(0).Item(19) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='sisaSaldo'>  Saldo</TD><td>" & .Rows(0).Item(20) & "</td>" &
                        "<TD field='isactive'  > isactive</TD><td> " & .Rows(0).Item(21) & "</td></tr>"

                    sTable += "<tr class='bottom-border' > <TD field='dtmIns'>  dtmIns</TD><td>" & .Rows(0).Item(22) & "</td>" &
                        "<TD field='usrIns'  > usrIns</TD><td> " & .Rows(0).Item(23) & "</td></tr>"

                    'sTable += "<tr class='bottom-border' >  "
                    'sTable += " <td  >"
                    'sTable += "<a  style='cursor:pointer;font-size:12px' onclick=""ViewAgreementCard('" & .Rows(0).Item(4) & "' )"" id='btnView'  ><font color='Blue'>  Agreement Card </font> </a> &nbsp; "
                    'sTable += "</td><td>"
                    'sTable += "<a style='cursor:pointer;font-size:12px' onclick=""ViewApproval ('" & EncryptText(HttpUtility.UrlDecode(.Rows(x).Item(4).ToString)) & "', '" & EncryptText(HttpUtility.UrlDecode(RequestID)) & "')"" id='btnPrintOut' ><font color='Blue'>Print Approval</font></a>"
                    'sTable += "</td></tr>"


                End With
                sTable += "</tbody></table>"
            Else
                sTable = generatetemplate()
            End If

            sResult = sTable

            Return sResult

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function generatetemplate() As String
        Dim sTable As String = ""
        sTable += " <table class='comicGreen'> <tbody>"
        sTable += " <tr   >" &
                        "<TD field='PKSid' > PKSid </TD><td>-</td>" &
                        "<TD field='SupplierGroupShowroom' > SupplierGroupShowroom</TD><td>-</td></tr>"

        sTable += "<tr class='bottom-border' > <TD field='supplierName' > supplierName</TD>"
        sTable += "<td><input type = 'text' id='txtsupplierName'  runat='server'   >"
        sTable += "<TD field='topUpno'  > top Up Seqno</TD>"
        sTable += "<td><input type = 'text' id='txttopUpno'  runat='server'  value='0' > </tr>"


        sTable += "<tr class='bottom-border' > <TD field='plafon' > plafon</TD>"
        sTable += "<td><input type = 'text' id='txtplafon'  runat='server'  value='0'  >"
        sTable += "<TD field='plafonOrigin'  > plafonOrigin</TD> "
        sTable += "<td><input type = 'text' id='txtplafonOrigin'  runat='server'  value='0'  >  </tr>"

        sTable += "<tr class='bottom-border' > <TD field='tglMulaiAPS' > Tgl Mulai APS</TD>"
        sTable += "<td>" '<input type = 'text' id='txttglMulaiAPS'  runat='server'   >"
        sTable += "<input Class='cssTextBoxNum' id='txttglMulaiAPS' type='text' size='15' name='txttglMulaiAPS' runat='server'>"
        'sTable += "<small> <A href = 'javascript:showCal('MulaiAPS')' > Pick Date</A></small></TD> "
        sTable += "<TD field='tglBerakhirAPS'  > Tgl Akhir </TD> "
        sTable += "<td>"
        sTable += "<input Class='cssTextBoxNum' id='txttglBerakhirAPS' type='text' size='15' name='txttglBerakhirAPS' runat='server'>"
        sTable += "<small> <A href = 'javascript:showCal('AkhirAPS')' > Pick Date</A></small></TD> "

        'sTable += "<td><input type = 'text' id='txttglBerakhirAPS'  runat='server'   > </tr>"

        sTable += "<tr class='bottom-border' > <TD field='tgltopup' > Tgl Topup</TD>"
        sTable += "<td><input type = 'text' id='txttgltopup'  runat='server'   >"
        sTable += "<TD field='tglJatuhTempoTopup'  > tglJatuhTempoTopup</TD> "
        sTable += "<td><input type = 'text' id='txttglJatuhTempoTopup'  runat='server'   > </tr>"

        sTable += "<tr class='bottom-border' > <TD field='durasiTopUp' > Durasi TopUp</TD>"
        sTable += "<td><input type = 'text' id='txtdurasiTopUp'  runat='server'   >"
        sTable += "<TD field='isHolding'  > isHolding</TD> "
        sTable += "<td><input type = 'text' id='txtisHolding'  runat='server'   > </tr>"

        sTable += "<tr class='bottom-border' > <TD field='metodePlafonCode' > metodePlafonCode</TD>"
        sTable += "<td><input type = 'text' id='txtmetodePlafonCode'  runat='server'   >"
        sTable += "<TD field='pengurangCode'  > pengurangCode</TD> "
        sTable += "<td><input type = 'text' id='txtpengurangCode'  runat='server'   > </tr>"

        sTable += "<tr class='bottom-border' > <TD field='totalSalesUnit' > total SalesUnit</TD>"
        sTable += "<td><input type = 'text' id='txttotalSalesUnit'  runat='server'  value='0'  >"
        sTable += "<TD field='pengurangCode'  > totalPencairan</TD> "
        sTable += "<td><input type = 'text' id='txttotalPencairan'  runat='server' value='0'   > </tr>"

        sTable += "<tr class='bottom-border' > <TD field='penalty' > penalty</TD>"
        sTable += "<td><input type = 'text' id='txtpenalty'  runat='server'  value='0'  >"
        sTable += "<TD field='nexTopUp'  > nexTopUp</TD> "
        sTable += "<td><input type = 'text' id='txtnexTopUp'  runat='server' value='0'   > </tr>"

        sTable += "<tr class='bottom-border' > <TD field='sisaSaldo' > sisaSaldo</TD>"
        sTable += "<td><input type = 'text' id='txtsisaSaldo'  runat='server'  value='0'  >"
        sTable += "<TD field='isactive'  > isactive</TD> "
        sTable += "<td><input type = 'text' id='txtisactive'  runat='server' value='0'   > </tr>"

        sTable += "<tr class='bottom-border' > <TD field='dtmIns'>  dtmIns</TD><td>-</td>" &
                        "<TD field='usrIns'  > usrIns</TD><td> -</td></tr>"

        sTable += "<tr class='bottom-border' >  "
        sTable += " <td  colspan=4>"
        sTable += "<a  style='cursor:pointer;font-size:12px' onclick=""SaveDataAPS()"" id='btnSave'  ><font color='Blue'>  Save </font> </a> &nbsp; "
        sTable += "</td> </tr>"

        sTable += "</tbody></table>"
        Return sTable

    End Function
    Private Function EncryptText(ByVal SourceText As System.String) As System.String
        Dim MyKey As String = "RestructureCovid19AndriGun2020"
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim strResult As System.String = ""

        Try
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Strings.Left(MyKey, 8))
            Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(SourceText)
            Dim des As New DESCryptoServiceProvider
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write)
            cs.Write(InputByteArray, 0, InputByteArray.Length)
            cs.FlushFinalBlock()
            strResult = Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Throw New Exception
        End Try
        Return strResult
    End Function


    Private Function DecryptText(ByVal Chippedtexta As System.String) As System.String
        Chippedtexta = Chippedtexta.Replace(" ", "+")
        Dim mykey As String = "RestructureCovid19AndriGun2020"
        Dim iv() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputbytearray(Chippedtexta.Length) As Byte
        Dim strresult As System.String
        Try
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Strings.Left(mykey, 8))
            Dim des As New DESCryptoServiceProvider
            inputbytearray = Convert.FromBase64String(Chippedtexta)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(bykey, iv), CryptoStreamMode.Write)
            cs.Write(inputbytearray, 0, inputbytearray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            strresult = encoding.GetString(ms.ToArray())
            Return strresult
        Catch ex As Exception
            Throw New Exception
        End Try
    End Function


End Class