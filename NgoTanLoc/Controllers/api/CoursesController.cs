﻿using Microsoft.AspNet.Identity;
using NgoTanLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NgoTanLoc.Controllers.api
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext _dbContext;
        public CoursesController() 
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel (int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);
            if (course.isCancelled)
                return NotFound();
            course.isCancelled = true;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
