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
        [HttpGet("GetRoles")]
        public ActionResult<IEnumerable<string>> GetRoles()
        {
            var roles = Enum.GetNames(typeof(Role)).ToList();
            roles.Insert(0, "all"); // Insert "all" at the beginning of the roles list
            return roles;
        }

        [HttpGet("ShowUsersByRole")]
        public async Task<ActionResult<IEnumerable<User>>> ShowUsersByRole(string role)
        {
            if (role == "all")
            {
                return await _dbManager.Users.ToListAsync();
            }
            else
            {
                if (Enum.TryParse<Role>(role, out var parsedRole))
                {
                    var users = await _dbManager.Users.Where(user => user.Role == parsedRole).ToListAsync();
                    return users;
                }
                else
                {
                    // Handle invalid role string
                    return BadRequest("Invalid role specified");
                }
            }
        }




    }

}