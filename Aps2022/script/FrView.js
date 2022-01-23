var Reqid; var Userid;
var sAPr;
$(document).ready(function () {
    sAPr = "";
    Userid = document.getElementById("txtUserID").value;
    Reqid = document.getElementById("txtReqID").value;
    // alert(Reqid);
    GetAPSDetailByAPSid(Reqid); 
    GetTopUpHistorybyReqID(Reqid)
    var i;
   // for (i = 1; i < 3; i++) {
    //    GetListData(Reqid, i);
   // }
});
 

function GetAPSDetailByAPSid(Reqid) {
    //$('#dvLoader').show();  
    //alert(Reqid);
    var Scrip;
    var dataPassed = new Object();
    dataPassed.RequestID = Reqid;
    $.ajax({
        type: "Post",
        url: "../ApsWs.asmx/GetAPSDetailByAPSid",
        data: $.toJSON(dataPassed),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (msg) {
            Scrip = msg.d.split("__"); 
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

function GetTopUpHistorybyReqID(Reqid) {
    var Scrip;
    var dataPassed = new Object();
    dataPassed.RequestID = Reqid;
    $.ajax({
        type: "Post",
        url: "../ApsWs.asmx/GetTopUpHistorybyReqID",
        data: $.toJSON(dataPassed),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (msg) {
            Scrip = msg.d.split("__"); 
            document.getElementById("Divhist").innerHTML = msg.d;
            //tab1.innerHTML = msg.d
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
             alert(XMLHttpRequest.responseText);
           // divDataList.innerHTML = XMLHttpRequest.responseText;
           //  alert("error");
        }
    });
} 
