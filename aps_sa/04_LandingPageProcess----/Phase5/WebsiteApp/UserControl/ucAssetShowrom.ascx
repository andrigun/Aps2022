<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucAssetShowrom.ascx.vb" Inherits="WebsiteApp.ucAssetShowrom" %>
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
                <td style="width:200px;"><a  class="cssLabelText" >CMO</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtCmoName" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
             <tr>
                <td style="width:50px; background-color:cornflowerblue;" colspan="3" ><a  class="cssLabelText" >SUPPLIER</a></td>
            </tr>
             <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Nama Supplier</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtNamaSupplier" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
              <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Alamat Supplier</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtAlamatSupplier" runat="server" CssClass="inptype" Width="500px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
             <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Contact Person</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtContactPerson" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td style="width:50px; background-color:cornflowerblue;" colspan="3"><a  class="cssLabelText" >ASSET</a></td>
            </tr>
           <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Asset Type</a></td>
                <td style="width:10px;">:</td>
                <td style="width:480px;"><asp:TextBox ID="txtJenisAsset" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Asset Condition</a></td>
                <td style="width:10px;">:</td>
                <td style="width:480px;"><asp:TextBox ID="txtAssetCondition" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Merk Type</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtMerkAsset" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
             <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Type Asset</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtTypeAsset" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
             <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Tahun Asset</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtTahunAsset" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
             <tr>
                <td style="width:200px;"><a  class="cssLabelText" >No Polisi</a></td>
                <td style="width:10px;">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtNoPolisi" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>     
            </table>