using TUIFrameWork.Containers;
namespace TUIFrameWork.Selection.Containers;

public class Menu : Selector
{
    #region Constructor
    public Menu(bool isEscapable=false, int gap=0, LayoutDirection direction=LayoutDirection.Column, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        IsEscapable = isEscapable;
        
        this.selectableItems = new List<ISelectable>();
        this.gap = gap;
        this.direction = direction;
        
        ProcessDimensions();
    }
    #endregion

    #region Abstract Class Method Overrides
    public override void Add(ISelectable item)
    {
        switch (direction)
        {
            case LayoutDirection.Column:
                if (selectableItems.Count == 0)
                {
                    item.Position = new Point(this.Position.X, this.Position.Y);
                }
                else
                {
                    item.Position = new Point(this.Position.X, this.Position.Y + selectableItems.Count +
                                                               (selectableItems.Count * gap));
                }
                
                break;
            case LayoutDirection.Row:
                item.Position = selectableItems.Count == 0 ? 
                    new Point(this.Position.X, this.Position.Y) : new Point(this.Position.X + Width,this.Position.Y);
                break;
        }
        selectableItems.Add(item);
        
        if (selectableItems.Count == 1)
        {
            selected = selectableItems[0];
        }
        
        ProcessDimensions();
    }
    
    public override void MonitorInput()
    {
        isMonitoringInput = true;
        while (isMonitoringInput)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    try
                    {
                        selected.Deselect();
                        int newIndex = selectableItems.IndexOf(selected) - 1;
                        selected = selectableItems[newIndex];

                        selected.Select();
                    }
                    catch (Exception e)
                    {
                        selected = selectableItems[0];
                    }

                    break;
                case ConsoleKey.DownArrow:
                    try
                    {
                        selected.Deselect();
                        int newIndex = selectableItems.IndexOf(selected) + 1;
                        selected = selectableItems[newIndex];

                        selected.Select();
                    }
                    catch (Exception e)
                    {
                        selected = selectableItems[^1];
                    }

                    break;
                case ConsoleKey.Enter:
                    selected.Act();
                    break;
                case ConsoleKey.Escape when IsEscapable:
                    isMonitoringInput = false;
                    break;
            }
        }
    }
    #endregion
}