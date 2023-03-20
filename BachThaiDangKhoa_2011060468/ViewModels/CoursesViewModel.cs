using BachThaiDangKhoa_2011060468.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BachThaiDangKhoa_2011060468.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}