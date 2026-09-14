using Microsoft.EntityFrameworkCore;
using MovieWatchList.Data;
using MovieWatchList.Models;
using MovieWatchList.RepositoryContracts;

namespace MovieWatchList.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {
        private readonly ApplicationDbContext _context;

        public WatchListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemToWatchList(WatchlistItem watchlistItem)
        {
            await _context.AddAsync(watchlistItem);
            await Save();
        }

        public async Task DeleteItemFromWatchList(WatchlistItem watchlistItem)
        {
            _context.WatchlistItems.Remove(watchlistItem);
            await Save();
        }

        public async Task<IEnumerable<WatchlistItem>> GetAllItems()
        {
            var items = await _context.WatchlistItems
                .Include("movies")
                .ToListAsync();

            return items;
        }

        public async Task<WatchlistItem?> GetItemById(Guid id)
        {
            var item = await _context.WatchlistItems
                .FirstOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
