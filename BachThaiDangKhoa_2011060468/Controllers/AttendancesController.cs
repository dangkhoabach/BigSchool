﻿using BachThaiDangKhoa_2011060468.DTOs;
using BachThaiDangKhoa_2011060468.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BachThaiDangKhoa_2011060468.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbcontext;

        public AttendancesController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbcontext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists!");

            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                /*AttendeeId = User.Identity.GetUserId()*/
                AttendeeId = userId
            };

            _dbcontext.Attendances.Add(attendance);
            _dbcontext.SaveChanges();

            return Ok();
        }
    }
}
