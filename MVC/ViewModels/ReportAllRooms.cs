using System.ComponentModel;

namespace MVC.ViewModels
{
    public class ReportAllRooms
    {
        [DisplayName("Branche Id")]
        public int brancheId { get; set; }
        [DisplayName("Branche Name")]
        public string brancheName { get; set; }
        [DisplayName("Branche Location")]
        public string branchLocation { get; set; }

        [DisplayName("Room Number")]
        public int RoomNo { get; set; }
        [DisplayName("Floor Number")]
        public int FloorNo { get; set; }
        [DisplayName("Number Of Beds")]
        public int NoOfBeds { get; set; }
        [DisplayName("Price Per Day")]
        public decimal PricePerDay { get; set; }
        [DisplayName("Is Available")]
        public bool IsAvaliable { get; set; }
    }
}
