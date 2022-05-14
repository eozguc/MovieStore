using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Genre.GenreViews;

namespace MovieStoreWebApi.Application.GenreOperations.Queries.GetAllQuery
{
    public class GetAllGenreQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetAllGenreQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenreViewModel> Handle()
        {
            var obj = _context.Genres
            .OrderBy(x=>x.Name);
            if(obj is null)
                throw new InvalidOperationException("Hiçbir Kayıt Bulunamadı!");
                
            return _mapper.Map<List<GenreViewModel>>(obj);
        }
    }
}