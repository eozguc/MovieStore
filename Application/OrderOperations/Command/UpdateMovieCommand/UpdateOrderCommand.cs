using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Order.OrderCrudModels;

namespace MovieStoreWebApi.Application.OrderOperation.Command.UpdateOrderCommand
{
    public class UpdateOrderCommand
    {
        public int Id;
        public UpdateOrderModel updatedData;
        IMovieStoreDbContext _context;
        
        public UpdateOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var obj =_context.Orders.Where(x=>x.Id==Id).FirstOrDefault();
            if(obj is null)
            {
                throw new InvalidOperationException("İlgili Sirapiş Bulunamadı!");
            }
                obj.CustomerId = (updatedData.CustomerId == default) ? obj.CustomerId: updatedData.CustomerId;
                obj.MovieId = (updatedData.MovieId == default) ? obj.MovieId: updatedData.MovieId;
                obj.TotalPrice = (updatedData.TotalPrice == default) ? obj.TotalPrice: updatedData.TotalPrice;
                obj.OrderDate = (updatedData.OrderDate == default) ? obj.OrderDate: updatedData.OrderDate;
            _context.SaveChanges();
        }

    }
}