CREATE PROCEDURE dbo.GetArtistDetails
    @artistID INT
AS 
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ar.artistID, 
        ar.title as artistTitle, 
        ar.biography, 
        ar.imageURL as artistImageURL, 
        ar.heroURL
    FROM dbo.Artist ar
    WHERE ar.artistID = @artistID;

    SELECT 
        a.albumID, 
        a.title as albumTitle, 
        a.imageURL as albumImageURL, 
        a.[year]
    FROM dbo.Album a
    WHERE a.artistID = @artistID;

    SELECT 
        s.songID, 
        s.title as songTitle,
        s.bpm,
        s.timeSignature,
        s.multitracks,
        s.customMix,
        s.chart,
        s.rehearsalMix,
        s.patches,
        s.songSpecificPatches,
        s.proPresenter
    FROM dbo.Song s
    WHERE s.artistID = @artistID;

END