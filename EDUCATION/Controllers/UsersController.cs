using EDUCATION.Models;
using EDUCATION.Models.Users;
using EDUCATION.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUCATION.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost, Route("login")]
        public async Task<LoginResponse> LoginAsync([FromBody] LoginRequest request) =>
            await _usersService.LoginAsync(request);

        //public string Get()
        //{
        //    using (var db = new EFDbContext()) { }
        //        return "Its Work";
        //}
    }
}
