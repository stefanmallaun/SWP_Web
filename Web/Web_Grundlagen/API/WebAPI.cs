using Microsoft.AspNetCore.Mvc;
using Web_Grundlagen.Models;
using Web_Grundlagen.DB;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web_Grundlagen.Migrations;

namespace Web_Grundlagen.API
{
 
    [ApiController]
    [Route("api/user/")]
    public class UserApiController : ControllerBase
    {
        private readonly DBManager _dbManager;

        public UserApiController(DBManager dbManager)
        {
            _dbManager = dbManager;
        }

        [HttpGet("ShowAllUser")]
        public async Task<ActionResult<IEnumerable<User>>> ShowAllUser()
        {
            var users = await _dbManager.Users.ToListAsync();
            return users;
        }

        [HttpGet("ShowRegisteredUser")]
        public async Task<ActionResult<IEnumerable<User>>> showRegisteredUser() {

            var users = await _dbManager.Users.Where(users => users.Role == Role.registeredUser).ToListAsync();
            return users;

        }

        [HttpGet("showAdminUsers")]
        public async Task<ActionResult<IEnumerable<User>>> showAdminUsers() {

            var users = await _dbManager.Users.Where(users => users.Role == Role.Admin).ToListAsync();
            return users;

        }

    }

}