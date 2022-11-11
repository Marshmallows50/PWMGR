namespace TUIFrameWork.Selection.Components;


/// <summary>
/// The Menu Class is responsible for our Menu functionality.
///Using the arrow keys, the user  can select and activate a menu item such as Start Game or View Scores.
/// </summary>
public class MenuItem : ISelectable
{   
    //fields
    private Point position;
    private string text;
    public Action? action;
    
    #region Contructor
    // ctor for MenuItem
    public MenuItem(Point position, string text)
    {
        this.position = position;
        this.text = text;
    }
    #endregion
    
    #region Interface Methods
    // Generic Draw method for our menu items.
    public void Draw()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Panel.SetCursorToPoint(position);
        Console.Write(text);
    }

    //Highlighter for currently selected menu item.
    public void Select()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Panel.SetCursorToPoint(position);
        Console.Write(text);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    //Deselect item and redraws it
    public void Deselect()
    {
        Draw();
    }
    
    // performs action based on option selected
    public void Act()
    {
        if (action != null) //If an action has been set
            action();
    }
    #endregion
}