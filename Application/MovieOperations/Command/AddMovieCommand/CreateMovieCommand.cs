using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.MovieOperation.Command.AddMovieCommand
{
    public class CreateMovieCommand
    {
        IMapper _mapper;
        IMovieStoreDbContext _context;
        public CreateMovieModel createMovieModel;
    

        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var newMovieObj = _mapper.Map<Movie>(createMovieModel);
            var check = _context.Movies.FirstOrDefault(x=>x.Name == newMovieObj.Name && x.MovieYear==newMovieObj.MovieYear);
            if(check is not null)
            {
                throw new InvalidOperationException("Böyle bir film zaten mevcut!");
            }
            _context.Movies.Add(newMovieObj);
            _context.SaveChanges();

        }
        
        
    }
}