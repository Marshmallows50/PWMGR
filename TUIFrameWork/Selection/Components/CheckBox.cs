using TUIFrameWork.Containers;
namespace TUIFrameWork.Selection.Components;

public class CheckBox : ISelectable
{
    #region Fields and Properties
    private string text;
    public bool Toggled { get; private set; }
    
    public Point Position {  get; set; }
    public int Width { get; internal set; }
    public int Height { get; set; }
    #endregion

    #region Constructor
    public CheckBox(string text, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        this.text = text;
        ProcessDimensions();
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

    public void Act()
    {
        if (Toggled)
            Toggled = false;
        else
            Toggled = true;
        UpdateConsole();
    }
    
    public void Draw()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        UpdateConsole();
    }
    
    public void ProcessDimensions()
    {
        Width = text.Length + 5;
        Height = 1;
    }
    #endregion
    
    #region Functionality Methods
    private void UpdateConsole()
    {
        Frame.SetCursorToPoint(Position);
        if (Toggled)
            Console.Write($"{text}: [X]");
        else
            Console.Write($"{text}: [ ]");
    }
    #endregion
}