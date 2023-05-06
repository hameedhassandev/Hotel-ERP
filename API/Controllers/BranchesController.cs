using API.Entities;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        DBManager _dBmanager = new DBManager();


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _dBmanager.ExecuteDataSet("GetAllBranches");

            var branches = new List<Branche>();

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    branches.Add(new Branche
                    {
                        Id = (int)dr["ID"],
                        BrancheName = (string)dr["brancheName"],
                        BrancheLocation = (string)dr["BrancheLocation"]
                    });

                }
            }

            return Ok(branches);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([Required] int brancheId)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BrancheId"] = brancheId;

            var findBranche = _dBmanager.ExecuteDataSet("GetBrancheById", map);
            if (findBranche.Tables[0].Rows.Count == 0)  return NotFound();
            Branche br = new Branche();
            foreach (DataRow dr in findBranche.Tables[0].Rows)
            {
                br=new Branche
                {
                    Id = (int)dr["ID"],
                    BrancheName = (string)dr["brancheName"],
                    BrancheLocation = (string)dr["BrancheLocation"]
                };

            }
            return Ok(br);
        }

       

}
}
