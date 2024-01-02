using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs.Genres;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.AutoMapperProfiles;

public class GenreAutoMapperProfile : Profile
{
    public GenreAutoMapperProfile()
    {
        CreateMap<Genre, GenreOverviewDTO>()
            .ForMember(g => g.Decade, opt => opt.MapFrom(src => MapDecade(src.DateOfOrigin)))
            .ForMember(g => g.Children, opt => opt.MapFrom(src => src.SubGenres));
        CreateMap<GenreCreateDTO, Genre>();
        CreateMap<Genre, GenreDetailDTO>();
        CreateMap<GenreUpdateDTO, Genre>().ReverseMap();
        CreateMap<Genre, GenreSimpleDTO>();
    }

    private string? MapDecade(DateOnly? dateOfOrigin)
    {
        if (dateOfOrigin.HasValue)
        {
            int year = dateOfOrigin.Value.Year;

            if (year < 1000)
            {
                return "Pre-Millennium";
            }
            else if (year < 1100)
            {
                return "11th Century";
            }
            else if (year < 1200)
            {
                return "12th Century";
            }
            else if (year < 1300)
            {
                return "13th Century";
            }
            else if (year < 1400)
            {
                return "14th Century";
            }
            else if (year < 1500)
            {
                return "15th Century";
            }
            else if (year < 1600)
            {
                return "16th Century";
            }
            else if (year < 1700)
            {
                return "17th Century";
            }
            else if (year < 1800)
            {
                return "18th Century";
            }
            else if (year < 1900)
            {
                return "19th Century";
            }
            else if (year < 1910)
            {
                return "1900s (early)";
            }
            else if (year < 1920)
            {
                return "1910s";
            }
            else if (year < 1930)
            {
                return "1920s";
            }
            else if (year < 1940)
            {
                return "1930s";
            }
            else if (year < 1950)
            {
                return "1940s";
            }
            else if (year < 1955)
            {
                return "early 50s";
            }
            else if (year < 1960)
            {
                return "mid 50s";
            }
            else if (year < 1965)
            {
                return "early 60s";
            }
            else if (year < 1970)
            {
                return "mid 60s";
            }
            else if (year < 1975)
            {
                return "early 70s";
            }
            else if (year < 1980)
            {
                return "mid 70s";
            }
            else if (year < 1985)
            {
                return "early 80s";
            }
            else if (year < 1990)
            {
                return "mid 80s";
            }
            else if (year < 1995)
            {
                return "early 90s";
            }
            else if (year < 2000)
            {
                return "mid 90s";
            }
            else if (year < 2005)
            {
                return "early 2000s";
            }
            else if (year < 2010)
            {
                return "mid 2000s";
            }
            else if (year < 2015)
            {
                return "early 2010s";
            }
            else if (year < 2020)
            {
                return "mid 2010s";
            }
            else if (year < 2025)
            {
                return "early 2020s";
            }
            else if (year < 2030)
            {
                return "mid 2020s";
            }

        }

        return null;
    }
}
