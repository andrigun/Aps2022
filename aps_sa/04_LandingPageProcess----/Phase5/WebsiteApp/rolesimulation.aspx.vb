Public Class rolesimulation
	Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim a As String
        a = "abc"
    End Sub

    Protected Sub btnBPCD_Click(sender As Object, e As EventArgs) Handles btnBPCD.Click
        Session("userid") = "Indri_BPCD"
        Session("branchid") = "801"
		Session("branchname") = "Kemayoran"
		Session("akses") = "BPCD"
		Response.Redirect("./form/BPCD_StartPage.aspx")
	End Sub

    Protected Sub btnADMIN_Click(sender As Object, e As EventArgs) Handles btnADMIN.Click
        Session("userid") = "Indri_ADMIN"
        Session("branchid") = "801"
		Session("branchname") = "Kemayoran"
        Session("akses") = "Admin"
        Response.Redirect("./form/Admin_StartPage.aspx")
	End Sub

	Protected Sub btnCA_Click(sender As Object, e As EventArgs) Handles btnCA.Click
        Session("userid") = "Indri_CA"
        Session("branchid") = "801"
		Session("branchname") = "Kemayoran"
		Session("akses") = "CA"
		Response.Redirect("./form/CA_StartPage.aspx")
	End Sub

    Protected Sub btnBM_Click(sender As Object, e As EventArgs) Handles btnBM.Click
        Session("userid") = "Indri_BM"
        Session("branchid") = "801"
		Session("branchname") = "Kemayoran"
		Session("akses") = "BM"
		Response.Redirect("./form/BM_StartPage.aspx")
	End Sub

End Class