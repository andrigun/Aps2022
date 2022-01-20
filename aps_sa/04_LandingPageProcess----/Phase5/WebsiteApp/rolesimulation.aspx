<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rolesimulation.aspx.vb" Inherits="WebsiteApp.rolesimulation" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
    <title>Simulasi Role</title>
		<link href="css/AccAcq.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.buttonlink {
  background-color: #4CAF50; /* Green */
    display: block;
    width: 170px;
    height: 45px;
    background: #4E9CAF;
    padding: 10px;
     text-align: left;
    border-radius: 8px;
    color: white;
    font-weight: bold;
		  cursor: pointer;
  text-decoration: none;

		  display: inline-block;
}

.buttonlink:hover {
  box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24), 0 17px 50px 0 rgba(0,0,0,0.19);
    background-color: #ffcc00; /* Green */
  color: white;
}
</style>
 </head>
<body>
<table cellpadding="0" cellspacing="0" border="0" height="39" width="100%">
		<tr>
			<td width="100" height="39" valign="top">
				<img src="images/logobnf.png" style=" border-width:1px;">
			</td>
			<td width="100%" valign="top" align="right">
			<u><font style="font-size:large; font-weight:bold;color:#00A321">Data From Channel Processing</font></u> <br />
               <font style="font-size:smaller;color:#00A321"> <asp:Label ID="userid" runat="server" Text="Label"></asp:Label> (<asp:Label ID="branchid" runat="server" Text="Label"></asp:Label>)</font>
			</td>
		</tr>
</table>
    <form id="form1" runat="server">
        <div>
				<center>
					<font style="font-size:x-large;font-weight:bold;color:darkslategray"><u>:: Simulasi Role ::</u></font><br />
					<font style="font-size:large;font-weight:bold;color:darkslategray"></font>
				</center>
				<br />
				<table border = '0'  align='left' style='width:100%;border-collapse:collapse;' >
					<tr>
						<td> 
							<asp:Button ID="btnBPCD" runat="server" Text="1. BPCD" class='buttonlink' />&nbsp;&nbsp;
							<asp:Button ID="btnCA" runat="server" Text="2. CRA" class='buttonlink' />&nbsp;&nbsp;
                          	<asp:Button ID="btnBM" runat="server" Text="3. BM" class='buttonlink' />&nbsp;&nbsp;
							<asp:Button ID="btnADMIN" runat="server" Text="4. ADMIN" class='buttonlink' />&nbsp;&nbsp;
						</td>
				</tr>
				</table><br />

				<br /><br />
						<table border = '0'  align='left' style='width:100%;border-collapse:collapse;' >
					<tr>
						<td> 	<br /><br />
				<b><u>&nbsp;</u></b>
										</td>
				</tr>
				</table><br />
        </div>
    </form>
</body>
</html>
