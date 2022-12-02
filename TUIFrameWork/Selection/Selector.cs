using TUIFrameWork.Containers;

namespace TUIFrameWork.Selection;

public abstract class Selector : Container
{
    #region Fields and Properties
    protected ISelectable selected;
    
    public bool IsEscapable { get; set; }
    #endregion

    #region Constructor
    protected Selector(bool isEscapable=false, int gap=0, LayoutDirection direction=LayoutDirection.Column, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        IsEscapable = isEscapable;
        
        this.gap = gap;
        this.direction = direction;
    }
    #endregion
    
    
    #region Inherited Abstract Methods
    public override void ProcessDimensions()
    {
        Width = 0;
        Height = 0;
        switch (direction)
        {
            case LayoutDirection.Column:
                Height = containedItems.Count + (containedItems.Count * gap) - gap;
                Width = containedItems.Select(i => i.Width).Max();
                break;
            
            case LayoutDirection.Row:
                Width = containedItems.Select(i => i.Width).Sum()
                    + (containedItems.Count * gap) - gap;
                Height = containedItems.Select(i => i.Height).Max();
                break;
        }
        if (Parent!=null)
            Parent.ProcessDimensions();
    }
    
    protected override void CalculatePosition(IComponent item)
    {
        int index = containedItems.IndexOf((ISelectable) item);
        item.Position = new Point(Position.X, Position.Y);
        switch (direction)
        {
            case LayoutDirection.Column:
                if (index > 0)
                    item.Position.Y += index + (index * gap);
                break;
            case LayoutDirection.Row:
                int sumWidthUntilIndex = 0;
                for (int i = 0; i < index; i++)
                    sumWidthUntilIndex += containedItems[i].Width;

                if (index > 0)
                    item.Position.X += sumWidthUntilIndex + (index * gap);
                break;
        }
    }
    
    public override void CalcAllPositions()
    {
        foreach (IComponent item in containedItems)
            CalculatePosition(item);
    }
    #endregion
    
    
    #region Abstract Methods
    public abstract ConsoleKey MonitorInput();
    #endregion

    
    #region Regular Methods
    public void Add(ISelectable item)
    {
        containedItems.Add(item);
        item.Parent = this;

        if (containedItems.Count == 1)
            selected = (ISelectable) containedItems[0];
    }
    
    public void Remove(ISelectable item)
    {
        containedItems.Remove(item);
        item.Parent = null;
    }

    public void SetColors(ConsoleColor background, ConsoleColor foreground)
    {
        backgroundColor = background;
        foregroundColor = foreground;
    }
    #endregion
}