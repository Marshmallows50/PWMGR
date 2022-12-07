using TUIFrameWork.Base;
using TUIFrameWork.Containers;
namespace TUIFrameWork.Selection.Components;

/// <summary>
/// An ISelectable that can be toggled on or off
/// </summary>
public class CheckBox : ISelectable
{
    #region Fields and Properties
    private string text;
    public bool Toggled { get; private set; }
    
    public Action? action;
    
    public Point Position {  get; set; }
    public Container? Parent { get; set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    
    
    public ConsoleColor foregroundColor { get; set; }
    public ConsoleColor backgroundColor { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Creates a new CheckBox with provided text.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="position"></param>
    public CheckBox(string text, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        this.text = text;
        foregroundColor = ConsoleColor.White;
        backgroundColor = ConsoleColor.Black;
        
        ProcessDimensions();
    }
    #endregion
    
    #region Interface Methods
    public void Select()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        UpdateConsole();
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
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = foregroundColor;
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
    
    public void InheritColors()
    {
        if (Parent == null) return;
        foregroundColor = Parent.foregroundColor;
        backgroundColor = Parent.backgroundColor;
    }
    #endregion
}