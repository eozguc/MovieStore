using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.MovieOperations.Queries.GetAllQuery
{
    public class GetAllMovieQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetAllMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<MovieViewModel> Handle()
        {
            var obj = _context.Movies
            .Include(x=>x.Genre)
            .Include(x=>x.Director)
            .Include(x=>x.Actors)
                .ThenInclude(x=>x.Actor)
            .OrderBy(x=>x.Name);
            if(obj is null)
                throw new InvalidOperationException("Hiçbir Kayıt Bulunamadı!");
                
            return _mapper.Map<List<MovieViewModel>>(obj);
        }
    }
}