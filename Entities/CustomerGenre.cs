namespace MovieStoreWebApi.Entities
{
    public class CustomerGenre
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}