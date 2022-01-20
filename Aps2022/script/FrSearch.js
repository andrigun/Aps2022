function resetSearch() {
    frmMain.txtPksNo.value = "";
    frmMain.txtSupplier.value = "";
    frmMain.txtRequestdate1.value = "";
    frmMain.txtRequestdate2.value = "";
    frmMain.txtAprDate1.value = "";
    frmMain.txtAprDate2.value = "";
}

function SearchData() {
    ////$('#dvLoader').show(); 
    //var e = document.getElementById("ddlViewBy");
    //var sStatus = e.options[e.selectedIndex].value;

    // alert("search");


    var sBranchid, sPksNo, sSupplier;
    var RequestFrom, RequestTo;
    var aprDateFrom, aprDateTo;

    sPksNo = document.getElementById("txtPksNo").value;
    sSupplier = document.getElementById("txtSupplier").value;
    RequestFrom = document.getElementById("txtRequestdate1").value;
    RequestTo = document.getElementById("txtRequestdate2").value;
    aprDateFrom = document.getElementById("txtAprDate1").value;
    aprDateTo = document.getElementById("txtAprDate2").value;

    //if ((aprDateFrom !== "" || aprDateTo !== "") && (sStatus === "" ||sStatus === "NEW" )) {
    //jAlert('<b>Request Status Tidak Boleh kosong atau NEW </b> <br> Karena Approval Date Terisi', 'Search Data');
    //return false;
    //}


    $('#dvLoader').show();
    //sStatus = sStatus;
    var Scrip;
    var dataPassed = new Object();

    dataPassed.sPksNo = sPksNo;
    dataPassed.sSupplier = sSupplier;
    dataPassed.RequestFrom = RequestFrom;
    dataPassed.RequestTo = RequestTo;
    dataPassed.AprDateFrom = aprDateFrom;
    dataPassed.AprDateTo = aprDateTo;

    $.ajax({
        type: "Post",
        url: "../ApsWs.asmx/LoadListAps",
        data: $.toJSON(dataPassed),
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
                , "oLanguage": { "sEmptyTable": "<font color='red'> Data No is Not Found</font>" }

            });

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.responseText);
            divDataList.innerHTML = XMLHttpRequest.responseText;
            //alert("error");
        }
    });
}

function ViewData(sID) {
    // jAlert(sID, 'View Data');   
    var url = 'FrView.aspx?argReqID=' + sID + '';
    window.open(url, '_blank');
}
