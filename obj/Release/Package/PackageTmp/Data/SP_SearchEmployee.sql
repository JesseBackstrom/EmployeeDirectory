USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_SearchEmployee]    Script Date: 9/17/2014 10:45:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_SearchEmployee]
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
	
	select ID,FirstName,LastName,Employee_ID,Role,Location,email,Status
	from Employee
	where (FirstName = @FirstName OR @FirstName is null)
	and (LastName = @LastName OR @LastName is null)
	and (Employee_ID = @Employee_ID OR @Employee_ID is null)
	and (Role = @Role OR @Role is null)
	and (Location = @Location OR @Location is null)
	and (Email = @Email OR @Email is null)
	and (status = @Status OR @Status is null)
END



GO

