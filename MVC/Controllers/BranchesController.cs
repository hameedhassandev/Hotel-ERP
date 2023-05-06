using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.ViewModels;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MVC.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IBrancheService _brancheService;

        public BranchesController(IBrancheService brancheService)
        {
            _brancheService = brancheService;
        }
        public IActionResult Index()
        {
            var allBranches = _brancheService.GetAllBranches();
            return View(allBranches);
        }   
    }
}
