
IF OBJECT_ID('up_GetContact') IS NOT NULL
	BEGIN
		DROP PROCEDURE dbo.up_GetContact
	END
GO

CREATE PROCEDURE dbo.up_GetContact
(
    @ContactReferenceId UNIQUEIDENTIFIER
)
AS
BEGIN

	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRY

		BEGIN TRANSACTION

		   SELECT 
			 ContactReferenceId
			,FirstName
			,LastName
			,Organization
			,Email
			,PhoneNumber
			,IsDeleted
		   FROM dbo.Contact
			WHERE ContactReferenceId = @ContactReferenceId
			AND IsDeleted = 0

		COMMIT TRAN

	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- you can Raise ERROR with RAISEERROR() Statement including the details of the exception
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY()
        DECLARE @ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

	END CATCH

END
GO

----------------------------------------------------------------------------------------------------------------------

IF OBJECT_ID('up_GetContacts') IS NOT NULL
	BEGIN
		DROP PROCEDURE dbo.up_GetContacts
	END
GO

CREATE PROCEDURE dbo.up_GetContacts
AS
BEGIN

	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRY

		BEGIN TRANSACTION

		   SELECT 
			 ContactReferenceId
			,FirstName
			,LastName
			,Organization
			,Email
			,PhoneNumber
			,IsDeleted
		   FROM dbo.Contact
			WHERE IsDeleted = 0

		COMMIT TRAN

	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- you can Raise ERROR with RAISEERROR() Statement including the details of the exception
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY()
        DECLARE @ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

	END CATCH

END
GO

----------------------------------------------------------------------------------------------------------------------


IF OBJECT_ID('up_AddContact') IS NOT NULL
	BEGIN
		DROP PROCEDURE dbo.up_AddContact
	END
GO

CREATE PROCEDURE dbo.up_AddContact
(    
	@ContactReferenceId UNIQUEIDENTIFIER,
	@FirstName NVARCHAR(200),
	@LastName NVARCHAR(200),
	@Organization NVARCHAR(200),
	@Email NVARCHAR(200),
	@PhoneNumber NVARCHAR(15)
)
AS
BEGIN

	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRY

		BEGIN TRANSACTION

		   INSERT INTO dbo.Contact
           (ContactReferenceId
           ,FirstName
           ,LastName
           ,Organization
           ,Email
           ,PhoneNumber
		   ,CreatDateTime
           ,IsDeleted)
     VALUES
           (@ContactReferenceId
           ,@FirstName
           ,@LastName
           ,@Organization
           ,@Email
           ,@PhoneNumber
		   ,GETDATE()
           ,0)

		SELECT * FROM dbo.Contact WHERE ContactReferenceId = @ContactReferenceId

		COMMIT TRAN

	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- you can Raise ERROR with RAISEERROR() Statement including the details of the exception
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY()
        DECLARE @ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

	END CATCH

END
GO

----------------------------------------------------------------------------------------------------------------------


IF OBJECT_ID('up_UpdateContact') IS NOT NULL
	BEGIN
		DROP PROCEDURE dbo.up_UpdateContact
	END
GO

CREATE PROCEDURE dbo.up_UpdateContact
(    
	@ContactReferenceId UNIQUEIDENTIFIER,
	@FirstName NVARCHAR(200),
	@LastName NVARCHAR(200),
	@Organization NVARCHAR(200),
	@Email NVARCHAR(200),
	@PhoneNumber NVARCHAR(15)
)
AS
BEGIN

	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRY

		BEGIN TRANSACTION

		   UPDATE dbo.Contact
			   SET ContactReferenceId = @ContactReferenceId
				  ,FirstName = @FirstName
				  ,LastName = @LastName
				  ,Organization = @Organization
				  ,Email = @Email
				  ,PhoneNumber = @PhoneNumber
				  ,IsDeleted = 0
				  ,UpdateDateTime = GETDATE()
			 WHERE ContactReferenceId = @ContactReferenceId

			 SELECT * FROM dbo.Contact 
			 WHERE ContactReferenceId = @ContactReferenceId

		COMMIT TRAN

	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- you can Raise ERROR with RAISEERROR() Statement including the details of the exception
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY()
        DECLARE @ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

	END CATCH

END
GO

----------------------------------------------------------------------------------------------------------------------


IF OBJECT_ID('up_DeleteContact') IS NOT NULL
	BEGIN
		DROP PROCEDURE dbo.up_DeleteContact
	END
GO

CREATE PROCEDURE dbo.up_DeleteContact
(    
	@ContactReferenceId UNIQUEIDENTIFIER
)
AS
BEGIN

	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRY

		BEGIN TRANSACTION

		   UPDATE dbo.Contact
			   SET IsDeleted = 1
			 WHERE ContactReferenceId = @ContactReferenceId

			SELECT CAST(1 AS BIT)

		COMMIT TRAN

	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK TRAN --RollBack in case of Error

		-- you can Raise ERROR with RAISEERROR() Statement including the details of the exception
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY()
        DECLARE @ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, -- Message text.  
               @ErrorSeverity, -- Severity.  
               @ErrorState -- State.  
               );

	END CATCH

END
GO

----------------------------------------------------------------------------------------------------------------------

