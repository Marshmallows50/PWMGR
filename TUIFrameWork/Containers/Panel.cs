using TUIFrameWork.Selection;
namespace TUIFrameWork.Containers;

public class Panel : Container
{
    // TODO: Add support for colors

    #region Fields and Properties
    private IList<Selector> containers = new List<Selector>();
    private Selector monitoring;
    private int indexOfMonitoring;
    
    private bool isManuallySized;

    private double widthPercent;
    private double heightPercent;
    
    
    #endregion
    
    
    #region Constructor
    public Panel(int gap, Point? position = null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        
        this.gap = gap;
        
        direction = LayoutDirection.Column;
        hAlignment = HAlignment.Start;
        vAlignment = VAlignment.Start;
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
                // Process Height if column
                ProcessHeight( new Action(delegate
                {
                    foreach (IComponent item in containedItems)
                    {
                        Height += item.Height;
                    }
                    if (containedItems.Count > 1)
                        Height += gap * (containedItems.Count - 1);
                }));

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
                ProcessHeight(new Action(delegate
                {
                    foreach (IComponent item in containedItems)
                    {
                        if (item.Height > Height)
                            Height = item.Height;
                    }
                }));

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
        if (Parent != null)
            Parent.ProcessDimensions();
    }

    protected override void CalculatePosition(IComponent item)
    {
        item.Position = new Point(Position.X, Position.Y);
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

        switch (vAlignment)
        {
            case VAlignment.Start:
                VerticalStart(item);
                break;
            case VAlignment.Center:
                VerticalCenter(item);
                break;
            case VAlignment.End:
                VerticalEnd(item);
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
        if (item is Panel panel)
            GetSelectors(panel);

        item.Parent = this;
        ProcessDimensions();
        CalculatePosition(item);
    }
    
    public void Remove(IComponent item)
    {
        containedItems.Remove(item);
        if (item is Panel panel)
            RemoveSelectors(panel);

        item.Parent = null;
        ProcessDimensions();
        CalcAllPositions();
    }
    
    private void GetSelectors(Panel panel)
    {
        foreach (IComponent component in panel)
        {
            switch (component)
            {
                case Selector childSelector:
                    containers.Add(childSelector);
                    if (Parent != null)
                        ((Panel) Parent).containers.Add(childSelector);
                    
                    break;
                case Panel childPanel:
                    GetSelectors(childPanel);
                    break;
            }
        }
    }

    private void RemoveSelectors(Panel panel)
    {
        foreach (IComponent component in panel)
        {
            switch (component)
            {
                case Selector childSelector:
                    if (panel.Contains(childSelector))
                    {
                        containers.Remove(childSelector);
                        if (Parent != null)
                            ((Panel) Parent).containers.Remove(childSelector);
                    }

                    break;
                case Panel childPanel:
                    RemoveSelectors(childPanel);
                    break;
            }
        }
    }
    
    public void ManageInput()
    {
        monitoring = containers[0];
        isMonitoringInput = true;
        while (isMonitoringInput)
        {
            switch (monitoring.MonitorInput())
            {
                case ConsoleKey.PageUp:
                    try
                    {
                        int newIndex = containers.IndexOf(monitoring) - 1;
                        monitoring = containers[newIndex];
                    }
                    catch
                    {
                        monitoring = containers[0];
                    }
                    break;
                
                case ConsoleKey.PageDown:
                    try
                    {
                        int newIndex = containers.IndexOf(monitoring) + 1;
                        monitoring = containers[newIndex];
                    }
                    catch
                    {
                        monitoring = containers[^1];
                    }
                    break;
                
                case ConsoleKey.Escape:
                    isMonitoringInput = false;
                    break;
            }
        }
    }

    public void RefreshEverything() 
    {
        // if Framework is use correctly, this should probably not be used, but just in case here it is
        foreach (IComponent item in containedItems)
        {
            if (item is not Panel panel) continue;
            RemoveSelectors(panel);
            GetSelectors(panel);
        }
        ProcessDimensions();
        CalcAllPositions();
    }
    #endregion

    
    #region Dimension Calculation Methods
    public void SetWidth(double width)
    {
        widthPercent = width;
        isManuallySized = true;
        ProcessDimensions();
    }

    private void ProcessWidth(Action widthBlock) 
    {
        if (isManuallySized == false)
            widthBlock.Invoke();
        else
            try
            {
                Width = (int)(Parent.Width * (widthPercent / 100));
            }
            catch
            {
                Width = (int)(Console.WindowWidth * (widthPercent / 100));
            }
    }

    public void SetHeight(double height)
    {
        heightPercent = height;
        isManuallySized = true;
        ProcessDimensions();
    }
    
    private void ProcessHeight(Action heightBlock)
    {
        if (isManuallySized == false)
            heightBlock.Invoke();
        else
            try
            {
                Height = (int)(Parent.Height * (heightPercent / 100));
            }
            catch
            {
                Height = (int)(Console.WindowHeight * (heightPercent / 100));
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
                item.Position.X = Position.X;
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
                if (x < 0)
                    x = 0;
                
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
                if (startingP < 0)
                    startingP = 0;

                item.Position.X = index == 0 ? startingP : startingP + sumWidthUntilIndex;
                break;
                
        }
    }

    private void VerticalStart(IComponent item)
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
                item.Position.Y = Position.Y;
                break;
        }
        
    }

    private void VerticalCenter(IComponent item)
    {
        int index = containedItems.IndexOf(item);
        switch (direction)
        {
            case LayoutDirection.Column:
                int sumHeightOfItems = 0;
                int sumHeightUntilIndex = 0;

                foreach (IComponent containedItem in containedItems)
                    sumHeightOfItems += containedItem.Height + gap;

                for (int i = 0; i < index; i++)
                    sumHeightUntilIndex += containedItems[i].Height + gap;

                int y = (Height - sumHeightOfItems - gap) / 2;
                if (y < 0)
                    y = 0;

                item.Position.Y = index == 0 ? y : y + sumHeightUntilIndex;
                break;
            
            case LayoutDirection.Row:
                item.Position.Y = (Height - item.Height) / 2;
                break;
        }
    }

    private void VerticalEnd(IComponent item)
    {
        int index = containedItems.IndexOf(item);
        switch (direction)
        {
            case LayoutDirection.Column:
                int sumHeightOfItems = 0;
                int sumHeightUntilIndex = 0;

                foreach (IComponent containedItem in containedItems)
                    sumHeightOfItems += containedItem.Height + gap;

                for (int i = 0; i < index; i++)
                    sumHeightUntilIndex += containedItems[i].Height + gap;

                int startingP = Height - sumHeightOfItems + gap;
                if (startingP < 0)
                    startingP = 0;
                
                item.Position.Y = index == 0 ? startingP : startingP + sumHeightUntilIndex;
                break;
            case LayoutDirection.Row:
                item.Position.Y = Height - item.Height;
                break;
        }
    }
    #endregion
}