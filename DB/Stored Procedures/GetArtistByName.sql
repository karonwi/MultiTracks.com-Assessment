CREATE PROCEDURE GetArtistByName
    @Title NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ArtistID,
        DateCreation,
        Title,
        Biography,
        ImageURL,
        HeroURL
    FROM 
        Artist
    WHERE 
        Title LIKE @Title + '%'
END