using System.Collections.Generic;
using MovieStoreWebApi.DTo.Genre.GenreViews;
using MovieStoreWebApi.DTo.Movie.MovieViews;

namespace MovieStoreWebApi.DTo.Customer.CustomerViews

{
    public class CustomerDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<MovieTemplateViewModel> CustomerMovies { get; set; }
        public List<GenreViewModel> CustomerGenres { get; set; }

    }
}