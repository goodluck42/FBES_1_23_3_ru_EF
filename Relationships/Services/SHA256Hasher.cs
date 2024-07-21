using System.Security.Cryptography;
using System.Text;

namespace Relationships.Services;

// ReSharper disable once InconsistentNaming
public class SHA256Hasher : IHasher
{
    public byte[] HashString(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        
        return SHA256.HashData(bytes);
    }
}