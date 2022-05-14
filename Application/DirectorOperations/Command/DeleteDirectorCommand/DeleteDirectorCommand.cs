using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Application.DirectorOperation.Command.DeleteDirectorCommand
{
    public class DeleteDirectorCommand
    {
        public int Id;
        IMovieStoreDbContext _context;
        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var CheckByDirectorId = _context.Directors.Where(A=>A.Id == Id).FirstOrDefault();
            if(CheckByDirectorId is null)
            {
                throw new InvalidOperationException("Yönetmen Bulunamadı.");
            }
            _context.Directors.Remove(CheckByDirectorId);
            _context.SaveChanges();
            

        }
    }
}