using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NgoTanLoc.DTOs;
using NgoTanLoc.Models;
namespace NgoTanLoc.Controllers
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendanceController ()
        {
            _dbContext = new ApplicationDbContext();

        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO attendanceDTO)
        {
            
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDTO.CourseId))
                return BadRequest("The attendance already exists");

            var attendance = new Attendance
            {
                CourseId = attendanceDTO.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
