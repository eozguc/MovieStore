using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieYear { get; set;}
        public int GenreId { get; set; }
        public Genre Genre { get; set;}
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public List<MoviesActor> Actors { get; set; }
        public double Price { get; set; }
    }
}