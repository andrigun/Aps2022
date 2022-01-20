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
Public Class ucAssetShowrom
    Inherits System.Web.UI.UserControl
    Dim reffnumber As String
    Dim sqlconapps As New SqlConnection(ConfigurationManager.ConnectionStrings("Conapps").ConnectionString)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As Integer
        Dim sTable As String
        Dim oDs As DataSet
        Dim oLoad As New ClsApp_Extension
        Dim OComm As New clsCommon
        Dim nRowList As Integer

        If Not Me.IsPostBack Then
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
                txtCustomerName.Text = .Rows(x).Item("firstName")
                txtProspectNo.Text = .Rows(x).Item("prospectno")
                txtOrderNo.Text = .Rows(x).Item("orderNo_Confins")
                txtNamaSupplier.Text = .Rows(x).Item("NamaSupplier")
                txtAlamatSupplier.Text = .Rows(x).Item("AlamatSupplier")
                txtContactPerson.Text = .Rows(x).Item("ContactPerson")
                txtJenisAsset.Text = .Rows(x).Item("JenisAsset")
                txtAssetCondition.Text = .Rows(x).Item("AssetType")
                txtMerkAsset.Text = .Rows(x).Item("MerkAsset")
                txtTypeAsset.Text = .Rows(x).Item("TypeAsset")
                txtTahunAsset.Text = .Rows(x).Item("TahunAsset")
                txtCmoName.Text = .Rows(x).Item("CMO")
                txtNoPolisi.Text = .Rows(x).Item("noPolisi")
            Else
                txtCustomerName.Text = ""
                txtProspectNo.Text = ""
                txtOrderNo.Text = ""
                txtNamaSupplier.Text = ""
                txtAlamatSupplier.Text = ""
                txtContactPerson.Text = ""
                txtJenisAsset.Text = ""
                txtAssetCondition.Text = ""
                txtMerkAsset.Text = ""
                txtTypeAsset.Text = ""
                txtTahunAsset.Text = ""
                txtCmoName.Text = ""
                txtNoPolisi.Text = ""
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