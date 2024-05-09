namespace Netflix_Server.Models.MovieGroup
{
    public class MovieStatus
    {

        public int Id { get; set; }

        public int Views { get; set; }
        public int filmId { get; set; }
        public virtual Movie? Film { get; set; }



    }
}
