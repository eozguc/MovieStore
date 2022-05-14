using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Customer.CustomerCrudModels;

namespace MovieStoreWebApi.Application.CustomerOperations.Command.UpdateCustomerCommand
{
    public class UpdateCustomerCommand
    {
        IMovieStoreDbContext _context;
        public int Id;
        public UpdateCustomerModel updatedData;
        
        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var obj =_context.Customers.Where(x=>x.Id==Id).FirstOrDefault();
            if(obj is null)
            {
                throw new InvalidOperationException("Film Bulunamadı!");
            }
                obj.Name = (updatedData.Name == default) ? obj.Name: updatedData.Name;
                obj.SurName = (updatedData.SurName == default) ? obj.SurName: updatedData.SurName;
            _context.SaveChanges();
        }

    }
}