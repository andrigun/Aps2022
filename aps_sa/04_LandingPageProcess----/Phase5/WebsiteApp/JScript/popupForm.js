//fungsi untuk msg box...=======================================================================              
function showMsgBox(Title, StrCOntent, button1, button2, scriptButton1, scriptButton2, width,height, nLeft, nTop) {
  
    var btns = {};
    btns[button1] = function() { eval(scriptButton1); };
    if (button2 != "") { btns[button2] = function() { eval(scriptButton2); }; }
   
    ContentString.innerHTML = StrCOntent;

    $("#in").click(function () {
        $("bell").width($("bell").width() + 100);
        $("bell").height($("bell").height() + 100);
    });
    $("#out").click(function () {
        $("bell").width($("bell").width() - 100);
        $("bell").height($("bell").height() - 100);
    });

   
    if (height=='') {height='auto'}

    $("#divMsgBox").dialog({
        title: Title,
        modal: true,
        buttons: btns,
       // show: "fold",
        height: height,
        width: width, ///set 'auto jika ingin automatis'
        left: nLeft,
        top: nTop
    });
}

function showMsgBox_WaitAMoment(Title, StrCOntent, button1, button2, scriptButton1, scriptButton2, width, height, nLeft, nTop) {
    var btns = {};
    btns[button1] = function() { eval(scriptButton1); };
  if (button2 != "") { btns[button2] = function() { eval(scriptButton2); }; }

    ContentString.innerHTML = StrCOntent;

    if (height == '') { height = 'auto' }

    $("#divMsgBox").dialog({
        title: Title,
        modal: true,
        buttons: 'no-button',
        // show: "fold",
        height: height,
        width: width, ///set 'auto jika ingin automatis'
        left: nLeft,
        top: nTop
    });
}


function CloseDialogBox() {
    $("#divMsgBox").dialog("close");
}
//eof funsi Msgbox==============================================================================
