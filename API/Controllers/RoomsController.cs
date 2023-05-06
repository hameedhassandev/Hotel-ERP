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
    public class RoomsController : ControllerBase
    {
        DBManager _dBmanager = new DBManager();


        [HttpGet("GetAllWithBranchId")]
        public IActionResult GetAllWithBranchId([Required]int brancheId)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BrancheId"] = brancheId;


            var data = _dBmanager.ExecuteDataSet("GetAllRoomsWithBranchId", map);

            var rooms = new List<Room>();

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    rooms.Add(new Room
                    {
                        BrancheName = (string)dr["brancheName"],
                        RoomNo = (int)dr["RoomNo"],
                        NoOfBeds = (int)dr["NoOfBeds"],
                        FloorNo = (int)dr["FloorNo"],
                        PricePerDay = (decimal)dr["PricePerDay"],
                        IsAvailable = (bool)dr["IsAvailable"],
                        
                    });

                }
            }

            return Ok(rooms);
        }



        [HttpGet("GetAllAvailableWithBranchId")]
        public IActionResult GetAllAvailableWithBranchId([Required] int brancheId)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BrancheId"] = brancheId;


            var data = _dBmanager.ExecuteDataSet("GetAllAvailableRoomsWithBranchId", map);

            var rooms = new List<Room>();

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    rooms.Add(new Room
                    {
                        BrancheName = (string)dr["brancheName"],
                        RoomNo = (int)dr["RoomNo"],
                        NoOfBeds = (int)dr["NoOfBeds"],
                        FloorNo = (int)dr["FloorNo"],
                        PricePerDay = (decimal)dr["PricePerDay"],
                        IsAvailable = (bool)dr["IsAvailable"],

                    });

                }
            }

            return Ok(rooms);
        }


        [HttpGet("ReportAllRooms")]
        public IActionResult ReportAllRooms()
        {
            var data = _dBmanager.ExecuteDataSet("ReportAllRooms");

            var allRooms = new List<ReportAllRooms>();

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    allRooms.Add(new ReportAllRooms
                    {
                        BrancheId = (int)dr["ID"],
                        BrancheName = (string)dr["brancheName"],
                        BranchLocation = (string)dr["BrancheLocation"],
                        FloorNo = (int)dr["FloorNo"],
                        RoomNo = (int)dr["RoomNo"],
                        NoOfBeds = (int)dr["NoOfBeds"],
                        PricePerDay = (decimal)dr["PricePerDay"],
                        IsAvaliable = (bool)dr["IsAvailable"],
                    });
                }
            }
            return Ok(allRooms);
        }



        [HttpPost("AddRoom")]
        public IActionResult AddRoom([FromForm] RoomDto dto)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BrancheId"] = dto.BrancheId;
            map["@NoOfBeds"] = dto.NoOfBeds;
            map["@FloorNo"] = dto.FloorNo;
            map["@PricePerDay"] = dto.PricePerDay;

            _dBmanager.ExecuteScaler("AddRoom", map);

            return Ok();
        }


        [HttpPut("UpdateRoom")]
        public IActionResult UpdateRoom([FromForm] UpdateRoomDto dto)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map["@BrancheId"] = dto.BrancheId;
            map["@NoOfBeds"] = dto.NoOfBeds;
            map["@FloorNo"] = dto.FloorNo;
            map["@PricePerDay"] = dto.PricePerDay;
            map["@IsAvailable"] = dto.IsAvailable;
            map["@RoomNo"] = dto.RoomNo;


            Dictionary<string, object> mapRoomNo = new Dictionary<string, object>();
            mapRoomNo["@RoomNo"] = dto.RoomNo;

            var findRoom = _dBmanager.ExecuteDataSet("GetRoomById", mapRoomNo);
             if (findRoom.Tables[0].Rows.Count == 0)
             {
                return NotFound();
             }

            _dBmanager.ExecuteScaler("UpdateRoom", map);

            return Ok();
        }
    }
}
