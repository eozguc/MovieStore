using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.TokenOperations;
using MovieStoreWebApi.TokenOperations.Models;

namespace MovieStoreWebApi.Application.UserOperations.Command.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel model;
        readonly IMovieStoreDbContext _context;
        readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public CreateTokenCommand(IMovieStoreDbContext context,IMapper mapper ,IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password);
            if(user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı Adı veya şifre hatalı");
            }
        }

    }
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}