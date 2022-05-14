using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.DeleteCustomerCommand
{
    public class DeleteCustomerCommand
    {
        public int Id;
        IMovieStoreDbContext _context;
        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var CheckByCustomerId = _context.Customers.Where(x=>x.Id == Id).FirstOrDefault();
            if(CheckByCustomerId is null)
            {
                throw new InvalidOperationException("Müşteri Bulunamadı.");
            }
            _context.Customers.Remove(CheckByCustomerId);
            _context.SaveChanges();
            

        }
    }
}