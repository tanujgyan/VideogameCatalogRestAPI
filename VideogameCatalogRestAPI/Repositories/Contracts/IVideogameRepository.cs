using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.Entities;

namespace VideogameCatalogRestAPI.Repositories.Contracts
{
    public interface IVideogameRepository
    {
        Task<ActionResult<IEnumerable<Videogame>>> GetVideogames();
    }
}
