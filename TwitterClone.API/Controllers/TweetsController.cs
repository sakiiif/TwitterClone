using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public TweetsController( IConfiguration configuration )
        {
            _configuration = configuration;
        }

        // GET /api/Tweets
        [HttpGet]
        public IActionResult GetTweets()
        {
            var maxLength = _configuration.GetValue<int>("TweetSettings:MaxTweetLength");

            var tweets = new List<Tweet>
            {
                new Tweet("tweet 1", Guid.NewGuid()),
                new Tweet("tweet 2", Guid.NewGuid()),
                new Tweet("tweet 3", Guid.NewGuid())
            };
            
            return Ok(
                new
                {
                    maxLength,
                    tweets
                }
            );
        }

        // GET /api/Tweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetTweetByID( [FromRoute] Guid id)
        {
            return Ok
            (
               new
               {
                   TweetId = id,
                   UserId = Guid.NewGuid(),
                   Content = "tweet adasad ",
                   CreatedAt = DateTime.UtcNow
               }
            );
        }

        // POST /api/Tweets
        [HttpPost]
        public IActionResult CreateTweet()
        {
            return Ok
            (
                new
                {
                    TweetId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Content = "tweet content",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        // PATCH /api/Tweets/{id}
        [HttpPatch("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id)
        {
            return Ok
            (
                new
                {
                    TweetId = id,
                    UserId = Guid.NewGuid(),
                    Content = "tweet content updated",
                    ModifiedAt = DateTime.UtcNow
                }
            );
        }

        // DELETE /api/Tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet( [FromRoute] Guid id)
        {
            return Ok
            (
                new
                {
                    TweetId = id,
                    Message = "tweet deleted successfully!"
                }
            );
        }

        [HttpGet("AppName-check")]
        public IActionResult GetAppName()
        {
            var appname = _configuration.GetValue<String>("AppName");

            return Ok(appname);
        }
    }
}
