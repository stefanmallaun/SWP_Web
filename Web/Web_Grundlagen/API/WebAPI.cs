using Microsoft.AspNetCore.Mvc;
using Web_Grundlagen.Models;
using Web_Grundlagen.DB;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Grundlagen.API
{
    // Note: This should be in an ApiController, not the MVC Controller.
    // You would need to create a separate ApiController or modify your existing UserController to inherit from ControllerBase instead of Controller.

    [ApiController]
    [Route("api/[controller]")]
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
            return Ok(users);
        }

        // Other API methods...
    }

}