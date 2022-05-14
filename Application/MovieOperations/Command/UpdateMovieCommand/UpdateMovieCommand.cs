using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;

namespace MovieStoreWebApi.Application.MovieOperation.Command.UpdateMovieCommand
{
    public class UpdateMovieCommand
    {
        public UpdateMovieModel updatedData;
        public int Id;
        IMovieStoreDbContext _context;
        
        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var obj =_context.Movies.Where(x=>x.Id==Id).FirstOrDefault();
            if(obj is null)
            {
                throw new InvalidOperationException("Film Bulunamadı!");
            }
                obj.DirectorId = (updatedData.DirectorId == default) ? obj.DirectorId: updatedData.DirectorId;
                obj.GenreId = (updatedData.GenreId == default) ? obj.GenreId: updatedData.GenreId;
                obj.MovieYear = (updatedData.MovieYear == default) ? obj.MovieYear: updatedData.MovieYear;
                obj.Name = (updatedData.Name == "string") ? obj.Name: updatedData.Name;
                obj.Price = (updatedData.Price == default) ? obj.Price: updatedData.Price;
            _context.SaveChanges();
        }

    }
}