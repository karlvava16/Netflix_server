namespace Netflix_Server.Models.MovieGroup
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CompanyImage> CompanyImages { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
