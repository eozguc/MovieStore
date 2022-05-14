using MovieStoreWebApi.Application.OrderOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.OrderOperation.Command.AddOrderCommand;
using MovieStoreWebApi.Application.OrderOperation.Command.DeleteOrderCommand;
using MovieStoreWebApi.Application.OrderOperation.Command.UpdateOrderCommand;
using MovieStoreWebApi.Application.OrderOperation.Queries.GetByIdOrderQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Order.OrderCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllOrderQuery getAllOrder = new GetAllOrderQuery(_context,_mapper);
            var result = getAllOrder.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public IActionResult GetByName(int Id)
        {   
            GetByIdOrderQuery getByIdOrder = new GetByIdOrderQuery(_context,_mapper);
            getByIdOrder.Id=Id;
            GetByIdOrderQueryValidator validator = new GetByIdOrderQueryValidator();
            validator.ValidateAndThrow(getByIdOrder);
            var result = getByIdOrder.Handle();
            
            return Ok(result);
        }  
        [HttpPost("/AddNewOrder")] 
        public IActionResult AddNewActor([FromBody] CreateOrderModel newOrder)
        {
            CreateOrderCommand createOrder = new CreateOrderCommand(_context,_mapper);
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            createOrder.createOrderModel = newOrder;
            validator.ValidateAndThrow(createOrder);
            createOrder.Handle();
            return Ok();
        }
        [HttpPut("{Id}")] 
        public IActionResult UpdateOrder(int Id, [FromBody] UpdateOrderModel updatedModel)  
        {
            UpdateOrderCommand updateOrder = new UpdateOrderCommand(_context);
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            updateOrder.Id = Id;
            updateOrder.updatedData = updatedModel;
            validator.ValidateAndThrow(updateOrder);
            updateOrder.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteOrder(int Id)
        {
            DeleteOrderCommand deleteOrderCommand = new DeleteOrderCommand(_context);
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            deleteOrderCommand.Id=Id;
            validator.ValidateAndThrow(deleteOrderCommand);
            deleteOrderCommand.Handle();
            return Ok();
        }       
    }
}