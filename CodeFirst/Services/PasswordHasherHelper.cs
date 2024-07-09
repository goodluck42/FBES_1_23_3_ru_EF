namespace CodeFirst.Services;

public static class PasswordHasherHelper
{
    public static string ByteArrayToString(byte[] array)
    {
        return Convert.ToHexString(array);
    }
}