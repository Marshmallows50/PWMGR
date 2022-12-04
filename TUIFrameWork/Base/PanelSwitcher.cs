using TUIFrameWork.Containers;

namespace TUIFrameWork.Base;

/// <summary>
/// Allows a panel to take the place of another panel with a parent container.
/// </summary>
public class PanelSwitcher
{
    #region Fields and Properties
    public Panel CurrentPanel { get; private set; }
    private int index;
    #endregion
    
    
    #region Constructor
    /// <summary>
    /// Constructor for PanelSwitcher. Sets panelToSwitch as CurrentPanel. CurrentPanel is
    /// the panel to be replaced when calling the SwitchTo(Panel newPanel) method.
    /// </summary>
    /// <param name="panelToSwitch"></param> must have a parent container.
    public PanelSwitcher(Panel panelToSwitch)
    {
        CurrentPanel = panelToSwitch;
        if (CurrentPanel.Parent != null) 
            index = ((Panel)CurrentPanel.Parent).GetIndex(CurrentPanel);
    }
    #endregion
    
    
    #region Functionality Methods
    /// <summary>
    /// Method replaces the CurrentPanel with <code>newPanel</code> in CurrentPanel's parent container.
    /// </summary>
    /// <param name="newPanel"></param> is the panel to replace CurrentPanel.
    public void SwitchTo(Panel newPanel)
    {
        if (CurrentPanel.Parent != null)
        {
            index = ((Panel)CurrentPanel.Parent).GetIndex(CurrentPanel);
            ((Panel)CurrentPanel.Parent).Insert(newPanel, index);
            ((Panel)CurrentPanel.Parent).Remove(CurrentPanel);
        }
        CurrentPanel = newPanel;
    }
    #endregion
}