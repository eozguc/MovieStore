using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Actor.ActorCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.ActorOperation.Command.AddActorCommand
{
    public class CreateActorCommand
    {
        IMapper _mapper;
        IMovieStoreDbContext _context;
        public CreateActorModel Model;
    
        
        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var newActorObj = _mapper.Map<Actor>(Model);
            _context.Actors.Add(newActorObj);
            _context.SaveChanges();

        }
        
        
    }
}