namespace MovieStoreWebApi.Entities
{
    public class CustomerMovie
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }   
}