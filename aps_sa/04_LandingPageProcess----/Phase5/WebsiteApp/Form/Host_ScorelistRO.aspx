<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Host_ScorelistRO.aspx.vb" Inherits="WebsiteApp.Host_ScorelistRO" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd class="tablegrid2" XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd class="tablegrid2"/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    
<title>Halaman View Data</title>
<meta http-equiv="x-ua-compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
<meta http-equiv="Expires" CONTENT="0">
<meta http-equiv="Cache-Control" CONTENT="no-cache">
<meta http-equiv="Pragma" CONTENT="no-cache">
<script src="../JScript/jquery-1.5.1.js"type="text/javascript"></script>
<script src="../JScript/jquery.json-1.3.min.js" type="text/javascript"></script>
<script src="../JScript/jquery.ui.core.js" type="text/javascript"></script>
<script src="../JScript/jquery.ui.widget.js" type="text/javascript"></script> 
<script src="../JScript/jquery.ui.position.js" type="text/javascript"></script>
<script src="../JScript/jquery.ui.dialog.js" type="text/javascript"></script>
<script src="../JScript/popupForm.js" type="text/javascript"></script>
<link href="../css/jquery.css" rel="stylesheet" type="text/css" />
<link href="../css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
<link href="../css/AccAcq.css" rel="stylesheet" type="text/css" />
	<!-- feature tab -- start-->
	<link rel="stylesheet" href="../css/responsive-tabs.css">
	<script src="../js/responsiveTabs.js"></script>
			<script>
				$(document).ready(function () {
					RESPONSIVEUI.responsiveTabs();
				})
	</script>
	<!-- feature tab -- end-->

     <script  type="text/javascript">
         var str1, str2, str3,str4,ptype,strU;
         $(document).ready(function () {
             LoadingContent();
         });

        
         function GetLocalValueReview() {     
           setstatus = document.getElementById("changestatusid").value;
           user = document.getElementById("txtUserId").value;
           note = "";
           cabang = document.getElementById("txtCabang").value;
			dataid = document.getElementById("txtDataId").value;
			cancelid = ""
			 }      

			 function closetab() {
				 window.close() ;
			 }

function statusselect(selectedvalue)
    {
   form1.changestatusid.value = selectedvalue;
    }

function savebpcdstatus() {
                if ((document.getElementById("changestatusid").value == "")) {
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                        "<td><img src='../css/Images/Qred.png' />&nbsp;</td>" +
                        "<td><b>Silahkan pilih jenis status yang baru.</b></td></tr></table>"
                         showMsgBox('Peringatan', str, 'Ok', '', 'CloseDialogBox()', '', 300, '');
                     }
                else {
                     document.getElementById("txtsetstatus").value='BMEND';
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                                  "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                  "<td><b>Lakukan perubahan status data' ?</b></td></tr></table>"
                         showMsgBox('Konfirmasi Perubahan Status', str, 'Ya', 'Tidak', 'WaitSaving()', 'CloseDialogBox()', 300, '', 100, 500);
                 }
}
        
         function ViewKTP() {     
    var str;
             var orderno = document.getElementById("hdnordernoconfins").value;
    str = "<table align='left' border='0' ><tr><td>";
    str = str + "<iframe scrolling='yes' src='http://10.10.1.88:4455/bnf/fotodms/view?order_no="+ orderno +"'";
    str = str + "frameborder='0' style='width:750px;height:500px;' id='iframe5'></iframe>";
    str = str + "</td></tr></table>";
    showMsgBox('Dokumen KTP', str, 'Tutup', '', 'CloseDialogBox()', '', 800, '');
         }

        function LoadingContent() {
         $("#loading").ajaxStart(function() { $(this).show(); });
        $("#loading").ajaxStop(function() { $(this).hide(); });
         }

	function ViewKTP_exp() {     
    var str;
        var orderno = document.getElementById("hdnordernoconfins").value;
    str = "<table align='left' border='0' ><tr><td>";
        str = str + "<iframe scrolling='yes' src='http://10.10.1.88:4455/bnf/fotodms/view?order_no="+ orderno +"'";
    str = str + " frameborder='0' style='width:750px;height:500px;' id='iframe5'></iframe>";
        str = str + "</td></tr></table>";

      //  alert("http://10.10.1.88:4455/bnf/fotodms/view?order_no='"+ orderno + "'");

    showMsgBox('Dokumen KTP', str, 'Tutup', '', 'CloseDialogBox()', '', 800, '');
         }

        function LoadingContent() {
         $("#loading").ajaxStart(function() { $(this).show(); });
        $("#loading").ajaxStop(function() { $(this).hide(); });
        }
</script>

<style>
.formattable tr { height: 14px; }
  bell{
  display: block;
  display: inline-block;
/* background-image: url(https://image.freepik.com/free-vector/golden-bell_1262-6415.jpg); */
  background-size: contain;
  height: 40px;
  width: 40px;
}
</style>
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
    <br /><br />
<table border="0" style="width:1180;border-collapse:collapse; overflow:hidden; white-space: nowrap;" >
<%--<table border="3" style="width:1180;border-color:#000000" >--%>

  
<tr>
  <td style="width:150px;vertical-align:top" ><br /><asp:Label ID="Label7" CssClass="cssLabelText" runat="server" Text="Label">Score List</asp:Label></td> 
  <td style="vertical-align:top"><br />:</td>
   <td style="width:1000px;" colspan="2">
       <br />
	  <table border="0" style="width:830;border-collapse:collapse; overflow:hidden; white-space: nowrap;" >
          <tr><td width="420px" valign="top">
               <asp:Label ID="finaldecision" runat="server" Text="" Style="display:none"></asp:Label>
	                   <table border="1" style="cell-spacing:0; cell-padding:0; border-collapse:collapse;border-color:cornflowerblue;border-width:thin;">
	                    <tr style="background-color:cornflowerblue; font-weight:bold;color:#fff"><td width="120px" style="text-align:center">Scoring Name</td><td width="100px" style="text-align:center">Result</td><td width="100px" style="text-align:center">Decision</td></tr>
                        <tr><td>NIK KTP</td><td style="text-align:center"><asp:Label ID="ektp1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="ektp2" runat="server" Text=""></asp:Label></td></tr>
		                <tr><td>DUPLICATE CHECKING DATA BUANA</td><td style="text-align:center"><asp:Label ID="dupcheck1" runat="server" Text=""></asp:Label></td><td align="center">Pass</td></tr>
		                <tr><td>NEGATIVE LIST DATA BUANA</td><td style="text-align:center"><asp:Label ID="negconfins1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="negconfins2" runat="server" Text="">-</asp:Label></td></tr>
		                <tr><td>APPI</td><td style="text-align:center"><asp:Label ID="appi1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="appi2" runat="server" Text=""></asp:Label></td></tr>
		                <tr><td>SLIK</td><td style="text-align:center"><asp:Label ID="slik1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="slik2" runat="server" Text=""></asp:Label></td></tr>
		                <tr><td>CRIMINAL RECORD ASLI RI</td><td style="text-align:center"><asp:Label ID="negrec1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="negrec2" runat="server" Text="">-</asp:Label></td></tr>
		                <tr><td>PHONE NUMBER VERIFICATION ASLI RI</td><td style="text-align:center"><asp:Label ID="phoneverasliri" runat="server" Text=""></asp:Label></td><td align="center">Pass</td></tr>
                        <tr><td>PEFINDO</td><td  style="text-align:center"><asp:Label ID="pefindo1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="pefindo2" runat="server" Text=""></asp:Label></td></tr>
                        <tr><td>TELCO SCORING</td><td style="text-align:center"><asp:Label ID="telco1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="telco2" runat="server" Text=""></asp:Label></td></tr>

                       </table>
	            </td>
                <td>&nbsp;&nbsp;</td>
	            <td valign="top" width="350px" align="left" valign="top">
                    <div runat="server" id="CBASPanel" style="margin-bottom:10px;"></div>
                      	<!--Phone Extra :--> <asp:Label ID="PhoneExtra1" CssClass="cssLabelText" runat="server" Text="" style="display:none"></asp:Label><asp:Label ID="PhoneExtra2" CssClass="cssLabelText"  runat="server" Text="" style="display:none"></asp:Label>
 	            </td>
	    </tr>
	  </table
          <br /><br />
   </td>
</tr> 
    <tr>
    <td style="width:150px;vertical-align:top"><a class="cssLabelText" >Duplicate Cust. Checked</a></td> 
   <td style="vertical-align:top">:</td>
	<td style="width:400px;" colspan="2">
	  <div runat="server" id="viewcekduplikat" style="margin-bottom:10px;"></div>
		</td>
</tr>
</table>




<table style="border-collapse:collapse;width:100%">
<tr>
    <td>
<div id="changestatusbox" runat="server">
<table border="0" width="250px">
<tr><td align="center"><br />
<b><u></u></b><br />
  <br />
   &nbsp;<input type="button" id="btnCStat" value="" class="cssButton" style="width:65px" runat="server" visible="false"/>
<br />&nbsp;
</td></tr>
</table>
</div>
</td>
</tr>
</table>
<table>
<tr>
<td style="color: burlywood"><input type="text" id="txtUserId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtCabang" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtDataId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtcekreffnumber" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtceknationalid" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtcekname" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtcekbirthdate" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtcektempatlahirdebitur" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtcekmobile" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtcekvaruserid" runat="server" style="display:none;color: burlywood;border:none" /></td>
</tr>
</table>
<br />

          <!-- Negative Record :--> <asp:Label ID="Label19" CssClass="cssLabelText"  runat="server" Text="" style="display:none"></asp:Label><br />  
        <asp:Button ID="Button1" runat="server" Text="Cek Asli RI" class="cssButton"  style="width:70px;display:none" />



                       <!-- Negative Record : --><asp:Label ID="NegativeRecords" CssClass="cssLabelText"  runat="server" Text="" style="display:none"></asp:Label><br />  
                    <%--	Phone Extra : <asp:Label ID="PhoneExtra1" runat="server" Text=""></asp:Label> /  <asp:Label ID="PhoneExtra2" runat="server" Text=""></asp:Label>--%>


</form>
<div id="divMsgBox"><div id="ContentString"></div></div>
</body>
</html>