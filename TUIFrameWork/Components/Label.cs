using TUIFrameWork.Selection;
namespace TUIFrameWork.Components;



public class Label
{
    public string Text { get; set; }
    
    private Point position;
    private int margin;
    private Alignment alignment; 

    public Label(Point position, string text, int margin=0, Alignment alignment=Alignment.Left)
    {
        this.position = position;
        Text = text;
        this.margin = margin;
        this.alignment = alignment;
    }

    public void Draw()
    {
        Panel.SetCursorToPoint(position);
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
}