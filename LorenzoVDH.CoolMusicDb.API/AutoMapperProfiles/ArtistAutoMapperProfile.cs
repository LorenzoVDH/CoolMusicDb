﻿using AutoMapper;
using LorenzoVDH.CoolMusicDb.API.DTOs;
using LorenzoVDH.CoolMusicDb.API.DTOs.Artists;
using LorenzoVDH.CoolMusicDb.ApplicationCore.Entities;

namespace LorenzoVDH.CoolMusicDb.API.AutoMapperProfiles
{
    public class ArtistAutoMapperProfile : Profile
    {
        public ArtistAutoMapperProfile()
        {
            CreateMap<Artist, ArtistOverviewDTO>();
            CreateMap<ArtistCreateDTO, Artist>();
            CreateMap<Artist, ArtistSimpleDTO>();
            CreateMap<Artist, ArtistDetailDTO>();
            CreateMap<ArtistUpdateDTO, Artist>();
        }
    }
}
