using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Order.OrderViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.OrderOperation.Queries.GetByIdOrderQuery
{
    public class GetByIdOrderQuery
    {
        public int Id;
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetByIdOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public OrderDetailViewModel Handle()
        {
            var obj = _context.Orders
                .Include(c=>c.Customer)
                .Include(m=>m.Movie)
                .FirstOrDefault(x=>x.Id==Id);
    
            if(obj is null)
                throw new InvalidOperationException("Sipariş Bulunamadı!");
                
            return _mapper.Map<OrderDetailViewModel>(obj);
        }
    }
    
}