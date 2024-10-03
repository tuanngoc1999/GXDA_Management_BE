using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ClaimsPrincipal> AuthenticateAsync(string username, string password)
    {
        try
        {
            var user = await _context.Users
            .Where(u => u.Username == username)
            .SingleOrDefaultAsync();

            if (user == null)
                return null;

            var passwordHash = ComputeHash(password);

            if (user.Password != passwordHash)
                return null;

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("CatechistId", user.Id.ToString())
        };

            var identity = new ClaimsIdentity(claims, "jwt");
            return new ClaimsPrincipal(identity);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    private string ComputeHash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}

