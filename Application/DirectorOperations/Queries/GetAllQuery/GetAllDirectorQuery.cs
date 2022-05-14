using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Director.DirectorViews;

namespace MovieStoreWebApi.Application.DirectorOperations.Queries.GetAllQuery
{
    public class GetAllDirectorQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetAllDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DirectorViewModel> Handle()
        {
            var obj = _context.Directors
            .OrderBy(x=>x.Name);
            if(obj is null)
                throw new InvalidOperationException("Hiçbir Kayıt Bulunamadı!");
                
            return _mapper.Map<List<DirectorViewModel>>(obj);
        }
    }
}