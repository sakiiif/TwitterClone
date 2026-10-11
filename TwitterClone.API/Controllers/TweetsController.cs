using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos.Tweet;
using TwitterClone.Application.Interfaces;
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
        private readonly ITweetService _tweetService;
        public TweetsController( IConfiguration configuration, ITweetService tweetService )
        {
            _configuration = configuration;
            _tweetService = tweetService;
        }

        // GET /api/Tweets?userId={userId}
        [HttpGet]
        [ProducesResponseType(typeof(List<TweetDto>), StatusCodes.Status200OK)]
        public IActionResult GetTweets([FromQuery] Guid? userId)
        {
            return Ok( _tweetService.GetTweets(userId) );
        }

        // GET /api/Tweets/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTweetByID( [FromRoute] Guid id)
        {
            var tweet = _tweetService.GetTweetById(id);
            if(tweet == null) return NotFound();
            return Ok( tweet );
        }

        // POST /api/Tweets
        [HttpPost]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            var createdTweet = _tweetService.CreateTweet(createTweetDto);

            if (createdTweet == null)
            {
                // Content is already validated by [ApiController], so the only failure left is an unknown user.
                return NotFound($"User '{createTweetDto.UserId}' does not exist.");
            }

            return CreatedAtAction(nameof(GetTweetByID), new { id = createdTweet.Id }, createdTweet);
        }

        // PUT /api/Tweets/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TweetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetDto updateTweetDto)
        {
            var tweet = _tweetService.UpdateTweet(id, updateTweetDto);
            if(tweet == null) return NotFound();
            return Ok(tweet);

        }

        // DELETE /api/Tweets/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTweet( [FromRoute] Guid id)
        {
            var isDeleted = _tweetService.DeleteTweet(id);
            if(isDeleted == false) return NotFound();
            return NoContent();
        }

        [HttpGet("AppName-check")]
        public IActionResult GetAppName()
        {
            var appname = _configuration.GetValue<String>("AppName");

            return Ok(appname);
        }
    }
}
