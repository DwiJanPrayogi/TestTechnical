using BPKB_APP.Models;
using BPKB_APP.wwwroot.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;

namespace BPKB_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var bpkbList = new List<BpkbDTO>();
            var url = $"https://localhost:7009/api/";
            var parameters = $"Bpkb";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                bpkbList = JsonConvert.DeserializeObject<List<BpkbDTO>>(jsonString);
            }
            return View(bpkbList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> AddBpkb()
        {
            var locationList = new List<LocationDTO>();
            var addBpkb = new List<LocationDTO>();
            var url = $"https://localhost:7009/api/";
            var parameters = $"Location";
            dynamic mymodel = new ExpandoObject();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                locationList = JsonConvert.DeserializeObject<List<LocationDTO>>(jsonString);
            }
            mymodel.location = locationList;
            mymodel.addBpkcb = addBpkb;

            return View(mymodel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string test1, DateTime test2, string test3, string test4, string test5, string test6, DateTime test7, DateTime test8, string test9)
        {
            var data = new BpkbInputDTO 
            { 
                agreement_number = test1,
                bpkb_date = test2,
                branch_id = test3,
                police_no = test4,
                bpkb_no = test5,
                location_id = test6,
                bpkb_date_in = test7,
                created_on = test8,
                faktur_no = test9
            };
            var url = $"https://localhost:7009/api/";
            var parameters = $"Bpkb";
            var payload = JsonSerializer.Serialize(data);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
                           
            var response = await client.PostAsync(parameters, content);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
