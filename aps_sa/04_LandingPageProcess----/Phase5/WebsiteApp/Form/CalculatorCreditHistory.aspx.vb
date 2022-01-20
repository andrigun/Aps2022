Imports System.Data.SqlClient
Imports System.IO
Public Class CalculatorCreditHistory
    Inherits System.Web.UI.Page
    Dim reffnumber As String
    Dim iCurrPage As Integer
    Dim iRowPerPage As Integer = 100
    Dim iTotalPage As Integer
    Dim oQry As New clsQry
    Dim nRowList As Integer
    Dim x As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        reffnumber = Request.QueryString("dfcid")

        If Not IsPostBack Then

        Else


        End If
        If reffnumber <> "" Then
            loadDataCalculatorCreditHistory(reffnumber)
        Else
        End If
    End Sub

    Private Sub loadDataCalculatorCreditHistory(reffnumber)
        Dim oDsur As DataSet
        'oDsur = oQry.loadCalculatorCredit(10364)

        oDsur = oQry.loadCalculatorCreditHistory(reffnumber)
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

                'dicommment dulu
                txtCPerusahaanAsuransi.Text = .Rows(x).Item("PerusahaanAsuransi")
                'txtCPerusahaanAsuransi.Text = "abcdef"

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
                'txtCAssetName2.Text = .Rows(x).Item("AssetName")
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
                txtCreateDate.Text = .Rows(x).Item("History_insertDate")


            Else

            End If

        End With
    End Sub

End Class