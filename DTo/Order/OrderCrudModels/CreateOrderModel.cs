namespace MovieStoreWebApi.DTo.Order.OrderCrudModels
{
    public class CreateOrderModel
        {
            public int CustomerId { get; set; }
            public int MovieId { get; set; }
            public double TotalPrice { get; set; }

        }

}