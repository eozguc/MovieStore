using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Genre.GenreCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.GenreOperation.Command.AddGenreCommand
{
    public class CreateGenreCommand
    {
        IMapper _mapper;
        IMovieStoreDbContext _context;
        public CreateGenreModel createGenreModel;

        public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var newGenreObj = _mapper.Map<Genre>(createGenreModel);
            _context.Genres.Add(newGenreObj);
            _context.SaveChanges();

        }
        
        
    }
}