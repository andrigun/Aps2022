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
Public Class ucSurvey
    Inherits System.Web.UI.UserControl
    Dim reffnumber As String
    Dim orderNoConfins As String
    Dim surveyIvalue As String
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        surveyIvalue = "Unit"
        Dim x As Integer
        Dim sTable As String
        Dim oDs As DataSet
        Dim oLoad As New ClsApp_Extension
        Dim OComm As New clsCommon
        Dim nRowList As Integer

        If Not Me.IsPostBack Then
            'hold sementara inikeyword
            reffnumber = Decrypt(HttpUtility.UrlDecode(Request.QueryString("reID")))
        Else
            reffnumber = ""
        End If

        Dim oDsur As DataSet
        oDsur = oLoad.displaydatapagesurvey(reffnumber)
        With oDsur.Tables(0)
            nRowList = oDsur.Tables(0).Rows.Count
            nRowList = oDsur.Tables(0).Rows.Count - 1

            If oDsur.Tables(0).Rows.Count <> 0 Then
                orderNoConfins = .Rows(x).Item("orderNo_Confins")
                txtCustomerName.Text = .Rows(x).Item("firstName")
                txtProspectNo.Text = .Rows(x).Item("prospectno")
                txtOrderNo.Text = .Rows(x).Item("orderNo_Confins")
                txtAlamatSurveyDebitur.Text = .Rows(x).Item("AlamatSurveyDebitur")
                txtAlamatSurveyDebiturNote.Text = .Rows(x).Item("AlamatSurveyDebiturNote")
                txtAlamatSurveyUnit.Text = .Rows(x).Item("AlamatSurveyUnit")
                txtAlamatSurveyUnitNote.Text = .Rows(x).Item("AlamatSurveyUnitNote")
                txtAlamatUsaha.Text = .Rows(x).Item("alamatUsaha")
            Else
                txtCustomerName.Text = ""
                txtProspectNo.Text = ""
                txtOrderNo.Text = ""
                txtAlamatSurveyDebitur.Text = ""
                txtAlamatSurveyDebiturNote.Text = ""
                txtAlamatSurveyUnit.Text = ""
                txtAlamatSurveyUnitNote.Text = ""
                txtAlamatUsaha.Text = ""
            End If

        End With
        LoadSurveyUrutan(reffnumber, orderNoConfins)
        LoadSurveyI(orderNoConfins)
        LoadSurveyII(orderNoConfins)
    End Sub

    Private Sub LoadSurveyUrutan(reffnumber, orderNoConfins)
        Dim oDsur As DataSet
        Dim oLoad As New ClsApp_Extension
        Dim nRowList As Integer
        Dim n As Integer
        oDsur = oLoad.displaydatasurveyurutan(reffnumber, orderNoConfins)
        With oDsur.Tables(0)
            nRowList = oDsur.Tables(0).Rows.Count
            nRowList = oDsur.Tables(0).Rows.Count - 1
            If oDsur.Tables(0).Rows.Count <> 0 Then
                txtSurveyI.Text = .Rows(n).Item("survey_1")
                txtSurveyII.Text = .Rows(n).Item("survey_2")
            Else
                txtSurveyI.Text = ""
                txtSurveyII.Text = ""
            End If
        End With
    End Sub

    Private Sub LoadSurveyI(orderNoConfins)
        Dim oDsur As DataSet
		Dim oLoad As New ClsApp_Extension
		Dim nRowList As Integer
        Dim n As Integer
        oDsur = oLoad.displaydatasurveyInII(orderNoConfins, "Survey 1")
        With oDsur.Tables(0)
            nRowList = oDsur.Tables(0).Rows.Count
            nRowList = oDsur.Tables(0).Rows.Count - 1
            'MsgBox(.Rows(n).Item("Survey_ke"))
            If oDsur.Tables(0).Rows.Count <> 0 Then
                txtTujuanSurveyPertama.Text = .Rows(n).Item("Survey_tujuan")
                txtStatusPertama.Text = .Rows(n).Item("Survey_Status")
                txtSurveyorPertama.Text = .Rows(n).Item("surveyBy")
                txtAssignDatePertama.Text = .Rows(n).Item("assign_date")
                txtDownloadPertama.Text = .Rows(n).Item("DOWNLOAD_DATE")
                txtReadPertama.Text = .Rows(n).Item("read_date")
                txtStartDatePertama.Text = .Rows(n).Item("start_dtm")
                txtSubmitDatePertama.Text = .Rows(n).Item("submit_date")
            Else
                txtTujuanSurveyPertama.Text = ""
                txtStatusPertama.Text = ""
                txtSurveyorPertama.Text = ""
                txtAssignDatePertama.Text = ""
                txtDownloadPertama.Text = ""
                txtReadPertama.Text = ""
                txtStartDatePertama.Text = ""
                txtSubmitDatePertama.Text = ""
            End If
        End With
    End Sub
    Private Sub LoadSurveyII(orderNoConfins)
        Dim oDsur As DataSet
		Dim oLoad As New ClsApp_Extension
		Dim nRowList As Integer
        Dim n As Integer
        oDsur = oLoad.displaydatasurveyInII(orderNoConfins, "Survey 2")
        With oDsur.Tables(0)
            nRowList = oDsur.Tables(0).Rows.Count
            nRowList = oDsur.Tables(0).Rows.Count - 1
            'MsgBox(.Rows(n).Item("Survey_ke"))
            If oDsur.Tables(0).Rows.Count <> 0 Then
                txtTujuanSurveyKedua.Text = .Rows(n).Item("Survey_tujuan")
                txtStatusKedua.Text = .Rows(n).Item("Survey_Status")
                txtSurveyorKedua.Text = .Rows(n).Item("surveyBy")
                txtAssignDateKedua.Text = .Rows(n).Item("assign_date")
                txtDownloadKedua.Text = .Rows(n).Item("DOWNLOAD_DATE")
                txtReadKedua.Text = .Rows(n).Item("read_date")
                txtStartDateKedua.Text = .Rows(n).Item("start_dtm")
                txtSubmitDateKedua.Text = .Rows(n).Item("submit_date")
            Else
                txtTujuanSurveyKedua.Text = ""
                txtStatusKedua.Text = ""
                txtSurveyorKedua.Text = ""
                txtAssignDateKedua.Text = ""
                txtDownloadKedua.Text = ""
                txtReadKedua.Text = ""
                txtStartDateKedua.Text = ""
                txtSubmitDateKedua.Text = ""
            End If
        End With
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
End Class