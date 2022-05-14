using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Application.MovieOperation.Command.DeleteMovieCommand
{
    public class DeleteMovieCommand
    {
        public int Id;
        IMovieStoreDbContext _context;
        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var CheckByMovieId = _context.Movies.Where(x=>x.Id == Id).FirstOrDefault();
            if(CheckByMovieId is null)
            {
                throw new InvalidOperationException("Film Bulunamadı.");
            }
            _context.Movies.Remove(CheckByMovieId);
            _context.SaveChanges();
            

        }
    }
}