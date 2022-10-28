using BookTheShowBLL.services;
using BookTheShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }


        [HttpGet("GetAdmins")] //attributes called inside square brackets 
        // by default get method fires if we not specify attributes

        public IEnumerable<Admin> GetAdmins()
        {
            return _adminService.GetAdmins();
        }



        [HttpPost("Register")]
        public IActionResult Register([FromBody] Admin admin)
        {
            _adminService.Register(admin);
            return Ok("Register successfully!!");
        }

        [HttpDelete("DeleteAdmin")]

        public IActionResult DeleteAdmin(int adminId)  //iactionresult it can return anything like integer string json etc
        {
            _adminService.DeleteAdmin(adminId);

            return Ok("Admin Deleted successfully!!");


        }

        [HttpPut("UpdateAdmin")]

        public IActionResult UpdateAdmin([FromBody] Admin admin)
        {
            _adminService.UpdateAdmin(admin);
            return Ok("Admin updated successfully!!");
        }


        [HttpGet("GetAdminbyId")]
        public Admin GetAdminbyId(int adminId)
        {

            return _adminService.GetAdminbyId(adminId);

        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Admin admin)
        {
            Admin adminn = _adminService.Login(admin);
            if (adminn != null)
                return Ok("Login success!!");
            else
                return NotFound();
        }

    }
}
