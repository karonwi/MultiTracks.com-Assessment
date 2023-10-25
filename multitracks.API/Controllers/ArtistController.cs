using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MTDTO.Request;

using Services.Interfaces;

namespace multitracks.API.Controllers
{
    [Route("api.multitracks.com/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artristService;
        public ArtistController(IArtistService artistService)
        {
            _artristService = artistService;
        }


        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchArtistByName(string name)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            var result = await _artristService.GetArtistByNameAsync(name);
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateArtist(CreateArtistDto model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            var result = await _artristService.AddArtistAsync(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }
    }
}
