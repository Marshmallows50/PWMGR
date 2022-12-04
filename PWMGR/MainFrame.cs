using System;
using TUIFrameWork;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR
{
    public class MainFrame
    {
        public static void DrawMainFrame()
        {
            // create panels
            Panel mainPanel = new Panel(0);
            mainPanel.direction = LayoutDirection.Column;
            mainPanel.vAlignment = VAlignment.Start;
            mainPanel.hAlignment = HAlignment.Start;
            mainPanel.SetDimensions(70, 70);

            // panel for menu bar
            Panel rowContainer1 = new Panel(2);
            rowContainer1.direction = LayoutDirection.Row;
            rowContainer1.hAlignment = HAlignment.Center;
            rowContainer1.vAlignment = VAlignment.Center;
            rowContainer1.SetDimensions(100, 20);
            rowContainer1.backgroundColor = ConsoleColor.DarkGray;

            // panel for sidebar
            Panel rowContainer2 = new Panel(1);
            rowContainer2.direction = LayoutDirection.Column;
            rowContainer2.hAlignment = HAlignment.Center;
            rowContainer2.vAlignment = VAlignment.End;
            rowContainer2.SetDimensions(20, 85);
            rowContainer2.backgroundColor = ConsoleColor.Gray;

            // panel for main content
            // TODO Not sure how to fit it with the other panels.


            // create menus for menubar and sidebar
            Menu menuBar = CreateMenuBar();
            Menu sideBar = CreateSideBarMenu();

            // add menus to containers 
            rowContainer1.Add(menuBar);
            rowContainer1.ProcessDimensions();
            rowContainer2.Add(sideBar);
            rowContainer2.ProcessDimensions();

            // add conatiners to main panel
            mainPanel.Add(rowContainer1);
            mainPanel.Add(rowContainer2);
            mainPanel.ProcessDimensions();
            mainPanel.CalcAllPositions();
            mainPanel.Draw();

            menuBar.MonitorInput();
            sideBar.MonitorInput();
        }

        public static Menu CreateMenuBar()
        {
            Menu menuBar = new Menu(true, 2, LayoutDirection.Row);

            MenuItem btnOpen = new MenuItem("open");
            MenuItem btnLock = new MenuItem("lock");
            MenuItem btnNew = new MenuItem("new");
            MenuItem btnEdit = new MenuItem("edit");
            MenuItem btnRemove = new MenuItem("remove");
            MenuItem btnPsswdGenerator = new MenuItem("password generator");

            menuBar.Add(btnOpen);
            menuBar.Add(btnLock);
            menuBar.Add(btnNew);
            menuBar.Add(btnEdit);
            menuBar.Add(btnRemove);
            menuBar.Add(btnPsswdGenerator);
            menuBar.ProcessDimensions();
            menuBar.backgroundColor = ConsoleColor.Green;

            return menuBar;
        }

        private static Menu CreateSideBarMenu()
        {
            Menu sideBarMenu = new Menu(true, 1);

            MenuItem btn1 = new MenuItem("Btn 1");
            MenuItem btn2 = new MenuItem("Btn 2");
            MenuItem btn3 = new MenuItem("Btn 3");
            MenuItem btn4 = new MenuItem("Btn 4");
            MenuItem btn5 = new MenuItem("Btn 5");

            sideBarMenu.Add(btn1);
            sideBarMenu.Add(btn2);
            sideBarMenu.Add(btn3);
            sideBarMenu.Add(btn4);
            sideBarMenu.Add(btn5);
            sideBarMenu.ProcessDimensions();
            sideBarMenu.backgroundColor = ConsoleColor.Blue;

            return sideBarMenu;
        }
    }
}

