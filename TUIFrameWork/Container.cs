namespace TUIFrameWork;

public enum HAlignment {Start, Center, End}
public abstract class Container : IComponent
{
    #region Fields and Properties
    protected LayoutDirection direction;
    protected int gap;

    public HAlignment hAlignment;

    public ConsoleColor foregroundColor = ConsoleColor.White;
    public ConsoleColor backgroundColor = ConsoleColor.Black;
    
    public Point Position { get; set; }
    public int Width { get; internal set; }
    public int Height { get; internal set; }
    #endregion
    
    
    #region Interface Methods
    public abstract void Draw();
    public abstract void ProcessDimensions();
    #endregion

    
    #region Abstract Methods
    public abstract void CalcAllPositions();
    protected abstract void CalculatePosition(IComponent item);
    #endregion
}