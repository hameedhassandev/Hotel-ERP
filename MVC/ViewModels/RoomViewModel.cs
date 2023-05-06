namespace MVC.ViewModels
{
    public class RoomViewModel
    {
        public int RoomNo { get; set; }
        public string BrancheName { get; set; }
        public int FloorNo { get; set; }
        public int NoOfBeds { get; set; }
        public decimal PricePerDay { get; set; }
        public bool isAvailable { get; set; }

    }
}
