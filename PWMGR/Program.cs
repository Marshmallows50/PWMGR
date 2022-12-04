using PWMGR;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork;
using TUIFrameWork.Base;


Panel mainPanel = new Panel(1);
mainPanel.direction = LayoutDirection.Column;
mainPanel.hAlignment = HAlignment.Center;
mainPanel.vAlignment = VAlignment.Start;
mainPanel.SetDimensions(85,85);
mainPanel.ProcessDimensions();
mainPanel.backgroundColor = ConsoleColor.Cyan;


Panel cubePanel = Cube.MakeCube();
Panel thingPanel = Example2.MakeThing();

PanelSwitcher switcher = new PanelSwitcher(cubePanel);

Menu menu = new Menu(true, 2, LayoutDirection.Row);
MenuItem p1 = new MenuItem("Cube");
MenuItem p2 = new MenuItem("Thing");

menu.Add(p1);
menu.Add(p2);
menu.ProcessDimensions();


mainPanel.Add(menu);
mainPanel.Add(cubePanel);
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

mainPanel.ManageInput();

