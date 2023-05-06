using MVC.ViewModels;

namespace MVC.Interfaces
{
    public interface IBrancheService
    {
        IEnumerable<BrancheViewModel> GetAllBranches();
    }
}
