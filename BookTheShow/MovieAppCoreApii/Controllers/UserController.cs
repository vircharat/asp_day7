using BookTheShowBLL.services;
using BookTheShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public static int userid { get; set; }
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetUsers")] //attributes called inside square brackets 
        // by default get method fires if we not specify attributes

        public IEnumerable<Userv> GetUsers()
        {
            return _userService.GetUsers();
        }



        [HttpPost("Register")]
        public IActionResult Register([FromBody] Userv userv)
        {
            _userService.Register(userv);
            return Ok("Register successfully!!");
        }

        [HttpDelete("DeleteUser")]

        public IActionResult DeleteUser(int userId)  //iactionresult it can return anything like integer string json etc
        {
            _userService.DeleteUser(userId);

            return Ok("User Deleted successfully!!");


        }

        [HttpPut("UpdateUser")]

        public IActionResult UpdateUser([FromBody] Userv userv)
        {
            _userService.UpdateUser(userv);
            return Ok("User updated successfully!!");
        }


        [HttpGet("GetUserbyId")]
        public Userv GetUserbyId(int userId)
        {

            return _userService.GetUserbyId(userId);

        }

        
        
        [HttpPost("Login")]
        public int Login([FromBody] Userv userv)
        {
            Userv user = _userService.Login(userv);
            if (user != null)
            {
                userid = user.UservId;
                /* return Ok("Login success!!");*/
                return userid;
            }
            else
                /*return NotFound();*/
                return 0;
        }
        [HttpGet("userid")]
        public int getuseridbylogin()
        {
            return userid;
        }

    }
}
