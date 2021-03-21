using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideogameCatalogRestAPI.Entities
{
    public class Videogame
    {
        [Key]
        public int VideogameId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string VideogameName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Platform { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Genere { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string PublisherName { get; set; }
    }
}
