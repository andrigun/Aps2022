 
    //here goes the script.. !!

    var Vagreementno;
    var Reqid; var Userid;
    var sAPr;
$(document).ready(function () {
        sAPr = "";
    Userid = document.getElementById("txtUserID").value;
    Reqid = document.getElementById("txtReqID").value;
    // alert(Reqid);
    GetCustomerDetailByRequestID(Reqid);
    GetCustomerFilesByRequestID(Reqid);
     //GetApprovalDetail(Reqid, 4)
        var i;
        for (i = 1; i < 8; i++) {
            GetApprovalDetail(Reqid, i);
        }
    });
    
function GetCustomerDetailByRequestID(Reqid) {
    //$('#dvLoader').show();  
    //alert(Reqid);
    var Scrip;
    var dataPassed = new Object();
    dataPassed.RequestID = Reqid;
    $.ajax({
        type: "Post",
    url: "../BuanaCovid.asmx/GetCustomerDetailByRequestID",
    data: $.toJSON(dataPassed),
    contentType: "application/json; charset=utf-8",
    datatype: "json",
        success: function (msg) {
        Scrip = msg.d.split("__");
    //DivQ.innerHTML = "";
    DivQ.innerHTML = msg.d;// Scrip[1];
    //tab1.innerHTML = msg.d
},
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        //alert(XMLHttpRequest.responseText);
        divDataList.innerHTML = XMLHttpRequest.responseText;
    //alert("error");
    }
});
}

function GetCustomerFilesByRequestID(Reqid) {
    //$('#dvLoader').show();  
    //alert(Reqid);
    var i;
    i = "1";
    var Scrip;
    var dataPassed = new Object();
    dataPassed.RequestID = Reqid;
    $.ajax({
        type: "Post",
    url: "../BuanaCovid.asmx/GetCustomerFilesByRequestID",
    data: $.toJSON(dataPassed),
    contentType: "application/json; charset=utf-8",
    datatype: "json",
        success: function (msg) {
        Scrip = msg.d.split("__");
    //DivQ.innerHTML = "";
    tab1.innerHTML = msg.d;// Scrip[1];
    //  document.getElementById("tab" + i ).innerHTML= msg.d;
},
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        //alert(XMLHttpRequest.responseText);
        tab8.innerHTML = XMLHttpRequest.responseText;
    //alert("error");
    }
});
}

function GetApprovalDetail(Reqid, iKomid) {
        //$('#dvLoader').show();  
        //alert(Reqid);
        var tabID;
        tabID = iKomid + 1;

        var Scrip;
        var dataPassed = new Object();
        dataPassed.RequestID = Reqid;
        dataPassed.KomiteID = iKomid;
        $.ajax({
            type: "Post",
        url: "../BuanaCovid.asmx/GetApprovalDetail",
        data: $.toJSON(dataPassed),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
            success: function (msg) {
            Scrip = msg.d.split("__");
        //DivQ.innerHTML = "";
        //tab1.innerHTML = msg.d;// Scrip[1]; 
        document.getElementById("tab" + tabID).innerHTML = msg.d;
    },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert(XMLHttpRequest.responseText);
            tab8.innerHTML = XMLHttpRequest.responseText;
        //alert("error");
        }
    });
}

function  xSaveApproval(ApprovalId, ReqID, komID, sComment) {
  

    jConfirm('Save the Data?', 'Confirmation Save', function (r) {
        //jAlert('Confirmed: ' + r, 'Confirmation Results');
        if (r === true) {
            _SaveApproval(ApprovalId, ReqID, komID, OVP, sComment);
        }
    });
}

function SaveApproval(ApprovalId, ReqID, komID, sComment) {
    jConfirm('Save the Data?', 'Confirmation Save', function (r) {  
        if (r === true) {
            _SaveApproval(ApprovalId, ReqID, komID,sComment);
        }
    });
 }

function _SaveApproval(ApprovalId, ReqID, komID,  sComment) {
         
            var OVP = "";

            //$('#dvLoader').show();
            //ApprovalID, RequestID, komiteHeaderID, Userid, OVP, ApprovalStatus, Comment, usrUpd
            var sApprovalStatus;
           // var sRecCA = frmMain.txtRecCA.value;
            //if (komID === "1") {
            //    sApprovalStatus = sRecCA;
            //}
            //else {
            //    sApprovalStatus = document.getElementById("txtappr" + komID).value;
            //}

            sApprovalStatus = document.getElementById("txtappr" + komID).value;
       //      alert(ApprovalId + "-" + ReqID + "-" + komID + "-" + OVP + "-" + sComment + "-" + sApprovalStatus);

            if (sApprovalStatus === "") {
                jAlert("Approval Must Be Selected", 'Save Data');
            return false;
        }
            if (sComment === "") {
                jAlert("Comments must be completed", 'Save Data');
            return false;
        }
        var Scrip;
        var dataPassed = new Object();
        dataPassed.ApprovalID = ApprovalId;
        dataPassed.RequestID = ReqID;
        dataPassed.KomiteID = komID;
        dataPassed.Userid = Userid;
        dataPassed.OVP = "";
        dataPassed.ApprovalStatus = sApprovalStatus;
        dataPassed.Comment = sComment;
        dataPassed.usrUpd = Userid;
            $.ajax({
                type: "Post",
            url: "../BuanaCovid.asmx/InsertApprovalDetail",
            data: $.toJSON(dataPassed),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
                success: function (msg) {
                Scrip = msg.d.split("__");
            // alert(msg.d);
            // frmMain.LblSave.innerHTML = msg.d; 
            jAlert(msg.d, 'Save Data');
            GetCustomerDetailByRequestID(ReqID);
        },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert(XMLHttpRequest.responseText);
                document.getElementById("LblSave").value = XMLHttpRequest.responseText;
            //tab8.innerHTML = XMLHttpRequest.responseText;
            //alert("error");
            }
        });
    }

function CancelRequest(ReqID) {
    jConfirm('Are You Sure Cancel This Request?', 'Confirmation Cancel', function (r) {
        if (r === true) {
             _CancelRequest(ReqID);
        }
    }); 
}

function _CancelRequest(ReqID) {
   // alert(ReqID);
    var Scrip;
    var dataPassed = new Object(); 
    dataPassed.RequestID = ReqID; 
    dataPassed.Userid = Userid;
    $.ajax({
        type: "Post",
        url: "../BuanaCovid.asmx/CancelRequestRestructure",
        data: $.toJSON(dataPassed),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (msg) {
            Scrip = msg.d.split("__");
            // alert(msg.d);
            // frmMain.LblSave.innerHTML = msg.d; 
            jAlert(msg.d, 'Cancel Request');
            GetCustomerDetailByRequestID(ReqID);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert(XMLHttpRequest.responseText);
            document.getElementById("LblSave").value = XMLHttpRequest.responseText;
            //tab8.innerHTML = XMLHttpRequest.responseText;
            //alert("error");
        }
    });
}

function getRecbyCA(theRadio) {
        frmMain.txtRecCA.value = theRadio.value;
    }
    
function getApproved(theRadio, sid) {
        // alert(sid);
        document.getElementById("txtappr" + sid).value = theRadio.value;
    sAPr = document.getElementById("txtappr" + sid).value
    // frmMain.txtappr+id.value  =theRadio.value ;
}

function ViewFile(ReqID, agrno, fnName) {
    var strWindowFeatures = "location=no,height=200,width=200,scrollbars=yes,status=yes";
    var sFeatures = "Height:200px; Width:200px; dialogTop: 1px; dialogLeft: 1px;"
    sFeatures += "edge: Raised; center: Yes; help: No;	resizable: yes; status: No; scroll: yes"

    var URL = "FrFile.aspx?argReqID=" + ReqID + "&argAgrNo=" + agrno + "&argFnName=" + fnName;
    var win = window.open(URL, "_blank", sFeatures, true);

}

function ViewApproval(AgreementNo, ReqID) {
    // alert(AgreementNo);
    var strWindowFeatures = "location=no,height=200,width=200,scrollbars=yes,status=yes";
    var sFeatures = "Height:200px; Width:200px; dialogTop: 1px; dialogLeft: 1px;"
    sFeatures += "edge: Raised; center: Yes; help: No;	resizable: yes; status: No; scroll: yes"

    var URL = "FrViewApproval.aspx?argAgrNo=" + AgreementNo + "&argReqId=" + ReqID;
    //var win = window.open(URL, "_blank", sFeatures, true);
    window.open(URL, "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=10,left=100,width=800,height=800");

} 