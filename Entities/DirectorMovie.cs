using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class DirectorMovie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}