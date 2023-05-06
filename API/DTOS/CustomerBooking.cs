namespace API.DTOS
{
    public class CustomerBooking
    {
        public int BookingId { get; set; } 
        public string BrancheName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; }
        public int NoOfDays { get; set; }
        public DateTime EndDate { get { return StartDate.AddDays(NoOfDays); } }
        public bool IsCanceled { get; set; }
        
    }
}
