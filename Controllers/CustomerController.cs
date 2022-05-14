using MovieStoreWebApi.Application.CustomerOperations.Queries.GetAllQuery;
using AutoMapper;
using MovieStoreWebApi.DTo.Customer.CustomerCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.CustomerOperations.Command.AddCustomerCommand;
using MovieStoreWebApi.Application.CustomerOperations.Command.DeleteCustomerCommand;
using MovieStoreWebApi.Application.CustomerOperations.Command.UpdateCustomerCommand;
using MovieStoreWebApi.Application.CustomerOperation.Queries.GetByIdCustomerQuery;
using MovieStoreWebApi.DbOperations;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public CustomerController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllCustomerQuery getAllCustomer = new GetAllCustomerQuery(_context,_mapper);
            var result = getAllCustomer.Handle(); 
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            GetByIdCustomerQuery getByIdCustomer = new GetByIdCustomerQuery(_context,_mapper);
            getByIdCustomer.Id = Id;

            GetByIdCustomerQueryValidator validator = new GetByIdCustomerQueryValidator();
            validator.ValidateAndThrow(getByIdCustomer);
            var result = getByIdCustomer.Handle();
            
            return Ok(result);
        }  
        [HttpPost] 
        public IActionResult AddNewActor([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand createCustomer = new CreateCustomerCommand(_context,_mapper);
            createCustomer.createCustomerModel = newCustomer;
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(createCustomer);
            createCustomer.Handle(newCustomer);
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateActor(int Id, [FromBody] UpdateCustomerModel updatedModel)  
        {
            UpdateCustomerCommand updateCustomer = new UpdateCustomerCommand(_context);
            updateCustomer.Id = Id;
            updateCustomer.updatedData = updatedModel;
            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            updateCustomer.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteActor(int Id)
        {
            DeleteCustomerCommand deleteCustomer = new DeleteCustomerCommand(_context);
            deleteCustomer.Id = Id;
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(deleteCustomer);
            deleteCustomer.Handle();
            return Ok();
        }       
    }
}