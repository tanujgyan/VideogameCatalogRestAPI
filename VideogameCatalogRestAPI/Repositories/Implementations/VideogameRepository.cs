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

        public async Task<ActionResult<Videogame>> GetVideogame(int id)
        {
            try
            {
                var videogame = await _context.Videogames.FindAsync(id);

                if (videogame == null)
                {
                    return null;
                }

                return videogame;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<Videogame>>> GetVideogames()
        {
            try
            {
                return await _context.Videogames.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ActionResult<Videogame>> PostVideogame(Videogame videogame)
        {
            try
            {
                _context.Videogames.Add(videogame);
                await _context.SaveChangesAsync();

                return new CreatedAtActionResult("GetVideogame", "GetVideogame", new { id = videogame.VideogameId }, videogame);
            }
            catch 
            { 
                throw;
            }
        }

        public async Task<IActionResult> PutVideogame(int id, Videogame videogame)
        {
           
            if (id != videogame.VideogameId)
            {
                return new  BadRequestResult();
            }

            _context.Entry(videogame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideogameExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return new NoContentResult();
        }
        private bool VideogameExists(int id)
        {
            return _context.Videogames.Any(e => e.VideogameId == id);
        }
    }
}
