using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MTDomain.Entities;
using MTDomain.Interfaces;

using MTDTO.Response;

using Services.Interfaces;

namespace Services.Implementations
{
    public class SongService : ISongService
    {
        private readonly IRepository<Song> _songRepo;
        public SongService(IRepository<Song> songRepo)
        {
            _songRepo = songRepo;
        }
        public async Task<Response<IEnumerable<GetSongsDto>>> ListSongsPaginatedAsync(int pageSize, int pageNumber)
        {
            var songs = await _songRepo.ListPaginatedAsync(pageNumber, pageSize);
            var mappedResult = MapEntityToDto(songs);
            if (songs!=null)
            {
                return new Response<IEnumerable<GetSongsDto>>()
                {
                    Data = mappedResult,
                    Message = "Successfully gotten songs",
                    Success = true
                };
            }
            return new Response<IEnumerable<GetSongsDto>>()
            {
                Errors = "Couldn't get songs",
                Message = "Unsuccessful",
                Success = false
            };
        }

        private IEnumerable<GetSongsDto> MapEntityToDto(IEnumerable<Song> songs)
        {
            return songs.Select(song => new GetSongsDto
            {
                SongID = song.SongID,
                DateCreation = song.DateCreation,
                AlbumID = song.AlbumID,
                ArtistID = song.ArtistID,
                Title = song.Title,
                Bpm = song.Bpm,
                TimeSignature = song.TimeSignature,
                Multitracks = song.Multitracks,
                CustomMix = song.CustomMix,
                Chart = song.Chart,
                RehearsalMix = song.RehearsalMix,
                Patches = song.Patches,
                SongSpecificPatches = song.SongSpecificPatches,
                ProPresenter = song.ProPresenter
            }).ToList();
        }
    }
}
