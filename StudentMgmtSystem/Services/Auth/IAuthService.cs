using StudentMgmtSystem.Models.Request.Auth;

namespace StudentMgmtSystem.Services.Auth
{
    public interface IAuthService
    {
        public Task<string> GenerateOtp(OtpRequest req);
        public Task<(bool Success, string Message)> Register(RegisterRequest req);
        public Task<(bool Success, string Token)> Login(LoginRequest req);
    }
}
