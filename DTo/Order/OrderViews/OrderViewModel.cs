using System;
using MovieStoreWebApi.DTo.Customer.CustomerViews;
using MovieStoreWebApi.DTo.Movie.MovieViews;

namespace MovieStoreWebApi.DTo.Order.OrderViews
 {
    public class OrderViewModel
    {
      public CustomerViewModel Customer { get; set; }
      public MovieTemplateViewModel Movie { get; set; }
      public double TotalPrice { get; set; }
      public DateTime OrderDate { get; set; }
    }
 }