using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Application.GenreOperation.Command.DeleteGenreCommand
{
    public class DeleteGenreCommand
    {
        public int Id;
        IMovieStoreDbContext _context;
        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var CheckByGenreId = _context.Genres.Where(x=>x.Id == Id).FirstOrDefault();
            if(CheckByGenreId is null)
            {
                throw new InvalidOperationException("Film Türü Bulunamadı.");
            }
            _context.Genres.Remove(CheckByGenreId);
            _context.SaveChanges();
            

        }
    }
}