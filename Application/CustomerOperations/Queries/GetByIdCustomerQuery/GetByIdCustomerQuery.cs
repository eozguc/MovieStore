using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Customer.CustomerViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.CustomerOperation.Queries.GetByIdCustomerQuery
{
    public class GetByIdCustomerQuery
    {
        public int Id;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByIdCustomerQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public CustomerDetailViewModel Handle()
        {
            var obj = _context.Customers.
            Include(x=>x.CustomerMovies)
                .ThenInclude(m=>m.Movie)
            .Include(c=>c.CustomerGenres)
                .ThenInclude(m=>m.Genre)
            .SingleOrDefault(x=>x.Id == Id);
    
            if(obj is null)
                throw new InvalidOperationException("Belirtilen İsimde Bir Müşteri Bulunamadı!");
                
            return _mapper.Map<CustomerDetailViewModel>(obj);
        }
    }
    
}