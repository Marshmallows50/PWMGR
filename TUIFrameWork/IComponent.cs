namespace TUIFrameWork;

public interface IComponent
{
    public Point Position { get; set; }
    void Draw();
}