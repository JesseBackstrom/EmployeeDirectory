USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdatePassword]    Script Date: 9/17/2014 10:46:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdatePassword]
	-- Add the parameters for the stored procedure here

	@Employee_ID bigint,
	@Password varchar(32)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS (Select * from EMPLOYEE where Employee_ID = @Employee_ID)
	Begin
		UPDATE [dbo].[Employee]
		Set
			EmpPassword = Hashbytes('MD5', @Password),
			Status = 1
		where
			Employee_ID = @Employee_ID
	END
END



GO

