namespace Netflix_Server.Models.MovieGroup
{
    public class MovieImage
    {
        public int Id { get; set; }
        public int MovieId { get; set; }

        public string Alt { get; set; }
        public string PosterPath { get; set; }
        public Movie? Movie { get; set; }
    }
}
