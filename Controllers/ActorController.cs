using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Actor.ActorCrudModels;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.ActorOperation.Command.AddActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Command.AddMovieToActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Command.DeleteActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Command.UpdateActorCommand;
using MovieStoreWebApi.Application.ActorOperation.Queries.GetByNameActorQuery;
using MovieStoreWebApi.Application.ActorOperations.Queries.GetAllQuery;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ActorController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllActorQuery getAllActor = new GetAllActorQuery(_context,_mapper);
            var result = getAllActor.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name},{surname}")]
        public IActionResult GetByName(string name,string surname)
        {
            
            GetByNameActorQuery getByNameActor = new GetByNameActorQuery(_context,_mapper);
            getByNameActor.Name = name;
            getByNameActor.SurName=surname;
            GetByNameActorQueryValidator validator = new GetByNameActorQueryValidator();
            validator.ValidateAndThrow(getByNameActor);
            var result = getByNameActor.Handle();
            
            return Ok(result);
        }  
        [HttpPost("/AddNewActor")] 
        public IActionResult AddNewActor([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand createActor = new CreateActorCommand(_context,_mapper);
            createActor.Model = newActor;

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(createActor);

            createActor.Handle();

            return Ok();
        }
        [HttpPost("/AddMovieToActor")] 
        public IActionResult AddNewMovieToActor([FromBody] CreateNewMoviesActor newMovieToActor)
        {
            AddMovieToActorCommand addMovie = new AddMovieToActorCommand(_context,_mapper);
            addMovie.newMoviesActorModel = newMovieToActor;
            AddMovieToActorCommandValidator addMovieToActor = new AddMovieToActorCommandValidator();

            addMovieToActor.ValidateAndThrow(addMovie);
            addMovie.Handle();

            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateActor(int Id, [FromBody] UpdateActorModel updatedModel)  
        {
            UpdateActorCommand updateActor = new UpdateActorCommand(_context);
            updateActor.Id = Id;
            updateActor.updatedData = updatedModel;
            UpdateActorCommandValidator updateActorCommand = new UpdateActorCommandValidator();
            updateActorCommand.ValidateAndThrow(updateActor);
            updateActor.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteActor(int Id)
        {
            DeleteActorCommand deleteActor = new DeleteActorCommand(_context);
            deleteActor.Id = Id;
            DeleteActorCommandValdiator deleteActorValdiator = new DeleteActorCommandValdiator();
            deleteActorValdiator.ValidateAndThrow(deleteActor);
            deleteActor.Handle();
            return Ok();
        }       
    }
}