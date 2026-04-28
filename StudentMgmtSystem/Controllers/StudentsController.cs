using Microsoft.AspNetCore.Mvc;
using StudentMgmtSystem.Models.Request;
using StudentMgmtSystem.Services.Students;

namespace StudentMgmtSystem.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
       private readonly IStudentService _studentService;

       public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetStudent();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentRequest request)
        {
            var result = await _studentService.CreateStudent(request);

            if (!result.Success)
            {
                return NotFound(result.Message); // This returns a 404 status code
            }

            return Ok(result.Message);
        }
    }
}
