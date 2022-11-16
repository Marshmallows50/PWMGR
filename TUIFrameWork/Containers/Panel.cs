using System.Collections;
using System.Runtime.InteropServices;
using TUIFrameWork.Selection;

namespace TUIFrameWork.Containers;

// public enum Layout { Hamburger, SideHamburger, KindaLikeGrid }

public enum LayoutAlignment { Start, Center, End }

public class Panel
{
    // configure and set layouts
    // add and remove Panels and Components
    // Draw and ReDraw Itself with every component
    // automatically manage positioning of each Panel Component inside of it based on the layout
    // Manage Colors (foreground and background) for each Panel and Component inside it
    // Manage what component or panel is currently monitoring inputs
    // Manage where components or panels inside of it are and what their order is.
    
    // possibly make a separate ScrollablePanel
    // possible css flexbox or css grid like layouts?
    
    
    public int width;
    public int height;
    private int gap;
    private int margin;
    
    private Point position;
    private LayoutAlignment hAlignment;
    private LayoutAlignment vAlignment;

    private LayoutDirection direction;
    public Panel? ParentPanel { get; private set; }

    private List<IComponent> children;


    public Panel(Point position, int width, int gap=1, int margin=1, LayoutDirection direction = LayoutDirection.Row)
    {
        this.position = position;
        this.width = width;
        
        this.margin = margin;
        this.gap = gap;
        this.direction = direction;
        
        children = new List<IComponent>();
    }

    public void Add(IComponent component)
    {
        children.Add(component);
    }

    public void Remove(IComponent component)
    {
        children.Remove(component);
    }
    
    
}