Public Partial Class vb
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()> _
 Public Shared Function SetSession(ByVal name As String) As String
        HttpContext.Current.Session("Name") = name
        Return "Hello " & HttpContext.Current.Session("Name") & Environment.NewLine & "The Current Time is: " & DateTime.Now.ToString()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim x As String
        x = Session("Name")
        x = x
        x = x
    End Sub
End Class