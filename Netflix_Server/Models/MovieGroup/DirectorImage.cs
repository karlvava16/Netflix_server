namespace Netflix_Server.Models.MovieGroup
{
    public class DirectorImage
    {
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }

        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
