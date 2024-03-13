using DistinctWebAPI.Database;
using DistinctWebAPI.Models.Services;
using DistinctWebAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DistinctWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly ILogger<TextController> _logger;
        private readonly IDatabaseService _databaseService;
        private readonly TextDbContext _context;


        public TextController(ILogger<TextController> logger, TextDbContext context, IDatabaseService databaseService)
        {
            _logger = logger;
            _context = context;
            _databaseService = databaseService;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<TextRequest>> ProcessText(TextRequest request)
        {
            try
            {
                var allWords = InputValidator.CleanInput(request.Text);
                var newWords = allWords.Except(_context.UniqueWords.AsNoTracking().Select(dw => dw.Text)).ToList();

                _databaseService.InsertRange(newWords);

                var watchList = await _context.Watchlist
                    .AsNoTracking().Select(w => w.Word).ToListAsync();

                var watchlistMatch = watchList.Intersect(allWords);
                return Ok(new TextResponse
                {
                    DistinctUniqueWords = newWords.Count(),
                    WatchlistWords = watchlistMatch
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing unique words");
                return StatusCode(500, "Internal server error");
            }
        }

        private class TextResponse
        {
            public int DistinctUniqueWords { get; set; }
            public IEnumerable<string> WatchlistWords { get; set; }
        }

        public class TextRequest
        {
            public string Text { get; set; }
        }
    }
}