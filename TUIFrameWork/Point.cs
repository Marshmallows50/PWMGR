namespace TUIFrameWork;

/// <summary>
/// Defines a coordinate (x,y) to facilitate positioning objects on screen.
/// </summary>
public class Point
{
    // properties
    public int X { get; }
    public int Y { get; }

    
    //ctor Point
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    //returns the coordinate as a string in the format: (x, y)
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}