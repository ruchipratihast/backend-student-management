namespace StudentMgmtSystem.Models.Database
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Foreign Key
        public Guid CourseId { get; set; }

        // Navigation Property - allows EF to "Join" the tables
        public CourseModel Course { get; set; } = null!;

    }
}
