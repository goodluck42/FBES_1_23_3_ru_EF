namespace CodeFirst.Services;

public interface IHasher
{
    byte[] HashString(string value);
}

