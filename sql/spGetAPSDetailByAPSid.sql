create procedure dbo.spGetAPSDetailByAPSid   
		@RequestID   varchar(25) 

as 

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  topUpID 
      , PKSid 
      , SupplierGroupShowroom 
      , supplierID 
      , supplierName 
      , topUpno 
      , plafon 
      , plafonOrigin 
      , tglMulaiAPS 
      , tglBerakhirAPS 
      , tgltopup 
      , tglJatuhTempoTopup 
      , durasiTopUp 
      , isHolding 
      , metodePlafonCode 
      , pengurangCode 
      , totalSalesUnit 
      , totalPencairan 
      , penalty 
      , nexTopUp 
      , sisaSaldo 
      , isactive 
      , dtmIns 
      , usrIns 
      , dtmUpd 
      , usrUpd 
  FROM [BussdevCF].[dbo].[topUp]
  where pksid = @RequestID   