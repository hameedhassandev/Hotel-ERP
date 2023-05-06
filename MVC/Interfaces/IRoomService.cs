using MVC.ViewModels;

namespace MVC.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<RoomViewModel> GetAllRoomsByBrancheId(int BrancheId);
        public IEnumerable<ReportAllRooms> ReportAllRooms();
    }
}
