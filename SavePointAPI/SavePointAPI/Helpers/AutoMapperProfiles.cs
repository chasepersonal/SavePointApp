using AutoMapper;
using SavePointApp.Dtos;
using SavePointApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavePointApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        // Constructor to initalize a map for user profiles to Dto's
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                // For single member, retrieve propfile photo
                // Will retrieve photo URL, then map it to one within the database
                // Will choose the first or defaulted photo and pull the current photo
                .ForMember(dest => dest.ProfilePhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.ProfilePhotos.FirstOrDefault(p => p.IsCurrent).Url);
                });

            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.ProfilePhotoUrl, opt =>
            {
                opt.MapFrom(src => src.ProfilePhotos.FirstOrDefault(p => p.IsCurrent).Url);
            });

            CreateMap<User, PhotosForDetailedDto>();
        }
    }
}
