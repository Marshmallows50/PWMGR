using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;

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
        selectableItems.Add(item);
        ProcessDimensions();
        CalculatePosition(item);
        
        if (selectableItems.Count == 1)
        {
            selected = (ISelectable) selectableItems[0];
        }
        
        
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