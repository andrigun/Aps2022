 ALTER  procedure dbo.spLoadListAps  
 
 @sPksNo varchar(25)  , 
 @sSupplier  varchar(50)  ,
 @RequestFrom  varchar(12)  ,
 @RequestTo  varchar(12)  , 
 @AprDateFrom  varchar(12)  ,
 @AprDateTo  varchar(12)   


 as 

declare @cmd as varchar(8000) , @filter as varchar(500)= ' where dtmIns is not null '
declare @Camyear  nvarchar(5) , @Cammonth   nvarchar(14) , @cdate nvarchar(14) 

if @RequestFrom <>''
begin 
	set @Camyear = right( @RequestFrom , 4) + '-' 
	set @Cammonth =   @Camyear +  right(left( right(  @RequestFrom  , 8) ,4) ,3) + '-'  
	set @cdate =   left(@RequestFrom,2)  
	set @cdate = @Cammonth + @cdate   
	set @cdate = replace(@cdate ,'--', '-') 
	set @RequestFrom = rtrim(  @cdate) 
end
if @RequestTo <>''
begin 
	set @Camyear = right( @RequestTo , 4) + '-' 
	set @Cammonth =   @Camyear +  right(left( right(  @RequestTo  , 8) ,4) ,3) + '-'  
	set @cdate =   left(@RequestTo,2)  
	set @cdate = @Cammonth + @cdate   
	set @cdate = replace(@cdate ,'--', '-') 
	set @RequestTo = rtrim(  @cdate) 
end 

if @AprDateFrom <>''
begin 
	set @Camyear = right( @AprDateFrom , 4) + '-' 
	set @Cammonth =   @Camyear +  right(left( right(  @AprDateFrom  , 8) ,4) ,3) + '-'  
	set @cdate =   left(@AprDateFrom,2)  
	set @cdate = @Cammonth + @cdate   
	set @cdate = replace(@cdate ,'--', '-') 
	set @AprDateFrom = rtrim(  @cdate) 
end
if @AprDateTo <>''
begin 
	set @Camyear = right( @AprDateTo , 4) + '-' 
	set @Cammonth =   @Camyear +  right(left( right(  @AprDateTo  , 8) ,4) ,3) + '-'  
	set @cdate =   left(@AprDateTo,2)  
	set @cdate = @Cammonth + @cdate   
	set @cdate = replace(@cdate ,'--', '-') 
	set @AprDateTo = rtrim(  @cdate) 
end 

if @sPksNo <>''  
begin
	set @filter  += ' and PKSID	 like ''%' + @sPksNo  + '%'''  + char(10)  
end

if @sSupplier <>''  
begin
	set @filter  += ' and supplierName like ''%' + @sSupplier  + '%'''  + char(10)  
end 


 


set @cmd  =  'select  PKSid , supplierName , plafon , tglMulaiAPS , tglBerakhirAPS , ISNULL ( sisaSaldo , 0) sisaSaldo from topUp'  
set @cmd  =  @cmd + @filter  

print @filter 
print @cmd
exec (@cmd)

 --PKSid , supplierName , plafon , tglMulaiAPS , tglBerakhirAPS 