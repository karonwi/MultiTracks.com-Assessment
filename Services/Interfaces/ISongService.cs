using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MTDTO.Response;

namespace Services.Interfaces
{
    public interface ISongService
    {
        Task<Response<IEnumerable<GetSongsDto>>> ListSongsPaginatedAsync(int pageSize, int pageNumber);
    }
}
