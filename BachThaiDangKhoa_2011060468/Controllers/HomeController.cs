using BachThaiDangKhoa_2011060468.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BachThaiDangKhoa_2011060468.ViewModels;
using Microsoft.AspNet.Identity;

namespace BachThaiDangKhoa_2011060468.Controllers
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
            var upcommingCourses = _dbContext.Courses.Include(c => c.Lecturer).Include(c => c.Category).Where(c => c.DateTime > DateTime.Now);
            /*return View(upcommingCourses);*/

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Attendances.Where(a => a.AttendeeId == userId).Select(a => a.Course).Include(l => l.Lecturer).Include(l => l.Category).ToList();

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = courses,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }
    }
}