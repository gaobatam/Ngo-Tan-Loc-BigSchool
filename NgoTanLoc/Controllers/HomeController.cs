using NgoTanLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NgoTanLoc.ViewModels;

namespace NgoTanLoc.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var upCommingCourses = _dbContext.Courses
                .Include(c => c.Lecture)
                .Include(c => c.Category);
            //.Where(c => c.DateTime > DateTime.Now);

            var viewModle = new ViewsCourseChecking
            {
                UpcommingCourses = upCommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModle);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}