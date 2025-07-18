namespace MyPractice.Infrastructure.Helper;

public static class StringConvertor
{
    public static string ConvertImageToBase64(byte[] image)
    {
        return System.Convert.ToBase64String(image);
    }
}