using Microsoft.EntityFrameworkCore;
using StudentMgmtSystem.Models.Database;
using StudentMgmtSystem.Models.Request;
using StudentMgmtSystem.Models.Response;

namespace StudentMgmtSystem.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly EFCoreDbContext _dbContext;

        public StudentService(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentResponse>> GetStudent()
        {
            // 1. Fetch the data from the database
            var students = await _dbContext.StudentModel.ToListAsync();

            // 2. Map the StudentModel list to a StudentResponse list
            return students.Select(s => new StudentResponse
            {
                Id = s.Id,
                CourseId = s.CourseId,
                FullName = s.FullName,
                Email = s.Email,
                Birthday = s.Birthday
            }).ToList();
        }
        // Change return type to Task<string?> so we can return an error message
        public async Task<(bool Success, string Message)> CreateStudent(StudentRequest bodyDatas)
        {

            var course = await _dbContext.CourseModel
                .FirstOrDefaultAsync(c => c.Id == bodyDatas.CourseId);

            if (course == null)
            {
                return (false, "Course not found in database.");
            }

            var student = new StudentModel
            {
                Id = Guid.NewGuid(),
                FullName = bodyDatas.FullName,
                Birthday = bodyDatas.Birthday,
                Email = bodyDatas.Email,
                CourseId = course.Id 
            };

            try
            {
                _dbContext.StudentModel.Add(student);
                await _dbContext.SaveChangesAsync();
                return (true, "Student created successfully!");
            }
            catch (Exception ex)
            {
                // This will help you see the EXACT Postgres message if it still fails
                return (false, $"Database Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
    }
