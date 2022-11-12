using System.Drawing;
using TUIFrameWork.Selection;
namespace TUIFrameWork.Selection.Components;

public class TextField : ISelectable
{
    //fields
    private Point position;
    private int length;
    
    private string placeHolder;
    private Alignment alignment;
    
    public string text;
    private bool isModified;
    
    //properties
    public Selector? ParentSelector { get; set; }

    #region Constructor
    public TextField(Point position, int length, string placeHolder=" ", Alignment alignment = Alignment.Left)
    {
        this.position = position;
        this.length = length;
        this.placeHolder = placeHolder;
        this.alignment = Alignment.Left;
    }
    #endregion
    

    #region Interface Methods
    public void Draw()
    {
        
    }

    public void Select()
    {
        throw new NotImplementedException();
    }

    public void Deselect()
    {
        throw new NotImplementedException();
    }

    public void Act()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Functionality Methods

    

    #endregion
}