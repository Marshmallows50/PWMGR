namespace TUIFrameWork;

public interface IComponent
{
    #region Properties
    public Point Position { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    #endregion

    #region Methods
    void Draw();
    void ProcessDimensions();
    #endregion
}