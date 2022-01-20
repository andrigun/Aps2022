<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Host_CalculatorRefundRO.aspx.vb" Inherits="WebsiteApp.Host_CalculatorRefundRO" %>
<%@ Register Src="~/UserControl/ucRefund.ascx" TagName="WebControl5" TagPrefix="ucRefund" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd class="tablegrid2" XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd class="tablegrid2"/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    
<title>Halaman View Data</title>
<meta http-equiv="x-ua-compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
<meta http-equiv="Expires" CONTENT="0">
<meta http-equiv="Cache-Control" CONTENT="no-cache">
<meta http-equiv="Pragma" CONTENT="no-cache">
<!-- <script src="../JScript/jquery-1.5.1.js"type="text/javascript"></script>
<script src="../JScript/jquery.json-1.3.min.js" type="text/javascript"></script>
<script src="../JScript/jquery.ui.core.js" type="text/javascript"></script>
<script src="../JScript/jquery.ui.widget.js" type="text/javascript"></script>
<script src="../JScript/jquery.ui.position.js" type="text/javascript"></script>
<script src="../JScript/jquery.ui.dialog.js" type="text/javascript"></script>
<script src="../JScript/popupForm.js" type="text/javascript"></script>
<link href="../css/jquery.css" rel="stylesheet" type="text/css" />
<link href="../css/jquery.ui.all.css" rel="stylesheet" type="text/css" /> -->
<link href="../css/AccAcq.css" rel="stylesheet" type="text/css" />

  <!--   <script  type="text/javascript">
         var str1, str2, str3,str4,ptype,strU;
         $(document).ready(function () {
             LoadingContent();
         });
        function LoadingContent() {
         $("#loading").ajaxStart(function() { $(this).show(); });
        $("#loading").ajaxStop(function() { $(this).hide(); });
        }
</script> -->

<style type="text/css">
	.urlImgOn130 {
		width: 130px;
		height:34px;
		display:block;
		background-image: url('images/tab_on130.png');
		text-decoration:none;
		cursor:default;
		font-weight:bold;
		color:#FFFFFF;
	}
	.urlImg130 {
		width: 130px;
		height:34px;
		display:block;
		background-image: url('images/tab_off130.png');
		text-decoration:none;
	}
	.urlImg130:hover {
		width: 130px;
		height:34px;
		background-image: url('images/tab_on130.png');
		text-decoration:none;
		font-weight:bold;
		color:#FFFFFF;
	}
	.urlImgOn {
		width: 190px;
		height:34px;
		display:block;
		background-image: url('images/tab_on.png');
		text-decoration:none;
		cursor:default;
		font-weight:bold;
		color:#FFFFFF;
	}
	.urlImg {
		width: 190px;
		height:34px;
		display:block;
		background-image: url('images/tab_off.png');
		text-decoration:none;
	}
	.urlImg:hover {
		width: 190px;
		height:34px;
		background-image: url('images/tab_on.png');
		text-decoration:none;
		font-weight:bold;
		color:#FFFFFF;
	}
</style>
</head>
<body>
<form id="form1" runat="server">    
  <table cellpadding="0" cellspacing="0" border="0" height="39" width="100%">
		<tr>
			<td width="100" height="39" valign="top">
				<img src="../images/logobnf.png" style=" border-width:1px;">
			</td>
			<td width="100%" valign="top" align="right">
			<font style="font-size:large; font-weight:bold;color:#00A321">Dashboard Multiguna - LOS</font><br />
               <font style="font-size:smaller;color:#00A321"><asp:Label ID="lblactivity" runat="server" Text="Label"></asp:Label> - <asp:Label ID="userid" runat="server" Text="Label"></asp:Label> (<asp:Label ID="branchid" runat="server" Text="Label"></asp:Label>)</font>
			</td>
		</tr>
</table> 
<table runat="server"  cellSpacing='0' cellPadding='0'  border='0' width="793px" align="left">
    <tr><td id="tdtabdisplay" runat="server"></td></tr>
	<tr><td style="background-color:#008CFF; height:5px;"></td></tr>
</table> 
	<div><ucRefund:WebControl5 ID="calrefund" runat="server" /></div>
</form>
</body>
</html>