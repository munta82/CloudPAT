use CloudPAT
GO
Create Procedure prcGetMeasuringApplications
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial Development

***************************************/

BEGIN
	SELECT [MeasureAppId]
      ,[MeasureAppCode]
      ,[MeasureAppName]
      ,[IsActive]     
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
1		21-Jun-21	Initial Development

prcGetMeasuringApplicationMappings 'PPAT'
***************************************/
BEGIN 
SELECT [MeasureAppMapId]
      ,[MeasureAppCode]
      ,[AppCode]
      ,[IsActive]    
  FROM [CloudPAT].[dbo].[MeasuringApplicationMappings]
  Where AppCode=@AppCode and isActive='Y'
END

GO

Create Procedure prcGetStates
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

***************************************/
BEGIN


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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

***************************************/
BEGIN
  SELECT  [ComId]
      ,[CommunityCode]
      ,[CommunityName]
      ,[IsActive]     
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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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
1		21-Jun-21	Initial Development

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

Alter Procedure prcGetPPATMasterInfo
(@AppCode varchar(25))
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial Development
prcGetPPATMasterInfo 'PPAT'
***************************************/
BEGIN
	SELECT  [MeasureAppMapId]
      ,[MeasureAppCode]
      ,[AppCode]
      ,[IsActive]      
  FROM [CloudPAT].[dbo].[MeasuringApplicationMappings]
  WHERE AppCode=@AppCode

  SELECT DISTINCT --[StateId],
      [StateCode]
      ,[StateName]
      --,[IsActive]      
  FROM [CloudPAT].[dbo].[StateLookUp]
  Where isActive='Y'

SELECT  [PCId]
      ,[PCCode]
      ,[PCName]
      ,[StateCode]
      ,[IsActive]
      
  FROM [CloudPAT].[dbo].[ParliamentLookUp]
  Where isActive='Y'

SELECT [ACId]
      ,[ACCode]
      ,[ACName]
      ,[PCCode]
      ,[IsActive]
  FROM [CloudPAT].[dbo].[AssemblyLookUp]
  Where isActive='Y'

SELECT [MDId]
      ,[MandalCode]
      ,[MandalName]
      ,[ACCode]
      ,[IsActive]      
  FROM [CloudPAT].[dbo].[MandalLookUp]
  Where isActive='Y'

SELECT [VGId]
      ,[VillageCode]
      ,[VillageName]
      ,[MandalCode]
      ,[IsActive]
  FROM [CloudPAT].[dbo].[VillageLookUp]
   Where isActive='Y'

SELECT  [EduId]
      ,[EducationCode]
      ,[EducationName]
      ,[IsActive]
  FROM [CloudPAT].[dbo].[EducationLookUp]
  Where IsActive='Y'

  SELECT  [ComId]
      ,[CommunityCode]
      ,[CommunityName]
      ,[IsActive]     
  FROM [CloudPAT].[dbo].[CommunityLookUp]
  Where isActive='Y'

SELECT [IFId]
      ,[IFCode]
      ,[IFName]
      ,[IsActive]      
  FROM [CloudPAT].[dbo].[IFPartyLookUp]
  Where IsActive='Y'

SELECT  [PPATSFId]
      ,[PPAT_SFCode]
      ,[PPAT_SFName]
      ,[IsActive]     
  FROM [CloudPAT].[dbo].[PPAT_SFLookUp]
  Where [IsActive]='Y'

SELECT   [PPAT_PRFId]
      ,[PPAT_PRFCode]
      ,[PPAT_PRFName]
      ,[IsActive]       
  FROM [CloudPAT].[dbo].[PPAT_PRFLookUp]
  Where [IsActive]='Y'

SELECT  [PPAT_VPFId]
      ,[PPAT_VPFCode]
      ,[PPAT_VPFName]
      ,[IsActive]       
  FROM [CloudPAT].[dbo].[PPAT_VPFLookUp]
  Where [IsActive]='Y'

SELECT [PPAT_PIFId]
      ,[PPAT_PIFCode]
      ,[PPAT_PIFName]
      ,[IsActive]      
  FROM [CloudPAT].[dbo].[PPAT_PIFLookUp]
  Where [IsActive]='Y'





END

GO

Alter Procedure prcGetEmployeeInfo
(
@UserName varchar(25) = null,
@EmpId INT = null
)
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial Development
prcGetEmployeeInfo 'sa','-1'
***************************************/
BEGIN
	if(@UserName IS NOT null)
	BEGIN
		Select @EmpId =EmpId from EmployeeInfo Where EmpUsername=@UserName  
		EXEC prcGetEmployeeMasterInfo @EmpId
	END
	else IF(@EmpId != -1)
		EXEC prcGetEmployeeMasterInfo @EmpId
END

GO

ALTER Procedure prcCheckUserAuthentication
(
@UserName varchar(25),
@Password varchar(25)
)
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial Development
prcCheckUserAuthentication 'sa','sa'
***************************************/
BEGIN
if(@Password = '')
	If Exists(Select 1 from EmployeeInfo Where EmpUsername=@UserName and EmpPassword=@Password)
	BEGIN
		Declare @EmpId as Int
		Select @EmpId =EmpId from EmployeeInfo Where EmpUsername=@UserName and EmpPassword=@Password
		--Select * from EmployeeInfo Where EmpId = @EmpId 
		--SELECT [Id]
		--,[EmpId]
		--,[AppCode]
		--,[IsActive]       
		--FROM [CloudPAT].[dbo].[EmployeeAppAccess]
		--Where EmpId = @EmpId
		EXEC prcGetEmployeeMasterInfo @EmpId
		 
   END
	ELSE
		Select -1 as EmpId 
END

GO

Create Procedure prcGetEmployeeMasterInfo
(
@EmpId INT
)
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		21-Jun-21	Initial Development
prcGetEmployeeMasterInfo 1
***************************************/
BEGIN
	SELECT  e.[EmpId]
      ,[EmpFirstName]
      ,[EmpLastName]
      ,[EmpPhone]
      ,[EmpEmail]
      ,[EmpAddress]
      ,[EmpUsername]
      ,[EmpPassword]
      ,er.RoleId      
	  ,r.RoleName
  FROM [CloudPAT].[dbo].[EmployeeInfo] e
  JOIN EmployeeRoles  er on e.EmpId = er.EmpId
  JOIN RolesLookUp R on R.RoleId= er.RoleId 
  Where e.EmpId = @EmpId
  and e.isActive='Y' and er.IsActive='Y'

  SELECT [Id]
      ,[EmpId]
      ,[AppCode]
      ,[IsActive]       
  FROM [CloudPAT].[dbo].[EmployeeAppAccess]
   Where EmpId = @EmpId
    
END

GO


Create Procedure SaveUpdateUserInfo
(
@PSCode varchar(25)
)
AS 
/***************************************
ID		Date		Change
----------------------------------------
1		23-Jun-21	Initial Development
prcGetConstituencyInfo_PSCode 1
***************************************/
BEGIN

END
