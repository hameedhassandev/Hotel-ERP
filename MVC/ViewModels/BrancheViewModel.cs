using System.ComponentModel;

namespace MVC.ViewModels
{
    public class BrancheViewModel
    {
        public int Id { get; set; }
        [DisplayName("Branche Name")]
        public string BrancheName { get; set; }

        [DisplayName("Branche Location")]
        public string BrancheLocation { get; set; }
      
    }
}
