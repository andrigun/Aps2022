<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucSurvey.ascx.vb" Inherits="WebsiteApp.ucSurvey" %>

   

<table border="0" style="width:1000;border-collapse:collapse;" > 
        <tr>
            <td style="width:200px;"><a  class="cssLabelText" >Customer Name</a></td> 
            <td style="width:10px">:</td>
		    <td style="width:800px;" colspan="3"><asp:TextBox ID="txtCustomerName" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
        </tr> 
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Prospect No</a></td>
                <td style="width:10px">:</td>
                <td style="width:480px;" colspan=""><asp:TextBox ID="txtProspectNo" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Order No</a></td>
                <td style="width:10px">:</td>
                <td style="width:180px;" colspan="3"><asp:TextBox ID="txtOrderNo" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
             <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Survey I</a></td>
                <td style="width:10px">:</td>
                <td style="width:800px;" colspan="3"><asp:TextBox ID="txtSurveyI" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Survey II</a></td>
                <td style="width:10px">:</td>
                <td style="width:800px;" colspan="3"><asp:TextBox ID="txtSurveyII" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td style="width:1000px; background-color:cornflowerblue;" colspan="6"><a  class="cssLabelText" >ALAMAT SURVEY</a></td>
            </tr>
             <tr>
                <td style="width:200px" ><a  class="cssLabelText" >Debitur</a></td>
                <td style="width:10px">:</td>
                <td style="width:250px;" ><asp:TextBox ID="txtAlamatSurveyDebitur" runat="server" CssClass="inptype" Width="500px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                <td style="width:30px" ><a  class="cssLabelText" >Note</a></td>
                <td style="width:10px">:</td>
                <td style="width:180px" ><asp:TextBox ID="txtAlamatSurveyDebiturNote" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
            </tr>
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Unit</a></td>
                <td style="width:10px">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtAlamatSurveyUnit" runat="server" CssClass="inptype" Width="500px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                <td style="width:30px;"><a  class="cssLabelText" >Note </a></td>
                <td style="width:10px">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtAlamatSurveyUnitNote" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                
            </tr>
            <tr>
                <td style="width:200px;"><a  class="cssLabelText" >Alamat Usaha</a></td>
                <td style="width:10px">:</td>
                <td style="width:180px;"><asp:TextBox ID="txtAlamatUsaha" runat="server" CssClass="inptype" Width="500px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                <td style="width:30px;"><a  class="cssLabelText" ></a></td>
                <td style="width:10px"></td>
                <td style="width:180px;"></td>
                
            </tr>

          
            <tr><td>&nbsp;</td></tr>

            <tr>
                <td style="width:1000px; background-color:cornflowerblue;" colspan="6"><a  class="cssLabelText" >STATUS SURVEY</a></td>
                <td></td>
            </tr>

            <tr>
                <td  style="width:1000px;" colspan="7">
                    <table border="1" style="cell-spacing:0; cell-padding:0; border-collapse:collapse;border-color:cornflowerblue;border-width:thin;">
                        <tr style="background-color:cornflowerblue; font-weight:bold;color:#fff">
                             <td style="width:210px;" ></td>
                             <td style="width:210px; text-align:center">SURVEY I</td>
                             <td style="width:210px; text-align:center">SURVEY II</td>
                        </tr>
                        <tr>
                            <td style="width:210px;">Tujuan</td>
                            <td style="width:210px;"><asp:TextBox ID="txtTujuanSurveyPertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtTujuanSurveyKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td style="width:210px;">Status</td>
                            <td style="width:210px;"><asp:TextBox ID="txtStatusPertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtStatusKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td style="width:210px;">Surveyor</td>
                            <td style="width:210px;"><asp:TextBox ID="txtSurveyorPertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none; text-align=right;"></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtSurveyorKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td style="width:210px;">Assign Date</td>
                            <td style="width:210px; text-align=right; "><asp:TextBox ID="txtAssignDatePertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right;  "></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtAssignDateKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td style="width:210px;">Download Date</td>
                            <td style="width:210px;"><asp:TextBox ID="txtDownloadPertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtDownloadKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td style="width:210px;">Read Date</td>
                            <td style="width:210px;"><asp:TextBox ID="txtReadPertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtReadKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                        </tr>
                         <tr>
                            <td style="width:210px;">Start Date</td>
                            <td style="width:210px;"><asp:TextBox ID="txtStartDatePertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtStartDateKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td style="width:210px;">Submit Date</td>
                            <td style="width:210px;"><asp:TextBox ID="txtSubmitDatePertama" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                            <td style="width:210px;"><asp:TextBox ID="txtSubmitDateKedua" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="width:190px;border:none;text-align: right; "></asp:TextBox> </td>
                        </tr>
                    </table>

                </td>
                
            </tr>
            <%--<tr><td><asp:Button ID="btnRequestSurvey" runat="server" Text="Request Survey"  Style="display: block"  OnClick="bRequestSurvey" /></td></tr>--%>
            <%--<tr><td><input type="button"  id="buttonClass" value="Kirim" class="btn btn-danger" onclick="saveHanArea()" style="width: 400px;">  </td></tr>            --%>
</table>
<%--<input id="txtMode" style="display: none" type="text" name="txtMode" runat="server">--%>