using TUIFrameWork.Containers;

namespace TUIFrameWork.Selection;

public abstract class Selector : IComponent
{
    //fields
    protected LayoutDirection direction;
    protected int gap;
    protected List<ISelectable> selectableItems;
    protected ISelectable selected;
    public bool isMonitoringInput;
    
    public ConsoleColor foregroundColor = ConsoleColor.White;
    public ConsoleColor backgroundColor = ConsoleColor.Black;
    
    
    public Point Position {  get; set; }
    public int width { get; set; }
    public int height { get; set; }

    

        #region Interface Methods
    public void Draw()
    {
        DrawItems();
    }
    #endregion
    
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
        Console.BackgroundColor = backgroundColor;
        Frame.SetCursorToPoint(Position);
        for (int i = 0; i < height; i++)
        {
            Console.Write(new string(' ', width) + "\n");
        }
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

    public void SetColors(ConsoleColor background, ConsoleColor foreground)
    {
        backgroundColor = background;
        foregroundColor = foreground;
    }

    protected void ProcessDimensions()
    {
        switch (direction)
        {
            case LayoutDirection.Column:
                height = selectableItems.Count + (selectableItems.Count * gap);
                
                int largest = 0;
                foreach (ISelectable item in selectableItems)
                {
                    if (item.width > largest)
                    {
                        largest = item.width;
                    }
                }

                width = largest;
                break;
            
            case LayoutDirection.Row:
                width = 0;
                foreach (ISelectable item in selectableItems)
                {
                    width += item.width + gap;
                }

                height = 1;
                break;
                
        }
    }
    #endregion



}