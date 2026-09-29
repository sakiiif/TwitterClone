namespace TwitterClone.API.Dtos.Tweet
{
    public class TweetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}
