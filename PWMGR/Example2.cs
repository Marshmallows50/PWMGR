using TUIFrameWork;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR;

public class Example2
{
    public static Panel MakeThing()
    {
        //create Panels
        Panel mainPanel = new Panel(2);
        mainPanel.direction = LayoutDirection.Row;
        mainPanel.vAlignment = VAlignment.Center;
        mainPanel.hAlignment = HAlignment.Center;
        mainPanel.SetDimensions(50,50);
        
        Panel sideBar = new Panel(2);
        sideBar.direction = LayoutDirection.Column;
        sideBar.hAlignment = HAlignment.Center;
        sideBar.vAlignment = VAlignment.Center;
        sideBar.SetDimensions(30, 100);
        sideBar.backgroundColor = ConsoleColor.Red;

        Panel mainContent = new Panel(0);
        mainContent.direction = LayoutDirection.Column;
        mainContent.hAlignment = HAlignment.Center;
        mainContent.vAlignment = VAlignment.Center;
        mainContent.SetDimensions(50, 100);
        mainContent.backgroundColor = ConsoleColor.Yellow;

        // create and configure menus
        Menu sideMenu1 = CreateSideMenu1();
        Menu sideMenu2 = CreateSideMenu2();
        Menu menu3 = CreateMenu3();
        
        
        // add menus to Sidebar
        sideBar.Add(sideMenu1);
        sideBar.Add(sideMenu2);
        sideBar.ProcessDimensions();
        

        // add menu3 to mainContent
        mainContent.Add(menu3);
        mainContent.ProcessDimensions();

        // add Panels to MainPanel
        mainPanel.Add(sideBar);
        mainPanel.Add(mainContent);
        mainPanel.ProcessDimensions();
        mainPanel.CalcAllPositions();
        // mainPanel.Draw();

        // menu3.MonitorInput();
        // mainPanel.ManageInput();
        return mainPanel;
    }

    private static Menu CreateMenu3()
    {
        Menu menu3 = new Menu(true, 2);
        MenuItem btna = new MenuItem("Btn a");
        MenuItem btnb = new MenuItem("Btn b");
        MenuItem btnc = new MenuItem("Btn c");

        menu3.Add(btna);
        menu3.Add(btnb);
        menu3.Add(btnc);
        menu3.ProcessDimensions();
        menu3.backgroundColor = ConsoleColor.Cyan;
        
        return menu3;
    }

    private static Menu CreateSideMenu1()
    {
        Menu sideMenu1 = new Menu(true, 0);

        MenuItem btn1 = new MenuItem("Btn 1");
        MenuItem btn2 = new MenuItem("Btn 2");
        MenuItem btn3 = new MenuItem("Btn 3");
        MenuItem btn4 = new MenuItem("Btn 4");
        MenuItem btn5 = new MenuItem("Btn 5");

        sideMenu1.Add(btn1);
        sideMenu1.Add(btn2);
        sideMenu1.Add(btn3);
        sideMenu1.Add(btn4);
        sideMenu1.Add(btn5);
        sideMenu1.ProcessDimensions();
        sideMenu1.backgroundColor = ConsoleColor.Gray;
        return sideMenu1;
    }

    private static Menu CreateSideMenu2()
    {
        Menu sideMenu2 = new Menu(true, 1);

        MenuItem btn6 = new MenuItem("Btn 6");
        MenuItem btn7 = new MenuItem("Btn 7");
        MenuItem btn8 = new MenuItem("Btn 8");
        MenuItem btn9 = new MenuItem("Btn 9");
        MenuItem btn0 = new MenuItem("Btn 0");

        sideMenu2.Add(btn6);
        sideMenu2.Add(btn7);
        sideMenu2.Add(btn8);
        sideMenu2.Add(btn9);
        sideMenu2.Add(btn0);
        sideMenu2.ProcessDimensions();
        sideMenu2.backgroundColor = ConsoleColor.Gray;
        return sideMenu2;
    }
}