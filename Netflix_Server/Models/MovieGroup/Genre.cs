using System.Text.Json.Serialization;

namespace Netflix_Server.Models.MovieGroup
{
    public class Genre
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movie>? Movie { get; set; }
    }
}
