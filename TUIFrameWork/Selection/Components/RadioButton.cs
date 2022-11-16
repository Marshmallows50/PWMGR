using TUIFrameWork.Containers;
namespace TUIFrameWork.Selection.Components;

public class RadioButton : ISelectable
{
    //fields
    private string text;

    //properties
    public bool Toggled { get; private set; }
    public Selector? ParentSelector { get; set; }
    public Point Position {  get; set; }
    public int width { get; set; }

    #region Constructor
    public RadioButton(string text, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        this.text = text;
        ProcessWidth();
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


    public void ProcessWidth()
    {
        width = text.Length + 5;
    }
    
    #endregion
    
    #region Functionality Methods
    private void UpdateConsole()
    {
        Frame.SetCursorToPoint(Position);
        if (Toggled)
            Console.Write($"{text}: (X)");
        else
            Console.Write($"{text}: ( )");
    }
    #endregion
}