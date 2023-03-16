using Microsoft.AspNet.Identity;
using NgoTanLoc.Models;
using NgoTanLoc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgoTanLoc.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        // GET: Courses
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel();
            viewModel.Categories = _dbContext.Categories.ToList();
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (CourseViewModel courseView)
        {
            if (!ModelState.IsValid)
            {
                courseView.Categories = _dbContext.Categories.ToList();
                return View("Create", courseView);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = courseView.GetDateTime(),
                CategoryId = courseView.Category,
                Place = courseView.Place
            };

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}