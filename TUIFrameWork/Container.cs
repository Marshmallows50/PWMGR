namespace TUIFrameWork;

public abstract class Container : IComponent
{
    #region Fields and Properties
    protected LayoutDirection direction;
    protected int gap;
    
    public ConsoleColor foregroundColor = ConsoleColor.White;
    public ConsoleColor backgroundColor = ConsoleColor.Black;
    
    public Point Position { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    #endregion
    
    
    #region Interface Methods
    public abstract void Draw();
    public abstract void ProcessDimensions();

    #endregion
}