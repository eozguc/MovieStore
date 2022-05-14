using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Customer.CustomerViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.CustomerOperations.Queries.GetAllQuery
{
    public class GetAllCustomerQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetAllCustomerQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CustomerViewModel> Handle()
        {
            var obj = _context.Customers
            .Include(x=>x.CustomerMovies)
                .ThenInclude(m=>m.Movie)
            .Include(c=>c.CustomerGenres)
                .ThenInclude(m=>m.Genre)
            .OrderBy(m=>m.Id);
            if(obj is null)
                throw new InvalidOperationException("Hiçbir Kayıt Bulunamadı!");
                
            return _mapper.Map<List<CustomerViewModel>>(obj);
        }
    }
}