---------------------------------------------
---------------- DROP TABLES ----------------
---------------------------------------------

IF OBJECT_ID(N'dbo.Contact', N'U') IS NOT NULL
	BEGIN
		DROP TABLE dbo.Contact;
	END
GO

---------------------------------------------
--------------- CREATE TABLES ---------------
---------------------------------------------

CREATE TABLE dbo.Contact(

	  ContactId INT IDENTITY(1,1) NOT NULL
	, ContactReferenceId UNIQUEIDENTIFIER NOT NULL
	, FirstName NVARCHAR(200) NOT NULL
	, LastName NVARCHAR(200) NULL
	, Organization NVARCHAR(200) NULL
	, Email NVARCHAR(200) NULL
	, PhoneNumber NVARCHAR(15) NULL
	, CreatDateTime DATETIME NOT NULL
	, UpdateDateTime DATETIME NULL
	, IsDeleted BIT DEFAULT(1) NOT NULL

	  CONSTRAINT PK_ContactId
		PRIMARY KEY (ContactId)
	
);

CREATE NONCLUSTERED INDEX IX_Contact_ContactReferenceId
	ON dbo.Contact (ContactReferenceId);