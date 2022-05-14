using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Application.ActorOperation.Command.DeleteActorCommand
{
    public class DeleteActorCommand
    {
        public int Id;
        IMovieStoreDbContext _context;
        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var CheckByActorId = _context.Actors.Where(x=>x.Id == Id).FirstOrDefault();
            if(CheckByActorId is null)
            {
                throw new InvalidOperationException("Aktör Bulunamadı.");
            }
            _context.Actors.Remove(CheckByActorId);
            _context.SaveChanges();
            

        }
    }
}