Public Class clsCommon
	Dim p_HTTP_REFERER_OpenPage As String
	Dim p_HTTP_REFERER_default As String
    Dim p_HTTP_REFERER_listData As String
    Dim p_HTTP_REFERER_listCustomer As String
    Const p_HTTP_VARIABLE_TO_CHECK As String = "HTTP_HOST"   '"HTTP_REFERER"

	'Public Const UserBPCD = "06500"
	'Public Const UserCA = "06501"
	'Public Const UserCustomerCare = "06502"
	'Public Const UserBM = "06503"
	'Public Const UserPublic = "06504"

	Public Property get_HTTP_Variable_to_Check() As String
		Get
			Return p_HTTP_VARIABLE_TO_CHECK
		End Get
		Set(ByVal value As String)
		End Set
	End Property

	Public Function FormatDec(ByVal par_Text As String) As String
		Dim textCurr As String
		If IsNumeric(par_Text) = False Then
			textCurr = par_Text
		Else
			textCurr = FormatCurrency(par_Text)
			textCurr = Replace(Replace(CStr(textCurr), "$", ""), "Rp", "")
			If Left(textCurr, 1) = "" Then
				textCurr = Mid(textCurr, 2, Len(textCurr) - 1)

			ElseIf Mid(textCurr, 2, 1) = "$" Then
				textCurr = Replace(textCurr, "$", "")
			End If
			If Right(textCurr, 6) = ".000000" Then
				textCurr = Left(textCurr, Len(textCurr) - 6)
			End If
		End If
		Return textCurr
	End Function

	Public Function replaceDec(ByVal par_Text As String) As String
        Dim sDec As String
        Dim iDec As Decimal
        Dim aText As Array, sDecPoint As String
        aText = par_Text.Split(".")
        If UBound(aText) = 1 Then
            sDecPoint = aText(1)
        Else
            sDecPoint = "00"
        End If
        sDec = Replace(aText(0), ",", "")
        If sDecPoint = "00" Then
            sDec = sDec & ""
        Else
            sDec = sDec & "." & sDecPoint
        End If
        Return sDec
    End Function

    Public Function formatDate(ByVal par_Date As Date) As String
        Return Format(par_Date, "dd MMM yyyy")
    End Function

    Public Function formatDateInd(ByVal par_Date As Date) As String
        Dim str As String
        str = Format(par_Date, "dd-MM-yyyy")
        If str = "01-01-1900" Then str = "-"
        Return str
    End Function
    Public Function formatDateSQl(ByVal par_Date As Date) As String
        Return Format(par_Date, "yyyy-MM-dd")
    End Function

    Public Function formatDtmSQl(ByVal par_Date As String) As String
        Dim syear, smonth, sdate As String
        syear = Right(par_Date, 4) & "-"
        smonth = syear & Mid(par_Date, 4, 2) & "-"
        sdate = smonth & Left(par_Date, 2)
        Return sdate
    End Function

    Public Function validQuote(ByVal par_Text As String) As String
        Return Replace(par_Text, "'", "''")
    End Function
    Public Function randomizeNumber(ByVal rNumber As String) As String
        Dim i As Integer
        Randomize()
        i = Int((100 * Rnd()) + 1)
        Return rNumber = i
    End Function
    Function Random(ByVal Lowerbound As Long, ByVal Upperbound As Long)
        Randomize()
        Random = Int(Rnd() * Upperbound) + Lowerbound
    End Function
    Public Function DesKutip(ByVal par_Text As String) As String
        Return Replace(par_Text, "'", "")
    End Function
End Class


