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
    [Route("[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfileService _ps;

        public ProfilesController(ProfileService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Profile>>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
