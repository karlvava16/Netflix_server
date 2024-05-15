namespace Netflix_Server.Models.MovieGroup
{
    public class ActorImage
    {
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
