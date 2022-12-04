using TUIFrameWork.Base;
using TUIFrameWork.Containers;
namespace TUIFrameWork.Selection.Components;

/// <summary>
/// MenuItem is a button equivalent that inherits from ISelectable
/// and can be added to a menu. MenuItem can be assigned an Action Delegate
/// to be called when the MenuItem is pressed.
/// </summary>
public class MenuItem : ISelectable
{
    #region Fields and Properties
    private string text;
    public Action? action;
    
    public Point Position {  get; set; }
    public Container? Parent { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    #endregion

    #region Contructor
    /// <summary>
    /// Creates a new MenuItem with provided text.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="position"></param>
    public MenuItem(string text, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        this.text = text;
        
        ProcessDimensions();
    }
    #endregion
    
    #region Interface Methods
    public void Select()
    {
        Frame.SetCursorToPoint(Position);
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Write(text);
        Console.BackgroundColor = ConsoleColor.Black;
    }
    
    public void Deselect()
    {
        Draw();
    }
    
    public void Act()
    {
        if (action != null) //If an action has been set
            action();
    }
    
    public void Draw()
    {
        Frame.SetCursorToPoint(Position);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(text);
    }
    
    public void ProcessDimensions()
    {
        Width = text.Length;
        Height = 1;
    }
    #endregion
}