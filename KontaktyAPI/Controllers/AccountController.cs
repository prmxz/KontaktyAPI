using KontaktyAPI.Models;
using KontaktyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Controllers
{
    /// <summary>
    /// controller managing new Accounts able to login, methods logic in AccountService class
    /// </summary>
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase                                
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Registering new user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDTO dto)                 
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        /// <summary>
        /// logging existing user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDTO dto)                               
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
