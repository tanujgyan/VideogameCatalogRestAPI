using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.Controllers;
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
        /// <summary>
        /// Query the DB to get a video game by id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns NotFoundResult if no video game is found
        /// </returns>
        public async Task<ActionResult<Videogame>> GetVideogame(int id)
        {
            try
            {
                var videogame = await _context.Videogames.FindAsync(id);

                if (videogame == null)
                {
                    return new NotFoundResult();
                }

                return videogame;
            }
            catch 
            {
                throw;
            }
        }
        /// <summary>
        /// Gets list of all video games in DB
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Add a new video game to DB
        /// </summary>
        /// <param name="videogame"></param>
        /// <returns>
        /// Newly created videogame
        /// </returns>
        public async Task<ActionResult<Videogame>> PostVideogame(Videogame videogame)
        {
            try
            {
                _context.Videogames.Add(videogame);
                await _context.SaveChangesAsync();

                return videogame;
            }
            catch 
            { 
                throw;
            }
        }
        /// <summary>
        /// Update an existing video game in DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="videogame"></param>
        /// <returns>
        /// Returns NoContentResult on success
        /// Returns Bad Request if id to be updated does not match the id of videogame object
        /// 
        /// </returns>
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
        /// <summary>
        /// Checks if videogame exists by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// true if found
        /// false if not found
        /// </returns>
        private bool VideogameExists(int id)
        {
            return _context.Videogames.Any(e => e.VideogameId == id);
        }
    }
}
