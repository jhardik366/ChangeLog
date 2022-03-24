using IRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IManager
{
    public interface IChangeLogManager
    {
        public Task<List<ReleaseInfoDto>> GetAllVersions();
    }
}
