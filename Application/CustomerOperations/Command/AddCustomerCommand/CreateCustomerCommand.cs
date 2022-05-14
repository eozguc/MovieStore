using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Customer.CustomerCrudModels;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.AddCustomerCommand
{
    public class CreateCustomerCommand
    {
        IMapper _mapper;
        IMovieStoreDbContext _context;
        public CreateCustomerModel createCustomerModel;
    

        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(CreateCustomerModel createCustomerModel)
        {
            var newCustomerObj = _mapper.Map<Customer>(createCustomerModel);
            _context.Customers.Add(newCustomerObj);
            _context.SaveChanges();

        }
        
        
    }
}