using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.DBContext;
using VideogameCatalogRestAPI.Entities;
using VideogameCatalogRestAPI.Repositories.Contracts;

namespace VideogameCatalogRestAPI.Repositories.Implementations
{
    public class VideogameRepository: IVideogameRepository
    {
        private readonly ApplicationDbContext _context;
        public VideogameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Videogame>>> GetVideogames()
        {
            return await _context.Videogames.ToListAsync();
        }
    }
}
