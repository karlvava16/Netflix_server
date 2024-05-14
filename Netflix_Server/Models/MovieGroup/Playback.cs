using System.Text.Json.Serialization;

namespace Netflix_Server.Models.MovieGroup
{
    public class Playback
    {
        public int Id { get; set; }
        public int QualityLevel { get; set; }

        public string Path { get; set; }
        [JsonIgnore]
        public virtual Movie Movie { get; set; }

    }
}
