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

// ======================
// end of String Function
// ======================


function back_Click(){
	window.history.go(-1);
}

// ======================
// Beginning of Numeric Function
// ======================

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

function isNotNumeric(sItem)
{
	if (!check(sItem,"1234567890")) 
		return false;
	return true;
}


// ======================
// end of Numeric Function
// ======================