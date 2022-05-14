using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MovieId {get;set;}
        public Movie Movie { get; set; }
        public double TotalPrice {get;set;}
        public DateTime OrderDate { get; set; }
    }
    
}