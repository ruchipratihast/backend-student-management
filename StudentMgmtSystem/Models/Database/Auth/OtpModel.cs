namespace StudentMgmtSystem.Models.Database.Auth
{
    public class OtpModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Otp { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
