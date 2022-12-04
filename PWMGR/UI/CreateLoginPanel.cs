using TUIFrameWork;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;

public class CreateLoginPanel
{
    public Panel DrawLoginFrame()
        {
            // create and configure panels
            Panel mainPanel = new Panel(2);
            mainPanel.direction = LayoutDirection.Column;
            mainPanel.hAlignment = HAlignment.Center;
            mainPanel.vAlignment = VAlignment.Start;
            mainPanel.SetDimensions(70, 70);
            mainPanel.ProcessDimensions();

            Panel rowContainer1 = new Panel(2);
            rowContainer1.direction = LayoutDirection.Row;
            rowContainer1.hAlignment = HAlignment.Center;
            rowContainer1.vAlignment = VAlignment.Center;
            rowContainer1.SetDimensions(100, 20);
            rowContainer1.backgroundColor = ConsoleColor.DarkGray;

            Panel rowContainer2 = new Panel(2);
            rowContainer2.direction = LayoutDirection.Row;
            rowContainer2.hAlignment = HAlignment.Center;
            rowContainer2.vAlignment = VAlignment.Center;
            rowContainer2.SetDimensions(90, 50);
            rowContainer2.backgroundColor = ConsoleColor.Gray;

            // make menu for password input
            Menu row2menu1 = new Menu(true, 1, LayoutDirection.Row);

            // create labels
            Label label1 = new Label("Password Manager!", 20, Alignment.Center);
            Label label2 = new Label("Password:", 5, Alignment.Center);
            TextField menu1item2 = new TextField(25, " Type Password!");
            MenuItem menu1item3 = new MenuItem("login");

            // add components to menus
            row2menu1.Add(menu1item2);
            row2menu1.Add(menu1item3);
            row2menu1.ProcessDimensions();

            // add menus & labels to panels
            rowContainer1.Add(label1);
            rowContainer1.ProcessDimensions();

            rowContainer2.Add(label2);
            rowContainer2.Add(row2menu1);
            rowContainer2.ProcessDimensions();

            // add rows to main panel
            mainPanel.Add(rowContainer1);
            mainPanel.Add(rowContainer2);
            mainPanel.ProcessDimensions();
            mainPanel.CalcAllPositions();

            return mainPanel;
        }
}