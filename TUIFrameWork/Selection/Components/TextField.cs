using System.Diagnostics;
using System.Drawing;
using System.Text;
using TUIFrameWork.Base;
using TUIFrameWork.Containers;
using Point = TUIFrameWork.Base.Point;

namespace TUIFrameWork.Selection.Components;

public class TextField : ISelectable
{
    #region Fields and Properties
    private bool isReadingInput;
    private bool isModified;
    
    private StringBuilder sb;
    public string? text;
    private string placeHolder;
    
    public Point Position {  get; set; }
    public Container? Parent { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    #endregion

    #region Constructor
    public TextField(int width, string placeHolder=" ", Point? position=null)
    {
        Position = position ?? Frame.GetCursorPositionAsPoint();
        Width = width;
        Height = 1;
        this.placeHolder = placeHolder;
    }
    #endregion
    
    #region Interface Methods
    public void Select()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Frame.SetCursorToPoint(Position);
        Console.Write(new string(' ',Width));
        
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
        Console.Write(new string(' ',Width));
        Frame.SetCursorToPoint(Position);
        if (isModified)
        {
            isReadingInput = true;
            ReadInput();
        }
        else
        {
            text = Console.ReadLine();
            isModified = true;
        }
    }

    public void Draw()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Frame.SetCursorToPoint(Position);
        Console.Write(new string(' ',Width));
        
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
    
    public void ProcessDimensions(){ } // not needed, Width and Height are defined in constructor
    #endregion

    #region Functionality Methods
    private void ReadInput()
    {
        sb = new StringBuilder();
        sb.Append(text);
        Console.Write(sb.ToString());
        while (isReadingInput)
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
                    isReadingInput = false;
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
    
    public void SetText(string text)
    {
        this.text = text;
    }
    
    private void ResetColors()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }
    #endregion
}