namespace Netflix_Server.Models.MovieGroup
{
    public class CompanyImage
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
