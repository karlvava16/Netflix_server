namespace Netflix_Server.Models.MovieGroup
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }

        public virtual ICollection<ActorImage> ActorImages { get; set; }
        public virtual ICollection<CompanyImage> CompanyImages { get; set; }
        public virtual ICollection<DirectorImage> DirectorImages { get; set; }
    }
}
