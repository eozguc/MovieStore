using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Director.DirectorCrudModels;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.UpdateDirectorCommand
{
    public class UpdateDirectorCommand
    {
        public int Id;
        public UpdateDirectorModel updatedModel;
        IMovieStoreDbContext _context;
        
        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var obj =_context.Directors.Where(x=>x.Id==Id).FirstOrDefault();
            if(obj is null)
            {
                throw new InvalidOperationException("Yönetmen Bulunamadı!");
            }
                obj.Name = (updatedModel.Name == default) ? obj.Name: updatedModel.Name;
                obj.Name = (updatedModel.SurName == default) ? obj.SurName: updatedModel.SurName;
            _context.SaveChanges();
        }

    }
}