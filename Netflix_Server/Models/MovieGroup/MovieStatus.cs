using System.Text.Json.Serialization;

namespace Netflix_Server.Models.MovieGroup
{
    public class MovieStatus
    {

        public int Id { get; set; }

        public int Views { get; set; }
        public int filmId { get; set; }
        [JsonIgnore]
        public virtual Movie? Film { get; set; }



    }
}
