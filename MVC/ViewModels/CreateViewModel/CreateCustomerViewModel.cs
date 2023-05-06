using Microsoft.Build.Framework;
using System.ComponentModel;

namespace MVC.ViewModels.CreateViewModel
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [DisplayName("Address")]
        [Required]
        public string CustomerAddress { get; set; }

    }
}
