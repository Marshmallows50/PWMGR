using System;
using TUIFrameWork;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR
{
    public class PsswdGeneratorFrame
    {
        public static void DrawPsswdGenerator()
        {
            // create and configure Panels
            Panel mainPanel = new Panel(1);
            mainPanel.direction = LayoutDirection.Column;
            mainPanel.hAlignment = HAlignment.Center;
            mainPanel.vAlignment = VAlignment.Start;
            mainPanel.SetDimensions(70, 70);
            mainPanel.ProcessDimensions();

            // panel for menu bar
            Panel menuBar = new Panel(2);
            menuBar.direction = LayoutDirection.Row;
            menuBar.hAlignment = HAlignment.Center;
            menuBar.vAlignment = VAlignment.Center;
            menuBar.SetDimensions(100, 20);
            menuBar.backgroundColor = ConsoleColor.DarkGray;

            Panel rowContainer1 = new Panel(4);
            rowContainer1.direction = LayoutDirection.Row;
            rowContainer1.hAlignment = HAlignment.Center;
            rowContainer1.vAlignment = VAlignment.Center;

            Panel rowContainer2 = new Panel(4);
            rowContainer2.direction = LayoutDirection.Row;
            rowContainer2.hAlignment = HAlignment.Center;
            rowContainer2.vAlignment = VAlignment.Start;

            // menus
            Menu row1menu1 = new Menu(true, 1, LayoutDirection.Column);
            Menu row2menu1 = new Menu(true, 1, LayoutDirection.Column);
            Menu row2menu2 = new Menu(true, 1, LayoutDirection.Column);

            // row1menu1
            Label label = new Label("Generate New Password");
            TextField menu1item3 = new TextField(20, "Type!");

            // row2menu1
            CheckBox menu2item1 = new CheckBox("Letters(e.g.Aa)");
            CheckBox menu2item2 = new CheckBox("Numbers(e.g.123)");
            CheckBox menu2item3 = new CheckBox("Symbols(e.g.@$?)");
            TextField menu2item4 = new TextField(5, "length");

            // row2menu2
            MenuItem menu1btn1 = new MenuItem("Generate Psswd Btn");
            MenuItem menu1btn2 = new MenuItem("Copy Psswd Btn");

            // add components to menus
            menuBar.Add(MainFrame.CreateMenuBar());
            row1menu1.Add(menu1item3);
            row1menu1.ProcessDimensions();

            row2menu1.Add(menu2item1);
            row2menu1.Add(menu2item2);
            row2menu1.Add(menu2item3);
            row2menu1.Add(menu2item4);
            row2menu1.ProcessDimensions();
            row2menu1.backgroundColor = ConsoleColor.Black;

            row2menu2.Add(menu1btn1);
            row2menu2.Add(menu1btn2);
            row2menu2.ProcessDimensions();
            row2menu2.backgroundColor = ConsoleColor.Black;

            // add menus to panels 
            rowContainer1.Add(label);
            rowContainer1.Add(row1menu1);
            rowContainer1.ProcessDimensions();

            rowContainer2.Add(row2menu1);
            rowContainer2.Add(row2menu2);
            rowContainer2.ProcessDimensions();

            mainPanel.Add(menuBar);
            mainPanel.Add(rowContainer1);
            mainPanel.Add(rowContainer2);
            mainPanel.ProcessDimensions();
            mainPanel.CalcAllPositions();

            // draw
            mainPanel.Draw();

            row1menu1.MonitorInput();
            row2menu1.MonitorInput();
            row2menu2.MonitorInput();
            // mainPanel.ManageInput();
        }
    }
}