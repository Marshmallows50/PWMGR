using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI_Demos;

public class TableWithData
{
    public static Table MakeFillTable()
    {
        EntryGroup group = new EntryGroup("test");
        int n = 1;
        
        Entry e1 = new Entry("Title","Ri", "Unh@ckab13PAsSW0rd", "coolwebsite.com", n++, "2410 Group Project");
        group.Add(e1);
        Entry e2 = new Entry("Some text","Gabe","l33tMar$All0ooooow","hello.com",n++, "2410 Group Project");
        group.Add(e2);
        group.Add(new Entry("BEEP BOOP","Hunter","CA1iTripp1n","goodbye.com",n++, "2410 Group Project"));
        e1.Tags.Add("Kool");
        e2.Tags.Add("King");

        Table demo = new Table("Some Table");
        
        demo.AddCols(new string[]{"Title", "Username", "Password", "URL"});
        foreach (string[] row in group.GetTableData())
        {
            demo.AddRow(row);
        }
        
        demo.ProcessDimensions();
        demo.CalcAllPositions();

        return demo;
    }
}