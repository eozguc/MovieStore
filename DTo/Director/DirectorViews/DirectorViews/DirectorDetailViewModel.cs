using System.Collections.Generic;
using MovieStoreWebApi.DTo.Movie.MovieViews;

namespace MovieStoreWebApi.DTo.Director.DirectorViews
{
    public class DirectorDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<MovieTemplateViewModel> MovieTemplateViewModels { get; set; }
    }
}