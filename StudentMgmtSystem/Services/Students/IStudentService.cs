using StudentMgmtSystem.Models.Database;
using StudentMgmtSystem.Models.Request;
using StudentMgmtSystem.Models.Response;

namespace StudentMgmtSystem.Services.Students
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetStudent();
        Task<(bool Success, string Message)> CreateStudent(StudentRequest bodyDatas);
    }
}
