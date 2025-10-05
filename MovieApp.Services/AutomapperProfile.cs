using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieApp.DataContext.Entities;
using MovieApp.DataContext.Dtos;


namespace MovieApp.Services
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>();

           
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Role, opt => opt.Ignore());

           
            CreateMap<LoginDto, User>().ForAllMembers(opt => opt.Ignore());

          
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Genres,
                           opt => opt.MapFrom(src => src.MovieGenres != null
                               ? src.MovieGenres.Select(mg => mg.Genre.Name).ToList()
                               : new System.Collections.Generic.List<string>()));

           
            CreateMap<MovieCreateDto, Movie>()
                .ForMember(dest => dest.MovieGenres,
                           opt => opt.MapFrom(src =>
                               src.GenreIds != null
                                   ? src.GenreIds.Select(id => new MovieGenre { GenreId = id }).ToList()
                                   : new System.Collections.Generic.List<MovieGenre>()))
                .ForMember(dest => dest.AverageRating, opt => opt.Ignore()) // számítás külön
                .ForMember(dest => dest.Id, opt => opt.Ignore());

     
            CreateMap<Genre, GenreDto>().ReverseMap();

        
            CreateMap<Rating, RatingDto>().ReverseMap();

            CreateMap<CreateRatingDto, Rating>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

           
            CreateMap<Favorite, FavoriteDto>()
                .ForMember(dest => dest.MovieTitle,
                           opt => opt.MapFrom(src => src.Movie != null ? src.Movie.Title : string.Empty));

            CreateMap<AddFavoriteDto, Favorite>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore()); // UserId add a controller/service-ben

            
            CreateMap<ViewHistory, ViewHistoryDto>()
                .ForMember(dest => dest.MovieTitle,
                           opt => opt.MapFrom(src => src.Movie != null ? src.Movie.Title : string.Empty));

            CreateMap<ViewHistoryDto, ViewHistory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

           
            
        }
    }
}
