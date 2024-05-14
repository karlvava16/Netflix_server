
using System.Text.Json.Serialization;

namespace Netflix_Server.Models.MovieGroup
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ActorImage ? Images { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movie>? Movies { get; set; }



    }
}
