using IRepository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IChangeLogRepository
    {
        public Task<List<ReleaseInfo>> GetAllVersionsAsync();
    }
}
