using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.AutoMapperProfiles
{
    public class ArtistAutoMapperProfile : Profile
    {
        public ArtistAutoMapperProfile()
        {
            CreateMap<Artist, ArtistOverviewDTO>();
            CreateMap<ArtistCreateDTO, Artist>(); 
        }
    }
}
