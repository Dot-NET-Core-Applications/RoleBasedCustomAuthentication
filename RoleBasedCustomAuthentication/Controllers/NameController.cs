using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RoleBasedCustomAuthentication.Models;

namespace RoleBasedCustomAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        /// <summary>
        /// Custom authentication manager.
        /// </summary>
        private readonly ICustomAuthenticationManager customAuthenticationManager;

        public NameController(ICustomAuthenticationManager customAuthenticationManager)
        {
            this.customAuthenticationManager = customAuthenticationManager;
        }
        // GET: api/Name
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "New Jersey", "New York" };
        }

        // GET: api/Name/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "New Orleans";
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredential credential)
        {
            string customToken = customAuthenticationManager.Authenticate(credential.UserName, credential.Password);
            return string.IsNullOrEmpty(customToken) ? Unauthorized("Unauthorized access") : Ok(customToken);
        }
    }
}
