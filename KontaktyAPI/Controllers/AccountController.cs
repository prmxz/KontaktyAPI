using KontaktyAPI.Models;
using KontaktyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase                                 //controller managing new Accounts able to login, methods logic in AccountService class
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDTO dto)                 //registering new user
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDTO dto)                               //logging existing user
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
