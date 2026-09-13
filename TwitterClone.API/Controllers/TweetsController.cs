using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TweetsController( IConfiguration configuration )
        {
            _configuration = configuration;
        }

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

        [HttpGet("AppName-check")]
        public IActionResult GetAppName()
        {
            var appname = _configuration.GetValue<String>("AppName");

            return Ok(appname);
        }
    }
}
