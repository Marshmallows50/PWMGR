using TUIFrameWork.Base;

namespace TUIFrameWork.Selection;

/// <summary>
/// Interface ISelectable inherits from IComponent and
/// defines what an ISelectable does and needs.
/// </summary>
public interface ISelectable : IComponent
{
    /// <summary>
    /// Selects the ISelectable
    /// </summary>
    public void Select();
    
    /// <summary>
    /// De-Selects the ISelectable
    /// </summary>
    public void Deselect();
    
    /// <summary>
    /// Performs an action associated with the ISelectable.
    /// </summary>
    public void Act();
}

