USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetEmployee]    Script Date: 9/17/2014 10:42:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetEmployee]
	-- Add the parameters for the stored procedure here
	@Employee_ID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT EmpPassword, FirstName, LastName, Employee_ID, Role.Role, Location.Location, Email, Status.Status 
	from Employee Join Role on Employee.Role = Role.Id 
	join Status on Employee.Status = Status.Id
	join Location on Employee.Location = Location.Id
	where Employee.Employee_ID = @Employee_ID
END







