using TUIFrameWork.Containers;

namespace TUIFrameWork.Base;
/// <summary>
/// Interface IComponent defines what an IComponent does and needs
/// </summary>
public interface IComponent
{
    #region Properties
    public Point Position { get; set; }
    public int Width { get; }
    public int Height { get; }
    public Container? Parent { get; set; }
    
    public ConsoleColor foregroundColor { get; set; }
    public ConsoleColor backgroundColor { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Draws the IComponent
    /// </summary>
    void Draw();
    
    /// <summary>
    /// Determines the Height and Width of the IComponent
    /// </summary>
    void ProcessDimensions();

    public void InheritColors();

    #endregion
}