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
Public Class ucCreditCalculator
    Inherits System.Web.UI.UserControl
    Dim reffnumber As String
    Dim surveyIvalue As String
    Dim oLoad As New ClsApp
    Dim nRowList As Integer
    Dim x As Integer
    Dim offname As String
    Dim iCurrPage As Integer
    Dim iRowPerPage As Integer = 100
    Dim iTotalPage As Integer
    Dim oQry As New clsQry
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sTable As String
        Dim OComm As New clsCommon
        If Not Me.IsPostBack Then
            reffnumber = Decrypt(HttpUtility.UrlDecode(Request.QueryString("reID")))
        Else
            reffnumber = ""
        End If
        Label1.Text = reffnumber
        Dim sQueryFile As DataSet
        loadCalculatorCredit(reffnumber)
    End Sub

    Private Sub loadCalculatorCredit(reffnumber)
        Dim oDsur As DataSet
        oDsur = oQry.loadCalculatorCredit(reffnumber)
        With oDsur.Tables(0)
            nRowList = oDsur.Tables(0).Rows.Count
            nRowList = oDsur.Tables(0).Rows.Count - 1
            If oDsur.Tables(0).Rows.Count <> 0 Then
                txtCBranchName.Text = .Rows(x).Item("office_name")
                txtCCustName.Text = .Rows(x).Item("CustomerName")
                txtCAssetName.Text = .Rows(x).Item("AssetName")
                txtCShowroom.Text = .Rows(x).Item("showroom")
                txtCBatasAsuransi.Text = .Rows(x).Item("BatasAsuransi")
                txtCPenutupanAsuransi.Text = .Rows(x).Item("PenutupanAsuransi")
                txtCCoverAsuransi.Text = .Rows(x).Item("coverAsuransi")
                txtCDepresiasiAsuransi.Text = .Rows(x).Item("DepresiasiAsuransi")
                txtCPerluasanSRCCTS.Text = .Rows(x).Item("isPerluasanSCCRTS")
                txtCPerluasaanGempaBumi.Text = .Rows(x).Item("isPerluasanGempa")
                txtCPerluasanBanjir.Text = .Rows(x).Item("isPerluasanBanjir")
                txtCTHJ.Text = .Rows(x).Item("isCapitalizedTJH")
                txtCPerusahaanAsuransi.Text = .Rows(x).Item("PerusahaanAsuransi")
                txtCCabangWilayahAsuransi.Text = .Rows(x).Item("Wilayah")
                txtCKategori.Text = .Rows(x).Item("JenisKendaraan")
                txtCPenggunaanOkupasi.Text = .Rows(x).Item("Okupasi")
                txtCTypeAngsuran.Text = .Rows(x).Item("TypeAngsuran")
                txtCBuanaProtectionKapitalis.Text = .Rows(x).Item("BuanaProtection")
                txtCTenorPembiayaan.Text = .Rows(x).Item("Tenor")
                txtCTahunKendaraan.Text = .Rows(x).Item("TahunKendaraan")
                txtCDpPersen.Text = .Rows(x).Item("Dppercent")
                txtCDpAmount.Text = .Rows(x).Item("DPAmount")
                txtCOtrAmount.Text = .Rows(x).Item("OTRAmount")
                txtCBiayaAdmin.Text = .Rows(x).Item("biayaAdmin")
                txtCFiducia.Text = .Rows(x).Item("biayaFiducia")
                txtCBiayaPolisAsuransi.Text = .Rows(x).Item("biayaPolis")
                txtCBiayaProvisi.Text = .Rows(x).Item("biayaProvisiPersen")
                txtCBiayaBuanaProtection.Text = .Rows(x).Item("biayaBuanaProtectionPersen")
                txtCOtrAmount2.Text = .Rows(x).Item("OTRAmount")
                txtCDpAmount2.Text = .Rows(x).Item("DPAmount")
                txtCPhMurni.Text = .Rows(x).Item("PHMurni")
                txtCKapitalisasi.Text = .Rows(x).Item("Kapitalisasi")
                txtCTotalPH.Text = .Rows(x).Item("TotalPH")
                txtCBunga.Text = .Rows(x).Item("Bunga")
                txtCPhBunga.Text = .Rows(x).Item("PHplusBunga")
                txtCltv.Text = .Rows(x).Item("LTVpercent")
                txtCPremiAsuransi.Text = .Rows(x).Item("PremiAsuransi")
                txtCThjDibayarDimuka.Text = .Rows(x).Item("TJH")
                txtCTotalPremiAsuransi.Text = .Rows(x).Item("TotalPremiAsuransi")
                txtCAdministrasi.Text = .Rows(x).Item("biayaAdmin")
                txtCPolisAsuransiDibayarDimuka.Text = .Rows(x).Item("biayaPolis")
                txtCFiduciaDibayarDimuka.Text = .Rows(x).Item("FidusiaDibayarDiMuka")
                txtCBuanaProtetion.Text = .Rows(x).Item("BuanaProtection")
                txtCJualFlat.Text = .Rows(x).Item("FlatRate")
                txtCJualEff.Text = .Rows(x).Item("effectiveRate")
                txtCAngsuranPerBulan.Text = .Rows(x).Item("AngsuranPerBulan")
                txtCTotalBayarPertama.Text = .Rows(x).Item("TotalBayarPertamaTDP")
                txtCPelunasanKeDealer.Text = .Rows(x).Item("PelunasanKeDealer")
                txtCDeviasi.Text = .Rows(x).Item("deviasi")
                txtCDeviasiNote.Text = .Rows(x).Item("deviasiNote")
                txtCreateDate.Text = .Rows(x).Item("dtm_crt")
                txtdfcid.Value = .Rows(x).Item("dfc_id")
            Else
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