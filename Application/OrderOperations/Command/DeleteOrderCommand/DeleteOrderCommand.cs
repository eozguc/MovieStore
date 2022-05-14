using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Application.OrderOperation.Command.DeleteOrderCommand
{
    public class DeleteOrderCommand
    {
        public int Id;
        IMovieStoreDbContext _context;
        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var CheckByOrderId = _context.Orders.Where(x=>x.Id == Id).FirstOrDefault();
            if(CheckByOrderId is null)
            {
                throw new InvalidOperationException("Film Bulunamadı.");
            }
            _context.Orders.Remove(CheckByOrderId);
            _context.SaveChanges();
            

        }
    }
}