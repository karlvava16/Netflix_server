namespace Netflix_Server.Models.MovieGroup
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string? Director {  get; set; }

        public string? Company {  get; set; }
        public bool IsNetflix { get; set; } //Поверка
        public bool IsTop10 { get; set; } //Проверка
        public string? Remark { get; set; }
        public string? Key { get; set; }
        public string? StarRating { get; set; } //Проверка
        public string? Rating { get; set; } // проверка
        public string? Year { get; set; }
        public string? Runtime { get; set; }

        public DateTime? releaseDate { get; set; }

        public string? Description { get; set; }

        public virtual MovieStatus Status { get; set; }



        public virtual ICollection<Genre>? Genres { get; set; }
        public virtual ICollection<MovieImage>? Images { get; set; }
        public  virtual ICollection<Actor>? Actors { get; set; }

        public virtual ICollection<Playback>? Playback { get; set; }

    }
}
