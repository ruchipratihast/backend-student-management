using Microsoft.EntityFrameworkCore;
using StudentMgmtSystem.Models.Database;
using StudentMgmtSystem.Models.Database.Auth;

namespace StudentMgmtSystem
{
    public class EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : DbContext(options)
    {
        public DbSet<StudentModel> StudentModel { get; set; }
        public DbSet<CourseModel> CourseModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<OtpModel> OtpModel { get; set; }
    }
}
    