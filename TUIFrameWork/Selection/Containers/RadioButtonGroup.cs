using TUIFrameWork.Selection;
using TUIFrameWork.Selection.Components;
namespace TUIFrameWork.Selection.Containers;

public class RadioButtonGroup : Selector
{
    // fields
    public int indexOfToggled;
    
    //properties
    public bool IsEscapable { get; }
    public bool HasToggled { get; internal set; }
    
    #region Constructor
    // Constructor
    public RadioButtonGroup(bool isEscapable=true)
    {
        selectableItems = new List<ISelectable>();
        IsEscapable = isEscapable;
    }
    #endregion

    #region Abstract Class Method Overrides
    // adds a RadioButton to the RadioButton Group
    public override void Add(ISelectable item)
    {
        if (item is RadioButton radioButton)
        {
            selectableItems.Add(radioButton);
            if (selectableItems.Count == 1)
            {
                selected = selectableItems[0];
            }
            SetAsChild(item);
        }
        else
        {
            throw new Exception("Cannot add Non-RadioButton objects to RadioButtonGroup");
        }
    }

    public override void MonitorInput()
    {
        while (isMonitoringInput)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            // TODO: Make this a switch statement
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
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
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
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
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (!HasToggled)
                {
                    selected.Act();
                    HasToggled = true;
                    indexOfToggled = selectableItems.IndexOf(selected);

                }
                else
                {
                    foreach (ISelectable item in selectableItems)
                    {
                        if (item is RadioButton button && button.Toggled)
                        {
                            button.Act();
                        }
                        item.Draw();
                    }
                    selected.Act();
                    indexOfToggled = selectableItems.IndexOf(selected);
                }
            }
            else if (keyInfo.Key == ConsoleKey.Escape && IsEscapable)
            {
                isMonitoringInput = false;
            }
        }
    }
    #endregion
}