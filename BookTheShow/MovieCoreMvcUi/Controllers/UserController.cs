using BookTheShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserCoreMvcUi.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Index(Userv userv)
        {
            IEnumerable<Userv> userresult = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "User/GetUsers";//api controller name and httppost name given inside httppost in Usercontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        userresult = JsonConvert.DeserializeObject<IEnumerable<Userv>>(result);
                    }



                }
            }
            return View(userresult);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(Userv userv)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userv), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/Register";//api controller name and its function

                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "User Details Saved Successfull!!";
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
        public async Task<IActionResult> EditUser(int UserId)
        {
            Userv User = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "User/GetUserbyId?userId=" + UserId;//UserId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in Usercontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        User = JsonConvert.DeserializeObject<Userv>(result);
                    }



                }
            }
            return View(User);

        }
        [HttpPost]
        public async Task<IActionResult> EditUser(Userv Userv)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Userv), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/UpdateUser";//api controller name and its function

                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Users Details Updated Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(Userv);


        }
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            Userv User = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "User/GetUserById?userId=" + UserId;//UserId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in Usercontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        User = JsonConvert.DeserializeObject<Userv>(result);
                    }



                }
            }
            return View(User);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Userv Userv)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "User/DeleteUser?userId=" + Userv.UservId;  //api controller name and its function

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Users Details Deleted Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(Userv);
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]

        public async Task<IActionResult> Login(Userv userv)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userv), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Tokenn/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("Index", "User");
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong credentials!";
                    }
                }
            }
            return View();



        }
       
        public IActionResult MyProfile()
        {
            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> MyProfile(Booking booking)
        {
            Userv userv=null;
            ViewBag.status = "";
            int a = Convert.ToInt32(TempData["userdataid"]);
            TempData.Keep();
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "User/GetUserById?userId=" + a;  //api controller name and its function

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time

                        var result = await response.Content.ReadAsStringAsync();
                        userv = JsonConvert.DeserializeObject<Userv>(result);
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(userv);
        }
        public IActionResult Signout()
        {
            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Signout(Userv userv)
        {
            return RedirectToAction("Index", "Main");
        }



    }
}
