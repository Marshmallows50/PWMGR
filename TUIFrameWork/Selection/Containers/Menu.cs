using TUIFrameWork.Base;

namespace TUIFrameWork.Selection.Containers;

/// <summary>
/// A Selector able to contain any ISelectable.
/// </summary>
public class Menu : Selector
{
    #region Constructor

    /// <summary>
    /// Initializes a new Menu with the provided parameters
    /// </summary>
    /// <param name="isEscapable"></param>
    /// <param name="gap"></param>
    /// <param name="direction"></param>
    /// <param name="position"></param>
    public Menu(bool isEscapable = false, int gap = 0, LayoutDirection direction = LayoutDirection.Column,
        Point? position = null) : base(isEscapable, gap, direction, position)
    {
        foregroundColor = ConsoleColor.White;
        backgroundColor = ConsoleColor.Black;
    }
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
                        selected.Select();
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
                        selected.Select();
                    }
                    break;
                
                case ConsoleKey.Enter:
                    selected.Act();
                    break;
                
                case ConsoleKey.Escape when IsEscapable:
                    return ConsoleKey.Escape;

                case ConsoleKey.PageUp when IsEscapable:
                    return ConsoleKey.PageUp;
                
                case ConsoleKey.PageDown when IsEscapable:
                    return ConsoleKey.PageDown;
            }
        }

        // should be unreachable but makes compiler happy
        return ConsoleKey.A;
    }
    
    #endregion
}