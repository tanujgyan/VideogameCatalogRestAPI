using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.Entities;

namespace VideogameCatalogRestAPI.Services.Contracts
{
   public interface IVideogameService
    {
        Task<ActionResult<IEnumerable<Videogame>>> GetVideogames();
        Task<ActionResult<Videogame>> GetVideogame(int id);
        Task<IActionResult> PutVideogame(int id, Videogame videogame);
        Task<ActionResult<Videogame>> PostVideogame(Videogame videogame);
    }
}
