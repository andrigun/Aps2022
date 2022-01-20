<%@ Page Language="vb" AutoEventWireup="false"  EnableViewState="false"  CodeBehind="Host_IndentitasCadebRO.aspx.vb" Inherits="WebsiteApp.Host_IndentitasCadebRO" %>
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
/* background-image: url(); */
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
<table border="0" style="width:1180;border-collapse:collapse; overflow:hidden; white-space: nowrap;" >
<%--<table border="3" style="width:1180;border-color:#000000" >--%>
<tr> 
    <td style="width:100px; "><asp:Label ID="Label6" CssClass="cssLabelText"  runat="server" Text="Label">Prospect Id.</asp:Label></td>
		<td style="width:10;">:</td>
	  <td style="width:350px;"><asp:Label ID="txtprospectid" CssClass="cssLabelText" runat="server" Text="Label" Width="190px" ReadOnly Style="border:none;"></asp:Label></td> 
    <td rowspan="6" valign="top">
        <table>
            <tr><td>OTR</td><td>:</td><td>Rp. <asp:Label ID="txtotr" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label></td></tr>
            <tr><td>DP Amount</td><td>:</td><td>Rp. <asp:Label ID="txtdpamount" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label></td></tr>
            <tr><td>DP Percentage</td><td>:</td><td><asp:Label ID="txtdppercentage" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label>%</td></tr>
            <tr><td>PH Total Amount</td><td>:</td><td>Rp. <asp:Label ID="txtpokokhutang" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label></td></tr>
        </table>
    </td>
</tr>    
<tr> 
    <td style="width:100px; "><asp:Label ID="Label11" CssClass="cssLabelText"  runat="server" Text="Label">Cabang Asal / Cabang Tujuan</asp:Label></td>
		<td style="width:10;">:</td>
	  <td style="width:180px;">
		<asp:Label ID="txtcabangasal" CssClass="cssLabelText" runat="server" Text="Label" ReadOnly Style="border:none;"></asp:Label> /
		<asp:Label ID="txtcabangtujuan" CssClass="cssLabelText" runat="server" Text="Label" ReadOnly Style="border:none;"></asp:Label>
	  </td> 
 
</tr>  
<tr>
    <td style="width:150px;"><asp:Label ID="Label16" CssClass="cssLabelText" runat="server" Text="Label">Sumber Data</asp:Label></td>
		<td>:</td>
    <td style="width:180px;"><asp:Label ID="txtsumberdata" CssClass="cssLabelText" runat="server"  Width="190px" ReadOnly Style="border:none;"></asp:Label> </td>
 
</tr> 
<tr>
    <td style="width:150px;"><asp:Label ID="Label1" CssClass="cssLabelText" runat="server" Text="Label">Customer Name</asp:Label></td>
		<td>:</td>
    <td style="width:180px;"><asp:Label ID="txtname" CssClass="cssLabelText" runat="server"  Width="190px" ReadOnly Style="border:none;"></asp:Label> </td>

</tr> 
<tr>
    <td style="width:150px;"><asp:Label ID="Label2" CssClass="cssLabelText" runat="server" Text="Label">Nomor KTP</asp:Label></td> 
		<td>:</td>
    <td style="width:180px;">
		<asp:Label ID="txtktp" CssClass="cssLabelText" runat="server" ReadOnly Style="border:none;"></asp:Label>
		<div id="divbtnktp" runat="server" style="display:inline;">
		<input type="button" id="btnviewktp" value="" class="cssButtonLookup" runat="server" onclick="ViewKTP_exp()" />
        </div>
	 </td>

</tr> 
<tr>
    <td style="width:150px;"><asp:Label ID="Label12" CssClass="cssLabelText" runat="server" Text="Label">Nomor NPWP</asp:Label></td> 
		<td>:</td>
    <td style="width:180px;">
		<asp:Label ID="txtnpwp" CssClass="cssLabelText" runat="server" ReadOnly Style="border:none;"></asp:Label>
    </td>

</tr> 
<tr>
    <td style="width:150px; "><asp:Label ID="Label3" CssClass="cssLabelText" runat="server" Text="Label">Tempat & Tgl.Lahir</asp:Label></td> 
		<td>:</td>
    <td style="width:180px; "><asp:Label ID="txttgllahir" CssClass="cssLabelText" runat="server" Width="190px" ReadOnly Style="border:none;"></asp:Label></td>
     <td>&nbsp;</td>
</tr> 
<tr> 
    <td style="width:100px; "><asp:Label ID="Label13" CssClass="cssLabelText"  runat="server" Text="Label">Customer Model / Marital Status</asp:Label></td>
		<td style="width:10;">:</td>
	  <td style="width:180px;">
		<asp:Label ID="txtcustomermodel" CssClass="cssLabelText" runat="server" Text="Label" ReadOnly Style="border:none;"></asp:Label> /
		<asp:Label ID="txtmaritalstatus" CssClass="cssLabelText" runat="server" Text="Label" ReadOnly Style="border:none;"></asp:Label>
	  </td> 
     <td>&nbsp;</td>
</tr>  
<tr> 
    <td style="width:100px; "><asp:Label ID="Label15" CssClass="cssLabelText"  runat="server" Text="Label">Alamat Usaha</asp:Label></td>
		<td style="width:10;">:</td>
	  <td style="width:180px;"><asp:Label ID="txtalamatusaha" CssClass="cssLabelText" runat="server" Text="Label" Width="190px" ReadOnly Style="border:none;"></asp:Label></td> 
      <td>&nbsp;</td>
</tr>  
<tr>
    <td style="width:150px; "><asp:Label ID="Label4" CssClass="cssLabelText" runat="server" Text="Label">Nomor HP / Email</asp:Label></td> 
		<td>:</td>
    <td style="width:180px; "><asp:Label ID="txtphone" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label> / 
		<asp:Label ID="txtemail" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>
    </td>
     <td>&nbsp;</td>
</tr> 
<tr> 
    <td style="width:100px; "><asp:Label ID="Label17" CssClass="cssLabelText"  runat="server" Text="Label">Nama CMO / Nama DocPro</asp:Label></td>
		<td style="width:10;">:</td>
		 <td style="width:180px; ">
		<asp:Label ID="txtcmo" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label> /
		<asp:Label ID="txtdocpro" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>
	  </td> 
     <td>&nbsp;</td>
</tr>  
<tr> 
    <td style="width:100px; "><asp:Label ID="Label5" CssClass="cssLabelText"  runat="server" Text="Label">Order No. Confins / Prospect No.</asp:Label></td>
		<td style="width:10;">:</td>
		    <td style="width:180px; ">
		<asp:Label ID="txtordernoconfins" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label> /
		<asp:Label ID="txtprospectno" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label>
	  </td> 
      <td>&nbsp;</td>
</tr>  
  
<tr>
  <td style="width:150px;vertical-align:top" ><asp:Label ID="Label7" CssClass="cssLabelText" runat="server" Text="Label">Score List</asp:Label></td> 
  <td style="vertical-align:top">:</td>
   <td style="width:1000px;" colspan=2><i>(Informasi Score List dapat dilihat di tab Score List)</i></td>
</tr>

<!-- tambahan phase 2 photo taken dan pilihan survey start -->
            <tr>
                <td style="width:200px; " valign="top">Foto Sudah Diambil ?</td>
                <td valign="top">:</td>
                <td colspan="2">
                    <asp:RadioButton ID="rbpicunitY" runat="server" value="Y" Text="Ya" GroupName="rbKetersediaanFotoUnit" /> &nbsp;&nbsp;&nbsp; 
                    <asp:RadioButton ID="rbpicunitN" runat="server" value="N" Text="Tidak" GroupName="rbKetersediaanFotoUnit" />  
                </td>
            </tr>
            <tr>
                <td style="width:200px; " valign="top">Survey Pertama Terhadap</td>
                <td valign="top">:</td>
                <td colspan="2">
                    <asp:RadioButton ID="rbS1" runat="server" value="Debitur" Text="Debitur" GroupName="rbSurveyTerhadap" /> &nbsp;&nbsp;&nbsp; 
                    <asp:RadioButton ID="rbS2" runat="server" value="Unit" Text="Unit" GroupName="rbSurveyTerhadap" />  &nbsp;&nbsp;&nbsp; 
										<asp:RadioButton ID="rbS3" runat="server" value="DebUnit" Text="Debitur dan Unit" GroupName="rbSurveyTerhadap" />  
                </td>
            </tr>
<!-- tambahan phase 2 photo taken dan pilihan survey end -->
<tr>
    <td style="width:150px;vertical-align:top"><a class="cssLabelText" >Duplicate Cust. Checked</a></td> 
   <td style="vertical-align:top">:</td>
    <td style="width:1000px;" colspan=2><i>(Informasi Duplicate Cust. Checked dapat dilihat di tab Score List)</i></td>
</tr>
<tr>
    <td style="width:150px;vertical-align:top"><asp:Label ID="Label14" CssClass="cssLabelText"  runat="server" Text="Label">Notes SO</asp:Label></td> 
		  <td style="vertical-align:top">:</td>
		<td style="width:180px; " colspan="2"><asp:TextBox ID="txtnotesSO" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ReadOnly ></asp:TextBox>
		</td>
</tr>
<tr>
    <td style="width:150px;vertical-align:top"><asp:Label ID="Label10" CssClass="cssLabelText"  runat="server" Text="Label">Notes CRA</asp:Label></td> 
		  <td style="vertical-align:top">:</td>
		<td style="width:180px; " colspan="2"><asp:TextBox ID="txtnotes" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ></asp:TextBox>
		</td>
</tr>
<tr>
    <td style="width:150px;vertical-align:top"><asp:Label ID="Label18" CssClass="cssLabelText"  runat="server" Text="Label">Status Fast Track</asp:Label></td> 
		  <td style="vertical-align:top">:</td>
		   <td colspan="2">
                    <asp:RadioButton ID="cadebFTY" runat="server" value="Y" Text="Ya" GroupName="cadebfasttrack" /> &nbsp;&nbsp;&nbsp; 
                    <asp:RadioButton ID="cadebFTN" runat="server" value="N" Text="Tidak" GroupName="cadebfasttrack" />  
           </td>
</tr>
<tr style="vertical-align:top">
    <td style="width:150px;vertical-align:top"><asp:Label ID="Label8" CssClass="cssLabelText" runat="server" Text="Label">Notes BM</asp:Label></td> 
		<td>:</td>
		<td style="width:180px; " colspan="2"><asp:TextBox ID="txtnotesbm" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ></asp:TextBox>
		</td>
</tr>
<tr>
    <td style="width:150px; "><asp:Label ID="Label9" CssClass="cssLabelText" runat="server" Text="Label">Current Status</asp:Label></td> 
		<td>:</td>
    <td style="width:180px;" colspan="2">
        <asp:Label ID="txtstatus" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label>&nbsp;
        (By&nbsp;<asp:Label ID="txtstatusby" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>&nbsp;on&nbsp;
        <asp:Label ID="txtstatusdate" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>)<br />
    </td>
</tr>
</table>
<table style="border-collapse:collapse;width:100%">
<tr>
    <td><br /><center>
        <input type="button" id="btnJJSVY" value="Janji Survey" class="cssButton" runat="server" onclick="return btnJJSVY_onclick()" />
        <input type="button" id="btnCLSVY" value="Cancel Survey" class="cssButton" runat="server" onclick="return btnCLSVY_onclick()" />
				<input type="button" id="btntutup" value="Tutup" class="cssButton" runat="server" onclick="return closetab()" />
</center>
<br />
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
<td style="color: burlywood"><input type="text" id="txtsetstatus" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtUserId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtCabang" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtDataId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="cancelid" value="" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="changestatusid" value="" runat="server" style="display:block;color: burlywood;border:none" readonly /></td>
<td style="color: burlywood"><input type="text" id="hdnordernoconfins" runat="server" style="display:none;color: burlywood;border:none" /></td>
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
<center>  <a class="cssLabelFooter">&copy; Dashboard LOS (Phase 5, P5B-Oktober 2021)   - Buana Finance 2021</a><br /></center>
<asp:Button ID="Button1" runat="server" Text="Cek Asli RI" class="cssButton"  style="width:70px;display:none" />

<!-- Negative Record : --><asp:Label ID="NegativeRecordsx" CssClass="cssLabelText"  runat="server" Text="" style="display:none"></asp:Label><br />  
 <%--	Phone Extra : <asp:Label ID="PhoneExtra1" runat="server" Text=""></asp:Label> /  <asp:Label ID="PhoneExtra2" runat="server" Text=""></asp:Label>--%>

</form>
<div id="divMsgBox"><div id="ContentString"></div></div>
</body>
</html>