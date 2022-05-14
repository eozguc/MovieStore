using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Actor.ActorCrudModels;

namespace MovieStoreWebApi.Application.ActorOperation.Command.UpdateActorCommand
{
    public class UpdateActorCommand
    {
        IMovieStoreDbContext _context;
        public int Id;
        public UpdateActorModel updatedData;
        
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var obj =_context.Actors.Where(x=>x.Id==Id).FirstOrDefault();
            if(obj is null)
            {
                throw new InvalidOperationException("Film Bulunamadı!");
            }
                obj.Name = (updatedData.Name == default) ? obj.Name: updatedData.Name;
                obj.SurName= (updatedData.SurName == default) ? obj.SurName: updatedData.SurName;
            _context.SaveChanges();
        }

    }
}