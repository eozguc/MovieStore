using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Genre.GenreCrudModels;

namespace MovieStoreWebApi.Application.GenreOperation.Command.UpdateGenreCommand
{
    public class UpdateGenreCommand
    {
        IMovieStoreDbContext _context;
        public UpdateGenreModel updatedData;
        public int Id;

        
        public UpdateGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var obj =_context.Genres.Where(x=>x.Id==Id).FirstOrDefault();
            if(obj is null)
            {
                throw new InvalidOperationException("Film Bulunamadı!");
            }
                obj.Name = (updatedData.Name == default) ? obj.Name: updatedData.Name;
            _context.SaveChanges();
        }

    }
}