using BookTheShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUi.Controllers
{
    public class AdminController : Controller
    {
        IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Index(Admin admin)
        {
            IEnumerable<Admin> Adminresult = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/GetAdmins";//api controller name and httppost name given inside httppost in Admincontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        Adminresult = JsonConvert.DeserializeObject<IEnumerable<Admin>>(result);
                    }



                }
            }
            return View(Adminresult);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(Admin admin)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/Register";//api controller name and its function

                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Admin Details Saved Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditAdmin(int adminnId)
        {
            Admin Admin = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/GetAdminbyId?adminId=" + adminnId;//AdminId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in Admincontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        Admin = JsonConvert.DeserializeObject<Admin>(result);
                    }



                }
            }
            return View(Admin);

        }
        [HttpPost]
        public async Task<IActionResult> EditAdmin(Admin admin)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/UpdateAdmin";//api controller name and its function

                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Admins Details Updated Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(admin);


        }
        public async Task<IActionResult> DeleteAdmin(int adminnId)
        {
            Admin Admin = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/GetAdminById?adminId=" + adminnId;//AdminId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in Admincontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        Admin = JsonConvert.DeserializeObject<Admin>(result);
                    }



                }
            }
            return View(Admin);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteAdmin(Admin admin)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/DeleteAdmin?adminId=" + admin.AdminId;  //api controller name and its function

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Admins Details Deleted Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(admin);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(Admin Adminv)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Adminv), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Admin/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("Index", "Admin");
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong credentials!";
                    }
                }
            }
            return View();



        }
        public IActionResult Signout()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Signout(Admin admin)
        {
            return RedirectToAction("Index", "Main");
        }

 


    }
}

