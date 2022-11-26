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

        ProcessDimensions();
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
                
                int largest = 0;
                foreach (IComponent item in containedItems)
                {
                    if (item.Width > largest)
                        largest = item.Width;
                }

                Width = largest;
                break;
            
            case LayoutDirection.Row:
                foreach (IComponent item in containedItems)
                {
                    Width += item.Width + gap;
                }
                Width -= gap;

                int tallest = 0;
                foreach (IComponent item in containedItems)
                {
                    if (item.Height > tallest)
                        tallest = item.Height;
                }

                Height = tallest;
                break;
        }
        if (Parent!=null)
            Parent.ProcessDimensions();
    }
    
    //TODO: simplify this method to make a bit more efficient.
    protected override void CalculatePosition(IComponent item)
    {
        int index = containedItems.IndexOf((ISelectable) item);
        switch (direction)
        {
            case LayoutDirection.Column:
                item.Position = index == 0 ?
                    new Point(this.Position.X, this.Position.Y) : 
                    item.Position = new Point(this.Position.X, this.Position.Y + index + (index * gap));
                break;
            case LayoutDirection.Row:
                int sumWidthUntilIndex = 0;
                for (int i = 0; i < index; i++)
                {
                    sumWidthUntilIndex += containedItems[i].Width;
                }
                
                item.Position = index == 0 ? 
                    new Point(this.Position.X, this.Position.Y) : 
                    new Point(this.Position.X + sumWidthUntilIndex + (index*gap),this.Position.Y);
                break;
        }
    }
    
    public override void CalcAllPositions()
    {
        foreach (IComponent item in containedItems)
        {
            CalculatePosition(item);
        }
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
        ProcessDimensions();
        CalculatePosition(item);
        
        if (containedItems.Count == 1)
        {
            selected = (ISelectable) containedItems[0];
        }
    }
    
    public void Remove(ISelectable item)
    {
        containedItems.Remove(item);
        item.Parent = null;
        
        ProcessDimensions();
        CalcAllPositions();
    }

    public void SetColors(ConsoleColor background, ConsoleColor foreground)
    {
        backgroundColor = background;
        foregroundColor = foreground;
    }
    #endregion
}