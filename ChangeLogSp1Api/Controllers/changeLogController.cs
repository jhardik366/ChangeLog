using IManager;
using IRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeLogSp1Api
{
    [Route("[controller]")]
    [ApiController]
    public class ChangeLogController : ControllerBase
    {
        private readonly IChangeLogManager _changeLogManager;

        public ChangeLogController(IChangeLogManager changeLogManager)
        {
            _changeLogManager = changeLogManager;
        }
        [HttpGet]
        public async Task<List<ReleaseInfoDto>> GetVersions()
        {
            return await _changeLogManager.GetAllVersions();
        }
    }
}
