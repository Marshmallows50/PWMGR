using TUIFrameWork.Base;
using TUIFrameWork.Selection;
namespace TUIFrameWork.Containers;

/// <summary>
/// A container that can contain any IComponent. This Class is responsible for managing,
/// positioning, and drawing its children. It also manages user inputs for its children.
/// </summary>
public class Panel : Container
{
    // TODO: Add support for colors

    #region Fields and Properties
    internal IList<Selector> containers = new List<Selector>();
    private Selector monitoring;
    private int indexOfMonitoring;
    
    private bool isManuallySized;

    private double widthPercent;
    private double heightPercent;
    #endregion
    
    
    #region Constructor
    /// <summary>
    /// Constructor initializes a panel with the provided parameters.
    /// </summary>
    /// <param name="gap"></param>
    /// <param name="position"></param>
    public Panel(int gap=0, Point? position = null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        
        foregroundColor = ConsoleColor.White;
        backgroundColor = ConsoleColor.Black;
        
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
        
        switch (isManuallySized)
        {
            case true when Parent!=null:
                Width = (int)(Parent.Width * (widthPercent / 100));
                Height = (int)(Parent.Height * (heightPercent / 100));
                foreach (IComponent item in containedItems)
                {
                    if (item is Panel { isManuallySized: true })
                        item.ProcessDimensions();
                }
                break;
            case true when Parent==null:
                Width = (int)(Console.WindowWidth * (widthPercent / 100));
                Height = (int)(Console.WindowHeight * (heightPercent / 100));
                foreach (IComponent item in containedItems)
                {
                    if (item is Panel { isManuallySized: true })
                        item.ProcessDimensions();
                }
                break;
            default:
            {
                switch (direction)
                {
                    case LayoutDirection.Column:
                        Height = containedItems.Select(i => i.Height).Sum()
                                 + (containedItems.Count * gap) - gap;
                        Width = containedItems.Select(i => i.Width).Max();
                        break;
            
                    case LayoutDirection.Row:
                        Width = containedItems.Select(i => i.Width).Sum()
                                + (containedItems.Count * gap) - gap;
                        Height = containedItems.Select(i => i.Height).Max();
                        break;
                }
                break;
            }
        }
    }

    public override void CalculatePosition(IComponent item)
    {
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
    /// <summary>
    /// Adds item to the panel.
    /// </summary>
    /// <param name="item"></param>
    public void Add(IComponent item)
    {
        containedItems.Add(item);
        AddSelector(item);
        item.Parent = this;
    }
    
    /// <summary>
    /// Inserts item into panel at the given index.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    public void Insert(IComponent item, int index)
    {
        containedItems.Insert(index, item);
        AddSelector(item);
        item.Parent = this;
    }
    
    /// <summary>
    /// Removed item from Panel
    /// </summary>
    /// <param name="item"></param>
    public void Remove(IComponent item)
    {
        containedItems.Remove(item);
        RemoveSelector(item);
        item.Parent = null;
    }

    /// <summary>
    /// Returns the index of a given item in the panel.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>the index of a given item in the panel.</returns>
    public int GetIndex(IComponent item)
    {
        return containedItems.IndexOf(item);
    }
    
    /// <summary>
    /// Manually sizes the panel to the provided width and height.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetDimensions(double width, double height)
    {
        widthPercent = width;
        heightPercent = height;
        isManuallySized = true;
    }
    
    /// <summary>
    /// clears the panel from the console window.
    /// </summary>
    public void Clear()
    {
        for (int i = 0; i < Height; i++)
        {
            Console.Write(new string(' ', Width) + "\n");
            Console.SetCursorPosition(Position.X, Position.Y + 1 + i);
        }
    }
    #endregion
    
    
    #region Input Management
    private void AddSelector(IComponent item)
    {
        switch (item)
        {
            case Selector selector:
            {
                this.containers.Add(selector);
                if (Parent != null)
                    ((Panel) Parent).AddSelector(selector);
                break;
            }
            case Panel panel:
                containers = containers.Concat(panel.containers).Distinct().ToList();
                break;
        }
    }

    private void RemoveSelector(IComponent item)
    {
        switch (item)
        {
            case Selector selector:
            {
                this.containers.Remove(selector);
                if (Parent != null)
                    ((Panel) Parent).RemoveSelector(selector);
                break;
            }
            case Panel panel:
                containers = containers.Except(panel.containers).ToList();
                break;
        }
    }

    /// <summary>
    /// Manages Input of Panel. Allows user to select and interact
    /// with any Selector in the panel.
    /// </summary>
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
                    sumWidthUntilIndex += containedItems[i].Width + gap;
                
                item.Position.X = (index == 0) ? Position.X : Position.X + sumWidthUntilIndex;
                break;
        }
    }
    
    private void HorizontalCenter(IComponent item)
    {
        int index = containedItems.IndexOf(item);
        switch (direction)
        {
            case LayoutDirection.Column:
                item.Position.X = Position.X + (Width - item.Width) /2;
                break;
            
            case LayoutDirection.Row:
                int sumWidthOfItems = 0;
                int sumWidthUntilIndex = 0;

                for (int i = 0; i < containedItems.Count; i++)
                {
                    sumWidthOfItems += containedItems[i].Width + gap;
                    if (i < index)
                        sumWidthUntilIndex += containedItems[i].Width + gap;
                }
                sumWidthOfItems -= gap;

                int x = Position.X + (Width - sumWidthOfItems) /2;
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
                item.Position.X = Position.X + Width - item.Width;
                break;
            case LayoutDirection.Row:
                int sumWidthOfItems = 0;
                int sumWidthUntilIndex = 0;

                for (int i = 0; i < containedItems.Count; i++)
                {
                    sumWidthOfItems += containedItems[i].Width + gap;
                    if (i < index)
                        sumWidthUntilIndex += containedItems[i].Width + gap;
                }

                int startingP = Position.X + Width - sumWidthOfItems + gap;
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
                    sumHeightUntilIndex += containedItems[i].Height + gap;

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

                for (int i = 0; i < containedItems.Count; i++)
                {
                    sumHeightOfItems += containedItems[i].Height + gap;
                    if (i < index)
                        sumHeightUntilIndex += containedItems[i].Height + gap;
                }
                sumHeightOfItems -= gap;

                int y = Position.Y + (Height - sumHeightOfItems) / 2;
                if (y < 0)
                    y = 0;

                item.Position.Y = index == 0 ? y : y + sumHeightUntilIndex;
                break;
            case LayoutDirection.Row:
                item.Position.Y = Position.Y + (Height - item.Height) / 2;
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

                for (int i = 0; i < containedItems.Count; i++)
                {
                    sumHeightOfItems += containedItems[i].Height + gap;
                    if (i < index)
                        sumHeightUntilIndex += containedItems[i].Height + gap;
                }

                int startingP = Position.Y + Height - sumHeightOfItems + gap;
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