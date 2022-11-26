namespace TUIFrameWork.Selection.Containers;

public class Menu : Selector
{
    #region Constructor
    public Menu(bool isEscapable = false, int gap = 0, LayoutDirection direction = LayoutDirection.Column,
        Point? position = null) : base(isEscapable, gap, direction, position) { }
    #endregion

    #region Inherited Abstract Methods
    public override ConsoleKey MonitorInput()
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
                        int newIndex = containedItems.IndexOf(selected) - 1;
                        selected = (ISelectable)containedItems[newIndex];
                        selected.Select();
                    }
                    catch
                    {
                        selected = (ISelectable) containedItems[0];
                    }
                    break;
                
                case ConsoleKey.DownArrow:
                    try
                    {
                        selected.Deselect();
                        int newIndex = containedItems.IndexOf(selected) + 1;
                        selected = (ISelectable) containedItems[newIndex];

                        selected.Select();
                    }
                    catch
                    {
                        selected = (ISelectable) containedItems[^1];
                    }
                    break;
                
                case ConsoleKey.Enter:
                    selected.Act();
                    break;
                
                case ConsoleKey.Escape when IsEscapable:
                    // isMonitoringInput = false;
                    return ConsoleKey.Escape;

                case ConsoleKey.PageUp when IsEscapable:
                    // isMonitoringInput = false;
                    return ConsoleKey.PageUp;
                
                case ConsoleKey.PageDown when IsEscapable:
                    // isMonitoringInput = false;
                    return ConsoleKey.PageDown;
            }
        }

        // should be unreachable but makes compiler happy
        return ConsoleKey.A;
    }
    
    #endregion
}