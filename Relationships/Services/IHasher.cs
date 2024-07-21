namespace Relationships.Services;

public interface IHasher
{
    byte[] HashString(string value);
}

