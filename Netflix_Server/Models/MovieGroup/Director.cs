namespace Netflix_Server.Models.MovieGroup
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DirectorImage> DirectorImages { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
