<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WarningPage.aspx.vb" Inherits="WebsiteApp.WarningPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>session Timeout</title>
    <script src="JScript/Blocking.js" type="text/javascript"></script> 
</head>
<body >
    <form id="form1" runat="server">
        <table align="center">
        <tr>
        <td rowspan="2"><img src="css/Images/warning.jpg" /></td>
        </tr>
        <tr>
        <td><br /><b><asp:Label ID="Label3" runat="server" Text="Silahkan tutup halaman ini dan login kembali." CssClass="cssLabelText2" ></asp:Label></b> <br />
        </td>
        </tr>
        </table>
        <p align="center"><a href="openPage.aspx"><b><u>Go to Login Page</u></b></a></p>
    </form>
</body>
</html>
