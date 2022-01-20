<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrSearch.aspx.vb" Inherits="Aps2022.FrSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List of  Advance Payment Solution </title>
 
   <link href="../css/form.css" rel="stylesheet" />  
    <link href="../css/StyleList.css" rel="stylesheet" />
    <link href="../css/Styles.css" rel="stylesheet" />
     
    <script src="../script/general.js"></script>
    <script src="../script/cal2.js"></script>
    <script src="../script/cal_conf2.js"></script>
    
    <script src="../script/jquery-1.5.1.js"></script>
    <script src="../script/jquery.json-1.3.min.js"></script>
     
     <link href="../script/jquery.alerts.css" rel="stylesheet" />
    <script src="../script/jquery.alerts.js"></script>
     <script src="../script/FrSearch.js"></script> 

  <script type="text/javascript" >// here goes the script // 


  </script>
 <style>
     .myButton {
	box-shadow:inset 0px 1px 0px 0px #a4e271;
	background:linear-gradient(to bottom, #89c403 5%, #77a809 100%);
	background-color:#89c403;
	border-radius:6px;
	border:1px solid #74b807;
	display:inline-block;
	cursor:pointer;
	color:#ffffff;
	font-family:Arial;
	font-size:15px;
	font-weight:bold;
	padding:6px 14px;
	text-decoration:none;
	text-shadow:0px 1px 0px #528009;
}
.myButton:hover {
	background:linear-gradient(to bottom, #77a809 5%, #89c403 100%);
	background-color:#77a809;
}
.myButton:active {
	position:relative;
	top:1px;
}
 </style>
</head>
<body  >
  <form id="frmMain" method="post" runat="server">
        <table>
				<tr vAlign="top" height="30" width="200">
					<td style="HEIGHT: 37px" colSpan="3"><IMG style="WIDTH: 281px; HEIGHT: 58px" height="58" src="logo_buana.jpg" width="281"></td>
				</tr>
				<tr>
					<td colSpan="2"><a class="TextLink" style="FONT-WEIGHT: bold; COLOR: black; FONT-STYLE: normal; FONT-VARIANT: normal">List 
							Of Advance Payment Solution </a>
					</td>
				</tr>
				<tr>
					<td width="100"><a class="cssLabelText">PKS Number </a>
					</td>
					<td width="300"><input class="cssTextBox" id="txtPksNo" style="WIDTH: 200px" type="text" name="txtPksNo"
							runat="server">
					</td>
					<%--<td style="WIDTH: 100px"><a class="cssLabelText">Branch Id</a></td>
					<td style="HEIGHT: 19px" width="700" height="19"><input class="cssTextBox" id="TxtBranchID" style="DISPLAY: none" type="text" name="TxtBranchID"
							runat="server"> <input class="cssTextBox" id="txtBranch" style="WIDTH: 200px" readOnly type="text" name="txtBranch"
							runat="server"> <input class="cssButton" style="Z-INDEX: 102; POSITION: relative; TOP: 2px" onclick="browseBranch()"
							type="button" value="...">
					</td>--%>
				<%--</tr>
				<tr>--%> 
					<td width="100"><a class="cssLabelText">Supplier Name </a>
					</td>
					<td width="300"><input class="cssTextBox" id="txtSupplier" style="WIDTH: 200px" type="text" name="txtSupplier"
							runat="server">
					</td> 
				</tr>
                <tr>
                        <td style="HEIGHT: 36px" height="36"><a class="cssLabelText">PKS Date from </a></td>
                        <td colspan=3>
                        <input class="cssTextBoxNum" id="txtAprDate1" type="text" size="15" name="txtAprDate1" runat="server">
                        <small><A href="javascript:showCal('AprDate1')">Pick Date</A></small>
                        <a class="cssLabelText">To </a>
                        <input class="cssTextBoxNum" id="txtAprDate2" type="text" size="15" name="txtAprDate2" runat="server">
                        <small><A href="javascript:showCal('AprDate2')">Pick Date</A></small>
				     
                        </td> 
                </tr>

				<tr style="display:none">
					<td style="HEIGHT: 36px" height="36"><a class="cssLabelText">Due Date from </a></td>
					<td colspan=3>
					<input class="cssTextBoxNum" id="txtRequestdate1" type="text" size="15" name="txtRequestdate1" runat="server">
   <small><A href="javascript:showCal('camdate1')">Pick Date</A></small>
				    <a class="cssLabelText">To </a>
				    <input class="cssTextBoxNum" id="txtRequestdate2" type="text" size="15" name="txtRequestdate2" runat="server">
				     <small><A href="javascript:showCal('camdate2')">Pick Date</A></small>
				     
				    </td>
					 
				</tr>

				<%--<tr>
                    <td width="100"><a class="cssLabelText">Agreement No </a>
					</td>
					<td width="300"><input class="cssTextBox" id="txtAgreementno" style="WIDTH: 200px" type="text" name="txtAgreementno"
							runat="server">
					</td>
				</tr>--%>
				<tr>
					<td width="100">&nbsp;</td>
					<td>
                        <input class="myButton" id="btnRefresh"  type="button" value="Search Data"  onclick="SearchData()"
							name="btnRefresh" runat="server">  
                        <input class="myButton" id="btnReset" onclick="resetSearch()" type="button" value="Reset"
							name="btnReset">
                        <input class="myButton" id="btnNewData" onclick="ViewData('New')" type="button" value="New Data"
							name="btnNewData">
					</td>
				</tr>
             
			</table>
      <hr style="width:95%;text-align:left;margin-left:0">

          <!-- datagrid -->
      <link href="../css/demo_page.css" rel="stylesheet" />
      <link href="../css/demo_table_jui.css" rel="stylesheet" />
      <link href="../css/jquery-ui-1.8.4.custom.css" rel="stylesheet" />
      <script src="../css/jquery.dataTables.js"></script>
      <script src="../css/datesort.js"></script>
<!-- end of datagrid -->  
    <div id="DivQHead" style="border:0px solid gray; width:93%; margin-bottom: 1em; padding: 10px">
         <br />
        <div id="DivQ" class="tabcontent"></div>  
    </div>  


      <div id="dvLoader" style="display: none;"> 
    <div id="updateProgressBackgroundFilter" style="background-color: #f8fccf;
    filter: alpha(opacity=40); opacity: 0.80; width: 100%; top: 0px; left: 0px; position: fixed;">
    <h2>Please Wait..</h2>
    </div>          
    <style>
        .center {
        display: block;
        margin-left: auto;
        margin-right: auto;
        width: 50%;
        left:12%;
        top:12%;
        }
    </style>
    <div class="center" style="font-family: Trebuchet MS;        
        filter: alpha(opacity=100); opacity: 1; font-size: small; position: absolute;" >
        <%--<h2> on progress..</h2>--%>
        <br /><br /> 
        <img  alt="Loading" src="../css/loadingP.gif"  height="200" width="200"  alt="Paris" class="center" /> 
        </div>
    </div>


<input type="text" id="txtUserID" runat="server" style="display:none"  />

    </form>
</body>

</html>
