using AutoMapper;
using fbayModels.DTOs.AdvertismentDTOs;
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
            CreateMap<Tag, TagDTO>();
            CreateMap<Image, ImageDTO>();
            CreateMap<AddressToTake, AddressToTakeDTO>();
            CreateMap<AddressToTakeDTO, AddressToTake>();    
            CreateMap<Advertisement, ReadAdvertisementDTO>();
            CreateMap<Advertisement, UpdateAdvertisementDTO>();
            CreateMap<UpdateAdvertisementDTO, Advertisement>();
            CreateMap<ReadAdvertisementDTO, Advertisement>();         
        }
    }
}
