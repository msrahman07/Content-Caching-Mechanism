using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IDatabase _cacheDb;


        public NewsController(DataContext context, IConnectionMultiplexer redis)
        {
            _context = context;
            _cacheDb = redis.GetDatabase();
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            if (_context.News == null)
            {
                return NotFound();
            }
            return await _context.News.ToListAsync();
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            if (_context.News == null)
            {
                return NotFound();
            }
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            // Increment the access count in the Redis Sorted Set
            await IncrementNewsAccessCountAsync(news);

            await AddToRecentlyViewedSetAsync(news);

            return news;
        }

        // GET: api/News/recentlyviewed
        [HttpGet("recentlyviewed")]
        public async Task<ActionResult<IEnumerable<News>>> GetRecentlyViewedNews()
        {
            // Get the list of recently viewed news JSON from the Redis set
            var recentlyViewedNewsJson = await _cacheDb.SortedSetRangeByRankAsync("recently_viewed_news", 0, -1, Order.Descending);

            // Convert the JSON strings back to News objects
            var recentlyViewedNews = recentlyViewedNewsJson.Select(newsJson => JsonConvert.DeserializeObject<News>(newsJson)).ToList();

            return Ok(recentlyViewedNews);
        }

        // GET: api/news/popular
        [HttpGet("popular")]
        public async Task<ActionResult<IEnumerable<News>>> GetPopularNews()
        {
            // Get the top 5 popular news articles based on access count
            var popularNewsJson = await _cacheDb.SortedSetRangeByRankAsync("popular_news", 0, 4, Order.Descending);

            // Convert the JSON strings back to News objects
            var popularNews = popularNewsJson.Select(newsJson => JsonConvert.DeserializeObject<News>(newsJson)).ToList();

            return Ok(popularNews);
        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(int id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'DataContext.News'  is null.");
            }
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.Id }, news);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            if (_context.News == null)
            {
                return NotFound();
            }
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsExists(int id)
        {
            return (_context.News?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task AddToRecentlyViewedSetAsync(News news)
        {
            // Convert the news object to a JSON string for storage
            var newsJson = JsonConvert.SerializeObject(news);

            // Add the news JSON to the Redis set
            await _cacheDb.SortedSetAddAsync("recently_viewed_news", newsJson, DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            // Trim the set to keep only the latest 5 viewed news articles
            await _cacheDb.SortedSetRemoveRangeByRankAsync("recently_viewed_news", 0, -6);
        }

        private async Task IncrementNewsAccessCountAsync(News news)
        {
            // Convert the news object to a JSON string for storage
            var newsJson = JsonConvert.SerializeObject(news);

            // Increment the access count in the Redis Sorted Set
            await _cacheDb.SortedSetIncrementAsync("popular_news", newsJson, 1);
        }
    }
}
