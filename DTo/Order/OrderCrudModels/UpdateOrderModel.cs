using System;
namespace MovieStoreWebApi.DTo.Order.OrderCrudModels
{
    public class UpdateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    
    }
}