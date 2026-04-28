namespace StudentMgmtSystem.Models.Response
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; } = string.Empty;

    }
}
