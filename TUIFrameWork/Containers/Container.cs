using System.Collections;
using TUIFrameWork.Base;
using TUIFrameWork.Containers;
namespace TUIFrameWork.Containers;

public enum HAlignment {Start, Center, End}
public enum VAlignment {Start, Center, End}

/// <summary>
/// Container abstract class inherits from IComponent and IEnumerable interfaces.
/// This class is responsible for defining what a container is and provides functionality
/// for subclasses.
/// </summary>
public abstract class Container : IComponent, IEnumerable<IComponent>
{
    #region Fields and Properties
    internal IList<IComponent> containedItems = new List<IComponent>();
    protected int gap;
    
    internal bool isMonitoringInput;

    public LayoutDirection direction;
    public HAlignment hAlignment;
    public VAlignment vAlignment;

    public ConsoleColor foregroundColor = ConsoleColor.White;
    public ConsoleColor backgroundColor = ConsoleColor.Black;
    
    public Point Position { get; set; }
    public int Width { get; internal set; }
    public int Height { get; internal set; }
    public Container? Parent { get; internal set; }

    Container? IComponent.Parent
    {
        get => this.Parent;
        set => this.Parent = value;
    }
    #endregion
    
    
    #region Inherited Interface Methods
    public void Draw()
    {
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
    /// <summary>
    /// Calculates the Positions of all items in the container. child container's item
    /// positions are also calculated recursively.
    /// </summary>
    public abstract void CalcAllPositions();
    
    /// <summary>
    /// Calculates the position of a single item in the container
    /// </summary>
    /// <param name="item"></param>
    public abstract void CalculatePosition(IComponent item);
    #endregion

    
    #region Enumeration Methods
    public IEnumerator<IComponent> GetEnumerator()
    {
        return containedItems.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion
}