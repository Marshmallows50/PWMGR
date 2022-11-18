using System.Collections;
using System.Runtime.InteropServices;
using TUIFrameWork.Selection;

namespace TUIFrameWork.Containers;

// public enum LayoutAlignment { Start, Center, End }

public class Panel : Container
{
    //TODO: should container two lists. One for each IComponent and one of Containers for the purpose of changing who is MonitorInput()-ing
    //TODO: justify-content and align-items equivalent

    //TODO: size (Width and Height) should be automatic until the user sets it manually. Constructor should not initialize Width and Height.
    //TODO: if size was set manually, ProcessDimensions should just do nothing.
    //TODO: if size is set manually, the values should be based off a percentage of parents dimensions. if panel has no parent, use Console.Window sizes

    //TODO: main panel should always have 100% Width and Height.
    
    
    #region Fields and Properties
    private IList<IComponent> containedItems = new List<IComponent>();
    private IList<Selector> selectorContainers = new List<Selector>();
    private Selector monitoring;
    private Container parent;
    #endregion
    
    
    #region Constructor
    public Panel(LayoutDirection direction, int gap, Point? position = null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        
        this.direction = direction;
        this.gap = gap;
    }
    #endregion

    #region Abstract Class Method Overrides
    public override void Draw()
    {
        throw new NotImplementedException();
    }

    public override void ProcessDimensions()
    {
        throw new NotImplementedException();
    }
    #endregion
}