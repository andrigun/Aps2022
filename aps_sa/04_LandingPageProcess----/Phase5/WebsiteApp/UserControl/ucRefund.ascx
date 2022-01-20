<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRefund.ascx.vb" Inherits="WebsiteApp.ucRefund" %>
<table border="0" style="width:1000;border-collapse:collapse;" > 
    <tr>
        <td style="width:200px;"><a  class="cssLabelText" >Customer Name</a></td> 
        <td style="width:10px" >:</td>
		<td style="width:800px;"><asp:TextBox ID="txtRCustomerName" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
    </tr>
     <tr>
        <td style="width:200px;"><a  class="cssLabelText" >Prospect No</a></td> 
        <td style="width:10px">:</td>
		<td style="width:800px;"><asp:TextBox ID="txtRProspectNo" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
    </tr>
     <tr>
        <td style="width:200px;"><a  class="cssLabelText" >Condition</a></td> 
        <td style="width:10px">:</td>
		<td style="width:800px;"><asp:TextBox ID="txtRCondition" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
    </tr>
      <tr>
        <td style="width:200px;"><a  class="cssLabelText" >Nama Supplier</a></td> 
        <td style="width:10px">:</td>
		<td style="width:800px;"><asp:TextBox ID="txtRNamaSupplier" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
    </tr>
    <tr>
        <td style="width:700px;"  colspan="6">
            <table border="1" style="cell-spacing:0; cell-padding:0; border-collapse:collapse;border-color:cornflowerblue;border-width:thin;">
                 <tr>
                    <td style="width:100px;" >Keterangan</td>
                    <td style="width:100px;">Admin</td>
                    <td style="width:100px;">Asuransi</td>
                    <td style="width:100px;">Bunga</td>
                    <td style="width:100px;">Provisi</td>
                    <td style="width:100px;">Total</td>
                 </tr>
                <tr>
                    <td style="width:100px;">Disburse</td>
                    <td style="width:100px; "><asp:TextBox ID="txtRDAdmin" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td> 
                    <td style="width:100px;"><asp:TextBox ID="txtRDAsuransi" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td> 
                    <td style="width:100px;"><asp:TextBox ID="txtRDBunga" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td>
                    <td style="width:100px;"><asp:TextBox ID="txtRDProvisi" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td>
                    <td style="width:100px;"><asp:TextBox ID="txtRDTotal" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td>
                 </tr>
                 <tr>
                    <td style="width:100px;">Hold</td>
                    <td style="width:100px;"><asp:TextBox ID="txtRHAdmin" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td> 
                    <td style="width:100px;"><asp:TextBox ID="txtRHAsuransi" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td> 
                    <td style="width:100px;"><asp:TextBox ID="txtRHBunga" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td>
                    <td style="width:100px;"><asp:TextBox ID="txtRHProvisi" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td>
                    <td style="width:100px;"><asp:TextBox ID="txtRHTotal" runat="server" CssClass="inptype" Width="100px" ReadOnly Style="border:none; text-align: right;"></asp:TextBox> </td>
                 </tr>
            </table>
        </td>
    </tr>
    <tr><td><br /></td></tr>
    <tr>
        <td style="width:810px;"  colspan="6">
           <div  id="divList" runat="server" style="padding:0px"></div>
        </td>
    </tr>
</table>
 <input id="txtRowCount" style="display: none" type="text" name="txtRowCount" runat="server">