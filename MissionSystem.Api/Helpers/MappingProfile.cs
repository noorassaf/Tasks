using MissionSystem.Core.Models;
using AutoMapper;
using System.Reflection;
using MissionSystem.Core.DTO;
using MissionSystem.Core.Models.Project;
using MissionSystem.Core.Dto;

namespace MissionSystem.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Missing, MissionDto>().ForMember(src => src.Poster, opt => opt.Ignore());
            CreateMap<Mission, MissionDetailDto>().ForMember(src => src.Poster, opt => opt.Ignore());
           
            CreateMap<MissionDto, Mission>().ForMember(src => src.Poster, opt => opt.Ignore());
            CreateMap<TypeMission,TypeMissionDetailsDto>();
            CreateMap<ApplicationUser,UserDetailsDto>();

            CreateMap<UserMission, UMDetailsDto>()
                .ForMember(dest => dest.MissionId, opt => opt.MapFrom(src => src.MissionId))
                .ForMember(dest => dest.MissionName, opt => opt.MapFrom(src => src.Mission.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.MissionPoint, opt => opt.MapFrom(src => src.Mission.Point))
                .ForMember(dest => dest.Complet, opt => opt.MapFrom(src => src.Complet));
            
        }
    }
}