namespace TUIFrameWork.Selection;

public interface ISelectable : IComponent
{
    void Select();
    void Deselect();
    void Act();
}