using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs.Genres;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.AutoMapperProfiles;

public class GenreAutoMapperProfile : Profile
{
    public GenreAutoMapperProfile()
    {
        CreateMap<Genre, GenreOverviewDTO>();
        CreateMap<GenreCreateDTO, Genre>();
        CreateMap<Genre, GenreDetailDTO>();
        CreateMap<GenreUpdateDTO, Genre>().ReverseMap();
    }
}
