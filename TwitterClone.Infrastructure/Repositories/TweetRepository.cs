
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly TwitterCloneDbContext _context;

        public TweetRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Tweet AddTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            _context.SaveChanges();

            return tweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            var existingTweet = _context.Tweets.SingleOrDefault( t => t.Id == tweet.Id);

            if (existingTweet == null)
                return false;

            _context.Tweets.Remove(existingTweet);
            _context.SaveChanges();

            return true;
        }

        public int DeleteTweetsByUserId(Guid userId)
        {
            var tweets = _context.Tweets
                .Where(t => t.UserId == userId)
                .ToList();

            if (tweets.Count == 0) return 0;

            _context.Tweets.RemoveRange(tweets);
            _context.SaveChanges();

            return tweets.Count;
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _context.Tweets.SingleOrDefault( t => t.Id == id);
        }

        public List<Tweet> GetTweets()
        {
            return _context.Tweets.ToList();
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _context.Tweets
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            _context.Tweets.Update(tweet);
            _context.SaveChanges();

            return tweet;
        }
    }
}
