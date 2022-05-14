using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Actor.ActorViews;

namespace MovieStoreWebApi.Application.ActorOperations.Queries.GetAllQuery
{
    public class GetAllActorQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetAllActorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorViewModel> Handle()
        {
            var obj = _context.Actors
            .OrderBy(x=>x.Name);
            if(obj is null)
                throw new InvalidOperationException("Hiçbir Kayıt Bulunamadı!");
                
            return _mapper.Map<List<ActorViewModel>>(obj);
        }
    }
}