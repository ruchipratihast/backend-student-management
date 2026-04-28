namespace StudentMgmtSystem.Models.Request
{
    public class StudentRequest
    {
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; } = string.Empty;
        public Guid CourseId { get; set; }

    }
}


