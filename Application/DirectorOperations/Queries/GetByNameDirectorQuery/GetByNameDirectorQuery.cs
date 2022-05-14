using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Director.DirectorViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.DirectorOperation.Queries.GetByNameDirectorQuery
{
    public class GetByNameDirectorQuery
    {
        public string Name;
        public string SurName;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByNameDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public DirectorDetailViewModel Handle()
        {
            var obj = _context.Directors.Include(x=>x.DiretoredMovies)
                .ThenInclude(x=>x.Movie)
                    .FirstOrDefault(x=>x.Name == Name);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir tür Bulunamadı!");
                
            return _mapper.Map<DirectorDetailViewModel>(obj);
        }
    }
    
}