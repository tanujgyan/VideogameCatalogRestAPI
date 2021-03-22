using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/Videogames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videogame>> GetVideogame(int id)
        {
            try
            {
                var videogame = await videogameService.GetVideogame(id);
                return videogame;
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex, "api/Videogames-> Error in PostVideogame controller");
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideogame(int id, Videogame videogame)
        {
            try
            {
                var result = await videogameService.PutVideogame(id, videogame);
                
                return result;
            }
            catch(DbUpdateConcurrencyException dbex)
            {
                Serilog.Log.Error(dbex, "api/Videogames-> Concurrency exception in PutVideogame controller");
                return StatusCode(409);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex, "api/Videogames-> Error in PutVideogame controller");
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Videogame>> PostVideogame(Videogame videogame)
        {
            try
            {
                var result = await videogameService.PostVideogame(videogame);
                //return result;
                return CreatedAtAction("GetVideogame", new { id = result.Value.VideogameId}, videogame);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "api/Videogames-> Error in PostVideogame controller");
                return StatusCode(500);
            }
        }
    }


}

