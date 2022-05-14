using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Director.DirectorCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.AddDirectorCommand
{
    public class CreateDirectorCommand
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public CreateDirectorModel createDirectorModel;

        public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var newDirectorObj = _mapper.Map<Director>(createDirectorModel);
            _context.Directors.Add(newDirectorObj);
            _context.SaveChanges();

        }
        
        
    }
}