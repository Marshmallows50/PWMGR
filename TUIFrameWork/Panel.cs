namespace TUIFrameWork;

public static class Panel
{
    //sets cursor to updated positions.
    public static void SetCursorToPoint(Point point)
    {
        Console.SetCursorPosition(point.X, point.Y);
    }
}