using System.Text;

namespace Task_002;

internal class Box
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
        return (boxOnTop.Length <= Length && boxOnTop.Width <= Width);
    }
}
