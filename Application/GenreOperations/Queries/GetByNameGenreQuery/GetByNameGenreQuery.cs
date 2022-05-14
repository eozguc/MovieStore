using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Genre.GenreViews;

namespace MovieStoreWebApi.Application.GenreOperation.Queries.GetByNameGenreQuery
{
    public class GetByNameGenreQuery
    {
        public string Name;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByNameGenreQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public GenreDetailViewModel Handle()
        {
            var obj = _context.Genres
            .FirstOrDefault(x=>x.Name == Name);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir tür Bulunamadı!");
                
            return _mapper.Map<GenreDetailViewModel>(obj);
        }
    }
    
}