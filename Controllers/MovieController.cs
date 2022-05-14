using MovieStoreWebApi.Application.MovieOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.MovieOperation.Command.AddActorToMovie;
using MovieStoreWebApi.Application.MovieOperation.Command.AddMovieCommand;
using MovieStoreWebApi.Application.MovieOperation.Command.DeleteMovieCommand;
using MovieStoreWebApi.Application.MovieOperation.Command.UpdateMovieCommand;
using MovieStoreWebApi.Application.MovieOperation.Queries.GetByNameMovieQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllMovieQuery getAllMovie = new GetAllMovieQuery(_context,_mapper);
            var result = getAllMovie.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            GetByNameMovieQuery getByName = new GetByNameMovieQuery(_context,_mapper);
            getByName.Name = name;

            var result = getByName.Handle();
            return Ok(result);
        }
        [HttpPost("/AddNewActorToMovie")] 
        public IActionResult AddNewActorToMovie([FromBody] CreateNewMoviesActor newMovieToActor)
        {
            AddActorToMovieCommand addActorTo = new AddActorToMovieCommand(_context,_mapper);
            addActorTo.newMoviesActor = newMovieToActor;

            addActorTo.Handle();
            return Ok();
        }  
        [HttpPost("/AddNeMovie")] 
        public IActionResult AddNewMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand createMovie = new CreateMovieCommand(_context,_mapper);
            createMovie.createMovieModel=newMovie;

            createMovie.Handle();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateMovie(int Id, [FromBody] UpdateMovieModel updatedModel)  
        {
            UpdateMovieCommand updateMovie = new UpdateMovieCommand(_context);
            updateMovie.Id = Id;
            updateMovie.updatedData = updatedModel;
            updateMovie.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteMovie(int Id)
        {
            DeleteMovieCommand deleteMovie = new DeleteMovieCommand(_context);
            deleteMovie.Id = Id;
            deleteMovie.Handle();
            return Ok();
        }
    }

    
}