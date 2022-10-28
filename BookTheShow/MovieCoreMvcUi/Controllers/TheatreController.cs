using BookTheShowEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUi.Controllers
{
    public class TheatreController : Controller
    {
        IConfiguration _configuration;
        public TheatreController(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Index(Theatrev theatrev)
        {
            IEnumerable<Theatrev> theatreresult = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/GetTheatres";//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        theatreresult = JsonConvert.DeserializeObject<IEnumerable<Theatrev>>(result);
                    }



                }
            }
            return View(theatreresult);
        }
        public IActionResult IndexAdmin()
        {
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> IndexAdmin(Theatrev theatrev)
        {
            IEnumerable<Theatrev> theatreresult = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/GetTheatres";//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        theatreresult = JsonConvert.DeserializeObject<IEnumerable<Theatrev>>(result);
                    }



                }
            }
            return View(theatreresult);
        }
        public IActionResult TheatreEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TheatreEntry(Theatrev theatrev)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatrev), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/AddTheatre";//api controller name and its function

                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theatre Details Saved Successfull!!";
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
        public async Task<IActionResult> EditTheatre(int TheatreId)
        {
            Theatrev theatrev = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/GetByTheatreId?theatreId=" + TheatreId;//movieId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        theatrev = JsonConvert.DeserializeObject<Theatrev>(result);
                    }



                }
            }
            return View(theatrev);

        }
        [HttpPost]
        public async Task<IActionResult> EditTheatre(Theatrev theatrev)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatrev), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/UpdateTheatre";//api controller name and its function

                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movies Details Updated Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(theatrev);


        }
        public async Task<IActionResult> DeleteTheatre(int TheatreId)
        {
            Theatrev theatrev = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/GetByTheatreId?theatreId=" + TheatreId;//movieId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        theatrev = JsonConvert.DeserializeObject<Theatrev>(result);
                    }



                }
            }
            return View(theatrev);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteTheatre(Theatrev theatrev)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Theatre/DeleteTheatre?theatreId=" + theatrev.TheatrevId;  //api controller name and its function

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movies Details Deleted Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(theatrev);





        }

    }
}
