namespace TUIFrameWork.Selection;

public interface ISelectable : IComponent
{
    public void Select();
    public void Deselect();
    public void Act();
}