namespace Netflix_Server.Models.MovieGroup
{
    public class ActorImage
    {

        public int Id { get; set; }
        public int ActorId { get; set; }

        public string Alt { get; set; }
        public string PosterPath { get; set; }
        public Actor? Actor { get; set; }

    }
}
