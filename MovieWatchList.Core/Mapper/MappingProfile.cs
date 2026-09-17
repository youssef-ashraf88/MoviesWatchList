using AutoMapper;
using MovieWatchList.DTO;
using MovieWatchList.Models;

namespace MovieWatchList.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieResponseDTO>();

            CreateMap<AddMovieDTO, Movie>();

            CreateMap<EditMovieDTO, Movie>();



            CreateMap<AddToWatchListDTO, WatchlistItem>();

            CreateMap<WatchlistItem, WatchListResponse>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.movies!.Title))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.movies!.Genre))
                .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.movies!.ReleaseYear))
                .ForMember(dest => dest.DurationMinutes, opt => opt.MapFrom(src => src.movies!.DurationMinutes))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.movies!.Rating));
        }
    }
}
