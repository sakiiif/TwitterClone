using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos.Tweet;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    // api/Tweets
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TweetsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TweetRepository _tweetRepository;
        public TweetsController( IConfiguration configuration, TweetRepository tweetRepository )
        {
            _configuration = configuration;
            _tweetRepository = tweetRepository;
        }

        // GET /api/Tweets
        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = _tweetRepository.GetTweets();
            var tweetsDto = tweets.Select(x =>
                new TweetDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Content = x.Content,
                }
            );
            return Ok(tweetsDto);
        }

        // GET /api/Tweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetTweetByID( [FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if(tweet == null)
            {
                return NotFound();
            }
            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content,
            };
            return Ok(tweetDto);
        }

        // POST /api/Tweets
        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto tweetb)
        {
            if( string.IsNullOrWhiteSpace(tweetb.Content) )
            {
                return BadRequest("Tweet cant be empty!");
            }

            var tweet = new Tweet(tweetb.Content, tweetb.UserId);
            _tweetRepository.AddTweet(tweet);

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };
            return Ok(tweetDto);
        }

        // PUT /api/Tweets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetDto contentb)
        {
            if( string.IsNullOrWhiteSpace(contentb.Content) )
            {
                return BadRequest("Tweet cant be empty!");
            }

            var tweet = _tweetRepository.GetTweetById(id);
            if(tweet == null)
            {
                return NotFound();
            }
            tweet.Content = contentb.Content;
            _tweetRepository.UpdateTweet(tweet);

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };
            return Ok(tweetDto);

        }

        // DELETE /api/Tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet( [FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if( tweet == null )
            {
                return NotFound();
            }
            var isDeleted = _tweetRepository.DeleteTweet(tweet);
            if (isDeleted == true) return Ok(isDeleted);
            else return StatusCode(500, "Something went wrong!");
        }

        [HttpGet("AppName-check")]
        public IActionResult GetAppName()
        {
            var appname = _configuration.GetValue<String>("AppName");

            return Ok(appname);
        }
    }
}
