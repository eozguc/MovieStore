using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.MovieOperation.Queries.GetByNameMovieQuery
{
    public class GetByNameMovieQuery
    {
        public string Name;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByNameMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public MovieDetailViewModel Handle()
        {
            var obj = _context.Movies
            .Include(x=>x.Director)
            .Include(x=>x.Genre)
            .Include(x=>x.Actors)
                .ThenInclude(x=>x.Actor)
            .FirstOrDefault(x=>x.Name == Name);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir Film Bulunamadı!");
                
            return _mapper.Map<MovieDetailViewModel>(obj);
        }
    }
    
}