 

    function resetSearch(){
        frmMain.txtRequestNo.value = "";
        frmMain.TxtBranchID.value = "";
        frmMain.txtBranch.value = "";
        frmMain.txtCustomer.value = "";
        frmMain.txtRequestdate1.value = "";
        frmMain.txtRequestdate2.value = "";
        frmMain.txtAgreementno.value = "";
        frmMain.txtAprDate1.value = "";
        frmMain.txtAprDate2.value = "";
    }

    function SearchData(){
        //$('#dvLoader').show(); 
        var e = document.getElementById("ddlViewBy");
        var sStatus = e.options[e.selectedIndex].value;

        //alert(sStatus);
 

        var sBranchid, sRequestno, sCustomer;
        var RequestFrom, RequestTo;
        var aprDateFrom, aprDateTo;

        sBranchid =document.getElementById("TxtBranchID").value ; //frmMain.txtBranchId.value;
        sRequestno= document.getElementById("txtRequestNo").value;
        sCustomer = document.getElementById("txtCustomer").value;
        RequestFrom = document.getElementById("txtRequestdate1").value;
        RequestTo = document.getElementById("txtRequestdate2").value;
        Agreementno = document.getElementById("txtAgreementno").value;
        aprDateFrom = document.getElementById("txtAprDate1").value;
        aprDateTo = document.getElementById("txtAprDate2").value;

        if ((aprDateFrom !== "" || aprDateTo !== "") && (sStatus === "" ||sStatus === "NEW" )) {
        jAlert('<b>Request Status Tidak Boleh kosong atau NEW </b> <br> Karena Approval Date Terisi', 'Search Data');
        return false;
        }

        //if ((aprDateFrom !== "" || aprDateTo !== "") && (sStatus  === "" || sStatus  == "NEW" )) {
        //    jAlert( 'Tgl Approval Harus Kosong' ,'Search Data');
        //    return false;
        //}

        $('#dvLoader').show();
        //sStatus = sStatus;
        var Scrip;
        var dataPassed = new Object();
   
        dataPassed.BranchId = sBranchid;
        dataPassed.Requestno = sRequestno;
        dataPassed.Customer = sCustomer;
        dataPassed.RequestFrom = RequestFrom;
        dataPassed.RequestTo = RequestTo;
        dataPassed.sStatus = sStatus;
        dataPassed.Agreementno = Agreementno;
        dataPassed.AprDateFrom = aprDateFrom;
        dataPassed.AprDateTo = aprDateTo;

        $.ajax({
            type: "Post",
            url: "../BuanaCovid.asmx/LoadListAgreementRestructure",
            data:$.toJSON(dataPassed),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (msg) {
            //divDataList.innerHTML= msg.d;// Scrip[1];
            $('#dvLoader').hide();
            Scrip = msg.d.split("__");
            $("#DivQ").html(Scrip[1]);
            oTable = $('#example').dataTable({
                "bJQueryUI": true
                , "sPaginationType": "full_numbers"
                , "ordering": true
                , "bSort": true
                , "oLanguage": {"sEmptyTable": "<font color='red'> Application No is Not Found</font>" }
             
            });

            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
            //alert(XMLHttpRequest.responseText);
            divDataList.innerHTML = XMLHttpRequest.responseText;
            //alert("error");
            }
        });
}

    function browseBranch(){ 
		
	var oResult;
    var oArgument = new Array();

    oArgument["FirstCol"] = "BranchID" ;
    oArgument["SecondCol"] = "Branch Fullname" ;
            
    sFeatures="dialogHeight: 450px; dialogWidth:300px; dialogTop: px; dialogLeft: px;"
    sFeatures += "edge: Raised; center: Yes; help: No;	resizable: No; status: No; scroll: yes"
 //oResult = window.showModalDialog("helpList.aspx?argListType=7",oArgument, sFeatures);
            
   //oResult = window.open('helpList.aspx?argListType=7','name',
//'height=450,width=300,toolbar=no,directories=no,status=no, linemenubar=no,scrollbars=yes,resizable=no,modal=yes,center=yes');

var w = 250;
var h = 350;
var left = Number((screen.width/2)-(w/2)) ;
var tops = Number(((screen.height/2)-(h/2) )- 150);

oResult = window.open('helpList.aspx?argListType=7','List of Branch', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);
oResult.focus();
}

    function callPrintOut(ReqID ) { 
                var strWindowFeatures = "location=no,height=200,width=200,scrollbars=yes,status=yes";
        var sFeatures="Height:200px; Width:200px; dialogTop: 1px; dialogLeft: 1px;"
            sFeatures += "edge: Raised; center: Yes; help: No;	resizable: yes; status: No; scroll: yes"

     var URL = "FrPrint.aspx?argReqID=" + ReqID   ;
     var win = window.open(URL, "_blank", sFeatures, true);

}

    function callApproval(RequestID, Requestno) {
        var sReqno;
sReqno = String(Requestno);

//var url = 'frApproval.aspx?argReqID=' + RequestID + '&argReqNo=' + sReqno + '';
   
       
        var _url = 'frApproval2.aspx?argReqID=' + RequestID + '';
        var url = 'frApproval.aspx?argReqID=' + RequestID + '';

//alert(RequestID + ' - ' + Requestno);
//window.open('frApproval.aspx', '_self', false)
    //window.open('frApproval.aspx', '_parent' )
//window.open(url, '_top');
// window.location.replace(url);
// window.location.href = "frApproval.aspx?argPartNo=" + par_PartNo;
// window.open ('frApproval.aspx','_blank',false)
window.open(url, '_blank');

}
function NewData() { 
    var url = 'formIn.aspx'; 
        window.open(url, '_blank');
    }

    function callView(RequestID, Requestno) {
        var sReqno;
sReqno = String(Requestno);
    var sFeatures="Height:1200px; Width:1200px; dialogTop: 1px; dialogLeft: 1px;"
                sFeatures += "edge: Raised; center: Yes; help: No;	resizable: yes; status: No; scroll: yes"

var url = 'frView.aspx?argReqID=' + RequestID +'';
window.open(url, '_blank');

}

    function ViewApproval(AgreementNo, ReqID) {
        // alert(AgreementNo);
            var strWindowFeatures = "location=no,height=200,width=200,scrollbars=yes,status=yes";
    var sFeatures="Height:200px; Width:200px; dialogTop: 1px; dialogLeft: 1px;"
        sFeatures += "edge: Raised; center: Yes; help: No;	resizable: yes; status: No; scroll: yes"

    var URL = "FrViewApproval.aspx?argAgrNo=" + AgreementNo +"&argReqId="+ReqID ;
    //var win = window.open(URL, "_blank", sFeatures, true);
window.open(URL, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=10,left=100,width=800,height=800");

} 