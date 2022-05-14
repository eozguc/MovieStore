using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.TokenOperations;
using MovieStoreWebApi.TokenOperations.Models;

namespace MovieStoreWebApi.Application.UserOperations.Command.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        readonly IMovieStoreDbContext _context;
        readonly IConfiguration _configuration;
        public RefreshTokenCommand(IMovieStoreDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x=>x.RefreshToken == this.RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Geçerli zamana ait bir refresh token bulunamadı!");
            }
        }

    }
}