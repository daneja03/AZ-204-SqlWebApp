using AZ_204_SqlWebApp.Models;
using AZ_204_SqlWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZ_204_SqlWebApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> courseList = _courseService.GetCourses();
            return View(courseList);
        }
    }
}
