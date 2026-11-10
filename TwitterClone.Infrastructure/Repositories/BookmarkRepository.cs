using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {

        //private readonly List<Bookmark> _bookmarks = new List<Bookmark>();
        private readonly TwitterCloneDbContext _context;
        public BookmarkRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            //_bookmarks.Add(bookmark);
            _context.Bookmarks.Add(bookmark);
            _context.SaveChanges();

            return bookmark;
        }

        public bool DeleteBookmark(Bookmark bookmark)
        {
            //return _bookmarks.Remove(bookmark);
            var existingBookmark = _context.Bookmarks.SingleOrDefault( b => b.Id == bookmark.Id);

            if (existingBookmark == null)
                return false;

            _context.Bookmarks.Remove(existingBookmark);
            _context.SaveChanges();
            return true;
        }

        public int DeleteBookmarksByUserId(Guid userId)
        {
            //return _bookmarks.RemoveAll(b => b.UserId == userId);
            var bookmarks = _context.Bookmarks
                .Where(b => b.UserId == userId)
                .ToList();

            if(bookmarks.Count == 0) return 0;

            _context.Bookmarks.RemoveRange(bookmarks);
            _context.SaveChanges();

            return bookmarks.Count;
        }

        public int DeleteBookmarksByTweetId(Guid tweetId)
        {
            // return _bookmarks.RemoveAll(b => b.TweetId == tweetId);
            var bookmarks = _context.Bookmarks
                .Where(b => b.TweetId == tweetId)
                .ToList();

            if (bookmarks.Count == 0) return 0;

            _context.Bookmarks.RemoveRange(bookmarks);
            _context.SaveChanges();

            return bookmarks.Count;
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            //return _bookmarks.SingleOrDefault(b => b.Id == id);
            return _context.Bookmarks.SingleOrDefault(b => b.Id == id);
        }

        public Bookmark? GetBookmarkByUserAndTweet(Guid userId, Guid tweetId)
        {
            //return _bookmarks.FirstOrDefault(b => b.UserId == userId && b.TweetId == tweetId);
            return _context.Bookmarks.FirstOrDefault(b => b.UserId == userId && b.TweetId == tweetId);
        }

        public List<Bookmark> GetBookmarks(Guid? userId)
        {
            /*return _bookmarks
                .Where(b => userId == null || b.UserId == userId)
                .ToList();*/

            return _context.Bookmarks
                .Where(b => userId == null || b.UserId == userId)
                .ToList();
        }
    }
}