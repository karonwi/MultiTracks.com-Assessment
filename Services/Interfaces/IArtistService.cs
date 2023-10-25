using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MTDTO.Request;
using MTDTO.Response;

namespace Services.Interfaces
{
    public interface IArtistService
    {
        Task<Response<CreateArtistDto>> GetArtistByNameAsync(string name);
        Task<Response<int>> AddArtistAsync(CreateArtistDto artist);
    }
}
