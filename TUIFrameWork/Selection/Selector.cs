namespace TUIFrameWork.Selection;

public abstract class Selector
{
    //fields
    protected List<ISelectable> selectableItems;
    protected ISelectable selected;
    public bool isMonitoringInput;

    
    #region Abstract Methods
    //Determines which menu item is selected and what to do with it.
    public abstract void MonitorInput();
    public abstract void Add(ISelectable item);
    #endregion

    #region Regular Methods
    public void Remove(ISelectable item)
    {
        selectableItems.Remove(item);
        UnSetAsChild(item);
    }

    public void DrawItems()
    {
        foreach (ISelectable item in selectableItems)
        {
            item.Draw();
        }
    }

    protected void SetAsChild(ISelectable item)
    {
        item.ParentSelector = this;
    }

    private void UnSetAsChild(ISelectable item)
    {
        item.ParentSelector = null;
    }
    #endregion



}