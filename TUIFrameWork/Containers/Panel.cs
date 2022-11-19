using TUIFrameWork.Selection;

namespace TUIFrameWork.Containers;

// public enum LayoutAlignment { Start, Center, End }

public class Panel : Container
{
    //TODO: should container two lists. One for each IComponent and one of Containers for the purpose of changing who is MonitorInput()-ing
    //TODO: justify-content and align-items equivalent

   
    //TODO: if size was set manually, ProcessDimensions should just do nothing.
    //TODO: if size is set manually, the values should be based off a percentage of parents dimensions. if panel has no parent, use Console.Window sizes

    //TODO: main panel should always have 100% Width and Height.
    
    // for now, just make it so height is always automatic. no need for manual setting of height
    // width still needs to be able to be set manually.
    
    #region Fields and Properties
    private IList<IComponent> containedItems = new List<IComponent>();
    private IList<Selector> selectorContainers = new List<Selector>();
    private Selector monitoring;
    private Container? parent;
    
    public bool isMainPanel; // might not be needed
    private bool isManuallySized; // might not be needed

    private double widthPercent;
    public int heightPercent;
    
    #endregion
    
    
    #region Constructor
    public Panel(LayoutDirection direction, int gap, int margin, Point? position = null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        
        this.direction = direction;
        this.gap = gap;

        parent = null;
        hAlignment = HAlignment.Start;
        // this.margin = margin;
        // Height = Console.WindowHeight;
        // Width = Console.WindowWidth;

    }
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
        foreach (IComponent item in containedItems)
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
                // Process Height if column
                
                foreach (IComponent item in containedItems)
                {
                    Height += item.Height;
                }
                if (containedItems.Count > 1)
                    Height += gap * (containedItems.Count - 1);
                
                // Process Width if column
                ProcessWidth(new Action(delegate
                {
                    foreach (IComponent item in containedItems)
                    {
                        if (item.Width > Width)
                            Width = item.Width;
                    }
                }));

                break;
            
            case LayoutDirection.Row:
                //Process Height if row
                foreach (IComponent item in containedItems)
                {
                    if (item.Height > Height)
                        Height = item.Height;
                }
                
                //Process Width if row
                ProcessWidth(new Action(delegate
                {
                    foreach (IComponent item in containedItems)
                    {
                        Width += item.Width;
                    }
                    if (containedItems.Count > 1)
                        Width += gap * (containedItems.Count - 1);
                }));

                break;
        }
    }

    protected override void CalculatePosition(IComponent item)
    {
        // item.Position = new Point(Position.X, Position.Y);
        switch (hAlignment)
        {                                            

            case HAlignment.Start:
                HorizontalStart(item);
                break;
            case HAlignment.Center:
                HorizontalCenter(item);
                break;
            case HAlignment.End:
                HorizontalEnd(item);
                break;
        }
    }

    public override void CalcAllPositions()
    {
        foreach (IComponent item in containedItems)
        {
            CalculatePosition(item);
            if (item is Container container)
            {
                container.CalcAllPositions();
            }
        }
    }

    #endregion

    #region Functionality Methods
    public void Add(IComponent item)
    {
        containedItems.Add(item);
        ProcessDimensions();
        // CalculatePosition(item);
        

        CalcAllPositions();
    }   
    
    public void setWidth(double width)
    {
        widthPercent = width;
        isManuallySized = true;
        ProcessDimensions();
    }

    private void ProcessWidth(Action codeBlock) 
    {
        if (!isManuallySized)
        {
            codeBlock.Invoke();
        }
        else
            try
            {
                 Width = (int)(parent.Width * (widthPercent / 100));
            }
            catch
            {
                Width = (int)(Console.WindowWidth * (widthPercent / 100));
            }
    }
    
    #endregion

    #region Position Calculation Methods
    private void HorizontalStart(IComponent item)
    {
        int index = containedItems.IndexOf(item);
        switch (direction)
        {
            case LayoutDirection.Column:
                int sumHeightUntilIndex = 0;
                for (int i = 0; i < index; i++)
                {
                    sumHeightUntilIndex += containedItems[i].Height + gap;
                }

                item.Position.Y = (index == 0) ? Position.Y : Position.Y + sumHeightUntilIndex;
                break;
                
            case LayoutDirection.Row:
                int sumWidthUntilIndex = 0;
                for (int i = 0; i < index; i++)
                {
                    sumWidthUntilIndex += containedItems[i].Width + gap;
                }

                item.Position.X = (index == 0) ? Position.X : Position.X + sumWidthUntilIndex;
                
                break;
        }
    }
    
    private void HorizontalCenter(IComponent item)
    {
        int index = containedItems.IndexOf(item);
        int x;
        switch (direction)
        {
            case LayoutDirection.Column:
                item.Position.X = (Width - item.Width) /2;
                break;
            
            case LayoutDirection.Row:
                int sumWidthOfItems = 0;
                int sumWidthUntilIndex = 0;

                foreach (IComponent containedItem in containedItems)
                    sumWidthOfItems += containedItem.Width + gap;
                
                for (int i = 0; i < index; i++)
                    sumWidthUntilIndex += containedItems[i].Width + gap;

                x = (Width - sumWidthOfItems - gap) /2;
                
                item.Position.X = index == 0 ? x : x + sumWidthUntilIndex;
                break;
        }
    }
    
    private void HorizontalEnd(IComponent item)
    {
        int index = containedItems.IndexOf(item);
        switch (direction)
        {
            case LayoutDirection.Column:
                item.Position.X = Width - item.Width;
                break;
            case LayoutDirection.Row:
                int sumWidthOfItems = 0;
                int sumWidthUntilIndex = 0;

                foreach (IComponent containedItem in containedItems)
                    sumWidthOfItems += containedItem.Width + gap;
                
                for (int i = 0; i < index; i++)
                    sumWidthUntilIndex += containedItems[i].Width + gap;

                int startingP = Width - sumWidthOfItems + gap;

                item.Position.X = index == 0 ? startingP : startingP + sumWidthUntilIndex;
                break;
                
        }
    }

    private void VerticalStart()
    {
        
    }

    private void VerticalCenter()
    {
        
    }

    private void VerticalEnd()
    {
        
    }

    #endregion
}