namespace TUIFrameWork.Containers;

public static class Frame
{
    // Static Fields
    public static int WindowHeight { get; }
    public static int WindowWidth { get; }
    private static bool IsWindows;

    // Properties
    public static Panel MainPanel { get; private set; }
    public static string Title { get; private set; }
    
    
    
    /// <summary>
    /// static ctor of Frame. Trys to set the window and buffer size
    /// of the console, but will fail if not running on Windows OS.
    /// </summary>
    static Frame()
    {
        try
        {
            Console.SetWindowSize(100,30);
            Console.SetBufferSize(100,30);
        }
        catch (Exception e)
        {
            IsWindows = false;
        }
        
        WindowHeight = Console.WindowHeight;
        WindowWidth = Console.WindowWidth;
    }

    #region Functionality Methods
    /// <summary>
    /// Sets <code>panel</code> as the main panel, which is the initial panel that
    /// is drawn when the program starts.
    /// </summary>
    /// <param name="panel"></param>
    public static void SetMainContentPanel(Panel panel)
    {
        MainPanel = panel;
        // do some stuff?
    }

    /// <summary>
    /// Sets <code>text</code> as the title to display in the console title bar.
    /// </summary>
    /// <param name="text"></param>
    public static void SetTitle(string text)
    {
        Title = text;
        Console.Title = Title;
    }
    #endregion

    #region Utility Methods
    /// <summary>
    /// Sets the position of the cursor to <code>point</code>
    /// </summary>
    /// <param name="point"></param>
    public static void SetCursorToPoint(Point point)
    {
        Console.SetCursorPosition(point.X, point.Y);
    }
    
    /// <summary>
    /// Sets cursor position to <code>position</code> if <code>position</code> is not null.
    /// </summary>
    /// <param name="position"></param>
    /// <returns>true if the cursor position was set to <code>position</code> and false otherwise</returns>
    public static bool TrySetCursorToPoint(Point position)
    {
        try
        {
            SetCursorToPoint(position);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /// <summary>
    /// Gets and returns the current position of the cursor as a Point
    /// </summary>
    /// <returns>current position of the cursor as a Point</returns>
    public static Point GetCursorPositionAsPoint()
    {
        return new Point(Console.CursorLeft, Console.CursorTop);
    }
    #endregion
}