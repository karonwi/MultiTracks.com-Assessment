using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using MTDomain.Entities;
using MTDomain.Interfaces;

using MTDTO.Request;
using MTDTO.Response;

using Services.Interfaces;

namespace Services.Implementations
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> _artistRepo;

        public ArtistService(IRepository<Artist> artistRepo)
        {
            _artistRepo = artistRepo;
        }

        public async Task<Response<CreateArtistDto>> GetArtistByNameAsync(string name)
        {
            try
            {
                var artist = await _artistRepo.GetByNameAsync(name);
                var mappedResult = MapEntityArtistToDto(artist);
                if (artist != null)
                {
                    return new Response<CreateArtistDto>()
                    {
                        Data = mappedResult,
                        Message = "Success",
                        Success = true

                    };
                }
                return new Response<CreateArtistDto>()
                {
                    Errors = "Error fetching artist",
                    Message = "Unsuccessful attempt",
                    Success = false

                };
            }
            catch (Exception x)
            {
                return new Response<CreateArtistDto>()
                {
                    Data = null,
                    Errors = HttpStatusCode.InternalServerError.ToString(),
                    Message = x.Message,
                    Success = false
                };
            }
            
        }

        public async Task<Response<int>> AddArtistAsync(CreateArtistDto artist)
        {
            try
            {
                var newArtist = MapDtoToEntity(artist);
                var artiste = await _artistRepo.AddAsync(newArtist);
                if (artiste > 1)
                {
                    return new Response<int>()
                    {
                        Message = "Successfully Created New Artist",
                        Success = true,
                        Data = artiste
                    };

                }

                return new Response<int>()
                {
                    Errors = "Error adding new Artist",
                    Message = "Unsuccessful",
                    Success = false
                };
            }
            catch (Exception exception)
            {
                return new Response<int>()
                {
                    Errors = HttpStatusCode.InternalServerError.ToString(),
                    Message = exception.Message,
                    Success = false
                };
            }
            
        }

        private  CreateArtistDto MapEntityArtistToDto(Artist artist)
        {

            return new CreateArtistDto()
            {
                Biography = artist.Biography,
                DateCreation = artist.DateCreation,
                HeroURL = artist.HeroURL,
                ImageURL = artist.ImageURL,
                Title = artist.Title
            };
        }

        private Artist MapDtoToEntity(CreateArtistDto artistDto)
        {
            return new Artist()
            {
                DateCreation = DateTime.Now,
                Title = artistDto.Title,
                Biography = artistDto.Biography,
                ImageURL = artistDto.ImageURL,
                HeroURL = artistDto.HeroURL
            };
        }
    }
}
