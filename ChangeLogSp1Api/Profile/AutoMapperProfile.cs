using AutoMapper;
using IManager;
using IRepository.Models;

namespace ChangeLogSp1Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ReleaseInfoDto, ReleaseInfo>();
            CreateMap<ReleaseInfo, ReleaseInfoDto>();
        }
    }
}
