namespace Netflix_Server.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public string Name { get; set; }
        public Movie? Movie { get; set; }
    }
}
