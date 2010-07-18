USE [GalacticAds]
GO

/****** Object:  StoredProcedure [dbo].[FindStoresNearAdvertiser]    Script Date: 07/04/2010 23:02:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FindStoresNearAdvertiser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[FindStoresNearAdvertiser]
GO

USE [GalacticAds]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rhys Campbell
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE FindStoresNearAdvertiser 
	-- Add the parameters for the stored procedure here
	@AdvertiserId int, 
	@DistanceInKm int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @AdvertiserLocation geography 
	select top 1 @AdvertiserLocation = location 
	from Address a
	where a.Id = @AdvertiserId
	
	SELECT s.Id, s.Name, a.Latitude, a.Longitude
	FROM
		Store s
			inner join 
		Address a on s.GeographicalLocation = a.Id
	WHERE a.Location.STDistance(@AdvertiserLocation) < @DistanceInKm
END
GO
