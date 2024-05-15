namespace Netflix_Server.Models.MovieGroupDto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ImageDto> Images { get; set; }
        public string Description { get; set; }
        public RemarkDto Remark { get; set; }
        public string Key { get; set; }
        public string StarRating { get; set; }
        public RatingDto Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public int Runtime { get; set; }
        public ICollection<ActorDto> Actors { get; set; }
        public DirectorDto Director { get; set; }
        public CompanyDto Company { get; set; }
    }
}
