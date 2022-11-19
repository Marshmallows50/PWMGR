using TUIFrameWork.Containers;

namespace TUIFrameWork.Selection;

public abstract class Selector : Container
{
    #region Fields and Properties

    protected List<ISelectable> selectableItems;
    protected ISelectable selected;
    public bool isMonitoringInput;
    
    public bool IsEscapable { get; set; }
    #endregion
    
    
    #region Abstract Class Method Overrides
    public override void Draw()
    {
        Console.BackgroundColor = backgroundColor;
        Frame.SetCursorToPoint(Position);
        for (int i = 0; i < Height; i++)
        {
            Console.Write(new string(' ', Width) + "\n");
        }
        foreach (ISelectable item in selectableItems)
        {
            item.Draw();
        }
    }
    
    public override void ProcessDimensions()
    {
        Width = 0;
        Height = 0;
        switch (direction)
        {
            case LayoutDirection.Column:
                Height = selectableItems.Count + (selectableItems.Count * gap);
                
                int largest = 0;
                foreach (ISelectable item in selectableItems)
                {
                    if (item.Width > largest)
                        largest = item.Width;
                }

                Width = largest;
                break;
            
            case LayoutDirection.Row:
                foreach (ISelectable item in selectableItems)
                {
                    Width += item.Width + gap;
                }
                Width -= gap;

                int tallest = 0;
                foreach (ISelectable item in selectableItems)
                {
                    if (item.Height > tallest)
                        tallest = item.Height;
                }

                Height = tallest;
                break;
        }
    }
    
    protected override void CalculatePosition(IComponent item)
    {
        int index = selectableItems.IndexOf((ISelectable) item);
        switch (direction)
        {
            case LayoutDirection.Column:
                item.Position = index == 0 ?
                    new Point(this.Position.X, this.Position.Y) : 
                    item.Position = new Point(this.Position.X, this.Position.Y + index + (index * gap));
                break;
            case LayoutDirection.Row:
                int SumWidthUntilIndex = 0;
                for (int i = 0; i < index; i++)
                {
                    SumWidthUntilIndex += selectableItems[i].Width;
                }
                
                item.Position = index == 0 ? 
                    new Point(this.Position.X, this.Position.Y) : 
                    new Point(this.Position.X + SumWidthUntilIndex + (index*gap),this.Position.Y);
                break;
        }
    }
    
    public override void CalcAllPositions()
    {
        foreach (ISelectable item in selectableItems)
        {
            CalculatePosition(item);
        }
    }
    #endregion
    
    
    #region Abstract Methods
    public abstract void MonitorInput();
    
    public abstract void Add(ISelectable item);
    #endregion

    
    #region Regular Methods
    public void Remove(ISelectable item)
    {
        selectableItems.Remove(item);
    }

    public void SetColors(ConsoleColor background, ConsoleColor foreground)
    {
        backgroundColor = background;
        foregroundColor = foreground;
    }
    #endregion
}