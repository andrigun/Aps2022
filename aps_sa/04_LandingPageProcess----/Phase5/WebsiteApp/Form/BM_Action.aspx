<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BM_Action.aspx.vb" Inherits="WebsiteApp.BM_Action" %>
<%@ Register Src="~/UserControl/ucAssetShowrom.ascx" TagName="WebControl" TagPrefix="usAssetShowrom" %>
<%@ Register Src="~/UserControl/ucSurvey.ascx" TagName="WebControl2" TagPrefix="ucSurvey" %>
<%@ Register Src="~/UserControl/ucCreditCalculator.ascx" TagName="WebControl3" TagPrefix="ucCreditCalculator" %>
<%@ Register Src="~/UserControl/ucCamSurvey.ascx" TagName="WebControl4" TagPrefix="ucCamSurvey" %>
<%@ Register Src="~/UserControl/ucRefund.ascx" TagName="WebControl5" TagPrefix="ucRefund" %>
<%@ Register Src="~/UserControl/ucRelatedData.ascx" TagName="WebControl6" TagPrefix="ucRelated" %>
<%@ Register Src="~/UserControl/ucCatatanDocpro.ascx" TagName="WebControl7" TagPrefix="ucCatatanDocpro" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd class="tablegrid2" XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd class="tablegrid2"/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    
<title>Halaman Review oleh BM</title>
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
         $(document).ready(function() {
					 LoadingContent();	
					            
         });

        function WaitSaving() {
                var str;
                str = "<table align='left' border='0' ><tr>" +
                                  "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                  "<td><b>Data sedang disimpan....</b></td></tr></table>"
               showMsgBox_WaitAMoment('Informasi', str, 'Ok', '', 'parent.refListDat()', '', 300, '');
             GetLocalValueReview();
                savedata(setstatus, note, user, cabang, dataid);
        }

			 function savedata(setstatus, note, user, cabang, dataid) {
             var Scrip;
             var dataPassed = new Object();
		        //create the data object for passing data to Web Service
             dataPassed.setstatus = setstatus;
             dataPassed.note = note;
             dataPassed.user = user;
             dataPassed.cabang = cabang;
             dataPassed.dataid = dataid;
						 dataPassed.cancelid = cancelid;
             $.ajax({
                 type: "POST",
                 url: "BM_Postback.asmx/subApproval",
                 //data: "{}",
                 data: $.toJSON(dataPassed),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function(msg) {
                 var str;
                 str = "<table align='left' border='0' ><tr>" +
                                          "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                          "<td><b>Data berhasil disimpan</b></td></tr></table>"

                 showMsgBox('Informasi', str, 'Tutup', '', 'closetab()', '', 300,'');
                 },
                 error: function(XMLHttpRequest, textStatus, errorThrown) {
                     alert(XMLHttpRequest.responseText);
                 }
             });
         }
   
         function GetLocalValueReview() {     
           setstatus = document.getElementById("txtsetstatus").value;
           user = document.getElementById("txtUserId").value;
           note = document.getElementById("txtnotes").value;
           cabang = document.getElementById("txtCabang").value;
					 dataid = document.getElementById("txtDataId").value;
					 cancelid = document.getElementById("cancelid").value;
			 }     

			 function closetab() {
				 window.close() ;
			 }

			 function LoadingContent() {
  $("#loading").ajaxStart(function() { $(this).show(); });
   $("#loading").ajaxStop(function() { $(this).hide(); });
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

         function BMEND() {
if ((document.getElementById("txtnotes").value == "")) {
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                        "<td><img src='../css/Images/Qred.png' />&nbsp;</td>" +
                        "<td><b>Kolom Notes belum diisi, lengkapi dahulu untuk lanjut proses.</b></td></tr></table>"
                         showMsgBox('Peringatan', str, 'Ok', '', 'CloseDialogBox()', '', 300, '');
                     }
                     else {
                     document.getElementById("txtsetstatus").value='BMEND';
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                                  "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                  "<td><b>Set status sebagai 'Drop Data by BM' ?</b></td></tr></table>"
                         showMsgBox('Konfirmasi Status : End Prospect', str, 'Ya', 'Tidak', 'WaitSaving()', 'CloseDialogBox()', 300, '', 100, 500);
                     }
         }

         function BMREQ() {
                 if (document.getElementById("txtnotes").value == "") {
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                        "<td><img src='../css/Images/Qred.png' />&nbsp;</td>" +
                        "<td><b>Kolom Notes masih kosong, lengkapi dahulu untuk lanjut proses.</b></td></tr></table>"
                         showMsgBox('Peringatan !', str, 'Ok', '', 'CloseDialogBox()', '', 300, '');
                     }
                     else {
                     document.getElementById("txtsetstatus").value='BMREQ';
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                                  "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                  "<td><b>Set status sebagai 'Override by BM' ?</b></td></tr></table>"
                         showMsgBox('Konfirmasi Status : Re-Reqest to CRA', str, 'Ya', 'Tidak', 'WaitSaving()', 'CloseDialogBox()', 300, '', 100, 500);
                     }
                 }
   </script>
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
               <font style="font-size:smaller;color:#00A321">BM Screen - <asp:Label ID="lblactivity" runat="server" Text="Label"></asp:Label> - <asp:Label ID="userid" runat="server" Text="Label"></asp:Label> (<asp:Label ID="branchid" runat="server" Text="Label"></asp:Label>)</font>
			</td>
		</tr>
</table>

<div class="responsive-tabs">
			<h2>Identitas Calon Debitur</h2>
			<div>
<table border="0" style="width:1180;border-collapse:collapse; overflow:hidden; white-space: nowrap;" >
<tr> 
    <td style="width:100px; "><asp:Label ID="Label6" CssClass="cssLabelText"  runat="server" Text="Label">Prospect Id.</asp:Label></td>
		<td style="width:10;">:</td>
	  <td style="width:180px;"><asp:Label ID="txtprospectid" CssClass="cssLabelText" runat="server" Text="Label" Width="190px" ReadOnly Style="border:none;"></asp:Label></td> 
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
    <td style="width:150px;"><asp:Label ID="Label160" CssClass="cssLabelText" runat="server" Text="Label">Sumber Data</asp:Label></td>
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
		 <input type="button" id="btnviewktp" value="" class="cssButtonLookup" runat="server" onclick="ViewKTP()" />

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
</tr> 
<tr> 
    <td style="width:100px; "><asp:Label ID="Label13" CssClass="cssLabelText"  runat="server" Text="Label">Customer Model / Marital Status</asp:Label></td>
		<td style="width:10;">:</td>
	  <td style="width:180px;">
		<asp:Label ID="txtcustomermodel" CssClass="cssLabelText" runat="server" Text="Label" ReadOnly Style="border:none;"></asp:Label> /
		<asp:Label ID="txtmaritalstatus" CssClass="cssLabelText" runat="server" Text="Label" ReadOnly Style="border:none;"></asp:Label>
	  </td> 
</tr>  
<tr> 
    <td style="width:100px; "><asp:Label ID="Label15" CssClass="cssLabelText"  runat="server" Text="Label">Alamat Usaha</asp:Label></td>
		<td style="width:10;">:</td>
	  <td style="width:180px;"><asp:Label ID="txtalamatusaha" CssClass="cssLabelText" runat="server" Text="Label" Width="190px" ReadOnly Style="border:none;"></asp:Label></td> 
</tr>  
<tr>
    <td style="width:150px; "><asp:Label ID="Label4" CssClass="cssLabelText" runat="server" Text="Label">Nomor HP / Email</asp:Label></td> 
		<td>:</td>
    <td style="width:180px; "><asp:Label ID="txtphone" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label> / 
		<asp:Label ID="txtemail" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>
    </td>
</tr> 
<tr> 
    <td style="width:100px; "><asp:Label ID="Label17" CssClass="cssLabelText"  runat="server" Text="Label">Nama CMO / Nama DocPro</asp:Label></td>
		<td style="width:10;">:</td>
		 <td style="width:180px; ">
		<asp:Label ID="txtcmo" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label> /
		<asp:Label ID="txtdocpro" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>
	  </td> 
</tr>  
<tr> 
    <td style="width:100px; "><asp:Label ID="Label5" CssClass="cssLabelText"  runat="server" Text="Label">Order No. Confins / Prospect No.</asp:Label></td>
		<td style="width:10;">:</td>
		    <td style="width:180px; ">
		<asp:Label ID="txtordernoconfins" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label> /
		<asp:Label ID="txtprospectno" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label>
	  </td> 
</tr>  
<tr>
  <td style="width:150px;vertical-align:top" ><asp:Label ID="Label7" CssClass="cssLabelText" runat="server" Text="Label">Score List</asp:Label></td> 
		 <td style="vertical-align:top">:</td>
   <td style="width:800px;">
	  <table border="0" style="width:600;border-collapse:collapse; overflow:hidden; white-space: nowrap;" ><tr><td>
	<asp:Label ID="finaldecision" runat="server" Text="" Style="display:none"></asp:Label>
	 <table border="1" style="cell-spacing:0; cell-padding:0; border-collapse:collapse;border-color:cornflowerblue;border-width:thin;">
	 <tr style="background-color:cornflowerblue; font-weight:bold;color:#fff"><td width="120px" style="text-align:center">Scoring Name</td><td width="100px" style="text-align:center">Result</td><td width="100px" style="text-align:center">Decision</td></tr>
	 	<tr><td>E-KTP</td><td style="text-align:center"><asp:Label ID="ektp1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="ektp2" runat="server" Text=""></asp:Label></td></tr>
	<tr><td>APPI</td><td style="text-align:center"><asp:Label ID="appi1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="appi2" runat="server" Text=""></asp:Label></td></tr>
	<tr><td>SLIK</td><td style="text-align:center"><asp:Label ID="slik1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="slik2" runat="server" Text=""></asp:Label></td></tr>
	<tr><td>Pefindo</td><td  style="text-align:center"><asp:Label ID="pefindo1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="pefindo2" runat="server" Text=""></asp:Label></td></tr>
	<tr><td>Telco</td><td style="text-align:center"><asp:Label ID="telco1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="telco2" runat="server" Text=""></asp:Label></td></tr>
	
       <tr><td>Criminal Record Asli RI</td><td style="text-align:center"><asp:Label ID="negrec1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="negrec2" runat="server" Text="">-</asp:Label></td></tr>
    <tr><td>Negative List Confins</td><td style="text-align:center"><asp:Label ID="negconfins1" runat="server" Text=""></asp:Label></td><td style="text-align:center"><asp:Label ID="negconfins2" runat="server" Text="">-</asp:Label></td></tr>
 
     </table>
	</td><td>&nbsp;&nbsp;</td>
	<td valign="top" width="200px">
	<!--Negative Record :--> <asp:Label ID="NegativeRecords" runat="server" Text="" style="display:none"></asp:Label><br />
	Phone Extra : <asp:Label ID="PhoneExtra1" CssClass="cssLabelText"  runat="server" Text=""></asp:Label> /  <asp:Label ID="PhoneExtra2" CssClass="cssLabelText"  runat="server" Text=""></asp:Label>
	</td>
	</tr></table>
   </td>
</tr> 
<div id="reactaction" runat="server">
<tr>
    <td style="width:150px; "><a class="cssLabelText" >&nbsp;&nbsp;Alasan Diajukan Kembali a</a></td> 
		<td>:</td>
    <td style="width:180px;vertical-align:top;">
		&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" style="width:200px;color:#383838; height:20px;font-style:italic;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
		<i>*</i>
 </td>
</tr> 
</div>

<div id="reactdisplay" runat="server">
<tr>
    <td style="width:150px; "><a class="cssLabelText" >&nbsp;&nbsp;Alasan Diajukan Kembali b</a></td> 
		<td>:</td>
    <td style="width:180px;vertical-align:top;">
		&nbsp;&nbsp;<asp:TextBox ID="txtcanceldesc" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> 
 </td>
</tr> 
</div>

<!-- tambahan phase 2 photo taken dan pilihan survey start -->
            <tr>
                <td style="width:200px; " valign="top">Foto Sudah Diambil ?</td>
                <td valign="top">:</td>
                <td>
                    <asp:RadioButton ID="rbpicunitY" runat="server" value="Y" Text="Ya" GroupName="rbKetersediaanFotoUnit" /> &nbsp;&nbsp;&nbsp; 
                    <asp:RadioButton ID="rbpicunitN" runat="server" value="N" Text="Tidak" GroupName="rbKetersediaanFotoUnit" />  
                </td>
            </tr>
            <tr>
                <td style="width:200px; " valign="top">Survey Pertama Terhadap</td>
                <td valign="top">:</td>
                <td>
                    <asp:RadioButton ID="rbS1" runat="server" value="Debitur" Text="Debitur" GroupName="rbSurveyTerhadap" /> &nbsp;&nbsp;&nbsp; 
                    <asp:RadioButton ID="rbS2" runat="server" value="Unit" Text="Unit" GroupName="rbSurveyTerhadap" />  &nbsp;&nbsp;&nbsp; 
										<asp:RadioButton ID="rbS3" runat="server" value="DebUnit" Text="Debitur dan Unit" GroupName="rbSurveyTerhadap" />  
                </td>
            </tr>
<!-- tambahan phase 2 photo taken dan pilihan survey end -->

<tr>
    <td style="width:150px;vertical-align:top"><a class="cssLabelText" >Duplicate Cust. Checked</a></td> 
   <td style="vertical-align:top">:&nbsp;</td>
	<td style="width:400px;>
	  <div runat="server" id="viewcekduplikat" style="margin-bottom:10px;"></div>
		</td>
 </tr>

<tr>
    <td style="width:150px;vertical-align:top"><asp:Label ID="Label14" CssClass="cssLabelText"  runat="server" Text="Label">Notes SO</asp:Label></td> 
		  <td style="vertical-align:top">:</td>
		<td style="width:180px; "><asp:TextBox ID="txtnotesSO" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ReadOnly ></asp:TextBox>
		</td>
</tr>

<tr style="vertical-align:top">
    <td style="width:150px;vertical-align:top"><a  class="cssLabelText" >Notes CRA</a></td> 
		<td>:</td>
		<td style="width:180px; "><asp:TextBox ID="txtnotescra" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ></asp:TextBox>

		</td>
</tr>
<tr style="vertical-align:top">
    <td style="width:150px;vertical-align:top"><a  class="cssLabelText" >Notes BM</a></td> 
		<td>:</td>
		<td style="width:180px; "><asp:TextBox ID="txtnotes" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ></asp:TextBox>

		</td>
</tr>
<tr>
    <td style="width:150px; "><asp:Label ID="Label9" CssClass="cssLabelText" runat="server" Text="Label">Current Status</asp:Label></td> 
		<td>:</td>
    <td style="width:180px; ">
        <asp:Label ID="txtstatus" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label>&nbsp;
        (By&nbsp;<asp:Label ID="txtstatusby" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>&nbsp;on&nbsp;
        <asp:Label ID="txtstatusdate" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>)
    </td>
</tr>
</table>

<br />

<table style="border-collapse:collapse;width:100%">
<tr>
    <td><center>
        <input type="button" id="btnBMREQ" value="Override by BM" class="cssButton" runat="server" onclick="BMREQ()" />
        <input type="button" id="btnBMEND" value="Drop Data by BM" class="cssButton" runat="server" onclick="BMEND()" />
				<input type="button" id="btntutup" value="Tutup" class="cssButton" runat="server" onclick="return closetab()" />
</center>
	<br /><br />	
	<div id="notereact" runat="server">
<!--	&nbsp;&nbsp;<i>*Dipilih jika ada permintaan pembatalan (cancel) survey.</i> -->
	</div>
</td>
</tr>
</table>
      </div>
   

			 	<!-- #####  Bagian Tab-UserControl START   ######-->
				<h2>Customer Related Data</h2>
						<div><ucRelated:WebControl6 ID="relateddata" runat="server" /></div>
       <h2>Asset & Showroom</h2>
							<div><usAssetShowrom:WebControl ID="AssetShowrom" runat="server"></usAssetShowrom:WebControl></div>
			 <h2>Survey</h2>
							<div><ucSurvey:WebControl2 ID="survey" runat="server"></ucSurvey:WebControl2></div>
			 <h2>Cam Survey</h2>
							<div><ucCamSurvey:WebControl4 ID="camSurvey" runat="server"></ucCamSurvey:WebControl4></div>
			<h2>Calculator</h2>
							<div><ucCreditCalculator:WebControl3 ID="calculator" runat="server"></ucCreditCalculator:WebControl3></div>
			<h2>Calculator Refund</h2>
							<div><ucRefund:WebControl5 ID="calrefund" runat="server"></ucRefund:WebControl5></div>
      <h2>Catatan Docpro</h2>
    				    <div><ucCatatanDocpro:WebControl7 ID="catatandocpro" runat="server"></ucCatatanDocpro:WebControl7></div>
				<!-- #####   Bagian Tab-UserControl END    ######-->

</div>


<!-- paramater check START -->
<table>
<tr>
<td style="color: burlywood"><input type="text" id="txtsetstatus" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtUserId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtCabang" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtDataId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="cancelid" value="" runat="server" style="display:none;color: burlywood;border:none" /></td>

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

<!-- paramater check END -->
<!-- <img src="../images/image.jpg" style="width:100%;">  -->
<br />
<center>  <a class="cssLabelFooter">&copy; Dashboard LOS (Phase 4, P4A-MAY 2021)  - Buana Finance 2021</a><br /></center>
    </form>

     <div id="divMsgBox"><div id="ContentString"></div></div>

</body>
</html>
