using MyPractice.CleanArchitecture.Domain.Common;
using MyPractice.CleanArchitecture.Domain.Exceptions;

namespace MyPractice.CleanArchitecture.Domain.ValueObjects;

public sealed class Colour(string code) : ValueObject
{
    public static Colour White => new("#FFFFFF");

    public static Colour Red => new("#FF5733");

    public static Colour Orange => new("#FFC300");

    public static Colour Yellow => new("#FFFF66");

    public static Colour Green => new("#CCFF99");

    public static Colour Blue => new("#6666FF");

    public static Colour Purple => new("#9966CC");

    public static Colour Grey => new("#999999");

    public string Code { get; private set; } = string.IsNullOrWhiteSpace(code)?"#000000":code;
    
    public static Colour From(string code)
    {
        var colour = new Colour(code);
        Console.WriteLine(SupportedColours);
        var colours = SupportedColours;
        var coloursList = SupportedColourCodes.ToList();
        if (!coloursList.Contains(colour.ToString()))
        {
            throw new UnsupportedColourException(code);
            //throw new Exception(code);// UnsupportedColourException(code);
        }

        return colour;
    }
    public static implicit operator string(Colour colour)
    {
        return colour.ToString();
    }

    public static explicit operator Colour(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return Code;
    }

    public static IEnumerable<Colour> SupportedColours
    {
        get
        {
            yield return White;
            yield return Red;
            yield return Orange;
            yield return Yellow;
            yield return Green;
            yield return Blue;
            yield return Purple;
            yield return Grey;
        }
    }
    public static IEnumerable<string> SupportedColourCodes
    {
        get
        {
            yield return White.ToString();
            yield return Red.ToString();
            yield return Orange.ToString();
            yield return Yellow.ToString();
            yield return Green.ToString();
            yield return Blue.ToString();
            yield return Purple.ToString();
            yield return Grey.ToString();
        }
    }

    public IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}