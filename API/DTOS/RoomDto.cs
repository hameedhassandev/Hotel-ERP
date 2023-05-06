using System.ComponentModel.DataAnnotations;

namespace API.DTOS
{
    public class RoomDto
    {
        [Required]
        public int NoOfBeds { get; set; }
        [Required]
        public int FloorNo { get; set; }
        [Required]
        public decimal PricePerDay { get; set; }
        [Required]
        public int BrancheId { get; set; }
    }
}
