using Microsoft.AspNetCore.Mvc;
using Web_Grundlagen.Models;
using Web_Grundlagen.DB;
using System.Linq;
using System.Collections.Generic;

namespace Web_Grundlagen.API {
    [Route("user/showAllUser")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly DBManager _dbManager; // Assuming DBManager is your DbContext

        public UserController(DBManager dbManager) {
            _dbManager = dbManager;
        }

        
        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles() {
            var roles = _dbManager.Users.Select(u => u.Role).Distinct().ToList();

            if (roles != null) {
                return Ok(roles);
            }
            else {
                return BadRequest("Falsch");
            }
        }

        
        [HttpGet("GetUsersByRole")]
        public IActionResult GetUsersByRole(Role role) {
            var users = _dbManager.Users.Where(u => u.Role == role).ToList();

            if (users != null) {
                return Ok(users);
            }
            else {
                return BadRequest("Falsch");
            }
        }
    }
}
