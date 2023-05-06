namespace API.DTOS
{
    public class ReportAllRooms
    {
        public int BrancheId { get; set; }
        public string BrancheName { get; set; }
        public string BranchLocation { get; set; }
        public int RoomNo { get; set; }
        public int FloorNo { get; set; }
        public int NoOfBeds { get; set; }
        public decimal  PricePerDay { get; set; }
        public bool  IsAvaliable { get; set; }
    }
}
