namespace TUIFrameWork.Selection;

public interface ISelectable : IComponent
{
    public Selector? ParentSelector { get; set; }
    public Point Position {  get; set; }
    
    // void Draw();
    void Select();
    void Deselect();
    void Act();

}