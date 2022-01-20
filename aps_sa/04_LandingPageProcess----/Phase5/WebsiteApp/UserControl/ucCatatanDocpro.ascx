<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCatatanDocpro.ascx.vb" Inherits="WebsiteApp.ucCatatanDocpro" %>
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

<script type = "text/javascript">
function myFunction() {
    document.getElementById("demo").innerHTML = "Hello World";
    alert(document.getElementById("txtnotes").value);
}

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Set this data status as 'Return' ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function RespondBranch() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Submit this Respond ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
</script>

<table border="0" style="width:1000;border-collapse:collapse;" > 
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Customer Name</a></td>
                <td style="width:10px;">:</td>
		        <td style="width:800px;"><asp:TextBox ID="txtCustomerName" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr> 
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Prospect No</a></td>
                <td style="width:10px;">:</td>
                <td style="width:800px;"><asp:TextBox ID="txtProspectNo" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Order No</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtOrderNo" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
     
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Asset Type</a></td>
                <td style="width:10px;">:</td>
                <td style="width:480px;"><asp:TextBox ID="txtAssetType" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
       <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Nama Supplier</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtNamaSupplier" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
    <tr><td colspan="3" ><a  class="cssLabelText" >&nbsp;</a></td></tr>
    <tr><td style="width:50px; background-color:cornflowerblue;" colspan="3" ><a  class="cssLabelText" >&nbsp;</a></td></tr>
 <tr><td colspan="3" ><a  class="cssLabelText" >&nbsp;</a></td></tr>
<tr style="vertical-align:top">
    <td style="width:200px;vertical-align:top"><a  class="cssLabelText" >
        <asp:Label ID="txtlabelnotes" runat="server" Text=""></asp:Label></a></td> 
		<td style="width:10px;"><asp:Label ID="txttitikdua" runat="server" Text=""></asp:Label></td>
		<td style="width:180px; "><asp:TextBox ID="txtnotes" TextMode="MultiLine" lines="10" cols="800" maxlength="1200" wrap="true"  runat="server" CssClass="inptype" style="width:800px;height:40px;white-space: pre-wrap;" ></asp:TextBox>
		</td>
</tr>
     <tr><td colspan="3" ><a  class="cssLabelText" >&nbsp;</a></td></tr>
    <tr style="vertical-align:top">
    <td style="width:200px;vertical-align:top">&nbsp;</td> 
		<td style="width:10px;">&nbsp;</td>
		<td style="width:180px; ">
              <asp:Button ID="Button2" runat="server" Text="Return"  
                           CssClass="cssButton"  OnClientClick="Confirm()" 
                           Width="186px" />
              <asp:Button ID="btnrespond" runat="server" Text="Submit Respond"  
                           CssClass="cssButton"  OnClientClick="RespondBranch()" 
                           Width="186px" />
            <div id="savingdata" runat="server">
            <center>
                <marquee width="300px" behavior="alternate" bgcolor="pink">Saving data...Please wait...</marquee>
                Saving data...Please wait...<br />
                <img src='../images/saving.gif' />
            </center>
            </div>
        		</td>
</tr>
</table>
<br /><br />
<table border="0" style="width:930px;border-collapse:collapse; overflow:hidden; white-space: nowrap;" >
<tr>
	<td style="width:930px;">
        <b><u>Log Catatan Docpro</u></b>
	  <div runat="server" id="viewcekduplikat" style="margin-bottom:10px;"></div>
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
</tr>
</table>