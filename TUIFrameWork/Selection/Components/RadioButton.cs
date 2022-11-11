using TUIFrameWork.Selection;
namespace TUIFrameWork.Selection.Components;

public class RadioButton : ISelectable
{
    //fields
    private Point position;
    private string text;
    
    //properties
    public bool Toggled { get; private set; }

    #region Constructor
    public RadioButton(Point position, string text)
    {
        this.position = position;
        this.text = text;
    }
    #endregion

    #region Interface Methods
    public void Select()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        UpdateConsole();
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public void Deselect()
    {
        Draw();
    }
    public void Draw()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        UpdateConsole();
    }
    
    public void Act()
    {
        if (Toggled)
            Toggled = false;
        else
            Toggled = true;
        UpdateConsole();
    }
    #endregion
    
    #region Functionality Methods
    private void UpdateConsole()
    {
        Panel.SetCursorToPoint(position);
        if (Toggled)
            Console.Write($"{text}: (X)");
        else
            Console.Write($"{text}: ( )");
    }
    #endregion
}