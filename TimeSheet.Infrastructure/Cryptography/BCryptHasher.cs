using BC = BCrypt.Net.BCrypt;
using TimeSheet.Application.Interfaces;

namespace TimeSheet.Infrastructure.Cryptography;

public class BCryptHasher : IPasswordHasher
{
    public string Hash(string password) => BC.HashPassword(password);

    public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
}
