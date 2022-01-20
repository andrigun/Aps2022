<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="vb.aspx.vb" Inherits="WebsiteApp.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    Your Name :
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <input id="btSet" type="button" value="Set Session" onclick="SetSession()" />
    <script type="text/javascript">
        function SetSession() {
            var name = document.getElementById("<%=txtUserName.ClientID%>").value;
            var request;
            if (window.XMLHttpRequest) {
                //New browsers.
                request = new XMLHttpRequest();
            }
            else if (window.ActiveXObject) {
                //Old IE Browsers.
                request = new ActiveXObject("Microsoft.XMLHTTP");
            }
            if (request != null) {
                var url = "VB.aspx/SetSession";
                request.open("POST", url, false);
                var params = "{name: '" + name + "'}";
                request.setRequestHeader("Content-Type", "application/json");
                request.onreadystatechange = function () {
                    if (request.readyState == 4 && request.status == 200) {
                        alert(JSON.parse(request.responseText).d);
                    }
                };
                request.send(params);
            }
        }
    </script>
    

    <asp:Button ID="Button1" runat="server" Text="Button" />
    
    </form>
</body>
</html>
