using MVC.Interfaces;
using MVC.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace MVC.Services
{
    public class BrancheService : IBrancheService
    {
        Uri baseAddress = new Uri("http://localhost:5243/api");
        private readonly HttpClient _httpClient;
        public BrancheService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAddress;
        }

        public IEnumerable<BrancheViewModel> GetAllBranches()
        {
            List<BrancheViewModel> branches = new List<BrancheViewModel>();
            HttpResponseMessage res = _httpClient.GetAsync(_httpClient.BaseAddress + "/Branches/GetAll").Result;
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                branches = JsonConvert.DeserializeObject<List<BrancheViewModel>>(data);
            }

            return branches.ToList();
        }
    }
}
