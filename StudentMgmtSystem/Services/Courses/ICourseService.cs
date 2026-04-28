using StudentMgmtSystem.Models.Database;
using StudentMgmtSystem.Models.Request;

namespace StudentMgmtSystem.Services.Courses
{
    public interface ICourseService
    {
     public Task<List<CourseModel>> GetCourse();
     public Task<bool> CreateCourse(CourseRequest bodyDatas);
    }
}
