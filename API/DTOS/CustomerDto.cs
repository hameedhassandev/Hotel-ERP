using System.ComponentModel.DataAnnotations;

namespace API.DTOS
{
    public class CustomerDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
    }
}
