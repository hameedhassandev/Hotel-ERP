namespace API.Entities
{
    public class Room
    {
        
        public int RoomNo { get; set; }
        public string BrancheName { get; set; }
        public int NoOfBeds { get; set; }
        public int FloorNo { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
