using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfiles:Profile
    {
        public PlatformProfiles()
        {
            CreateMap<Platform, PlatformReadDto>().ReverseMap();
            CreateMap<Platform, PlatformCreateDto>().ReverseMap();
        }
    }
}
