using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.Tweet;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUserRepository _UserRepository;
        public TweetService(ITweetRepository tweetRepository, IUserRepository userRepository)
        {
            _tweetRepository = tweetRepository; // DI injection
            _UserRepository = userRepository;
        }
        public TweetDto? CreateTweet(CreateTweetDto createTweetDto)
        {
            if( createTweetDto.Content.Length > Tweet.MaxContentLength  )
            {
                return null;
            }

            var user = _UserRepository.GetUserById(createTweetDto.UserId);
            if( user == null ) return null;
            var createdTweet = _tweetRepository.AddTweet( new Tweet(user.Id, createTweetDto.Content ) ); // database

            return createdTweet.ToDto();
        }

        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if( tweet == null ) return false;
            return _tweetRepository.DeleteTweet(tweet);
        }

        public TweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            //if(tweet == null ) return null;
            return tweet?.ToDto();
        }

        public List<TweetDto> GetTweets(Guid? userId)
        {
            var tweets = userId.HasValue ? 
                _tweetRepository.GetTweetsByUserId(userId.Value) : // if userId exists get this users tweet
                _tweetRepository.GetTweets(); // else get all tweets

            return tweets
                .OrderByDescending(t => t.CreatedAt) // newest first
                .Select(t => t.ToDto())
                .ToList();
        }

        public TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto)
        {
            if (updateTweetDto.Content.Length > Tweet.MaxContentLength)
            {
                return null;
            }

            var tweet = _tweetRepository.GetTweetById(id);
            if(tweet == null) return null;

            tweet.Content = updateTweetDto.Content;
            tweet.ModifyAt();

            tweet = _tweetRepository.UpdateTweet(tweet);

            return tweet.ToDto();
        }
    }
}
