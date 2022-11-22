using TUIFrameWork.Containers;
using TUIFrameWork.Selection;
using TUIFrameWork.Selection.Components;
namespace TUIFrameWork.Selection.Containers;

public class RadioButtonGroup : Selector
{
    #region Fields and Properties
    public int indexOfToggled;
    
    public bool HasToggled { get; private set; }
    #endregion

    #region Constructor
    public RadioButtonGroup(bool isEscapable=true, int gap=1, LayoutDirection direction=LayoutDirection.Column, Point? position=null)
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
        if (item is RadioButton radioButton)
        {
            selectableItems.Add(radioButton);
            ProcessDimensions();
            CalculatePosition(radioButton);
            
            if (selectableItems.Count == 1)
            {
                selected = selectableItems[0];
            }
            
            
        }
        else
        {
            throw new Exception("Cannot add Non-RadioButton objects to RadioButtonGroup");
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
                case ConsoleKey.Enter when !HasToggled:
                    selected.Act();
                    HasToggled = true;
                    indexOfToggled = selectableItems.IndexOf(selected);
                    break;
                case ConsoleKey.Enter:
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
                    break;
                }
                case ConsoleKey.Escape when IsEscapable:
                    selected.Deselect();
                    isMonitoringInput = false;
                    break;
            }
        }
    }
    #endregion
}