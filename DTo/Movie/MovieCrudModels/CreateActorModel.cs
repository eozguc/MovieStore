using System.Collections.Generic;

namespace MovieStoreWebApi.DTo.Movie.MovieCrudModels
{
    public class CreateMovieModel
        {
            public string Name { get; set; }
            public int MovieYear { get; set; }
            public double Price { get; set; }
            public int DirectorId { get; set; }
            public int GenreId { get; set; }
            public List<int> ActorId {get;set;}

        }

}