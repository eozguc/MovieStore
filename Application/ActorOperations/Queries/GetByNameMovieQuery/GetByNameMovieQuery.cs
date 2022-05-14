using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Actor.ActorViews;

namespace MovieStoreWebApi.Application.ActorOperation.Queries.GetByNameActorQuery
{
    public class GetByNameActorQuery
    {
        public string Name;
        public string SurName;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByNameActorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public ActorDetailViewModel Handle()
        {
            var obj = _context.Actors
            .FirstOrDefault(x=>x.Name == Name);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir Aktör Bulunamadı!");
                
            return _mapper.Map<ActorDetailViewModel>(obj);
        }
    }
    
}