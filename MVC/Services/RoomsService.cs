using MVC.Interfaces;
using MVC.ViewModels;
using Newtonsoft.Json;

namespace MVC.Services
{
    public class RoomsService : IRoomService
    {
        Uri baseAddress = new Uri("http://localhost:5243/api");
        private readonly HttpClient _httpClient;
        public RoomsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAddress;
        }

        public IEnumerable<RoomViewModel> GetAllRoomsByBrancheId(int BrancheId)
        {
            List<RoomViewModel> rooms = new List<RoomViewModel>();
            HttpResponseMessage res = _httpClient.GetAsync(_httpClient.BaseAddress + "/Rooms/GetAllWithBranchId?brancheId="+BrancheId).Result;
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                rooms = JsonConvert.DeserializeObject<List<RoomViewModel>>(data);
            }

            return rooms.ToList();
        }

        public IEnumerable<ReportAllRooms> ReportAllRooms()
        {
            List<ReportAllRooms> report = new List<ReportAllRooms>();
            HttpResponseMessage res = _httpClient.GetAsync(_httpClient.BaseAddress + "/Rooms/ReportAllRooms").Result;
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                report = JsonConvert.DeserializeObject<List<ReportAllRooms>>(data);
            }

            return report.ToList();
        }

    }
}
