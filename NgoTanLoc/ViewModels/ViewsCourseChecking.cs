using NgoTanLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgoTanLoc.ViewModels
{
    public class ViewsCourseChecking
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}