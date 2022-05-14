using MovieStoreWebApi.Application.GenreOperations.Queries.GetAllQuery;
using MovieStoreWebApi.Application.GenreOperation.Command.AddGenreCommand;
using MovieStoreWebApi.Application.GenreOperation.Command.DeleteGenreCommand;
using MovieStoreWebApi.Application.GenreOperation.Command.UpdateGenreCommand;
using MovieStoreWebApi.Application.GenreOperation.Queries.GetByNameGenreQuery;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Genre.GenreCrudModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class GenreController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _context;
        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllGenreQuery getAllGenre = new GetAllGenreQuery(_context,_mapper);
            var result = getAllGenre.Handle(); 
           
            return Ok(result);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            
            GetByNameGenreQuery getByNameGenre = new GetByNameGenreQuery(_context,_mapper);
            getByNameGenre.Name = name;
            GetByNameGenreQueryValidator validator = new GetByNameGenreQueryValidator();
            validator.ValidateAndThrow(getByNameGenre);
            //var result = query.Handle(name);
            var result = getByNameGenre.Handle();
            
            return Ok(result);
        }  
        [HttpPost] 
        public IActionResult AddNewGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand createGenre = new CreateGenreCommand(_context,_mapper);
            createGenre.createGenreModel = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(createGenre);
            createGenre.Handle();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateGenre(int Id, [FromBody] UpdateGenreModel updatedModel)  
        {
            UpdateGenreCommand updateGenre = new UpdateGenreCommand(_context);
            updateGenre.Id = Id;
            updateGenre.updatedData = updatedModel;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(updateGenre);
            updateGenre.Handle();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteGenre(int Id)
        {
            DeleteGenreCommand deleteGenre = new DeleteGenreCommand(_context);
            deleteGenre.Id = Id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(deleteGenre);
            deleteGenre.Handle();
            return Ok();
        }
    }
}