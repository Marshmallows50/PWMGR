using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection;
namespace TUIFrameWork.Selection.Containers;

/// <summary>
/// Responsible for creating a container for Selectable items and providing selecting functionality
/// All menu items are added this way and functionality is determined by item selected in menu.
/// </summary>
public class Menu : Selector
{
    //fields
    public bool IsEscapable { get; set; }
    
    #region Constructor
    //ctor for Menu.
    public Menu(bool isEscapable=false, LayoutDirection direction=LayoutDirection.Column, int gap=0, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        selectableItems = new List<ISelectable>();
        IsEscapable = isEscapable;
        
        this.gap = gap;
        this.direction = direction;
        ProcessDimensions();
    }
    #endregion

    #region Abstract Class Method Overrides
    //Adds a menu item to our menu.
    public override void Add(ISelectable item)
    {
        // TODO: Determine and assign item.Position based off of gap. update width and height
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
                if (selectableItems.Count == 0)
                {
                    item.Position = new Point(this.Position.X, this.Position.Y);
                }
                else
                {
                    item.Position = new Point(this.Position.X + width,this.Position.Y);
                }

                break;
                
        }
        selectableItems.Add(item);
        ProcessDimensions();
        if (selectableItems.Count == 1)
        {
            selected = selectableItems[0];
        }
        
        SetAsChild(item);
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
                selected.Act();
            }
            else if (keyInfo.Key == ConsoleKey.Escape && IsEscapable)
            {
                isMonitoringInput = false;
            }
        }
    }
    #endregion
}

