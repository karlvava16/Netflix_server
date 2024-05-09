namespace Netflix_Server.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsNetflix { get; set; }
        public bool IsTop10 { get; set; }
        public bool IsContinueWatch { get; set; }
        public string? Remark { get; set; }
        public string? Key { get; set; }
        public string? StarRating { get; set; }
        public string? Rating { get; set; }
        public string? Year { get; set; }
        public string? Runtime { get; set; }
        public ICollection<Genre>? Genres { get; set; }
        public ICollection<MovieImage>? Images { get; set; }
        public ICollection<Actor>? Actors { get; set; }
        
        public ICollection<Playback>? Playback { get; set; }

    }
}
