var USERCONTROL_PATH = "../userControl/";
var TINGGI_CELLTITLE = 40;
var TINGGI_CELL = 25;

var SIGN_PLUS = "../images/sign_plus.gif";
var SIGN_MINUS = "../images/sign_minus.gif";
var IMAGES_PATH = "../images/";

var NO_DATA = "No Data";

var AppId  = "012";
var AppApprovalID  = "01204";
var AppApprovalID2  = "01201";

var aMonthName = new Array();
		aMonthName[0] = "Jan" ;
		aMonthName[1] =	"Feb" ;
		aMonthName[2] = "Mar" ;
		aMonthName[3] =	"Apr" ;
		aMonthName[4] =	"May" ;
		aMonthName[5] =	"Jun" ;
		aMonthName[6] =	"Jul" ;
		aMonthName[7] =	"Aug" ;
		aMonthName[8] =	"Sep" ;
		aMonthName[9] =	"Oct" ;
		aMonthName[10] = "Nov" ;
		aMonthName[11] = "Dec" ; 
		
function IsNumeric(pi_sInput) {
	var re = /^\s*(\d*)\s*$/;
	if (re.test(pi_sInput)) {
		return true;
	}
	else {
		return false;
	}
}



function FormatDate(pi_strDate){
	if (typeof(pi_strDate) != "undefined")
		var oDate = new Date(pi_strDate);
	else	
		var oDate = new Date();	

	var sYear = new String();
	sYear = oDate.getYear() + "" ;
	if (sYear.length == 2){
		sYear = "19" + sYear ;
	}
	return oDate.getDate() + " " + aMonthName[oDate.getMonth()] + " " + sYear ;		
}



function iif(par_Valid, par_True, par_False){
	if (par_Valid){
		return par_True;
	}
	else{
		return par_False;
	}
}



// ===============
// String Function
// ===============

function Right(par_Text, par_iLen){
	return par_Text.substr(par_Text.length - par_iLen, par_iLen);
}

function Left(par_Text, par_iLen){
	return par_Text.substr(0, par_iLen);
}

function LTrim(sInput)
{	
	if (sInput.charAt(0) != " ")
		return sInput;
		
	var I, sTemp = "";		
	for (I=0; I < sInput.length; I++)
	{	
	if (sInput.charAt(I) != " ")
		{   
		for (; I < sInput.length; I++)
			sTemp = sTemp + sInput.charAt(I); 
		}
	}
	return sTemp;
}

function RTrim(sInput)
{	
	if (sInput.charAt(sInput.length-1) != " ")
		return sInput;
		
	var I, sTemp = "";
	for (I=sInput.length-1; I > -1; I--)
	{	if (sInput.charAt(I) != " ")		
		{   
			for (; I > -1; I--)
			sTemp = sInput.charAt(I) + sTemp; 
		}
	}
	return sTemp;
}

function Trim(sInput)
{	
	var sString = sInput;
	sString = LTrim(sString);
	sString = RTrim(sString);
	return sString;
}


function createPetik(par_Text)
{
	var sText;
	sText = par_Text.replace("PETIK_1", "'");
	sText = sText.replace("PETIK_2", "\"");
	return sText;
}
// ======================
// end of String Function
// ======================



// ======================
// Beginning of Numeric Function
// ======================


function clearFormatDec(sValue){
	var re = /,/g;
	sValue = sValue.replace(re, "");
	return sValue
}


//--GT--
function check(sInput, sCheck)
{	var chr, j;
	var bfound = false;
	var ok = true;
	for (var i = 0; i < sInput.length; i++)
	{
		chr = sInput.charAt(i);
		bfound = false;
		for (j=0; j < sCheck.length; j++)
		{
			if (chr == sCheck.charAt(j)) bfound = true;
		}
		if (!bfound) ok = false;
	}
	return ok;
}
							  
function isDecimal(sItem)
{
	var i ;
	i = sItem * 1 ;
	return (i == sItem);
	
	
//	return false ;
//	if (!check(sItem,"1234567890.")) 
//		return false;
//	return true;
}



function validateNumeric() {
    //if(event.keyCode == 46) event.keyCode = 0;
    if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode != 46 ) event.keyCode = 0;
}

// ======================
// end of Numeric Function
// ======================




// ============================
// Number and Currency function
// ============================

function formatCurrency(num) {
    num = Math.floor(num);
    num = num.toString().replace(/\$|\,/g, '');

    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
        
        return num;

  
}


function ReplaceDec(par_Text){
    //var regExp = /\,/g;
    var regExp = /\,/g;
	var s = "";
	par_Text = String(par_Text); //trambahan harus convert k string, kalau tidak akan error
	return par_Text.replace(regExp, "");
}

function ReplaceSpot(par_Text) {
    var regExp = /\./g;
    var s = "";
    return par_Text.replace(regExp, "");
}

function NumberValidation(){
	if(event.keyCode >= 48 && event.keyCode <=57){
	}
	else{
		event.keyCode = 0;
	}
}

function DecimalFormat(par_Check){
// par_Check is used to countinue this codes, when user type enter.
    // when user enter keyboard, onchange will be trigger.


	if(event.keyCode >= 48 && event.keyCode <=57){
	}
	else if(typeof(par_Check)=="undefined"){
		return;
	}
	var xLen =""  ;
	var aNumber;
	var aNumberComa = "";
	var nil;
	var comades;
	var iCount = 0;
	var sNumFormated = "";



	xLen = par_Check + "";

	aNumberComa = xLen.indexOf(".");


	
	nil = xLen.substring(0, (aNumberComa));
	comades = xLen.substring(aNumberComa, xLen.length);

	comades = comades.substring(0, 3); //ambile desimal point hanya 3 digit tanpa pembulatan



	if (nil == "")
	{ xLen = ReplaceDec(xLen); }
	else
	{ xLen = ReplaceDec(nil); }
	
	aNumber = xLen.split("");

	
	for (i=aNumber.length - 1; i >= 0; i--){
		iCount ++;
		if (iCount == 3 && i != 0){
		    sNumFormated = "," + aNumber[i] + sNumFormated;
			iCount = 0;	
		}
		else{
		    sNumFormated = aNumber[i] + sNumFormated;
		}			
	}
	//return sNumFormated;

	if (aNumberComa == "-1")
	{sNumFormated = sNumFormated;}
	else
	{ sNumFormated = sNumFormated + comades; }
	
	return sNumFormated;
//	event.keyCode = 0x24 ;
	//	event.srcElement.click;
}



function formatCurr(txt) {
    var txtX;
    txtX = document.getElementById(txt).value;
    /* if (txt == "InptSCM041") {
    var NilTunjMakan,Total;
    NilTunjMakan = ReplaceSpot(document.getElementById("InptSCM003").value);
    Total=txtX * NilTunjMakan
    document.getElementById("InptSCM003").value = Total; 
    }
    else
    { */
    // document.getElementById(txt).value = DecimalFormat(txtX);


    if (event.keyCode >= 48 && event.keyCode <= 57) {

    }
    else {
        //event.keyCode = 0;
        var x = String.fromCharCode(event.keyCode);
        txtX = txtX.replace(x.toLowerCase(), "");
    }
    document.getElementById(txt).value = DecimalFormat(txtX);

}







// ===================================
// end of Number and Currency function
// ===================================

function preventKeyboard(e) {
    var evt = e || window.event;
    if (evt) {
        var keyCode = evt.charCode || evt.keyCode;
        if (keyCode >= 0) {
            if (evt.preventDefault) {
                evt.preventDefault();
            } else {
                evt.returnValue = false;
            }
        }
    }
}


// INITIALIZE Disable right mouse click Script

//		var message="Function Disabled!";

//		///////////////////////////////////
//		var message="Function Disabled!"; 
//		function clickIE4(){
//			if (event.button==2){
//				alert(message);
//				return false;
//			}
//		}

//		function clickNS4(e){
//			if (document.layers||document.getElementById&&!document.all){
//				if (e.which==2||e.which==3){
//					alert(message);
//					return false;
//				}
//			}
//		}

//		if (document.layers){
//			document.captureEvents(Event.MOUSEDOWN);
//			document.onmousedown=clickNS4;
//		}
//		else if (document.all&&!document.getElementById){
//			document.onmousedown=clickIE4;
//		} 
//		document.oncontextmenu=new Function("alert(message);return false");

//Disable right mouse click Script
// INITIALIZE Disable right mouse click Script


