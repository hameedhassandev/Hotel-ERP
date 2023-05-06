using API.DTOS;
using API.Entities;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        DBManager _dBmanager = new DBManager();


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _dBmanager.ExecuteDataSet("GetAllCustomers");

            var customers = new List<Customer>();

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    customers.Add(new Customer
                    {
                        Id = (int)dr["Id"],
                        FullName = (string)dr["FullName"],
                        Email = (string)dr["Email"],
                        Phone = (string)dr["Phone"],
                        CustomerAddress = (string)dr["CustomerAddress"],
                        CreatedAt = (DateTime)dr["CreatedAt"],

                    });

                }
            }

            return Ok(customers);
        }


        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] CustomerDto dto)
        {
           
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@FullName"] = dto.FullName;
            map["@Email"] = dto.Email;
            map["@Phone"] = dto.Phone;
            map["@CustomerAddress"] = dto.CustomerAddress;
            map["@CreatedAt"] = DateTime.Now;

            _dBmanager.ExecuteScaler("CreateCustomer", map);

            return Ok();
        }

    }
}
