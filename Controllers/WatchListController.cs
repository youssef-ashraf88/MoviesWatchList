using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWatchList.DTO;
using MovieWatchList.ServiceContracts;

namespace MovieWatchList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListService _watchListService;

        public WatchListController(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(AddToWatchListDTO watchlist)
        {
            await _watchListService.AddToWatchlist(watchlist);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllwatchListItems()
        {
            var watchListItems = await _watchListService.GetAllWatchListItems();

            return Ok(watchListItems);
        }

        [HttpPut("{id}/watched")]
        public async Task<IActionResult> MarkMovieAsWatched(Guid id)
        {
            var item = await _watchListService.MarkAsWatched(id);

            if (!item)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "item not found"
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchListItem(Guid id)
        {
            var item = await _watchListService.DeleteFromWatchList(id);

            if (!item)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "item not found"
                });
            }

            return NoContent();
        }
    }
}
