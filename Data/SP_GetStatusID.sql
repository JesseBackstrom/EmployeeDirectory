USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetStatusID]    Script Date: 9/17/2014 10:45:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetStatusID]
	-- Add the parameters for the stored procedure here
	@Status varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  ID 
	from Status 
	where Status= @Status
END





GO

