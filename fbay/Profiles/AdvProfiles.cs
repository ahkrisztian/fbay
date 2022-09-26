﻿using AutoMapper;
using fbay.DTOs;
using fbay.DTOs.AdvertismentDTOs;
using fbay.DTOs.UserDTOs;
using fbay.Models;

namespace fbay.Profiles
{
    public class AdvProfiles : Profile
    {
        public AdvProfiles()
        {
            CreateMap<CreateAdvertisementDTO, Advertisement>();
            CreateMap<TagDTO, Tag>();
            CreateMap<ImageDTO, Image>();
            CreateMap<AddressToTakeDTO, AddressToTake>();    
            CreateMap<Advertisement, ReadAdvertisementDTO>();
            CreateMap<Advertisement, UpdateAdvertisementDTO>();
            CreateMap<UpdateAdvertisementDTO, Advertisement>();
            
        }
    }
}
