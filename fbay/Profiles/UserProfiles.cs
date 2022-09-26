using AutoMapper;
using fbay.DTOs.UserDTOs;
using fbay.Models;
using System;

namespace fbay.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<UpdateUserDTO, User>();
            CreateMap<Address, UpdateAddressDTO>();
            CreateMap<UpdateAddressDTO, Address>();
            CreateMap<User, ReadUserDTO>();
            CreateMap<Address, ReadAddressDTO>();
            CreateMap<CreateUserDTO, User>();
        }
    }
}
