using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.Entities;

namespace VideogameCatalogRestAPI.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Videogame> Videogames { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
