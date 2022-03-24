using AutoMapper;
using IRepository;
using IRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class ChangeLogRepository : IChangeLogRepository
    {
        private readonly ChangeLogDbContext _changeLogDbContext;

        public ChangeLogRepository( ChangeLogDbContext changeLogDbContext)
        {
            _changeLogDbContext = changeLogDbContext;
        }

        public async Task<List<ReleaseInfo>> GetAllVersionsAsync()
        {
            return await _changeLogDbContext.ReleaseInfo.ToListAsync();
        }
    }
}
