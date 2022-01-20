//fungsi untuk msg box...=======================================================================              
function popupFormInv_sub__(Title, StrCOntent, button1, button2, scriptButton1, scriptButton2, width,height, nLeft, nTop) {
    var btns = {};
    btns[button1] = function() { eval(scriptButton1); };
    if (button2 != "") { btns[button2] = function() { eval(scriptButton2); }; }

    ContentString.innerHTML = StrCOntent;
    
    //if (height=='') {height='auto'}

    $("#divMsgBox").dialog({
        title: Title,
        modal: true,
        buttons: btns,
        height: height,
        width: width, ///set 'auto jika ingin automatis'
        left: nLeft,
        scrollbars: false,
        toolbar:false,
        status:false,
        top: nTop
    });
}

function CloseDialogBox() {
    $("#divMsgBox").dialog("close");
}
//eof funsi Msgbox==============================================================================
