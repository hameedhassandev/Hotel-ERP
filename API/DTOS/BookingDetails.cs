namespace API.DTOS
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public int FloorNo { get; set; }
        public int RoomNo { get; set; }
        public int NoOfBeds { get; set; }
        public int NoOfDays { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal SubTotalPerRoom { get { return PricePerDay * NoOfDays; } }
    }
}
