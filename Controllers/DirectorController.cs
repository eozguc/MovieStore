using MovieStoreWebApi.Application.DirectorOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.DirectorOperation.Command.AddDirectorCommand;
using MovieStoreWebApi.Application.DirectorOperation.Command.DeleteDirectorCommand;
using MovieStoreWebApi.Application.DirectorOperation.Command.UpdateDirectorCommand;
using MovieStoreWebApi.Application.DirectorOperation.Queries.GetByNameDirectorQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Director.DirectorCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController:ControllerBase
    {
         private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;

        public IMovieStoreDbContext Context => _context;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllDirectorQuery getAllDirector = new GetAllDirectorQuery(Context,_mapper);
            var result = getAllDirector.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name},{surname}")]
        public IActionResult GetByName(string name,string surname)
        {
            
            GetByNameDirectorQuery getByNameDirector = new GetByNameDirectorQuery(Context,_mapper);
            GetByNameDirectorQueryValidator validator = new GetByNameDirectorQueryValidator();
            getByNameDirector.Name = name;
            getByNameDirector.SurName = surname;
            //var result = query.Handle(name);
            var result = getByNameDirector.Handle();
            
            return Ok(result);
        }  
        [HttpPost] 
        public IActionResult AddNewDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand createDirector = new CreateDirectorCommand(Context,_mapper);
            createDirector.createDirectorModel = newDirector;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(createDirector);
            createDirector.Handle();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateDirector(int Id, [FromBody] UpdateDirectorModel updatedModel)  
        {
            UpdateDirectorCommand updateDirector = new UpdateDirectorCommand(Context);
            updateDirector.Id = Id;
            updateDirector.updatedModel = updatedModel;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            updateDirector.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteDirector(int Id)
        {
            DeleteDirectorCommand deleteDirector = new DeleteDirectorCommand(Context);
            deleteDirector.Id = Id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(deleteDirector);
            deleteDirector.Handle();
            return Ok();
        }       
    }
}