using System.ComponentModel.DataAnnotations;

namespace API.DTOS
{
    public class UpdateRoomDto
    {
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int NoOfBeds { get; set; }
        [Required]
        public int FloorNo { get; set; }
        [Required]
        public decimal PricePerDay { get; set; }
        [Required]
        public int BrancheId { get; set; }
        [Required]
        public bool IsAvailable { get; set; }

    }
}
