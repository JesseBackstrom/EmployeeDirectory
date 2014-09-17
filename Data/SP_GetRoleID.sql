USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetRoleID]    Script Date: 9/17/2014 10:44:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetRoleID]
	-- Add the parameters for the stored procedure here
	@Role varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  ID 
	from Role 
	where Role= @Role
END





GO

