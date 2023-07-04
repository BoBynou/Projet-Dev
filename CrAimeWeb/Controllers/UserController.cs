using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrAime;

namespace CrAimeWeb.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            List<CrAime.User> users = Services.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var userData = Services.GetUser(id);
            if (userData != null)
            {
                return Ok(userData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserViewModel user)
        {
            try
            {
                Services.AddUser(user.Email, user.Password, user.First_name, user.Last_name, user.Phone_number, user.Is_admin);
                return Ok("allgood");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserViewModel user)
        {
            Services.UpdateUser(user.Id, user.Email, user.Password, user.First_name, user.Last_name, user.Phone_number, user.Is_admin);
            return Ok("allgood");
        }

        [HttpPut("{id}")]
        public IActionResult DeleteUser(string id)
        {
            Services.DeleteUser(id);
            return Ok("allgood");
        }
    }
}
