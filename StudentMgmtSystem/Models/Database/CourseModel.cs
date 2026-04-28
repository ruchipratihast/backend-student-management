namespace StudentMgmtSystem.Models.Database
{
    public class CourseModel
    {
        public Guid Id { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
