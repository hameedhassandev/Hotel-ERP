using System.ComponentModel;

namespace MVC.ViewModels
{
    public class BookingDetailsViewModel
    {
        public int BookingId { get; set; }
        [DisplayName("Room Number")]
        public int RoomId { get; set; }
        [DisplayName("Number Of Days")]
        public int NoOfDays { get; set; }

        [DisplayName("Price Per Day")]
        public int PricePerDay { get; set; }
    }
}
