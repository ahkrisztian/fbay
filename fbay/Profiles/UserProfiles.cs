using AutoMapper;
using fbay.DTOs;
using fbay.Models;
using System;

namespace fbay.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<Address, UpdateAddressDTO>();
            CreateMap<UpdateAddressDTO, Address>();
            CreateMap<User, ReadUserDTO>();
            CreateMap<Address, ReadAddressDTO>();
        }
    }
}
