CREATE PROCEDURE AddArtist
    @DateCreation DATETIME,
    @Title NVARCHAR(255),
    @Biography NVARCHAR(MAX),
    @ImageURL NVARCHAR(500),
    @HeroURL NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Artist(DateCreation, Title, Biography, ImageURL, HeroURL)
    VALUES (@DateCreation, @Title, @Biography, @ImageURL, @HeroURL);


    SELECT SCOPE_IDENTITY() AS ArtistID;
END