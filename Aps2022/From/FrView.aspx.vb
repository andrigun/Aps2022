Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class FrView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oUser As New clsUser
        Dim sUserID As String
        sUserID = Replace(System.Web.HttpContext.Current.User.Identity.Name, "BDF\", "")

        sUserID = "andrigun"

        txtUserID.Value = sUserID

        Dim argReqNo As String = ""
        Dim arReqID As String = Request.QueryString("argReqID")

        If UCase(arReqID) <> "NEW" Then
            arReqID = DecryptText(HttpUtility.UrlDecode(arReqID))
        End If

        txtReqID.Value = arReqID '  
    End Sub

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