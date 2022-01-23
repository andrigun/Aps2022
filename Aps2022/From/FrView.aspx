<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrView.aspx.vb" Inherits="Aps2022.FrView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
   <link href="../css/form.css" rel="stylesheet" />  
    <link href="../css/StyleList.css" rel="stylesheet" />
    <link href="../css/Styles.css" rel="stylesheet" />
     

    <script src="../script/jquery.min.js"></script>
    <script src="../script/jquery-1.5.1.js"></script>
    <script src="../script/jquery.json-1.3.min.js"></script> 
    <link href="../script/jquery.alerts.css" rel="stylesheet" />
    <script src="../script/jquery.alerts.js"></script> 

    <script src="../script/general.js"></script>
    <script src="../script/cal2.js"></script>
    <script src="../script/cal_conf2.js"></script>
    

 <script src="../script/FrView.js"></script>  

    <title>Form Detail APS</title>
    
<script type="text/javascript"> 
//here goes the script..test !! 
</script> 
 
</head>
<body>
      <form id="frmMain" method="post" runat="server"> 
          
        <table> 
				<tr>
					<td colSpan="2"><a class="TextLink" style="FONT-WEIGHT: bold; COLOR: black; FONT-STYLE: normal; FONT-VARIANT: normal">
                        Detail of APS</a>
					</td>
				</tr>
            </table>
       <%--   <hr style="width:95%;text-align:left;margin-left:0">--%>


<style>
table.comicGreen {
  font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
  background-color: #FFFFFF;
  width: 95%;
  text-align: left;
  border-collapse: collapse;
}
table.comicGreen td, table.comicGreen th {
  border: 1px solid #4F7849;
  padding: 4px 3px;
}
table.comicGreen tbody td {
  font-size: 10px;
  color: #4F7849;
}
table.comicGreen tr:nth-child(even) {
  background: #CEE0CC;
}
table.comicGreen thead {
  background: #4F7849;
  background: -moz-linear-gradient(top, #7b9a76 0%, #60855b 66%, #4F7849 100%);
  background: -webkit-linear-gradient(top, #7b9a76 0%, #60855b 66%, #4F7849 100%);
  background: linear-gradient(to bottom, #7b9a76 0%, #60855b 66%, #4F7849 100%);
  border-bottom: 1px solid #444444;
}
table.comicGreen thead th {
  font-size: 15px;
  font-weight: bold;
  color: #FFFFFF;
  text-align: center;
  border-left: 2px solid #D0E4F5;
}
table.comicGreen thead th:first-child {
  border-left: none;
}

table.comicGreen tfoot td {
  font-size: 21px;
}
 </style>  

        <div id="DivQ"  ></div>
          <link href="../css/TabCS.css" rel="stylesheet" />
        
          <input type="text" id="txtReqID" runat="server" style='display:none'   />  
          <input type="text" id="txtUserID" runat="server" style="display:none" />

          <script>
        $(document).ready(function() {
    $("#content").find("[id^='tab']").hide(); // Hide all content
    $("#tabs li:first").attr("id","current"); // Activate the first tab
    $("#content #tab1").fadeIn(); // Show first tab's content

    $('#tabs a').click(function(e) {
        e.preventDefault();
        if ($(this).closest("li").attr("id") == "current"){ //detection for current tab
         return;
        }
        else{
          $("#content").find("[id^='tab']").hide(); // Hide all content
          $("#tabs li").attr("id",""); //Reset id's
          $(this).parent().attr("id","current"); // Activate this
          $('#' + $(this).attr('name')).fadeIn(); // Show content for the current tab
        }
    });
              });
</script>

<style>
     
.myButton {
box-shadow: inset 0px 1px 0px 0px #d9fbbe;
background: linear-gradient(to bottom, #b8e356 5%, #a5cc52 100%);
background-color: #b8e356;
border-radius: 6px;
border: 1px solid #83c41a;
display: inline-block;
cursor: pointer;
color: #ffffff;
font-family: Arial;
font-size: 15px;
font-weight: bold;
padding: 9px 13px;
text-decoration: none;
text-shadow: 0px 1px 0px #86ae47;
}

.myButton:hover {
    background: linear-gradient(to bottom, #a5cc52 5%, #b8e356 100%);
    background-color: #a5cc52;
}

.myButton:active {
    position: relative;
    top: 1px;
}

</style>
 <a id="LblSave">  </a> 

<br />
          


<ul id="tabs"> 
    <li><a href="#" name="tab1">List Of History </a></li>
    <li><a href="#" name="tab2">List Of Agreement  </a></li> 
</ul> 
<!-- datagrid -->  
     <link href="css/demo_page.css" rel="stylesheet" /> 
    <link href="css/demo_table_jui.css" rel="stylesheet" />
    <link href="css/jquery-ui-1.8.4.custom.css" rel="stylesheet" />
    <script src="css/jquery.dataTables.js"></script>
    <script src="css/datesort.js"></script>
<!-- end of datagrid --> 
<div id="content" style="border:hidden">
    <div id="tab1" ><div id="Divhist" class="tabcontent"></div></div> 
    <div id="tab2"></div> 
</div>


    </form>
</body>
</html>
