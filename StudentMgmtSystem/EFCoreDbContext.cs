using Microsoft.EntityFrameworkCore;
using StudentMgmtSystem.Models.Database;

namespace StudentMgmtSystem
{
    public class EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : DbContext(options)
    {
        public DbSet<StudentModel> StudentModel { get; set; }
        public DbSet<CourseModel> CourseModel { get; set; }
    }
}
