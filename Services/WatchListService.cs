using AutoMapper;
using MovieWatchList.DTO;
using MovieWatchList.Models;
using MovieWatchList.RepositoryContracts;
using MovieWatchList.ServiceContracts;

namespace MovieWatchList.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository _watchListRepository;
        private readonly IMapper _mapper;

        public WatchListService(IWatchListRepository watchListRepository, IMapper mapper)
        {
            _watchListRepository = watchListRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddToWatchlist(AddToWatchListDTO watchlistItem)
        {
            var newItem = _mapper.Map<WatchlistItem>(watchlistItem);

            await _watchListRepository.AddItemToWatchList(newItem);

            return true;
        }

        public async Task<bool> DeleteFromWatchList(Guid id)
        {
            var item = await _watchListRepository.GetItemById(id);
            if (item == null)
                return false;

            await _watchListRepository.DeleteItemFromWatchList(item);

            return true;
        }

        public async Task<IEnumerable<WatchListResponse>> GetAllWatchListItems()
        {
            var items = await _watchListRepository.GetAllItems();

            return _mapper.Map<IEnumerable<WatchListResponse>>(items);
        }

        public async Task<bool> MarkAsWatched(Guid id)
        {
            var item = await _watchListRepository.GetItemById(id);

            if (item == null)
                return false;

            item.IsWatched = true;
            item.WatchedDate = DateTime.Now;

            await _watchListRepository.Save();

            return true;
        }
    }
}
