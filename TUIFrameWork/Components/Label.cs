using System.Linq.Expressions;
using TUIFrameWork.Base;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection;
namespace TUIFrameWork.Components;
/// <summary>
/// Creates a Label that contains text and a background color
/// </summary>
public class Label : IComponent
{
    #region Fields and Properties
    private int margin;
    private Alignment alignment;
    
    public string Text { get; private set; }
    
    public Point Position { get; set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public Container? Parent { get; set; }
    
    public ConsoleColor foregroundColor { get; set; }
    public ConsoleColor backgroundColor { get; set; }

    #endregion

    #region Constructor
    /// <summary>
    /// Constructor creates a new label with provided text, margin, alignment, and position.
    /// </summary>
    /// <param name="text"></param> text to display in label
    /// <param name="margin"></param>
    /// <param name="alignment"></param>
    /// <param name="position"></param>
    public Label(string text, int margin=0, Alignment alignment=Alignment.Left, Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        Text = text;

        foregroundColor = ConsoleColor.White;
        backgroundColor = ConsoleColor.DarkBlue;
        this.margin = margin;
        this.alignment = alignment;
        
        ProcessDimensions();
    }
    #endregion

    #region Interface Methods
    public void Draw()
    {
        Frame.SetCursorToPoint(Position);
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = foregroundColor;
        switch (alignment)
        {
            case Alignment.Left:
                Console.Write($"{Text}{new string(' ',margin)}");
                
                break;
            case Alignment.Center:
                string spaces = new string(' ',margin/2);
                Console.Write($"{spaces}{Text}{spaces}");
                break;
            case Alignment.Right:
                Console.Write($"{new string(' ',margin)}{Text}");
                break;
        }
    }

    public void ProcessDimensions()
    {
        Width = Text.Length + margin;
        Height = 1;
        if (Parent!=null)
            Parent.ProcessDimensions();
    }
    #endregion

    #region Functionality Methods
    /// <summary>
    /// Changes the Label's text
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        Text = text;
        ProcessDimensions();
    }

    public void InheritColors()
    {
        if (Parent == null) return;
        foregroundColor = Parent.foregroundColor;
        backgroundColor = Parent.backgroundColor;
    }
    #endregion
}