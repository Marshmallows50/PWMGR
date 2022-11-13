using System.Linq.Expressions;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection;
namespace TUIFrameWork.Components;



public class Label : IComponent
{
    //fields
    private int margin;
    private Alignment alignment;
    
    //properties
    public string Text { get; set; }
    public Point Position {  get; set; }

    #region Constructor
    public Label(string text, int margin=0, Alignment alignment=Alignment.Left, Point? position=null)
    {
        Text = text;
        this.margin = margin;
        this.alignment = alignment;
        Position = position ?? Frame.GetCursorPositionAsPoint();
    }
    #endregion

    #region Interface Methods
    public void Draw()
    {
        Frame.SetCursorToPoint(Position);
        Frame.SetCursorToPoint(Position);
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        switch (alignment)
        {
            case Alignment.Left:
                Console.Write($"{new string(' ',margin)}{Text}");
                break;
            case Alignment.Center:
                string spaces = new string(' ',margin/2);
                Console.Write($"{spaces}{Text}{spaces}");
                break;
            case Alignment.Right:
                Console.Write($"{Text}{new string(' ',margin)}");
                break;
        }
    }
    #endregion
    
}