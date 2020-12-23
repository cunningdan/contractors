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
    public class ContractorsController : ControllerBase
    {


        private readonly ContractorService _cs;

        public ContractorsController(ContractorService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contractor>> GetAll()
        {
            try
            {
                return Ok(_cs.GetAll());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Contractor>> Create([FromBody] Contractor newContractor)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newContractor.CreatorId = userInfo.Id;
                Contractor created = _cs.Create(newContractor);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
