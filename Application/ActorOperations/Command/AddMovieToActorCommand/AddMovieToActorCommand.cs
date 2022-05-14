using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.ActorOperation.Command.AddMovieToActorCommand
{
    public class  AddMovieToActorCommand
    {
        readonly IMovieStoreDbContext _context;
        readonly IMapper _mapper;
        public CreateNewMoviesActor newMoviesActorModel;
        public AddMovieToActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var result = _context.MoviesActors.FirstOrDefault(x=>x.ActorId==newMoviesActorModel.ActorId && x.MovieId == newMoviesActorModel.MovieId);
            if (result is not null)
            {
                throw new InvalidOperationException("Zaten Eklemek İstediğiniz Film Mevcut!");
            }
            var CreatedMoviesActor = _mapper.Map<MoviesActor>(newMoviesActorModel);
            _context.MoviesActors.Add(CreatedMoviesActor);
            _context.SaveChanges();
        }
    }
}