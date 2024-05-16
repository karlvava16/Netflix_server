using AutoMapper;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Models.MovieGroupDto;

namespace Netflix_Server.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Remark, RemarkDto>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();

            CreateMap<Actor, ActorDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ActorImages.Select(ai => ai.Image)));

            CreateMap<ActorDto, Actor>()
                .ForMember(dest => dest.ActorImages, opt => opt
                .MapFrom(src => src.Images.Select(imageDto => new ActorImage { ActorId = src.Id })));


            CreateMap<Director, DirectorDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.DirectorImages.Select(ai => ai.Image)));

            CreateMap<DirectorDto, Director>()
                .ForMember(dest => dest.DirectorImages, opt => opt
                .MapFrom(src => src.Images.Select(imageDto => new DirectorImage { DirectorId = src.Id })));


            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.CompanyImages.Select(ai => ai.Image)));

            CreateMap<CompanyDto, Company>()
                .ForMember(dest => dest.CompanyImages, opt => opt
                .MapFrom(src => src.Images.Select(imageDto => new CompanyImage { CompanyId = src.Id })));


            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.MovieImages.Select(ai => ai.Image)));

            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.MovieImages, opt => opt
                .MapFrom(src => src.Images.Select(imageDto => new MovieImage { MovieId = src.Id })));
        }
    }
}
