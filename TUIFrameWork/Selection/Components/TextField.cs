using System.Diagnostics;
using System.Drawing;
using System.Text;
using TUIFrameWork.Containers;
namespace TUIFrameWork.Selection.Components;

public class TextField : ISelectable
{
    //fields
    private int length;
    private bool M;
    private StringBuilder sb;
    
    private string placeHolder;

    public string? text;
    private bool isModified;
    
    //properties
    public Selector? ParentSelector { get; set; }
    public Point Position {  get; set; }

    #region Constructor
    public TextField(int length, string placeHolder=" ", Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        this.length = length;
        this.placeHolder = placeHolder;
    }
    #endregion
    
    #region Interface Methods
    public void Draw()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Frame.SetCursorToPoint(Position);
        Console.Write(new string(' ',length));
        
        Frame.SetCursorToPoint(Position);
        Console.ForegroundColor = ConsoleColor.Black;
        switch (isModified)
        {
            case true:
                Console.Write(text);
                break;
            case false:
                if (!placeHolder.Equals(" ")) // placeholder is optional
                {
                    Console.Write(placeHolder);
                }
                break;
        }
        ResetColors();
    }

    public void Select()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Frame.SetCursorToPoint(Position);
        Console.Write(new string(' ',length));
        
        Frame.SetCursorToPoint(Position);
        Console.ForegroundColor = ConsoleColor.Black;
        switch (isModified)
        {
            case true:
                Console.Write(text);
                break;
            case false:
                if (!placeHolder.Equals(" ")) // placeholder is optional
                {
                    Console.Write(placeHolder);
                }
                break;
        }
        ResetColors();
    }

    public void Deselect()
    {
        Draw();
    }

    public void Act()
    {
        Console.CursorVisible = true;
        Frame.SetCursorToPoint(Position);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write(new string(' ',length));
        Frame.SetCursorToPoint(Position);
        if (isModified)
        {
            M = true;
            ReadInput();
        }
        else
        {
            text = Console.ReadLine();
            isModified = true;
        }


    }
    #endregion

    #region Functionality Methods

    private void ReadInput()
    {
        sb = new StringBuilder();
        sb.Append(text);
        Console.Write(sb.ToString());
        while (M)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch(keyInfo.Key)
            {
                case ConsoleKey.Backspace:
                    try
                    {
                        sb = sb.Remove(sb.Length-1, 1);
                        WriteCurrent();
                        break;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        break;
                    }
                    
                case ConsoleKey.Enter:
                    text = sb.ToString();
                    M = false;
                    break;
                default:
                    sb.Append(keyInfo.KeyChar);
                    break;
            }
        }
    }

    private void WriteCurrent()
    {
        int x = Position.X+sb.Length;
        Console.SetCursorPosition(x,Position.Y);
        Console.Write(" ");
        Console.SetCursorPosition(x,Position.Y);

    }
    private void ResetColors()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }
    

    #endregion
}