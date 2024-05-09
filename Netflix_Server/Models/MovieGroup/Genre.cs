namespace Netflix_Server.Models.MovieGroup
{
    public class Genre
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public string Name { get; set; }
        public ICollection<Movie>? Movie { get; set; }
    }
}
