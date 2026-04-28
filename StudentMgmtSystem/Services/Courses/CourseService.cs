using Microsoft.EntityFrameworkCore;
using StudentMgmtSystem.Models.Database;
using StudentMgmtSystem.Models.Request;

namespace StudentMgmtSystem.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly EFCoreDbContext _dbContext;

        public CourseService(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CourseModel>> GetCourse()
        {
            var course =  await _dbContext.CourseModel.ToListAsync();
            return course;
        }
        public Task<bool> CreateCourse(CourseRequest bodyDatas)
        {
            var courses = new CourseModel
            {
                CourseCode = bodyDatas.CourseCode,
                Title = bodyDatas.Title,
            };
             _dbContext.CourseModel.Add(courses);
            var result = _dbContext.SaveChanges();
            return Task.FromResult(result > 0);
        }
    }
}
