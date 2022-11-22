using TUIFrameWork.Selection.Components;
namespace TUIFrameWork.Selection.Containers;

public class RadioButtonGroup : Selector
{
    #region Fields and Properties
    public bool HasToggled { get; private set; }
    #endregion

    #region Constructor
    public RadioButtonGroup(bool isEscapable=true, int gap=1, LayoutDirection direction=LayoutDirection.Column,
        Point? position=null) : base(isEscapable, gap, direction, position) { }
    #endregion

    #region Inherited Abstract Methods
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
                        int newIndex = containedItems.IndexOf(selected) - 1;
                        selected = (ISelectable) containedItems[newIndex];
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
                
                case ConsoleKey.Enter when !HasToggled:
                    selected.Act();
                    HasToggled = true;
                    break;
                
                case ConsoleKey.Enter:
                    foreach (IComponent item in containedItems)
                    {
                        if (item is RadioButton button && button.Toggled)
                            button.Act();
                        item.Draw();
                    }
                    selected.Act();
                    break;
                
                case ConsoleKey.Escape when IsEscapable:
                    selected.Deselect();
                    isMonitoringInput = false;
                    break;
            }
        }
    }
    #endregion
    
    public void Add(RadioButton item)
    {
        base.Add(item);
    }
}