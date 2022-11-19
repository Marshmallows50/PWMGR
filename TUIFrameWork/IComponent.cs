namespace TUIFrameWork;

public interface IComponent
{
    #region Properties
    public Point Position { get; set; }
    public int Width { get; }
    public int Height { get; }
    #endregion

    #region Methods
    void Draw();
    void ProcessDimensions();
    #endregion
}