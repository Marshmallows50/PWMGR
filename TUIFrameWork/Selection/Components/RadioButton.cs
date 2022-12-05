using TUIFrameWork.Base;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Containers;

namespace TUIFrameWork.Selection.Components;

/// <summary>
/// An ISelectable that can be added to a RadioButtonGroup
/// and toggled on or off. When Toggled, other RadioButtons in
/// the same RadioButtonGroup will be de-selected
/// </summary>
public class RadioButton : ISelectable
{
    #region Fields and Properties
    private string text;
    public bool Toggled { get; private set; }

    public Point Position {  get; set; }
    public Container? Parent { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public ConsoleColor foregroundColor { get; set; }
    public ConsoleColor backgroundColor { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Creates a new RadioButton with the provided text.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="position"></param>
    public RadioButton(string text, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        this.text = text;

        foregroundColor = ConsoleColor.White;
        foregroundColor = ConsoleColor.Black;
        ProcessDimensions();
    }
    #endregion
    
    #region Interface Methods
    public void Select()
    {
        Console.BackgroundColor = backgroundColor;
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
            Console.Write($"{text}: (X)");
        else
            Console.Write($"{text}: ( )");
    }
    
    public void InheritColors()
    {
        if (Parent == null) return;
        foregroundColor = Parent.foregroundColor;
        backgroundColor = Parent.backgroundColor;
    }
    #endregion
}