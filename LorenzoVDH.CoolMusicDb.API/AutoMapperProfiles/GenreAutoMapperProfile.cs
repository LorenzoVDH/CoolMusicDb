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
            else if (year >= 1000 && year < 1100)
            {
                return "11th Century";
            }
            else if (year >= 1100 && year < 1200)
            {
                return "12th Century";
            }
            else if (year >= 1200 && year < 1300)
            {
                return "13th Century";
            }
            else if (year >= 1300 && year < 1400)
            {
                return "14th Century";
            }
            else if (year >= 1400 && year < 1500)
            {
                return "15th Century";
            }
            else if (year >= 1500 && year < 1600)
            {
                return "16th Century";
            }
            else if (year >= 1600 && year < 1700)
            {
                return "17th Century";
            }
            else if (year >= 1700 && year < 1800)
            {
                return "18th Century";
            }
            else if (year >= 1800 && year < 1900)
            {
                return "19th Century";
            }
            else if (year >= 1900 && year < 1910)
            {
                return "1900s (early)";
            }
            else if (year >= 1910 && year < 1920)
            {
                return "1910s";
            }
            else if (year >= 1920 && year < 1930)
            {
                return "1920s";
            }
            else if (year >= 1930 && year < 1940)
            {
                return "1930s";
            }
            else if (year >= 1940 && year < 1950)
            {
                return "1940s";
            }
            else if (year >= 1950 && year < 1960)
            {
                return "50s";
            }
            else if (year >= 1960 && year < 1970)
            {
                return "60s";
            }
            else if (year >= 1970 && year < 1980)
            {
                return "70s";
            }
            else if (year >= 1980 && year < 1990)
            {
                return "80s";
            }
            else if (year >= 1990 && year < 2000)
            {
                return "90s";
            }
            else if (year >= 2000 && year < 2010)
            {
                return "00s";
            }
            else if (year >= 2010 && year < 2020)
            {
                return "2010s";
            }
            else if (year >= 2020 && year < 2030)
            {
                return "2020s";
            }
        }

        return null;
    }
}
