namespace TUIFrameWork;

public interface IComponent
{
    public Point Position { get; set; }
    public int width { get; set; }
    void Draw();
}