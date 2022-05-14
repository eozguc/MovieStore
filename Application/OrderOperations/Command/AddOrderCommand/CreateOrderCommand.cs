using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Order.OrderCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.OrderOperation.Command.AddOrderCommand
{

    public class CreateOrderCommand
    {
        IMapper _mapper;
        IMovieStoreDbContext _context;
        
        public CreateOrderModel createOrderModel;
        

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var newOrderObj = _mapper.Map<Order>(createOrderModel);
            _context.Orders.Add(newOrderObj);
            _context.SaveChanges();

        }
        
        
    }
}