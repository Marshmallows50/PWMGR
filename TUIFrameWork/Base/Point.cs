namespace TUIFrameWork.Base;

/// <summary>
/// Defines a coordinate (x,y) to facilitate positioning objects on screen.
/// </summary>
public class Point
{
    #region Fields and Properties
    public int X { get; set; }
    public int Y { get; set; }
    #endregion
    
    /// <summary>
    /// Constructor for Point. Sets X and Y when creating a Point.
    /// </summary>
    /// <param name="x"></param> coordinate
    /// <param name="y"></param> coordinate
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Returns the coordinate as a string in the format: (x, y).
    /// </summary>
    /// <returns>The coordinate as a string in the format: (x, y)</returns>
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}