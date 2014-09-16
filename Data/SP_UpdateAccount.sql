USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdateAccount]    Script Date: 9/16/2014 8:36:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdateAccount]
	-- Add the parameters for the stored procedure here
	@FirstName varchar(20),
	@LastName varchar(20),
	@Employee_ID bigint,
	@Role int,
	@Location smallint,
	@Email varchar(50),
	@Status smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS (Select * from EMPLOYEE where Employee_ID = @Employee_ID)
	Begin
		UPDATE [dbo].[Employee]
		Set
			FirstName = @FirstName,
			LastName = @LastName,
			Role = @Role,
			Location = @Location,
			email = @Email,
			Status = @Status
		where
			Employee_ID = @Employee_ID
	END
	ELSE
	BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Employee]
           ([FirstName]
           ,[LastName]
           ,[Employee_ID]
           ,[Role]
           ,[Location]
           ,[email]
           ,[Status])
     VALUES
           (@FirstName
           ,@LastName
           ,@Employee_ID
           ,@Role
           ,@Location
           ,@Email
           ,@Status);
	END
END


GO
