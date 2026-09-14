using MovieWatchList.Models;

namespace MovieWatchList.RepositoryContracts
{
    public interface IWatchListRepository
    {
        Task AddItemToWatchList(WatchlistItem watchlistItem);

        Task DeleteItemFromWatchList(WatchlistItem watchlistItem);

        Task<IEnumerable<WatchlistItem>> GetAllItems();

        Task<WatchlistItem?> GetItemById(Guid id);

        Task Save();
    }
}
