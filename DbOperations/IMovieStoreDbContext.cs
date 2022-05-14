using MovieStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Actor> Actors {get;set;}
        DbSet<Customer> Customers {get;set;}
        DbSet<CustomerMovie> CustomerMovies {get;set;}
        DbSet<Director> Directors {get;set;}
        DbSet<Genre> Genres {get;set;}
        DbSet<Movie> Movies {get;set;}
        DbSet<MoviesActor> MoviesActors {get;set;}
        DbSet<CustomerGenre> CustomerGenres {get;set;}
        DbSet<Order> Orders { get; set; }
        DbSet<DirectorMovie> DirectorMovies {get;set;}

        DbSet<User> Users {get;set;}
        int SaveChanges();

    }
    
}