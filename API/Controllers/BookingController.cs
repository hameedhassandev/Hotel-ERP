using API.DTOS;
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
    public class BookingController : ControllerBase
    {
        DBManager _dBmanager = new DBManager();

        [HttpGet("GetBookingByBrancheId")]
        public IActionResult GetBookingByBrancheId([Required] int brancheId)
        {
            var bookingLst = new List<CustomerBooking>();

            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BranncheId"] = brancheId;


            var data = _dBmanager.ExecuteDataSet("GetBookingByBrancheId", map);

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    bookingLst.Add(new CustomerBooking
                    {
                        BookingId = (int)dr["BookingId"],
                        BrancheName = (string)dr["brancheName"],
                        FullName = (string)dr["FullName"],
                        Email = (string)dr["Email"],
                        Phone = (string)dr["Phone"],
                        StartDate = (DateTime)dr["StartDate"],
                        NoOfDays = (int)dr["NoOfDays"],
                        
                        IsCanceled = (bool)dr["IsCanceled"],
                    });
                }
            }

            return Ok(bookingLst);
        }



        [HttpGet("GetBookingDetailsByBookingId")]
        public IActionResult GetBookingDetailsByBookingId([Required] int bookingId)
        {
            var bookingDetailsLst = new List<BookingDetails>();

            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BookingId"] = bookingId;


            var data = _dBmanager.ExecuteDataSet("GetBookingDetailsByBookingId", map);

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    bookingDetailsLst.Add(new BookingDetails
                    {
                        Id = (int)dr["Id"],
                        FloorNo = (int)dr["FloorNo"],
                        RoomNo = (int)dr["RoomNo"],
                        NoOfBeds = (int)dr["NoOfBeds"],
                        PricePerDay = (decimal)dr["PricePerDay"],
                        NoOfDays = (int)dr["NoOfDayes"],
                    });
                }
            }
            return Ok(bookingDetailsLst);
        }




        private int CountOfCustomerBooking(int customerId)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@CustomerId"] = customerId;
            var result = _dBmanager.ExecuteScaler("CountOfCustomerBooking", map);
            if ((int)result > 0) return (int)result;
            return -1;
        }

        [HttpGet("CalcTotalBooking")]
        public ActionResult<SubTotalDto> CalcTotalBooking([Required] int bookingId,[Required]int customerId)
        {

            decimal discountedPrice = 95;
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BookingId"] = bookingId;
            int countOfBooking = CountOfCustomerBooking(customerId);
            var total = _dBmanager.ExecuteScaler("TotalBookingPrice", map);

            if (countOfBooking > 0)
            {
                var totalPrice = (decimal)total - ((decimal)total * (discountedPrice / 100));
                return Ok(new SubTotalDto { Total = (decimal)total, Discount = discountedPrice, SubTotal = totalPrice });
            }

            return Ok(new SubTotalDto { Total = (decimal)total, Discount = 0, SubTotal = (decimal)total});

        }

        [HttpPost("CreateBook")]
        public IActionResult CreateBook()
        {
            //branche id 
            //customer id
            //room number 
            //start day = datetime.now
            //number of days
            //price per day

            // 1- create normal book 
            // get bookId then 
            return Ok();
        }

    }
}
