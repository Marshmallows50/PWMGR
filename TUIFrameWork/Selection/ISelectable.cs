namespace TUIFrameWork.Selection;

public interface ISelectable
{
    public Selector? ParentSelector { get; set; }
    
    void Draw();
    void Select();
    void Deselect();
    void Act();

}