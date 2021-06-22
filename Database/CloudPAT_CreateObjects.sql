IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'CloudPAT')
BEGIN
	--DROP DATABASE CloudPAT;
	CREATE DATABASE CloudPAT
END

GO

USE CloudPAT
GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'StateLookUp') AND TYPE in(N'U'))
DROP TABLE StateLookUp
GO
Create Table StateLookUp
(
 StateId Int Identity(1,1) NOT NULL
,StateCode Varchar(10) NOT NULL
,StateName Varchar(100) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'ParliamentLookUp') AND TYPE in(N'U'))
DROP TABLE ParliamentLookUp
GO
Create Table ParliamentLookUp
(
 PCId Int Identity(1,1) NOT NULL
,PCCode Varchar(10) NOT NULL
,PCName Varchar(100) NOT NULL
,StateCode Varchar(10) NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO





IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'AssemblyLookUp') AND TYPE in(N'U'))
DROP TABLE AssemblyLookUp
GO
Create Table AssemblyLookUp
(
 ACId Int Identity(1,1) NOT NULL
,ACCode Varchar(10) NOT NULL
,ACName Varchar(100) NOT NULL
,PCCode Varchar(10) NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO



IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'MandalLookUp') AND TYPE in(N'U'))
DROP TABLE MandalLookUp
GO
Create Table MandalLookUp
(
 MDId Int Identity(1,1) NOT NULL
,MandalCode Varchar(100) NOT NULL
,MandalName Varchar(100) NOT NULL
,ACCode Varchar(10)  NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'VillageLookUp') AND TYPE in(N'U'))
DROP TABLE VillageLookUp
GO
Create Table VillageLookUp
(
 VGId Int Identity(1,1) NOT NULL
,VillageCode Varchar(100) NOT NULL
,VillageName Varchar(100) NOT NULL
,MandalCode Varchar(100) NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO


IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'AssemblyPollingStationLookUp') AND TYPE in(N'U'))
DROP TABLE AssemblyPollingStationLookUp
GO
Create Table AssemblyPollingStationLookUp
(
 PSId Int Identity(1,1) NOT NULL
,PSCode Varchar(10) NOT NULL
,PSName Varchar(100) NULL
,VillageCode Varchar(100) NOT NULL
,MandalCode Varchar(100) NOT NULL
,ACCode Varchar(10) NOT NULL
,PCCode Varchar(10) NOT NULL
,StateCode Varchar(10) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO



IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'MuncipalityLookUp') AND TYPE in(N'U'))
DROP TABLE MuncipalityLookUp
GO
Create Table MuncipalityLookUp
(
 MuncipalId Int Identity(1,1) NOT NULL
,MuncipalCode Varchar(100) NOT NULL
,MuncipalName Varchar(100) NOT NULL
,ACCode Varchar(10) NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO


IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'MuncipalPollingStationLookUp') AND TYPE in(N'U'))
DROP TABLE MuncipalPollingStationLookUp
GO
Create Table MuncipalPollingStationLookUp
(
 MunPSId Int Identity(1,1) NOT NULL
,MunPSCode Varchar(10) NOT NULL
,MunPSName Varchar(100) NOT NULL
,MandalCode Varchar(100) NOT NULL
,ACCode Varchar(10) NOT NULL
,PCCode Varchar(10) NOT NULL
,StateCode Varchar(10) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO



IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'CommunityLookUp') AND TYPE in(N'U'))
DROP TABLE CommunityLookUp
GO
Create Table CommunityLookUp
(
 ComId Int Identity(1,1) NOT NULL
,CommunityCode Varchar(25) NOT NULL
,CommunityName Varchar(100) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'SubCasteLookUp') AND TYPE in(N'U'))
DROP TABLE SubCasteLookUp
GO
Create Table SubCasteLookUp
(
 SubCasteId Int Identity(1,1) NOT NULL
,SubCasteCode Varchar(25) NOT NULL
,SubCasteName Varchar(100) NOT NULL
,CommunityCode Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'GenderLookUp') AND TYPE in(N'U'))
DROP TABLE GenderLookUp
GO
Create Table GenderLookUp
(
 GenderId Int Identity(1,1) NOT NULL
,GenderCode Varchar(10) NOT NULL
,GenderName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'EducationLookUp') AND TYPE in(N'U'))
DROP TABLE EducationLookUp
GO
Create Table EducationLookUp
(
 EduId Int Identity(1,1) NOT NULL
,EducationCode Varchar(10) NOT NULL
,EducationName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'IFPartyLookUp') AND TYPE in(N'U'))
DROP TABLE IFPartyLookUp
GO
Create Table IFPartyLookUp
(
 IFId Int Identity(1,1) NOT NULL
,IFCode Varchar(25) NOT NULL
,IFName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'PPAT_SFLookUp') AND TYPE in(N'U'))
DROP TABLE PPAT_SFLookUp
GO
Create Table PPAT_SFLookUp
(
 PPATSFId Int Identity(1,1) NOT NULL
,PPAT_SFCode Varchar(10) NOT NULL
,PPAT_SFName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO


IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'PPAT_PRFLookUp') AND TYPE in(N'U'))
DROP TABLE PPAT_PRFLookUp
GO
Create Table PPAT_PRFLookUp
(
 PPAT_PRFId Int Identity(1,1) NOT NULL
,PPAT_PRFCode Varchar(10) NOT NULL
,PPAT_PRFName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'PPAT_VPFLookUp') AND TYPE in(N'U'))
DROP TABLE PPAT_VPFLookUp
GO
Create Table PPAT_VPFLookUp
(
 PPAT_VPFId Int Identity(1,1) NOT NULL
,PPAT_VPFCode Varchar(10) NOT NULL
,PPAT_VPFName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'PPAT_PIFLookUp') AND TYPE in(N'U'))
DROP TABLE PPAT_PIFLookUp
GO
Create Table PPAT_PIFLookUp
(
 PPAT_PIFId Int Identity(1,1) NOT NULL
,PPAT_PIFCode Varchar(10) NOT NULL
,PPAT_PIFName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'ApplicationLookUp') AND TYPE in(N'U'))
DROP TABLE ApplicationLookUp
GO
Create Table ApplicationLookUp
(
 AppId Int Identity(1,1) NOT NULL
,AppCode Varchar(25) NOT NULL
,AppName Varchar(100) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
,PRIMARY KEY(AppCode)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'MeasuringApplicationLookUp') AND TYPE in(N'U'))
DROP TABLE MeasuringApplicationLookUp
GO
Create Table MeasuringApplicationLookUp
(
 MeasureAppId Int Identity(1,1) NOT NULL
,MeasureAppCode Varchar(50) NOT NULL
,MeasureAppName Varchar(100) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
,PRIMARY KEY(MeasureAppCode )
)

GO


---------------------MeasuringApplicationMappings----------------------
IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'MeasuringApplicationMappings') AND TYPE in(N'U'))
DROP TABLE MeasuringApplicationMappings
GO
Create Table MeasuringApplicationMappings
(
 MeasureAppMapId Int Identity(1,1) NOT NULL
,MeasureAppCode Varchar(50) NOT NULL
,AppCode Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO

ALTER TABLE MeasuringApplicationMappings
ADD FOREIGN KEY (AppCode) REFERENCES ApplicationLookUp(AppCode);

Go

ALTER TABLE MeasuringApplicationMappings
ADD FOREIGN KEY (MeasureAppCode) REFERENCES MeasuringApplicationLookUp(MeasureAppCode);

GO
---------------------MeasuringApplicationMappings----------------------

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'EmployeeInfo') AND TYPE in(N'U'))
DROP TABLE EmployeeInfo
GO
Create Table EmployeeInfo
(
 EmpId Int Identity(1,1) NOT NULL
,EmpFirstName Varchar(50) NULL
,EmpLastName Varchar(50) NULL
,EmpPhone Varchar(50) NOT NULL
,EmpEmail Varchar(100) NULL
,EmpAddress Varchar(200) NULL
,EmpUsername Varchar(50) NOT NULL
,EmpPassword Varchar(50) NOT NULL
,EmpSecureId UNiqueIdentifier NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
,PRIMARY KEY(EmpId)
)

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'RolesLookUp') AND TYPE in(N'U'))
DROP TABLE RolesLookUp
GO
Create Table RolesLookUp
(
 AutoId Int Identity(1,1) NOT NULL
,RoleId INT NOT NULL
,RoleName Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100) NULL
,PRIMARY KEY(RoleId)
)

GO


---------------------EmployeeRoles-------------------------------
IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'EmployeeRoles') AND TYPE in(N'U'))
DROP TABLE EmployeeRoles
GO
Create Table EmployeeRoles
(
 AutoRoleId Int Identity(1,1) NOT NULL
,EmpId INT NOT NULL
,RoleId INT NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO
ALTER TABLE EmployeeRoles
ADD FOREIGN KEY (EmpId) REFERENCES EmployeeInfo(EmpId);

Go

ALTER TABLE EmployeeRoles
ADD FOREIGN KEY (RoleId) REFERENCES RolesLookUp(RoleId);

GO
---------------------EmployeeRoles-------------------------------
GO

------------------EmployeeAppAccess---------------------------------
GO
IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'EmployeeAppAccess') AND TYPE in(N'U'))
DROP TABLE EmployeeAppAccess
GO
Create Table EmployeeAppAccess
(
 Id Int Identity(1,1) NOT NULL
,EmpId INT NOT NULL
,AppCode Varchar(25) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO
ALTER TABLE EmployeeAppAccess
ADD FOREIGN KEY (EmpId) REFERENCES EmployeeInfo(EmpId);

Go

ALTER TABLE EmployeeAppAccess
ADD FOREIGN KEY (AppCode) REFERENCES ApplicationLookUp(AppCode);

GO


------------------EmployeeAppAccess---------------------------------

GO

IF EXISTS(Select 1 from SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'UserInfo') AND TYPE in(N'U'))
DROP TABLE UserInfo
GO
Create Table UserInfo
(
 UserId Int Identity(1,1) NOT NULL
,UserDisplayName Varchar(100) NULL
,Gender varchar(8) NOT NULL
,UserMobile Varchar(25) NOT NULL
,Occupation Varchar(100) NULL
,EducationCode Varchar(50) NOT NULL
,CommunityCode Varchar(50) NOT NULL
,SubCasteCode Varchar(50) NOT NULL
,IFCode Varchar(50) NOT NULL
,SFCode Varchar(50) NOT NULL
,PRFCode Varchar(50) NOT NULL
,VPFCode Varchar(50) NOT NULL
,PIFCode Varchar(50) NOT NULL
,Remarks Varchar(250) NULL
,StateCode Varchar(50) NOT NULL
,PCCode Varchar(50) NOT NULL
,ACCode Varchar(50) NOT NULL
,MandalCode Varchar(50) NOT NULL
,VillageCode Varchar(50) NOT NULL
,PSCode Varchar(50) NOT NULL
,MeasureAppCode Varchar(50) NOT NULL
,AppCode Varchar(10) NOT NULL
,IsActive Char(1) NULL
,CreatedDate DateTime NULL
,CreatedBy Varchar(100) Null
,ModifiedDate DateTime NULL
,ModifiedBy Varchar(100)
)

GO




