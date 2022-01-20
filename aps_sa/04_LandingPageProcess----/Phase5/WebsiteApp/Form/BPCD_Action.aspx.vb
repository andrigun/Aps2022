Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Web.Mail
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports System.Web.Services.WebService
Imports System.Net
Imports System.Net.HttpRequestHeader
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Microsoft.VisualBasic

Public Class BPCD_Action
	Inherits System.Web.UI.Page
	Dim reffnumber As String
	'Dim MailFunc As New ClsSendMail_SubmitCabang
	Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
	Public sQuery As String
	Dim oComm As New clsCommon
	Dim var_userid As String
    Dim isphototaken As String
    Dim varakses As String
    Dim sur As String

    Dim cekreffnumber As String
    Dim ceknationalid As String
    Dim cekname As String
    Dim cekbirthdate As String
    Dim cektempatlahirdebitur As String
    Dim cekmobile As String
    Dim cekvaruserid As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim negative_record As String
		Dim phonex_result As String
		Dim phonex_total As String
		Dim tempatlahirdebitur As String

		'settimeout in minute
		Session.Timeout = 3600

        If Not IsPostBack Then


            If Session("userid") = "" Then
                Exit Sub
            End If

            var_userid = Session("userid")
            varakses = Session("akses")
            userid.Text = Session("userid")
            branchid.Text = Session("branchid")

            txtUserId.Value = Session("userid")
            txtCabang.Value = Session("BranchId")


            reffnumber = Decrypt(HttpUtility.UrlDecode(Request.QueryString("reID")))
            Session("reffnumber") = reffnumber

            Dim oDsq As New DataSet
            Dim sQueryq As String

            sQueryq = "Select  dfcx.idofthistable, isnull(dfcx.negative_record,'') as negative_record, isnull(dfcx.phonex_result,'') as phonex_result,  " &
            "isnull(dfcx.phonex_total,'') as phonex_total, isnull(dfcx.TempatLahirDebitur,'') as tempatlahirdebitur,  " &
            "isnull(tbd.nationalId,'') as nationalId, isnull(tbd.firstname,'') + ' ' + isnull(tbd.lastname,'')  as name , isnull(tbd.birthdate,'') as birthdate, isnull(tbd.mobile,'') as mobile   " &
            "From dataFromChannel_X dfcx with (nolock)   " &
            "Left Join tbldetail tbd on dfcx.idofthistable = tbd.reffnumber  " &
            "where dfcx.idOfThisTable = " & reffnumber & " order by  dfcx.idofthistable"

            Dim oAdapterq As New SqlDataAdapter(sQueryq, sqlconapps)
            Dim oDsmarq As New DataSet
            oAdapterq.Fill(oDsmarq, "DataSet")

            With oDsmarq.Tables(0)

                negative_record = .Rows(0).Item("negative_record")
                phonex_result = .Rows(0).Item("phonex_result")
                phonex_total = .Rows(0).Item("phonex_total")

                ' If (negative_record <> "" And phonex_result <> "" And phonex_total <> "") Then

                If (negative_record <> "") Then
                    NegativeRecords.Text = .Rows(0).Item("negative_record")
                    PhoneExtra1.Text = .Rows(0).Item("phonex_result")
                    PhoneExtra2.Text = .Rows(0).Item("phonex_total")
                Else

                    txtcekreffnumber.Value = reffnumber
                    txtceknationalid.Value = .Rows(0).Item("nationalId")
                    txtcekname.Value = .Rows(0).Item("name")
                    txtcekbirthdate.Value = .Rows(0).Item("birthDate")
                    txtcektempatlahirdebitur.Value = .Rows(0).Item("tempatlahirdebitur")
                    txtcekmobile.Value = .Rows(0).Item("mobile")
                    txtcekvaruserid.Value = var_userid

                    getasliri()

                    sQueryq = sQueryq
                    sQueryq = sQueryq

                End If

            End With

            txtDataId.Value = reffnumber

            Dim x As Integer
            Dim sTable As String
            Dim oDs As DataSet
            Dim oLoad As New ClsApp
            Dim OComm As New clsCommon
            Dim nRowList As Integer

            oDs = oLoad.displaydatapagedetailreview(reffnumber)

            sTable = ""
            With oDs.Tables(0)
                lblactivity.Text = "View Data"
                btnJJSVY.Visible = False
                btnCLSVY.Visible = False
                txtnotes.ReadOnly = True
                txtnotesbm.ReadOnly = True
                txtprospectid.Text = .Rows(x).Item("reffnumber")
                txtname.Text = .Rows(x).Item("name")
                txtktp.Text = .Rows(x).Item("nationalId")

                If Len(txtktp.Text) = 0 Then
                    divbtnktp.Visible = False
                End If

                txttgllahir.Text = .Rows(x).Item("tempatlahirdebitur") & ", " & .Rows(x).Item("birthDate")
                txtphone.Text = .Rows(x).Item("mobile")
                txtemail.Text = .Rows(x).Item("email")
                txtnotesSO.Text = .Rows(x).Item("notesso")
                txtnotes.Text = .Rows(x).Item("canote")
                txtnotesbm.Text = .Rows(x).Item("bmnote")
                txtstatus.Text = RTrim(.Rows(x).Item("statusname"))


                ceknationalid = .Rows(x).Item("nationalId")
                cekbirthdate = .Rows(x).Item("birthDate")


                If ((RTrim(.Rows(x).Item("statusid")) = "CBASC") Or (RTrim(.Rows(x).Item("statusid")) = "RQSVY") Or
                (RTrim(.Rows(x).Item("statusid")) = "DROPD") Or (RTrim(.Rows(x).Item("statusid")) = "BMREQ") Or
                (RTrim(.Rows(x).Item("statusid")) = "BMEND")) Then
                    changestatusbox.Visible = True
                Else
                    changestatusbox.Visible = False
                End If


                txtstatusdate.Text = LTrim(RTrim(.Rows(x).Item("statusdate"))) & " " & LTrim(RTrim(.Rows(x).Item("statustime")))
                txtstatusby.Text = LTrim(RTrim(.Rows(x).Item("userid")))

                'txtcanceldesc.Text = .Rows(x).Item("canceldesc")
                txtnpwp.Text = .Rows(x).Item("npwp")

                txtcabangasal.Text = .Rows(x).Item("cabangasal")
                txtcabangtujuan.Text = .Rows(x).Item("cabangtujuanorder")
                txtcustomermodel.Text = .Rows(x).Item("customermodel")
                txtmaritalstatus.Text = .Rows(x).Item("maritalstatus")
                txtalamatusaha.Text = .Rows(x).Item("alamatusaha")
                txtcmo.Text = .Rows(x).Item("cmo")
                txtdocpro.Text = .Rows(x).Item("docpro")
                txtordernoconfins.Text = .Rows(x).Item("ordernoconfins")
                txtprospectno.Text = .Rows(x).Item("prospectno")

                txtsumberdata.Text = .Rows(x).Item("sumberdata")

                hdnordernoconfins.Value = .Rows(x).Item("ordernoconfins")
                If Len(.Rows(x).Item("ordernoconfins")) <> 0 Then
                    btnviewktp.Visible = True
                Else
                    btnviewktp.Visible = False
                End If

                ektp1.Text = .Rows(x).Item("ektp_result")
                ektp2.Text = .Rows(x).Item("ektp_decision")
                appi1.Text = .Rows(x).Item("appi_result")
                appi2.Text = .Rows(x).Item("appi_decision")
                slik1.Text = .Rows(x).Item("slik_result")
                slik2.Text = .Rows(x).Item("slik_decision")
                pefindo1.Text = .Rows(x).Item("pef_result")
                pefindo2.Text = .Rows(x).Item("pef_decision")
                telco1.Text = .Rows(x).Item("telco_result")
                telco2.Text = .Rows(x).Item("telco_decision")
                finaldecision.Text = .Rows(x).Item("finaldecision")

                negative_record = .Rows(x).Item("negative_record")
                phonex_result = .Rows(x).Item("phonex_result")
                phonex_total = .Rows(x).Item("phonex_total")
                tempatlahirdebitur = .Rows(x).Item("tempatlahirdebitur")

                negrec1.Text = negative_record

                ' If (negative_record <> "" And phonex_result <> "" And phonex_total <> "") Then

                If (negative_record <> "") Then
                    NegativeRecords.Text = .Rows(x).Item("negative_record")

                    If .Rows(0).Item("negative_record") = "Not Found" Then
                        negrec1.Text = "Not Found"
                        negrec2.Text = "Pass"
                    ElseIf .Rows(0).Item("negative_record") = "Found" Then
                        negrec1.Text = "Found"
                        negrec2.Text = "Reject"
                    Else
                        negrec1.Text = "(Not Checked)"
                        negrec2.Text = "(Not Checked)"
                    End If

                    PhoneExtra1.Text = .Rows(x).Item("phonex_result")
                    PhoneExtra2.Text = .Rows(x).Item("phonex_total")
                Else
                    NegativeRecords.Text = "(Belum cek AsliRI)"
                    PhoneExtra1.Text = "(Belum cek AsliRI)"
                    PhoneExtra2.Text = "(Belum cek AsliRI)"
                End If

                isphototaken = .Rows(x).Item("isphototaken")  'tanya Octa : nama status nya
                If isphototaken = "Yes" Then
                    rbpicunitY.Checked = True
                    rbpicunitY.Enabled = True
                    rbpicunitN.Enabled = False
                ElseIf isphototaken = "No" Then
                    rbpicunitN.Checked = True
                    rbpicunitN.Enabled = True
                    rbpicunitY.Enabled = False
                Else 'tanya Octa : nama status nya
                    rbpicunitY.Enabled = False
                    rbpicunitN.Enabled = False
                End If

            End With

            displaydatasurveyurutan(reffnumber)

            'bagian cek duplikat
            sQuery = "exec usp_dfc_duplicateCustChecked '" & reffnumber & "','0'"

            Dim oAdapter As New SqlDataAdapter(sQuery, sqlconapps)
            Dim oDs2 As New DataSet
            oAdapter.Fill(oDs2, "DataSet")

            nRowList = oDs2.Tables(0).Rows.Count - 1

            sTable = ""
            sTable = sTable & "<table border = '1' style='cell-spacing:0; cell-padding:0; border-collapse:collapse;border-color:cornflowerblue;border-width:thin;' width='800px'>"
            sTable = sTable & " <tr style='background-color:cornflowerblue; font-weight:bold;color:#fff'><td style='text-align:center;width:200px'>Cust. Name Found</td><td style='text-align:center;width:200px'>Cust. No. Found</td><td style='text-align:center;width:200px'>Data Yg Sama</td><td style='text-align:center;width:200px'>Isi Data Yg Sama</td><td style='text-align:center;width:200px'>Tgl. Checked</td></tr>"

            If ((oDs2.Tables(0).Rows.Count <> 0)) Then
                With oDs2.Tables(0)
                    For x = 0 To nRowList
                        sTable = sTable & "<tr><td>" & .Rows(x).Item("cust_name_found") & "</td><td>" & .Rows(x).Item("cust_no_found") & "</td><td>" & .Rows(x).Item("data_yg_sama") & "</td><td>" & .Rows(x).Item("isi_data_yg_sama") & "</td><td>" & .Rows(x).Item("tgl_checked") & "</td></tr>"
                    Next
                End With
                sTable = sTable & "</table>"
            Else
                '		sTable = sTable & "<tr><td colspan=5>Data tidak tersedia.....</td></tr></table>"
            End If

            viewcekduplikat.InnerHtml = sTable

            '###########################################

            'bagian cek negative confins

            Dim tgl As String = Left(cekbirthdate, 2)
            Dim thn As String = Right(cekbirthdate, 4)
            Dim bln As String = Mid(cekbirthdate, 4, 2)
            Dim thnblntgl As String

            thnblntgl = thn & "-" & bln & "-" & tgl

            sQuery = "exec NEGATIVE_LIST_DATA_BUANA '" & ceknationalid & "', '" & thnblntgl & "'"

            Dim oAdapternc As New SqlDataAdapter(sQuery, sqlconapps)
            Dim oDs2nc As New DataSet
            oAdapternc.Fill(oDs2nc, "DataSet")

            nRowList = oDs2.Tables(0).Rows.Count - 1

            If ((oDs2nc.Tables(0).Rows.Count <> 0)) Then
                With oDs2nc.Tables(0)
                    If .Rows(0).Item("output") = "FOUND MATCH" Then
                        negconfins1.Text = "Found"
                        negconfins2.Text = "Reject"
                    Else
                        negconfins1.Text = "Not Found"
                        negconfins2.Text = "Pass"
                    End If
                End With
            Else
                negconfins1.Text = "-"
                negconfins2.Text = "-"
            End If
            '###########################

            If sqlconapps.State = ConnectionState.Open Then
                sqlconapps.Close()
            End If

        End If

        TabSelector(1)

        Exit Sub
	End Sub

	Private Sub displaydatasurveyurutan(reffnumber)
		Dim oDsDf As DataSet
		Dim oLoadDf As New ClsApp_Extension
		Dim n As Integer
		Dim nRowList2 As Integer

		sur = ""

		oDsDf = oLoadDf.displaydatasurveyurutan(reffnumber)
		With oDsDf.Tables(0)
			nRowList2 = oDsDf.Tables(0).Rows.Count
			nRowList2 = oDsDf.Tables(0).Rows.Count - 1
			If nRowList2 >= 0 Then
				sur = .Rows(n).Item("survey_1")
			Else
				sur = ""
			End If
		End With

		If isphototaken = "No" Or (isphototaken = "") Then
			If sur = "Debitur" Then
				rbS1.Checked = True
				rbS1.Enabled = True
				rbS2.Enabled = False
				rbS3.Enabled = False
			ElseIf sur = "Unit" Then
				rbS1.Enabled = False
				rbS2.Checked = True
				rbS2.Enabled = True
				rbS3.Enabled = False
			ElseIf sur = "DebUnit" Then  'tanya Octa : nama status nya
				rbS1.Enabled = False
				rbS2.Enabled = False
				rbS3.Checked = True
				rbS3.Enabled = True
			Else
				rbS1.Enabled = False
				rbS2.Enabled = False
				rbS3.Enabled = False
			End If
		ElseIf isphototaken = "Yes" Then
			If sur = "Debitur" Then
				rbS1.Checked = True
				rbS1.Enabled = True
				rbS2.Enabled = False
				rbS3.Enabled = False
			ElseIf sur = "Unit" Then
				rbS1.Enabled = False
				rbS2.Checked = True
				rbS2.Enabled = True
				rbS3.Enabled = False
			ElseIf sur = "DebUnit" Then
				rbS1.Enabled = False
				rbS2.Enabled = False
				rbS3.Checked = True
				rbS3.Enabled = True
			Else
				rbS1.Enabled = False
				rbS2.Enabled = False
				rbS3.Enabled = False
			End If
		End If

		Exit Sub
	End Sub

    Public Class MyRequestData
        Public Property ReqID As String
        Public Property NIK As String
        Public Property Name As String
        Public Property dob As String
        Public Property pob As String
        Public Property handphone As String
        Public Property sUserID As String

    End Class


    Private Sub getasliri()

        cekreffnumber = txtcekreffnumber.Value
        ceknationalid = txtceknationalid.Value
        cekname = txtcekname.Value
        cekbirthdate = txtcekbirthdate.Value
        cektempatlahirdebitur = txtcektempatlahirdebitur.Value
        cekmobile = txtcekmobile.Value
        cekvaruserid = txtcekvaruserid.Value

        'Dim q As String
        'q = "cekasliri(" & cekreffnumber & ", " & ceknationalid & ", " & cekname & ", " & cekbirthdate & ", " & cektempatlahirdebitur & ", " & cekmobile & ", " & cekvaruserid & ")"
        'MsgBox(q)

        'production : cekasliri akan mengupadte table datafromchannel_x
        cekasliri(cekreffnumber, ceknationalid, cekname, cekbirthdate, cektempatlahirdebitur, cekmobile, cekvaruserid)

        Exit Sub

    End Sub



    Public Sub cekasliri(ByVal ReqID As String, ByVal NIK As String, ByVal Name As String, ByVal dob As String, ByVal pob As String, ByVal handphone As String, ByVal sUserID As String)
        'call api section start

        Dim Httprequest As HttpWebRequest
        Dim response As HttpWebResponse
        Dim reader As StreamReader
        Dim rawresponse As String = ""

        Dim sResult As String = ""

        Dim urlWebsrvices As String

        urlWebsrvices = "http://10.10.1.43/AsliRiCheck/asliri.asmx/GetAsliriinternal"

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls ' SecurityProtocolType.Tls12

        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

        Dim client = New WebClient
        client.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current

        Try

            Httprequest = DirectCast(WebRequest.Create(urlWebsrvices), HttpWebRequest)
            Httprequest.ContentType = "application/json"
            Httprequest.Method = "POST"
            'xHttprequest.TransferEncoding = xTrue  
            Httprequest.AllowAutoRedirect = True
            Httprequest.Proxy.Credentials = CredentialCache.DefaultCredentials
            Httprequest.ContentType = "application/json"
            Httprequest.UseDefaultCredentials = True
            Httprequest.Accept = "application/json"
            Httprequest.KeepAlive = True
            Httprequest.ProtocolVersion = HttpVersion.Version10

            Dim requestd As New MyRequestData With {
                                                .ReqID = ReqID,
                                                .NIK = NIK,
                                                .Name = Name,
                                                .dob = dob,
                                                .pob = pob,
                                                .handphone = handphone,
                                                .sUserID = sUserID
                                                    }

            Dim postdata As String = JsonConvert.SerializeObject(requestd)

            Dim requestWriter As StreamWriter = New StreamWriter(Httprequest.GetRequestStream())
            requestWriter.Write(postdata)
            requestWriter.Close()

            response = DirectCast(Httprequest.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            rawresponse = reader.ReadToEnd()

            'MsgBox(rawresponse)

            Dim json As JObject = JObject.Parse(rawresponse)
            'MsgBox(json.SelectToken("data").SelectToken("negative_record"))
            'MsgBox(json.SelectToken("data.Phone_extra_result"))
            'MsgBox(json.SelectToken("data.Phone_extra_total"))

            NegativeRecords.Text = json.SelectToken("data.negative_record")
            PhoneExtra1.Text = json.SelectToken("data.Phone_extra_result")
            PhoneExtra2.Text = json.SelectToken("data.Phone_extra_total")

            'bagian checking sudah ada atau belum  ---start
            'sQuery = "exec chk_neg_exist '" & ReqID & "','" & json.SelectToken("data").SelectToken("negative_record") & "', '" & json.SelectToken("data.Phone_extra_result") & "', '" & json.SelectToken("data.Phone_extra_total") & "'"

            Dim val1, val2, val3 As String
            val1 = json.SelectToken("data.negative_record")
            val2 = json.SelectToken("data.Phone_extra_result")
            val3 = json.SelectToken("data.Phone_extra_total")

            'testing hardcodex
            'ReqID = "10212"

            sQuery = "exec chk_neg_exist '" & ReqID & "','" & val1 & "','" & val2 & "','" & val3 & "'"

            Dim oAdapter As New SqlDataAdapter(sQuery, sqlconapps)
            Dim oDs2 As New DataSet
            oAdapter.Fill(oDs2, "DataSet")

            'bagian checking sudah ada atau belum  ---end


        Catch ex As Exception
            'Call InsertLog(sNIk, ex.ToString, sUserId)
            Console.WriteLine(ex.ToString)
            '	Return ex.ToString
        End Try
        'rawresponse
        'call api section end

        Exit Sub

    End Sub

    Private Function Decrypt(cipherText As String) As String
		Dim EncryptionKey As String = "MAKV2SPBNI99212"
		cipherText = cipherText.Replace(" ", "+")
		Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
		Using encryptor As Aes = Aes.Create()
			Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
			 &H65, &H64, &H76, &H65, &H64, &H65,
			 &H76})
			encryptor.Key = pdb.GetBytes(32)
			encryptor.IV = pdb.GetBytes(16)
			Using ms As New MemoryStream()
				Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
					cs.Write(cipherBytes, 0, cipherBytes.Length)
					cs.Close()
				End Using
				cipherText = Encoding.Unicode.GetString(ms.ToArray())
			End Using
		End Using
		Return cipherText
	End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tesdummy.Focus()
    End Sub

    Private Function TabSelector(ByVal Tabno As Byte) As Byte
        Dim sHTML As String
        Dim tabnoselect As Byte
        Dim gotopage As String
        tabnoselect = Tabno

        tabnoselect = 1

        gotopage = "branchid=" & Session("branchid") & "&applicationid=" & Request.QueryString("applicationid") & "&assetseqno=" & Request.QueryString("assetseqno")
        sHTML = "<table width='793px' height='32px' cellpadding=0 cellspacing=0 border=0><tr>"

        If tabnoselect = 1 Then
            sHTML = sHTML & "<td width='190px' style='background-image:Images/Tab_on130.png;'><a class='urlImgOn' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Identitas Calon Debitur</a></td>"
        Else
            sHTML = sHTML & "<td width='190px'><a href='UT_AlamatPool.aspx?" & gotopage & "' class='urlImg' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Identitas Calon Debiturl</a></td>"
        End If

        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 2 Then
            sHTML = sHTML & "<td width='100px' style='background-image:Images/Tab_on.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Cust. Related Data</a></td>"
        Else
            sHTML = sHTML & "<td width='100px'><a href='UT_KondisiFisik.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Cust. Related Data</a></td>"
        End If

        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 3 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Asset & Showroom</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='UT_Foto.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;Asset & Showroom</a></td>"
        End If


        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 4 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Survey</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='UT_Foto.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Survey</a></td>"
        End If

        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 5 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;CAM Survey</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='UT_Foto.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;CAM Survey</a></td>"
        End If

        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 6 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='UT_Foto.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator</a></td>"
        End If

        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 7 Then
            sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator Refund</a></td>"
        Else
            sHTML = sHTML & "<td width='130px'><a href='UT_Foto.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Calculator Refund</a></td>"
        End If

        sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        If tabnoselect = 8 Then
            sHTML = sHTML & "<td width='70px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Catatan Docpro</a></td>"
        Else
            sHTML = sHTML & "<td width='70px'><a href='UT_Foto.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Catatan Docpro</a></td>"
        End If


        'sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        'If Session("ses_Akses") = "Admin" Then
        '    If tabnoselect = 4 Then
        '        sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Proses Recovery</a></td>"
        '    Else
        '        sHTML = sHTML & "<td width='130px'><a href='UT_ProsesRecovery.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Proses Recovery</a></td>"
        '    End If
        '    sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        'Else
        '    If tabnoselect = 4 Then
        '        sHTML = sHTML & "<td width='130px' style='background-image:Images/Tab_on130.png'><a class='urlImgOn130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Submit Data</a></td>"
        '    Else
        '        sHTML = sHTML & "<td width='130px'><a href='UT_SubmitCabang.aspx?" & gotopage & "' class='urlImg130' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Submit Data</a></td>"
        '    End If
        '    sHTML = sHTML & "<td width='1px'>&nbsp;</td>"
        'End If
        'If Session("ses_Akses") = "Admin" Then
        '    If tabnoselect = 5 Then
        '        sHTML = sHTML & "<td width='190px' style='background-image:Images/Tab_on.png'><a class='urlImgOn' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Dokumen Proses Recovery</a></td>"
        '    Else
        '        sHTML = sHTML & "<td width='190px'><a href='UT_ProsesRecoveryDoc.aspx?" & gotopage & "' class='urlImg' title='Corelangs link'><div>&nbsp;</div>&nbsp;&nbsp;&nbsp;Dokumen Proses Recovery</a></td>"
        '    End If
        'End If
        sHTML = sHTML & "</tr></table>"
        tdtabdisplay.InnerHtml = sHTML
    End Function


End Class