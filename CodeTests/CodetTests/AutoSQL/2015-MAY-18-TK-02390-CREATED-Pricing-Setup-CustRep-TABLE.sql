/*
   Monday, May 18, 20152:10:31 PM
   User: suraj.sahoo
   Server: 192.168.8.222
   Database: Clysar
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.PricingSetupCustRep
	(
	PricingCustRepID bigint NOT NULL IDENTITY (1, 1),
	CustRepName char(75) NOT NULL,
	IsActive bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PricingSetupCustRep ADD CONSTRAINT
	PK_PricingSetupCustRep PRIMARY KEY CLUSTERED 
	(
	PricingCustRepID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PricingSetupCustRep SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PricingSetupCustRep', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PricingSetupCustRep', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PricingSetupCustRep', 'Object', 'CONTROL') as Contr_Per 