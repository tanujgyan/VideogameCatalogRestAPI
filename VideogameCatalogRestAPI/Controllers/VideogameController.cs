using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.Entities;
using VideogameCatalogRestAPI.Repositories.Contracts;
using VideogameCatalogRestAPI.Services.Contracts;

namespace VideogameCatalogRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogameController : ControllerBase
    {
        private readonly IVideogameService videogameService;
        public VideogameController(IVideogameService videogameService)
        {
            this.videogameService = videogameService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videogame>>> GetVideogames()
        {
            try
            {
                var videogames = await videogameService.GetVideogames();
                return videogames;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "api/Videogames-> Error in GetVideogames controller");
                return StatusCode(500);
            }

        }
    }
}
