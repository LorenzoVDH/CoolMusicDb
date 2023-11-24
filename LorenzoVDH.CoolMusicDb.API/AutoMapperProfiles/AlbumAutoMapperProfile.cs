using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.AutoMapperProfiles
{
    public class AlbumAutoMapperProfile : Profile
    {
        public AlbumAutoMapperProfile()
        {
            CreateMap<Album, AlbumOverviewDTO>();
        }
    }
}