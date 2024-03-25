using System.Text;

namespace Task_002;

public class Box
{
    public int Length { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public const int MIN_DIMENSION = 1;
    public const int MAX_DIMENSION = 10;

    public Box()
    {
        Random random = new();
        Length = random.Next(MIN_DIMENSION, MAX_DIMENSION);
        Width = random.Next(MIN_DIMENSION, MAX_DIMENSION);
        Height = random.Next(MIN_DIMENSION, MAX_DIMENSION);
    }

    public Box(int width, int length, int height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public Box(Box box)
    {
        Length = box.Length;
        Width = box.Width;
        Height = box.Height;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append($"\tW = {Width}");
        sb.Append($"\tL = {Length}");
        sb.Append($"\tH = {Height}");
        return sb.ToString();
    }

    public bool CanPassedBoxBePlacedOnTop(Box boxOnTop)
    {
        bool statement = (boxOnTop.Length <= Length && boxOnTop.Width <= Width);
        //Console.WriteLine($"Can box {boxOnTop} \tbe on top {this} \t? ==> {statement}");
        return statement;
    }

    public static bool operator <=(Box box1, Box box2)
    {
        return (box1.Length <= box2.Length && box1.Width <= box2.Width);
    }

    public static bool operator >=(Box box1, Box box2)
    {
        return (box1.Length >= box2.Length && box1.Width >= box2.Width);
    }
}