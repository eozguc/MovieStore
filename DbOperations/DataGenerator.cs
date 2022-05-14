using System;
using System.Linq;
using MovieStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MovieStoreWebApi.DbOperations
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
                {
                    if(context.Movies.Any())
                        return;
                    context.Genres.AddRange(
                        new Genre()
                        {
                            Name ="Action"
                        },
                        new Genre()
                        {
                            Name ="Dram"
                        },
                        new Genre()
                        {
                            Name ="Comedy"
                        },
                        new Genre()
                         {
                            Name ="Documentary"
                        },
                        new Genre()
                         {
                            Name ="Horror"
                        }
                    );
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Z",
                            SurName = "x",   
                        },
                        new Customer
                        {
                            Name = "Y",
                            SurName = "A",   
                        },
                        new Customer
                        {
                            Name = "H",
                            SurName = "O",   
                        }
                    );
                    context.Directors.AddRange(
                        new Director 
                        {
                            Name = "Emrehan",
                            SurName = "Aydın",
                        },
                        new Director 
                        {
                            Name = "Burak",
                            SurName = "Biçkioğlu",
        
                        },
                        new Director 
                        {
                            Name = "Onur",
                            SurName = "Göz",
                                                   
                        },
                        new Director 
                        {
                            Name = "Halil",
                            SurName = "Tanaç",
                                              
                        });
                    context.DirectorMovies.AddRange(
                        new DirectorMovie
                        {
                            DirectorId=1,
                            MovieId=1
                        },
                        new DirectorMovie
                        {
                            DirectorId=1,
                            MovieId=2
                        },
                        new DirectorMovie
                        {
                            DirectorId=2,
                            MovieId=4
                        },
                        new DirectorMovie
                        {
                            DirectorId=2,
                            MovieId=3
                        }
                    );
                    context.Actors.AddRange(
                        new Actor
                        {
                            Name = "Ali",
                            SurName = "Kemal",
                        },
                        new Actor
                        {
                            Name = "Yamaç",
                            SurName = "Koçavalı:)",
                        },
                        new Actor
                        {
                            Name = "Utku",
                            SurName = "Demir", 
                        },
                        new Actor
                        {
                            Name = "Işıl",
                            SurName = "Ceviz",  
                        }
                    );
                   
                    context.Movies.AddRange(
                        new Movie 
                        {
                            Name = "A",
                            MovieYear = 2020,
                            Price = 15,
                            DirectorId = 1,
                            GenreId = 1,
                        },
                        new Movie 
                        {
                            Name = "B",
                            MovieYear = 2000,
                            Price = 15,
                            DirectorId = 2,
                            GenreId = 3,
                        },
                        new Movie 
                        {
                            Name = "C",
                            MovieYear = 2019,
                            Price = 5,
                            DirectorId = 2,
                            GenreId = 2,
                        },
                        new Movie 
                        {
                            Name = "D",
                            MovieYear = 2021,
                            Price = 70,
                            DirectorId = 4,
                            GenreId = 2,
                        },
                        new Movie 
                        {
                            Name = "E",
                            MovieYear = 2020,
                            Price = 15,
                            DirectorId = 1,
                            GenreId = 1,
                        }
                        );
                        context.MoviesActors.AddRange(
                        new MoviesActor
                        {
                            MovieId = 1,
                            ActorId =1
                        },
                        new MoviesActor
                        {
                            MovieId = 2,
                            ActorId =2
                        }
                    );    
                    context.CustomerMovies.AddRange(
                        new CustomerMovie
                        {
                            CustomerId = 1,
                            MovieId = 1
                        },
                        new CustomerMovie
                        {
                            CustomerId = 1,
                            MovieId = 3
                        },
                        new CustomerMovie
                        {
                            CustomerId = 1,
                            MovieId = 2
                        },
                        new CustomerMovie
                        {
                            CustomerId = 2,
                            MovieId = 1
                        },
                        new CustomerMovie
                        {
                            CustomerId = 2,
                            MovieId = 3
                        });
                    
                    context.Orders.AddRange(
                        new Order
                        {
                            CustomerId = 1,
                            MovieId = 1,
                            TotalPrice = 10,
                            OrderDate = new DateTime(2001,5,21)
                        },
                        new Order
                        {
                            CustomerId = 1,
                            MovieId = 2,
                            TotalPrice = 10,
                            OrderDate = new DateTime(2010,5,20)
                        },
                        new Order
                        {
                            CustomerId = 2,
                            MovieId = 1,
                            TotalPrice = 10,
                            OrderDate = new DateTime(2021,5,20)
                        }
                    );
                    context.CustomerGenres.AddRange(
                        new CustomerGenre
                        {
                            CustomerId=1,
                            GenreId = 2
                        },
                        new CustomerGenre
                        {
                            CustomerId=1,
                            GenreId = 4
                        },
                        new CustomerGenre
                        {
                            CustomerId=2,
                            GenreId = 1
                        },
                        new CustomerGenre
                        {
                            CustomerId=1,
                            GenreId = 3
                        });
                       
                    context.SaveChanges();
                }
        }
    }
}