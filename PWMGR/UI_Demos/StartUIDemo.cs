using TUIFrameWork;
using TUIFrameWork.Base;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI_Demos;

public class StartUiDemo
{
    public static void Start()
    {
        Panel mainPanel = new Panel(1);
        mainPanel.direction = LayoutDirection.Column;
        mainPanel.hAlignment = HAlignment.Center;
        mainPanel.vAlignment = VAlignment.Start;
        mainPanel.SetDimensions(85,85);
        mainPanel.ProcessDimensions();
        mainPanel.backgroundColor = ConsoleColor.Cyan;


        Panel cubePanel = Cube.MakeCube();
        Panel thingPanel = Example2.MakeThing();
        Table demoTable = TableWithData.MakeFillTable();

        

        Menu menu = new Menu(true, 2, LayoutDirection.Row);
        MenuItem p1 = new MenuItem("Cube");
        MenuItem p2 = new MenuItem("Thing");
        MenuItem p3 = new MenuItem("Table");

        menu.Add(p1);
        menu.Add(p2);
        menu.Add(p3);
        menu.ProcessDimensions();


        mainPanel.Add(menu);
        mainPanel.Add(cubePanel);
        
        PanelSwitcher switcher = new PanelSwitcher(cubePanel);
        
        mainPanel.ProcessDimensions();
        mainPanel.CalcAllPositions();
        mainPanel.Draw();


        p1.action = delegate
        {
            switcher.SwitchTo(cubePanel);
            mainPanel.ProcessDimensions();
            mainPanel.CalcAllPositions();
            mainPanel.Draw();
        };

        p2.action = delegate
        {
            switcher.SwitchTo(thingPanel);
            mainPanel.ProcessDimensions();
            mainPanel.CalcAllPositions();
            mainPanel.Draw();
        };
        
        p3.action = delegate
        {
            switcher.SwitchTo(demoTable);
            mainPanel.ProcessDimensions();
            mainPanel.CalcAllPositions();
            mainPanel.Draw();
        };

        mainPanel.ManageInput();
    }
}