namespace MovieStoreWebApi.DTo.Movie.MovieCrudModels
{
    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public int MovieYear { get; set; }
        public double Price { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}