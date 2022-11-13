using TUIFrameWork.Containers;
namespace TUIFrameWork.Selection.Components;


/// <summary>
/// The Menu Class is responsible for our Menu functionality.
///Using the arrow keys, the user  can select and activate a menu item such as Start Game or View Scores.
/// </summary>
public class MenuItem : ISelectable
{   
    //fields
    private string text;
    public Action? action;
    
    //properties
    public Selector? ParentSelector { get; set; }
    public Point Position {  get; set; }
    
    #region Contructor
    // ctor for MenuItem
    public MenuItem(string text, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        this.text = text;
    }
    #endregion
    
    #region Interface Methods
    // Generic Draw method for our menu items.
    public void Draw()
    {
        Frame.SetCursorToPoint(Position);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(text);
    }

    //Highlighter for currently selected menu item.
    public void Select()
    {
        Frame.SetCursorToPoint(Position);
        Console.BackgroundColor = ConsoleColor.Gray;
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