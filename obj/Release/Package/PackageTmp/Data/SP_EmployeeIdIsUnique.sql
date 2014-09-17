USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_EmployeeIdIsUnique]    Script Date: 9/17/2014 10:41:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_EmployeeIdIsUnique]
	-- Add the parameters for the stored procedure here
	@Employee_ID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select Employee_ID from Employee where Employee_ID = @Employee_ID
END







GO
