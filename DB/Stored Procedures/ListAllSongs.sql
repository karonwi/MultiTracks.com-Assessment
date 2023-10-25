CREATE PROCEDURE ListAllSongs
    @PageSize INT,
    @PageNumber INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SongID, 
        DateCreation,
        AlbumID,
        ArtistID, 
        Title, 
        Bpm,
        TimeSignature,
        Multitracks,
        CustomMix,
        Chart,
        RehearsalMix,
        Patches,
        SongSpecificPatches,
        ProPresenter
    FROM 
        Song
    ORDER BY 
        SongID
    OFFSET (@PageSize * (@PageNumber - 1)) ROWS 
    FETCH NEXT @PageSize ROWS ONLY;
END