Create Procedure prcGetMeasuringApplications
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/

BEGIN
	SELECT [MeasureAppId]
      ,[MeasureAppCode]
      ,[MeasureAppName]
      ,[IsActive]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
  FROM [CloudPAT].[dbo].[MeasuringApplicationLookUp] 
  Where IsActive = 'Y' Order by MeasureAppName
END

GO

Create Procedure prcGetMeasuringApplicationMappings
(
@AppCode varchar(25)
)
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

prcGetMeasuringApplicationMappings 'PPAT'
***************************************/
BEGIN 
SELECT [MeasureAppMapId]
      ,[MeasureAppCode]
      ,[AppCode]
      ,[IsActive]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
  FROM [CloudPAT].[dbo].[MeasuringApplicationMappings]
  Where AppCode=@AppCode and isActive='Y'
END

GO

Create Procedure prcGetStates
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/

BEGIN
SELECT DISTINCT [StateId]
      ,[StateCode]
      ,[StateName]
      ,[IsActive]
      
  FROM [CloudPAT].[dbo].[StateLookUp]
  Where isActive='Y'
END

GO

Create Procedure prcGetParliaments
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT  [PCId]
      ,[PCCode]
      ,[PCName]
      ,[StateCode]
      ,[IsActive]
      
  FROM [CloudPAT].[dbo].[ParliamentLookUp]
  Where isActive='Y'
END

GO

Create Procedure prcGetAssemblies
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT [ACId]
      ,[ACCode]
      ,[ACName]
      ,[PCCode]
      ,[IsActive]
  FROM [CloudPAT].[dbo].[AssemblyLookUp]
  Where isActive='Y'
 END

GO

Create Procedure prcGetMandals
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT [MDId]
      ,[MandalCode]
      ,[MandalName]
      ,[ACCode]
      ,[IsActive]
      
  FROM [CloudPAT].[dbo].[MandalLookUp]
  Where isActive='Y'
END
GO


Create Procedure prcGetVilages
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT [VGId]
      ,[VillageCode]
      ,[VillageName]
      ,[MandalCode]
      ,[IsActive]
  FROM [CloudPAT].[dbo].[VillageLookUp]
   Where isActive='Y'
END
GO

Create Procedure prcGetAssemblyPollingStationsData
(
@PSCode varchar(25)
)
AS 
/***************************************
prcGetAssemblyPollingStationsData '56'
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [PSId]
      ,[PSCode]
      ,isNULL([PSName],'') as [PSName]
      ,[VillageCode]
      ,[MandalCode]
      ,[ACCode]
      ,[PCCode]
      ,[StateCode]
      ,[IsActive]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
  FROM [CloudPAT].[dbo].[AssemblyPollingStationLookUp]
  Where PSCode=@PSCode and isActive='Y'
END
GO


Create Procedure prcGetEducationCategory
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT  [EduId]
      ,[EducationCode]
      ,[EducationName]
      ,[IsActive]
  FROM [CloudPAT].[dbo].[EducationLookUp]
  Where IsActive='Y'
END

  GO

Create Procedure prcGetCommunityCategory
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
  SELECT  [ComId]
      ,[CommunityCode]
      ,[CommunityName]
      ,[IsActive]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
  FROM [CloudPAT].[dbo].[CommunityLookUp]
  Where isActive='Y'
END

Go

Create Procedure prcGetSubCasteCategory
(
@CommunityCode varchar(50)
)
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT TOP (1000) [SubCasteId]
      ,[SubCasteCode]
      ,[SubCasteName]
      ,[CommunityCode]
      ,[IsActive]
      --,[CreatedDate]
      --,[CreatedBy]
      --,[ModifiedDate]
      --,[ModifiedBy]
  FROM [CloudPAT].[dbo].[SubCasteLookUp]
  Where CommunityCode=@CommunityCode and IsActive='Y'
END

GO

Create Procedure prcGetIFPartyData

AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT [IFId]
      ,[IFCode]
      ,[IFName]
      ,[IsActive]
      
  FROM [CloudPAT].[dbo].[IFPartyLookUp]
  Where IsActive='Y'
END

GO



Create Procedure prcGetSFCategory
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT  [PPATSFId]
      ,[PPAT_SFCode]
      ,[PPAT_SFName]
      ,[IsActive]
     
  FROM [CloudPAT].[dbo].[PPAT_SFLookUp]
  Where [IsActive]='Y'
END

GO

Create Procedure prcGetPRFCategory
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT   [PPAT_PRFId]
      ,[PPAT_PRFCode]
      ,[PPAT_PRFName]
      ,[IsActive]
       
  FROM [CloudPAT].[dbo].[PPAT_PRFLookUp]
  Where [IsActive]='Y'
END



Go

Create Procedure prcGetVPFCategory
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT  [PPAT_VPFId]
      ,[PPAT_VPFCode]
      ,[PPAT_VPFName]
      ,[IsActive]
       
  FROM [CloudPAT].[dbo].[PPAT_VPFLookUp]
  Where [IsActive]='Y'
END
Go

Create Procedure prcGetPIFCategory
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial

***************************************/
BEGIN
SELECT [PPAT_PIFId]
      ,[PPAT_PIFCode]
      ,[PPAT_PIFName]
      ,[IsActive]
      
  FROM [CloudPAT].[dbo].[PPAT_PIFLookUp]
  Where [IsActive]='Y'
  END

GO