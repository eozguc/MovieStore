using System.Collections.Generic;
using MovieStoreWebApi.DTo.Actor.ActorViews;

namespace MovieStoreWebApi.DTo.Movie.MovieViews

{
    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public int MovieYear { get; set; }
        public double Price { get; set; }
        public string Director {get;set;}
        public List<ActorViewModel> ActorViewModels { get;set;}
        public string Genre { get; set; }
    }
}