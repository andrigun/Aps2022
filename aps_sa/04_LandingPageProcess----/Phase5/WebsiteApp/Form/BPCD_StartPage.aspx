<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BPCD_StartPage.aspx.vb" Inherits="WebsiteApp.BPCD_StartPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="x-ua-compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
    <title>BPCD Screen</title>
   <script src="../JScript/jquery-1.5.1.js" type="text/javascript"></script>
    <script src="../JScript/jquery.json-1.3.min.js" type="text/javascript"></script>
 <!--    <script src="../JScript/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../JScript/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../JScript/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../JScript/jquery.ui.draggable.js" type="text/javascript"></script>
    <script src="../JScript/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../JScript/jquery.ui.dialog.js" type="text/javascript"></script>
    <script src="../JScript/popupForm.js" type="text/javascript"></script>
    <script src="../JScript/popupFormInv_sub.js" type="text/javascript"></script>
       <script src="../jscript/open_url.js"type="text/javascript"></script>-->
  <!--  <script src="../JScript/general.js" type="text/javascript"></script>-->
  <!--  <link href="../css/jquery.css" rel="stylesheet" type="text/css" /> -->
    <link href="../css/AccAcq.css" rel="stylesheet" type="text/css" />
 <!--   <link href="../css/jquery.ui.all.css" rel="stylesheet" type="text/css" /> -->
  
    <script type="text/javascript">
			var BranchId, Akses;
			$(document).ready(function () {
				 if (document.getElementById("txtBranchId").value="")
            {
								var style = document.createElement("style");
								style.innerHTML="body { display:none !important; }";
								document.getElementsByTagName("HEAD")[0].appendChild(style);
            }

					LoadingContent();  //penting untu loading image

							 BranchId = document.getElementById("txtBranchId").value;
							 Akses = document.getElementById("txtAccess").value;
          CallDataGrid(Akses, BranchId, "", "", 1, "", "");

				//Event klik button Search
             $("#btnSearch").click(function() {
             if (document.getElementById("txtCustName").value=="")
            {
            document.getElementById("txtCustName").value="%";
            }
							 SearchName = document.getElementById("txtCustName").value;
							 frmMain.hdnstatusid.value = '';

							   //tambahan feature sort sortings
							 varsortby = frmMain.hdnsortby.value;
							varsortmethod = frmMain.hdnsortmethod.value;
							 if (frmMain.hdnsortby.value == "") {
								 CallDataPageList(Akses, "allstatus", SearchName, BranchId, 1, "", "");
							 }
							 else {
								  CallDataPageList(Akses, "allstatus", SearchName, BranchId, 1, varsortby, varsortmethod);
							 }
							  //tambahan feature sort  --sortings end

            });
			});

					/// tambahan function untuk sorting --start  sortings
						function sortinglist(varsortby, varsortmethod)
		{
							frmMain.hdnsortby.value = varsortby;
							frmMain.hdnsortmethod.value = varsortmethod;
							statusid=document.getElementById("hdnstatusid").value;
							CallDataPageList(Akses, statusid, "%", BranchId, 1, varsortby, varsortmethod);
						//	alert(frmMain.hdnstatusid.value);
      }
			/// tambahan function untuk sorting --end  --sortings

			//Function number : 01 
			function openreview(stri)
			{
				
				document.getElementById("txtdataid").value=stri;
				 document.getElementById('btnredirect').click(); 
				//window.open("BPCD_Action.aspx?isviewinvho=0&view=info&reID=" + stri , "_blank"); 
      }
   
       //Function number : 02  
			function gotoPage(par_Page)
			{
           statusid=document.getElementById("hdnstatusid").value;
           search=document.getElementById("txtCustName").value;

			//	CallDataPageList(Akses, statusid, search, BranchId, par_Page, "", "") 

				//tambahan feature sort  --sortings start
				varsortby = frmMain.hdnsortby.value;
				varsortmethod = frmMain.hdnsortmethod.value;
				if (frmMain.hdnsortby.value == "") {
								 CallDataPageList(Akses, statusid, search, BranchId, par_Page, "", "") 
				}
				else {
				  CallDataPageList(Akses, statusid, search, BranchId, par_Page, varsortby, varsortmethod);
				}
				//tambahan feature sort  --sortings end
			}

			//Function number : 03
			function openstatuslist(statusid)
			{
           frmMain.hdnstatusid.value=statusid;
           document.getElementById("txtCustName").value="%";
			//	CallDataPageList(Akses, statusid, "%", BranchId, 1, "", "");

							//tambahan feature sort  --sortings start
							varsortby = frmMain.hdnsortby.value;
							varsortmethod = frmMain.hdnsortmethod.value;
							 if (frmMain.hdnsortby.value == "") {
								 CallDataPageList(Akses, statusid, "%", BranchId, 1, "", "");
							 }
							 else {
								  CallDataPageList(Akses, statusid, "%", BranchId, 1, varsortby, varsortmethod);
							 }
							//tambahan feature sort  --sortings end
      }

			//Function number : 04
      function CallDataGrid(Akses, BranchId, Str2, Str3, Page, OrderBy, AscDesc) //fungsi untuk menampilkan data Grid
			{
            var dataPassed = new Object();   
            dataPassed.Akses = Akses;
            dataPassed.BranchId = BranchId;
            dataPassed.Str2 = 'BPCD';
            dataPassed.Str3 = Str3;
            dataPassed.page = Page;
            dataPassed.OrderBy = OrderBy;
            dataPassed.AscDesc = AscDesc;
            $.ajax({
                type: "POST",
             url: "BPCD_Postback.asmx/displaydataPageStatus",
                //data: "{}",
                data: $.toJSON(dataPassed),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    Scrip = msg.d.split("__");
                  //  divDataList.innerHTML = Scrip[1];
                    eval(Scrip[0]);
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    alert("ERROR : " + errorThrown);
                    alert(XMLHttpRequest.responseText);
                }
            });
        }

      //Function number : 05   
       function CallDataPageList(Akses,StatusId,SearchName,BranchId, Page, OrderBy, AscDesc) //fungsi untuk menampilkan data Grid
			 {     
            var Scrip;
            var BranchID, Status, ReqDate, BranchAccess, DebiturName;
				 var dataPassed = new Object();   
				  dataPassed.Akses = Akses;
            dataPassed.StatusId = StatusId;
            dataPassed.SearchName = SearchName;
            dataPassed.BranchId = BranchId;
            dataPassed.page = Page;
            dataPassed.OrderBy = OrderBy;
				 dataPassed.AscDesc = AscDesc;
				 dataPassed.filtering1 = StatusId;
				 dataPassed.filtering2 = StatusId;
				 dataPassed.filtering3 = StatusId;
            $.ajax({
                type: "POST",
                url: "BPCD_Postback.asmx/displayDataPageStatusList",
                //data: "{}",
                data: $.toJSON(dataPassed),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    Scrip = msg.d.split("__");
                    divDataListInvReq.innerHTML = Scrip[1];
                    eval(Scrip[0]);
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    alert("ERROR : " + errorThrown);
                    alert(XMLHttpRequest.responseText);
                }
            });
        }
    </script>

<!-- //script untuk loading image -- START -->
<script type="text/javascript">

function LoadingContent() {
  $("#loading").ajaxStart(function() { $(this).show(); });
   $("#loading").ajaxStop(function() { $(this).hide(); });
}

function onReady(callback) {
  var intervalId = window.setInterval(function() {
    if (document.getElementsByTagName('body')[0] !== undefined) {
      window.clearInterval(intervalId);
      callback.call(this);
    }
  }, 100);
}
	function setVisible(selector, visible) {
	//fixinternetexplorer
 // document.querySelector(selector).style.display = visible ? 'block' : 'none';
}
onReady(function() {
  setVisible('.page', true);
  setVisible('#loading', false);
});
</script>

<style type="text/css">  
#loading {
  display: block;
  position: absolute;
  top: 0;
  left: 0;
  z-index: 100;
  width: 100vw;
  height: 100vh;
  background-color: rgba(192, 192, 192, 0.5);
  background-image: url("../images/loading.gif");
  background-repeat: no-repeat;
  background-position: center;
}
</style>
<!-- //script untuk loading image -- END -->

 <script type="text/javascript">
    function SetTarget() {
        document.forms[0].target = "_blank";
    }
</script>
</head>
<body>
<form id="frmMain" runat="server">
<table cellpadding="0" cellspacing="0" border="0" height="39" width="100%">
		<tr>
			<td width="100" height="39" valign="top">
				<img src="../images/logobnf.png" style=" border-width:1px;">
			</td>
			<td width="100%" valign="top" align="right">
			<font style="font-size:large; font-weight:bold;color:#00A321">Dashboard Multiguna - LOS</font><br />
               <font style="font-size:smaller;color:#00A321">BPCD Screen - List Data - <asp:Label ID="userid" runat="server" Text="Label"></asp:Label> (<asp:Label ID="branchid" runat="server" Text="Label"></asp:Label>)</font>
			</td>
		</tr>
</table>
<asp:Button ID="btnredirect" runat="server" Text="buttonredirect"  Style="display: none"  OnClick="btnredirect_Click" OnClientClick="SetTarget();" />
<br />
    <table border="0"  align="left" style="width:1000px;border-collapse:collapse;" >
    <tr><td valign="top" align="left" width="550px">
<div id="dynamiczone">
	<asp:ScriptManager ID="sm1" runat="server" />
		<asp:UpdatePanel runat="server" ID="up">
			<ContentTemplate>
				<div style="text-align:right" class="cssLabelFooter">(Waktu Refresh : <asp:Label ID="currentTime" runat="server" /> / 10 detik)</div>
				  <div runat="server" id="Dynamic_Panel" style="margin-bottom:10px;"></div><br />
				<asp:Timer runat="server" ID="refreshTimer" Interval="10000" Enabled="true" ontick="refreshTimer_Tick" />
			</ContentTemplate>
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="refreshTimer" EventName="Tick" />
			</Triggers>
	</asp:UpdatePanel>
</div>
</td></tr>
</table>
<br /><br /><br /><br />
<table><tr><td>&nbsp;</td><tr><table>
<table border=0 style="background-color:white;border-collapse: collapse;" border="0" cellspacing="0" cellpadding="0">
<tr>
    <td>
        <table border="0"  align="left" style="border-collapse: collapse;" height="30px" cellspacing="0" cellpadding="0" >   
            <tr>
                <td style="width:100px;" >Customer Name</td> 
                <td style="width:100px;" >           
                    <asp:TextBox ID="txtCustName" runat="server"  >%</asp:TextBox>
                    </td>
                    <td align="left">
                    <input type="button" id="btnSearch" class="cssButton3" value="Search Customer Name" style="margin-left:5px;width:150px;" />
                </td>
            </tr> 
        </table>
    </td>
</tr>  
</table>
<table style="background-color:white;border-collapse: collapse;" border="0" cellspacing="0" cellpadding="0">
<tr>
    <td valign="top" align="left" width="550px">
        <div id="divDataListInvReq" ></div>
    </td>
</tr>
</table>
<!-- paramater check START -->
<table>
<tr>
<td style="color: burlywood"><input id="hdnstatusid" name="hdnstatusid" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtBranchId" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtUserID" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtAccess" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input type="text" id="txtdataid" runat="server" style="display:none;color: burlywood;border:none" /></td>
<!-- sortings start -->
<td style="color: burlywood"><input id="hdnsortby" name="hdnsortby" runat="server" style="display:none;color: burlywood;border:none" /></td>
<td style="color: burlywood"><input id="hdnsortmethod" name="hdnsortmethod" runat="server" style="display:none;color: burlywood;border:none" /></td>
<!-- sorting end -->
</tr>
</table>
<!-- paramater check END -->
<div id="divMsgBox"  >  
<div id="ContentString"></div>      
</div>   
<div id="loading"></div>
<br />
<center>  <a class="cssLabelFooter">&copy; Dashboard LOS (Phase 5, P5B-Oktober 2021)   - Buana Finance 2021</a><br /></center>
 </form>
</body>
</html>