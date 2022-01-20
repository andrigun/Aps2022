<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCreditCalculator.ascx.vb" Inherits="WebsiteApp.ucCreditCalculator" %>
<table border="0" style="width:1000;border-collapse:collapse;" > 
        <tr>
					  <td>
                <table border="0">
                     <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Branch Name</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBranchName" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                        <tr>
                            <td style="width:200px;"><a  class="cssLabelText" >Customer Name</a></td>
                            <td style="width:10px">:</td>
                            <td style="width:200px;"><asp:TextBox ID="txtCCustName" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                        </tr>
                    <tr>
                            <td style="width:200px;"><a  class="cssLabelText" >Asset Name</a></td>
                            <td style="width:10px">:</td>
                            <td style="width:200px;"><asp:TextBox ID="txtCAssetName" runat="server" CssClass="inptype" Width="300px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                        </tr>
                        <tr>
                            <td style="width:200px;"><a  class="cssLabelText" >Showroom/Dealer Name</a></td>
                            <td style="width:10px">:</td>
                            <td style="width:180px;"><asp:TextBox ID="txtCShowroom" runat="server" CssClass="inptype" Width="450px" ReadOnly Style="border:none;"></asp:TextBox> </td>
                        </tr>
                   <tr><td>&nbsp;</td></tr>
                     <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Batas Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBatasAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Penutupan Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPenutupanAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Cover Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCCoverAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Depresiasi Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCDepresiasiAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Perluasan SRCCTS</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPerluasanSRCCTS" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Perluasan Gempa Bumi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPerluasaanGempaBumi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Perluasan Banjir</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPerluasanBanjir" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >THJ(Kapitalisasi / Tidak)</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCTHJ" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                     <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Perusahaan Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPerusahaanAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr><td>&nbsp;</td></tr>
                  <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Cabang Wilayah Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCCabangWilayahAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Kategori Kendaraan</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCKategori" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Penggunaan / Okupasi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPenggunaanOkupasi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Type Angsuran</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCTypeAngsuran" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Buana Protection(Kapitalis / Tidak)</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBuanaProtectionKapitalis" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Tenor Pembiayaan</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCTenorPembiayaan" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Tahun Kendaraan</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCTahunKendaraan" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr><td>&nbsp;</td></tr>
                 <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Down Payment (DP %)</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCDpPersen" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox></td> 
                    </tr> 
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Down Payment (DP Amount)</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCDpAmount" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >OTR Amount</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCOtrAmount" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr> 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Biaya Administrasi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBiayaAdmin" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>     
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Biaya Fidusia</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCFiducia" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>         
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Biaya Polis Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBiayaPolisAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>             
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Biaya Provisi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBiayaProvisi" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>                 
                <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Biaya Buana Protection</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBiayaBuanaProtection" runat="server" CssClass="inptype" Width="190px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>  
            
                </table>
            </td>
            <td style="vertical-align:top">
               <table border="0">
                     <tr>
                   <td style="width:200px;"><a  class="cssLabelText" >OTR Amount</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCOtrAmount2" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                       </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >DP Amount</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCDpAmount2" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >PH Murni</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPhMurni" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Kapitalisasi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCKapitalisasi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Total PH</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCTotalPH" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Bunga</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBunga" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >PH + Bunga</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPhBunga" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >LTV</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCltv" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr ><td><br /></td></tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Premi Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPremiAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >THJ Dibayar Dimuka</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCThjDibayarDimuka" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Total Premi Asuransi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCTotalPremiAsuransi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                     <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Polis Asuransi Dibayar Dimuka</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPolisAsuransiDibayarDimuka" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Administrasi</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCAdministrasi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Fiducia Dibayar Dimuka</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCFiduciaDibayarDimuka" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Buana Protection</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCBuanaProtetion" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Jual Flat </a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCJualFlat" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Jual Eff </a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCJualEff" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Angsuran per Bulan </a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCAngsuranPerBulan" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Total Bayar Pertama </a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCTotalBayarPertama" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Pelunasan Ke Dealer </a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCPelunasanKeDealer" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Deviasi </a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCDeviasi" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Deviasi Note</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCDeviasiNote" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                   <tr>
                        <td style="width:200px;"><a  class="cssLabelText" >Create Date</a></td> 
                        <td style="width:10px">:</td>
		                <td style="width:200px;"><asp:TextBox ID="txtCreateDate" runat="server" CssClass="inptype" Width="250px" ReadOnly Style="border:none;"></asp:TextBox> </td> 
                    </tr>
                    <tr>
                       <td style="width:200px;"><a href="CalculatorCreditHistory.aspx?dfcid=<%=txtdfcid.Value()%>" target="_blank">History Simulation Credit</a> </td>
                    </tr>
               </table>
            </td>
        </tr> 
         <input id="txtdfcid" style="display: none" type="text" name="txtdfcid" runat="server">
         <input id="txtMode" style="display: none" type="text" name="txtMode" runat="server">
</table>
<br /><br /><br />
<asp:Label ID="Label1" runat="server" Text="Label" style="color:cornsilk"></asp:Label>