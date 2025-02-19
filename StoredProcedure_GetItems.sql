USE [ForumDB]
GO
/****** Object:  StoredProcedure [dbo].[GetItems]    Script Date: 1/27/2025 9:44:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetItems]
    @Offset INT,
    @PageSize INT
AS
BEGIN
    SELECT Id, Name
    FROM Items
    ORDER BY Id
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END