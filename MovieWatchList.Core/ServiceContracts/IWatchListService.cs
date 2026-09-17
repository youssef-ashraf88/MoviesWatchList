using MovieWatchList.DTO;
using MovieWatchList.Models;

namespace MovieWatchList.ServiceContracts
{
    public interface IWatchListService
    {
        Task<bool> AddToWatchlist(AddToWatchListDTO watchlistItem);

        Task<IEnumerable<WatchListResponse>> GetAllWatchListItems();

        Task<bool> DeleteFromWatchList(Guid id);

        Task<bool> MarkAsWatched(Guid id);
    }
}
