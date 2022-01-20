Public Class clsHelp

    Public Function getBranchList(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer) As DataSet
        ' by vw , 03 Jan 2006
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        sCmd = "SELECT branchID, branchFullname From branch" 
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function


    Public Function getBranchListComp1(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer, ByRef sUserid As String, ByRef sBranchid As String) As DataSet
        ' by vw , 03 Jan 2006
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        sCmd = "SELECT  branchID,  branchFullname From branch   where Branchid = '" & sBranchid & "' or '999' = '" & sBranchid & "'  order by  branchid"
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function


    Public Function getBranchListComp(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer, ByRef sBranchid As String) As DataSet
        ' by vw , 03 Jan 2006
        ' SP related : 
          Dim sUserid As String 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        sUserid = sBranchid

        'sCmd = "SELECT  branchID,  branchFullname From branch   where Branchid = '" & sBranchid & "' or '999' = '" & sBranchid & "'  order by  branchid"

        'sCmd = "select * from rememaildb.dbo.divisi"
        sCmd = "exec spgetBranchListComp    '" & sUserid & "'   "

        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function

    Public Function getKomiteList(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer) As DataSet
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        ' sCmd = "select * from KomiteHeader where isactive = 1 order by  KomiteID desc "

        sCmd = "exec CAM_getKomiteHeader  "
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function

    Public Function getKomiteListDoc(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer) As DataSet
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        ' sCmd = "select * from KomiteHeader where isactive = 1 order by  KomiteID desc "

        sCmd = "exec CAM_getKomiteHeaderDoc  "
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function


    Public Function getCamLevelSign(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer, ByVal sFilter As String, ByVal sargCAMID As String) As DataSet
        ' by vw , 03 Jan 2006
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        sCmd = "exec Cam_getCamLevelSign '" & sFilter & "' , '" & sargCAMID & "' "
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function

    Public Function getAgreementno(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer, ByVal sFilter As String) As DataSet
        ' by vw , 04 Jan 2006
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        sCmd = "select Agreementno , name  " & _
                " from agreement where Agreementno like '" & sFilter & "' order by Agreementno"
        'sCmd = "exec Cam_getAgreementno '" & sFilter & "'   "
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function


    Public Function getAssetCategoryList(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer) As DataSet
        ' by vw , 04 Jan 2006
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        sCmd = "SELECT assetCategoryID, assetCategoryDesc From assetCategory where "
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function

    Public Function getOwnerList(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer) As DataSet
        ' by vw , 04 Jan 2006
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        'sCmd = "SELECT ownerID, costCenter From owner where parentCostCenterID=''"
        sCmd = "select  ExpenseCategoryId  , Description from expensecategory  where IsActive = 'a' order by ExpenseCategoryId"
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function

    Public Function getCamId(ByVal currPage As Integer, ByVal rowPerPage As Integer, ByRef totalPage As Integer, ByVal sFilter As String) As DataSet
        ' by vw , 04 Jan 2006
        ' SP related : 

        Dim oDs As DataSet
        Dim oData As New clsData
        Dim sCmd As String

        sCmd = "select CamId , CamNumber  from CamHeader where isactive = 'A' and CamId like '" & sFilter & "' order by CamId"
        oDs = oData.executeQuery(sCmd, clsData.ReturnType.Paging, currPage, rowPerPage, totalPage)

        Return oDs

    End Function
End Class
