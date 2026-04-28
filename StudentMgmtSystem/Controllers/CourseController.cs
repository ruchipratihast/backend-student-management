using Microsoft.AspNetCore.Mvc;
using StudentMgmtSystem.Models.Request;
using StudentMgmtSystem.Services.Courses;

namespace StudentMgmtSystem.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetCourse();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseRequest request)
        {
            var result = await _courseService.CreateCourse(request);
            if (result)
            {
                return Ok(new { message = "Course created successfully" });
            }
            else
            {
                return BadRequest(new { message = "Failed to create course" });
            }
        }
    }
}
