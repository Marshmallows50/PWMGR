using TUIFrameWork.Containers;

namespace TUIFrameWork;

public enum HAlignment {Start, Center, End}
public enum VAlignment {Start, Center, End}
public abstract class Container : IComponent
{
    #region Fields and Properties
    protected IList<IComponent> containedItems = new List<IComponent>();
    protected int gap;

    public LayoutDirection direction;
    public HAlignment hAlignment;
    public VAlignment vAlignment;

    public ConsoleColor foregroundColor = ConsoleColor.White;
    public ConsoleColor backgroundColor = ConsoleColor.Black;
    
    public Point Position { get; set; }
    public int Width { get; internal set; }
    public int Height { get; internal set; }
    #endregion
    
    
    #region Inherited Interface Methods
    public void Draw()
    {
        ProcessDimensions();
        Console.BackgroundColor = backgroundColor;
        Frame.SetCursorToPoint(Position);
        for (int i = 0; i < Height; i++)
        {
            Console.Write(new string(' ', Width) + "\n");
            Console.SetCursorPosition(Position.X, Position.Y + 1 + i);
        }
        foreach (IComponent item in containedItems)
        {
            item.Draw();
        }
    }
    
    public abstract void ProcessDimensions();
    #endregion

    
    #region Abstract Methods
    public abstract void CalcAllPositions();
    protected abstract void CalculatePosition(IComponent item);
    #endregion
}