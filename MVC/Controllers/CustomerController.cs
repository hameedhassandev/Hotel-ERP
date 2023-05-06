using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using MVC.ViewModels.CreateViewModel;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5243/api");
        private readonly HttpClient _httpClient;

        public CustomerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult GetAll()
        {
            List<CustomerVewModel> customers = new List<CustomerVewModel>();
            HttpResponseMessage res = _httpClient.GetAsync(_httpClient.BaseAddress + "/Customers/GetAll").Result;
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<CustomerVewModel>>(data);
            }
            return View(customers);
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerViewModel model)
        {
            
            string data = JsonConvert.SerializeObject(model);   
            StringContent content  = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage res = _httpClient.PostAsync(_httpClient.BaseAddress + "/Customers/CreateCustomer",content).Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll");
            }

            ViewBag.massage = "Not Created, try again!: "+ res.RequestMessage.ToString();
            return View();
        }
    }
}
