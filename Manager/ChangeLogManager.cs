using AutoMapper;
using IManager;
using IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager
{
    public class ChangeLogManager : IChangeLogManager
    {
        private readonly IChangeLogRepository _changeLogRepository;
        private readonly IMapper _mapper;

        public ChangeLogManager(IChangeLogRepository changeLogRepository, IMapper mapper)
        {
            _changeLogRepository = changeLogRepository;
            _mapper = mapper;
        }
        public async Task<List<ReleaseInfoDto>> GetAllVersions()
        {
            var versions = await _changeLogRepository.GetAllVersionsAsync();
            List<ReleaseInfoDto> versionFinal = new List<ReleaseInfoDto>();
            foreach ( var version in versions)
            {
                versionFinal.Add(_mapper.Map<ReleaseInfoDto>(version));
            }

            return versionFinal;
        }
    }
}
