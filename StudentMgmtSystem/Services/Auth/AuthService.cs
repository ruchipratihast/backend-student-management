using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using StudentMgmtSystem.Models.Database.Auth;
using StudentMgmtSystem.Models.Request.Auth;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace StudentMgmtSystem.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly EFCoreDbContext _db;
        public AuthService(EFCoreDbContext db) => _db = db;

        private readonly IConfiguration _config;
        public AuthService(EFCoreDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public async Task<string> GenerateOtp(OtpRequest req)
        {
            var code = new Random().Next(100000, 999999).ToString();
            var otp = new Models.Database.Auth.OtpModel
            {
                Email = req.Email,
                Otp = code,
                Expiry = DateTime.UtcNow.AddMinutes(5)
            };
            _db.OtpModel.Add(otp);
            await _db.SaveChangesAsync();
            return code;
        }
        public async Task<(bool Success, string Message)> Register(RegisterRequest req)
        {
            //check otp exist or not with that Email
            var validOtp = await _db.OtpModel.AnyAsync(x => x.Email == req.Email && x.Otp == req.Otp && x.Expiry > DateTime.UtcNow);
            if (!validOtp) return (false, "Invalid or expired OTP");

            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = req.Email,
                Name = req.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                IsActive = true,
                Role = req.Role
            };

            _db.UserModel.Add(user);
            await _db.SaveChangesAsync();
            return (true, "User registered successfully");
        }
        public async Task<(bool Success, string Token)> Login(LoginRequest req)
        {
            var user = await _db.UserModel.FirstOrDefaultAsync(u => u.Email == req.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
                return (false, "Invalid credentials");
            // 2. Generate the Token
            var token = CreateJwtToken(user);

            return (true, token);
        }

        private string CreateJwtToken(UserModel user)
        {
            // Access the key from appsettings
            var secretKey = _config["JwtSettings:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.Name)
    };

            var token = new JwtSecurityToken(
                issuer: "StudentMgmtAPI",
                audience: "StudentMgmtAPI",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
        