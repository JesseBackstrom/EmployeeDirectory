USE [DB_Employee_Directory]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetLocationID]    Script Date: 9/17/2014 10:43:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetLocationID]
	-- Add the parameters for the stored procedure here
	@Location varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  ID 
	from Location 
	where Location= @Location
END





GO

