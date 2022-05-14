using MovieStoreWebApi.Application.UserOperations.Command.CreateToken;
using MovieStoreWebApi.Application.UserOperations.Command.CreateUser;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.TokenOperations.Models;
using MovieStoreWebApi.Application.UserOperations.Command.RefreshToken;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        readonly IConfiguration _configuration;
        public UserController(IMovieStoreDbContext context,IConfiguration configuration , IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand createUser = new CreateUserCommand(_context,_mapper);
            createUser.model = newUser;
            createUser.Handle();

            return Ok();
        }
        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel Login)
        {
            CreateTokenCommand createToken = new CreateTokenCommand(_context,_mapper,_configuration);
            createToken.model = Login;
            var token = createToken.Handle();
            return token;
        }

        [HttpPost("refresh/token")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand refreshToken = new RefreshTokenCommand(_context,_configuration);
            refreshToken.RefreshToken = token;
            var resultToken = refreshToken.Handle();
            return resultToken;
        }
    }
}