using MovieStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.DbOperations
{
    public class MovieStoreDbContext:DbContext,IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options):base(options)
        {
            
        }
 
        public DbSet<Actor> Actors {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<CustomerMovie> CustomerMovies { get; set; }
        public DbSet<Director> Directors {get;set;}
        public DbSet<Genre> Genres {get;set;}
        public DbSet<Movie> Movies {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<MoviesActor> MoviesActors{ get; set; }
        public DbSet<DirectorMovie> DirectorMovies { get; set; }
        public DbSet<CustomerGenre> CustomerGenres { get; set; }
        public DbSet<User> Users { get;set; }
    }
    
    
}