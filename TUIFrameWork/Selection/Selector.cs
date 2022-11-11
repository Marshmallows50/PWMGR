namespace TUIFrameWork.Selection;

public abstract class Selector
{
    //fields
    protected List<ISelectable> selectableItems;
    protected ISelectable selected;
    public bool isMonitoringInput;
    
    // methods
    public abstract void Add(ISelectable item);

    public void Remove(ISelectable item)
    {
        selectableItems.Remove(item);
    }

    public void DrawItems()
    {
        foreach (ISelectable item in selectableItems)
        {
            item.Draw();
        }
    }

    //Determines which menu item is selected and what to do with it.
    public abstract void MonitorInput();
}