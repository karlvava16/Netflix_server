namespace Netflix_Server.Models.MovieGroupDto
{
    public class FilterMovieDto
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        // если GenreIds содержин null либо пустой, значит все жанры
        public ICollection<int>? GenreIds { get; set; }
        // если пустая строка, значит нету подстроки
        public string? SearchSubstring { get; set; }
    }
}
