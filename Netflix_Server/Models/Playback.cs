namespace Netflix_Server.Models
{
    public class Playback
    {
        public int Id { get; set; }
        public int QualityLevel { get; set; }

        public string Path { get; set; }

        public virtual Movie Movie { get; set; }

    }
}
