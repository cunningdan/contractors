using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using contractors.Models;
using contractors.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;

namespace contractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorJobsController : ControllerBase
    {


        private readonly ContractorJobService _cjs;

        public ContractorJobsController(ContractorJobService cjs)
        {
            _cjs = cjs;
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ContractorJob>> Create([FromBody] ContractorJob newCj)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newCj.CreatorId = userInfo.Id;
                return Ok(_cjs.Create(newCj));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}