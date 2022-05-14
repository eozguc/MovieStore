using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.UserOperations.Command.CreateUser
{
    public class CreateUserCommand
    {     
        public CreateUserModel model;
        readonly IMovieStoreDbContext _context;
        readonly IMapper _mapper;
        public CreateUserCommand(IMovieStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x=>x.Email == model.Email);
            if (user is not null)
            {
                throw new InvalidOperationException("Bu kullanıcı zaten mevcut");
            }
            var CreatedUser = _mapper.Map<User>(model);
            _context.Users.Add(CreatedUser);
            _context.SaveChanges();
        }        
    }
    public class CreateUserModel
        {
            public string Name { get; set; }
            public string SurName {get;set;}
            public string Email { get; set; }  
            public string Password { get; set; }
        }
}