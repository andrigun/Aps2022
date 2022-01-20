<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Host_IndentitasCadebCA.aspx.vb" Inherits="WebsiteApp.Host_IndentitasCadebCA" %>
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
<title>Halaman Review</title>
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

				savedata(setstatus, note, user, cabang, dataid, surveyI, isfasttrack);
        }

         function savedata(setstatus, note, user, cabang, dataid, surveyI, isfasttrack) {
             var Scrip;
             var dataPassed = new Object();
		        //create the data object for passing data to Web Service
             dataPassed.setstatus = setstatus;
             dataPassed.note = note;
             dataPassed.user = user;
             dataPassed.cabang = cabang;
                 dataPassed.dataid = dataid;
             dataPassed.surveyI = surveyI
             dataPassed.isfasttrack = isfasttrack
				 $.ajax({
                 type: "POST",
                 url: "CA_Postback.asmx/subApproval",
                 //data: "{}",
                 data: $.toJSON(dataPassed),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function(msg) {
                 var str;
                 str = "<table align='left' border='0' ><tr>" +
                                          "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                          "<td><b>" + msg.d + "</b></td></table>"
								
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
                document.getElementById("txtDataId").value;
                radios = document.getElementsByName('rbSurveyTerhadap');
             
                 if (document.getElementById('rbS1').checked) {
                     surveyI = "Debitur";
                 } else {
													if (document.getElementById('rbS2').checked) {
														surveyI = "Unit";
													} else {
															surveyI = "DebUnit";
													}
                 } 

                 if (document.getElementById('cadebFTY').checked) {
                     isfasttrack = "Y";
                 } else {
						if (document.getElementById('cadebFTN').checked) { isfasttrack = "N"; } 
                 }

               //   alert(isfasttrack);

			 }     
			 
			 function closetab() {
                 window.close();
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

            //       alert("http://10.10.1.88:4455/bnf/fotodms/view?order_no='"+ orderno + "'");


    showMsgBox('Dokumen KTP', str, 'Tutup', '', 'CloseDialogBox()', '', 800, '');
         }

         function RQSVY() {
					if (document.getElementById("txtnotes").value == "") {
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                        "<td><img src='../css/Images/Qred.png' />&nbsp;</td>" +
                        "<td><b>Kolom Notes masih kosong, lengkapi dahulu untuk lanjut proses.</b></td></tr></table>"
                         showMsgBox('Peringatan !', str, 'Ok', '', 'CloseDialogBox()', '', 300, '');
                    } else if (document.getElementById('rbS1').checked == false && document.getElementById('rbS2').checked == false && document.getElementById('rbS3').checked == false) {
                        var str;
                         str = "<table align='left' border='0' ><tr>" +
                        "<td><img src='../css/Images/Qred.png' />&nbsp;</td>" +
                        "<td><b>Survey Pertama Terhadap Harus Diisi</b></td></tr></table>"
                         showMsgBox('Peringatan !', str, 'Ok', '', 'CloseDialogBox()', '', 300, '');
                    }
                     else {
						document.getElementById("txtsetstatus").value = 'RQSVY';
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                                  "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                  "<td><b>Set status sebagai 'Request Survey' ?</b></td></tr></table>"
                         showMsgBox('Konfirmasi Status : Request Survey', str, 'Ya', 'Tidak', 'WaitSaving()', 'CloseDialogBox()', 300, '', 100, 500);
                     }
                 }

         function DROPD() {
                if (document.getElementById("txtnotes").value == "") {
                         var str;
                         str = "<table align='left' border='0' ><tr>" +
                        "<td><img src='../css/Images/Qred.png' />&nbsp;</td>" +
                        "<td><b>Kolom Notes masih kosong, lengkapi dahulu untuk lanjut proses.</b></td></tr></table>"
                         showMsgBox('Peringatan', str, 'Ok', '', 'CloseDialogBox()', '', 300, '');
                     }
                     else {
                     document.getElementById("txtsetstatus").value='DROPD';
                    var str;
                  //  alert('Notifikasi.');
                         str = "<table align='left' border='0' ><tr>" +
                                  "<td><img src='../css/Images/Iblack.png' />&nbsp;</td>" +
                                  "<td><b>Set status sebagai 'Drop Data' ?</b></td></tr></table>"
                         showMsgBox('Konfirmasi Status : Drop Data', str, 'Ya', 'Tidak', 'WaitSaving()', 'CloseDialogBox()', 300, '', 100, 500);
                     }
         }

         		
   </script>
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
               <font style="font-size:smaller;color:#00A321">CRA Screen - <asp:Label ID="lblactivity" runat="server" Text="Label"></asp:Label> - <asp:Label ID="userid" runat="server" Text="Label"></asp:Label> (<asp:Label ID="branchid" runat="server" Text="Label"></asp:Label>)</font>
			</td>
		</tr>
</table>
<table runat="server"  cellSpacing='0' cellPadding='0'  border='0' width="793px" align="left">
    <tr><td id="tdtabdisplay" runat="server"></td></tr>
	<tr><td style="background-color:#008CFF; height:5px;"></td></tr>
</table> 
<table border="0" style="width:1180;border-collapse:collapse; overflow:hidden; white-space: nowrap;" >
 <%--   <table border="3" style="width:1180;border-color:#000000" >--%>
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
		<asp:Label ID="txtcabangtujuan" CssClass="cssLabelText" runat="server" Text="Label" ReadOnly Style="border:none;"></asp:Label></td> 
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
		<td style="width:180px; " colspan="2"><asp:TextBox ID="txtnotesSO" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;"  ReadOnly ></asp:TextBox>
		</td>
</tr>
<tr>
    <td style="width:150px;vertical-align:top"><asp:Label ID="Label8" CssClass="cssLabelText"  runat="server" Text="Label">Notes CRA</asp:Label></td> 
		  <td style="vertical-align:top">:</td>
		<td style="width:180px; " colspan="2"><asp:TextBox ID="txtnotes" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ></asp:TextBox>
		</td>
</tr>
<tr>
    <td style="width:150px;vertical-align:top">Status Fast Track</td> 
		  <td style="vertical-align:top">:</td>
		   <td colspan="2">
                    <asp:RadioButton ID="cadebFTY" runat="server" value="Y" Text="Ya" GroupName="cadebfasttrack" /> &nbsp;&nbsp;&nbsp; 
                    <asp:RadioButton ID="cadebFTN" runat="server" value="N" Text="Tidak" GroupName="cadebfasttrack" />  
           </td>
</tr>


<div id="divnotebm" runat="server">
<tr>
    <td style="width:150px;vertical-align:top"><asp:Label ID="Label9" CssClass="cssLabelText" runat="server" Text="Label">Notes BM</asp:Label></td> 
		<td>:</td>
		<td style="width:180px; " colspan="2"><asp:TextBox ID="txtnotesbm" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ></asp:TextBox>
		</td>
</tr>
</div>
<tr>
    <td style="width:150px; "><asp:Label ID="Label10" CssClass="cssLabelText" runat="server" Text="Label">Current Status</asp:Label></td> 
		<td>:</td>
    <td style="width:180px; " colspan="2">
        <asp:Label ID="txtstatus" runat="server" CssClass="cssLabelText" ReadOnly Style="border:none;"></asp:Label>&nbsp;
        (By&nbsp;<asp:Label ID="txtstatusby" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>&nbsp;on&nbsp;
        <asp:Label ID="txtstatusdate" runat="server" CssClass="cssLabelText"  ReadOnly Style="border:none;"></asp:Label>)
    </td>
</tr>
</table><br />
 <table style="border-collapse:collapse;width:100%">
<tr>
    <td><center>
        <input type="button" id="btnRQSVY" value="Request Survey" class="cssButton" runat="server" onclick="RQSVY()" />
        <input type="button" id="btnDROPD" value="Drop Data" class="cssButton" runat="server" onclick="DROPD()" />
		<input type="button" id="btntutup" value="Tutup" class="cssButton" runat="server" onclick="return closetab()" />
    </center>
</td>
</tr>
</table>
<table>
<tr>
<td style="color: burlywood"><input type="text" id="txtsetstatus" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtUserId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtCabang" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtDataId" runat="server" style="display:none;color: burlywood;border:none" /></td>
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

	
      <!-- Negative Record :--> <asp:Label ID="Label18" CssClass="cssLabelText"  runat="server" Text="" style="display:none"></asp:Label><br />  
        <asp:Button ID="Button1" runat="server" Text="Cek Asli RI" class="cssButton"  style="width:70px;display:none" />


    <!-- Negative Record :--> <asp:Label ID="NegativeRecords" CssClass="cssLabelText"  runat="server" Text="" style="display:none"></asp:Label><br />  
        <asp:Button ID="btncekasiri" runat="server" Text="Cek Asli RI" class="cssButton"  style="width:70px;display:none" />
    </form>
		<div id="divMsgBox"><div id="ContentString"></div></div>
</body>
</html>
