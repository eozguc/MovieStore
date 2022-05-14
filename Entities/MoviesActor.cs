using System.ComponentModel.DataAnnotations.Schema;

namespace  MovieStoreWebApi.Entities
{
    public class MoviesActor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }  
         public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}