using System;
using System.Collections.Generic;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Order.OrderViews;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreWebApi.Application.OrderOperations.Queries.GetAllQuery
{
    public class GetAllOrderQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GetAllOrderQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<OrderViewModel> Handle()
        {
            var obj = _context.Orders
                .Include(x=>x.Customer)
                .Include(x=>x.Movie);
                
            if(obj is null)
                throw new InvalidOperationException("Hiçbir Kayıt Bulunamadı!");
                
            return _mapper.Map<List<OrderViewModel>>(obj);
        }
    }
}