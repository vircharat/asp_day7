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
    public class ShowTimeController : Controller
    {
        IConfiguration _configuration;
        public ShowTimeController(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Index(ShowTimev showTimev)
        {
            IEnumerable<ShowTimev> showTimeresult = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/GetShows";//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        showTimeresult = JsonConvert.DeserializeObject<IEnumerable<ShowTimev>>(result);
                    }



                }
            }
            return View(showTimeresult);
        }

        public IActionResult IndexAdmin()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> IndexAdmin(ShowTimev showTimev)
        {
            IEnumerable<ShowTimev> showTimeresult = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/GetShows";//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        showTimeresult = JsonConvert.DeserializeObject<IEnumerable<ShowTimev>>(result);
                    }



                }
            }
            return View(showTimeresult);
        }
        public IActionResult ShowTimeEntry()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ShowTimeEntry(ShowTimev showTimev)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showTimev), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/AddShow";//api controller name and its function

                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTime Details Saved Successfull!!";
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
        public async Task<IActionResult> EditShowTime(int ShowTimeId)
        {
            ShowTimev ShowTimev = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/GetShowTimebyId?showId=" + ShowTimeId;//movieId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        ShowTimev = JsonConvert.DeserializeObject<ShowTimev>(result);
                    }



                }
            }
            return View(ShowTimev);

        }
        [HttpPost]
        public async Task<IActionResult> EditShowTime(ShowTimev ShowTimev)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(ShowTimev), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/UpdateShow";//api controller name and its function

                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Show Time  Updated Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(ShowTimev);


        }
        public async Task<IActionResult> DeleteShowTime(int ShowTimeId)
        {
            ShowTimev ShowTimev = null;
            using (HttpClient client = new HttpClient())
            {


                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/GetShowTimebyId?showId=" + ShowTimeId;//movieId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in moviecontroller of api

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        var result = await response.Content.ReadAsStringAsync();
                        ShowTimev = JsonConvert.DeserializeObject<ShowTimev>(result);
                    }



                }
            }
            return View(ShowTimev);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteShowTime(ShowTimev ShowTimev)
        {
            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTime/DeleteShow?showId=" + ShowTimev.ShowvId;  //api controller name and its function

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {   //dynamic viewbag we can create any variable name in run time
                        ViewBag.status = "Ok";
                        ViewBag.message = "Show Time Details Deleted Successfull!!";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }
            return View(ShowTimev);





        }
    }
}
