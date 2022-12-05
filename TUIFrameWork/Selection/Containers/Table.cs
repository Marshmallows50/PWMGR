using TUIFrameWork.Base;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;

namespace TUIFrameWork.Selection.Containers;

public class Table : Panel
{
    public string Name { get; set; }

    public Label columnHeaders = new Label("Add Titles", 20);
    public Menu rows = new Menu(true, 0, LayoutDirection.Column);
    
    

    public Table(string name)
    {
        Name = name;
        Add(rows);
    }

    public void AddCols(string[] colNames)
    {
        Label colHeads = new Label(string.Join("  |  ", colNames), 20);
        Insert(colHeads, 0);
        
    }

    public void AddRow(string[] data)
    {
        rows.Add(new MenuItem(string.Join(" | ", data )));
    }
}