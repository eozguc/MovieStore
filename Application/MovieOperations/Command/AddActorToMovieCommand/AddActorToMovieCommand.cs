using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.MovieOperation.Command.AddActorToMovie
{
    public class  AddActorToMovieCommand
    {
        public CreateNewMoviesActor newMoviesActor;
        readonly IMovieStoreDbContext _context;
        readonly IMapper _mapper;
        public AddActorToMovieCommand(IMovieStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
           var result = _context.MoviesActors.FirstOrDefault(x=>x.ActorId==newMoviesActor.ActorId && x.MovieId == newMoviesActor.MovieId);
            if (result is not null)
            {
                throw new InvalidOperationException("Zaten Eklemek İstediğiniz Film Mevcut!");
            }
            var CreatedMoviesActor = _mapper.Map<MoviesActor>(newMoviesActor);
            _context.MoviesActors.Add(CreatedMoviesActor);
            _context.SaveChanges();
        }
    }
}