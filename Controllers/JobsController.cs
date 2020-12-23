using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using contractors.Models;
using contractors.Services;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;

namespace contractors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobService _js;
        private readonly ContractorJobService _cjs;

        public JobsController(JobService js, ContractorJobService cjs)
        {
            _cjs = cjs;
            _js = js;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAll()
        {
            try
            {
                return Ok(_js.GetAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Contractor>> Create([FromBody] Job newJob)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newJob.CreatorId = userInfo.Id;
                Job created = _js.Create(newJob);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{jobId}/contractorjobs")]
        [Authorize]
        public ActionResult<IEnumerable<ContractorJob>> GetContractorsByJob(int jobId)
        {
            try
            {
                return Ok(_cjs.GetContractorsByJob(jobId));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
