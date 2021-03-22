using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.Entities;
using VideogameCatalogRestAPI.Repositories.Contracts;
using VideogameCatalogRestAPI.Services.Contracts;

namespace VideogameCatalogRestAPI.Services.Implementation
{
    public class VideogameService: IVideogameService
    {
        private readonly IVideogameRepository videogameRepository;
        public VideogameService(IVideogameRepository videogameRepository)
        {
            this.videogameRepository = videogameRepository;
        }

        public async Task<ActionResult<Videogame>> GetVideogame(int id)
        {
            return await videogameRepository.GetVideogame(id);
        }

        public async Task<ActionResult<IEnumerable<Videogame>>> GetVideogames()
        {
            return await videogameRepository.GetVideogames();
        }

        public async Task<ActionResult<Videogame>> PostVideogame(Videogame videogame)
        {
            return await videogameRepository.PostVideogame(videogame);
        }

        public async Task<IActionResult> PutVideogame(int id, Videogame videogame)
        {
            return await videogameRepository.PutVideogame(id, videogame);
        }
    }
}
