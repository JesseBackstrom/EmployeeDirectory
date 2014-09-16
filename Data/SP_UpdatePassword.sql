USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdateAccount]    Script Date: 9/16/2014 9:09:52 AM ******/
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
	@Password binary(16)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS (Select * from EMPLOYEE where Employee_ID = @Employee_ID)
	Begin
		UPDATE [dbo].[Employee]
		Set
			EmpPassword = @Password
		where
			Employee_ID = @Employee_ID
	END
END


GO
