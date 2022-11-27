using TUIFrameWork;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR;

public class Cube
{
    public static void MakeCube()
    {
        // create and configure some Panels
        Panel mainPanel = new Panel(1);
        mainPanel.direction = LayoutDirection.Column;
        mainPanel.hAlignment = HAlignment.Center;
        mainPanel.vAlignment = VAlignment.Center;
        mainPanel.SetDimensions(70, 70);
        mainPanel.ProcessDimensions();


        Panel rowContainer1 = new Panel(2);
        rowContainer1.direction = LayoutDirection.Row;

        Panel rowContainer2 = new Panel(2);
        rowContainer2.direction = LayoutDirection.Row;

        // create some labels
        Label label1 = new Label("Demonstration of Cube layout!", 18, Alignment.Center);
        Label label2 = new Label("I hope this made sense! look at my code", 8, Alignment.Center);


        // make 2 menus for each row container panel.
        Menu row1menu1 = new Menu(true, 1, LayoutDirection.Column);
        RadioButtonGroup row1menu2 = new RadioButtonGroup(true, 1, LayoutDirection.Column);

        RadioButtonGroup row2menu1 = new RadioButtonGroup(true, 1, LayoutDirection.Column);
        Menu row2menu2 = new Menu(true, 1, LayoutDirection.Column);


        // make 3 items for each menu
        MenuItem menu1item1 = new MenuItem("Im a button!")
        {
            action = delegate
            {
                rowContainer1.Remove(row1menu1);
                rowContainer1.Remove(row1menu2);
                Label label3 = new Label("removed menus and added label", 5, Alignment.Center);
                rowContainer1.Add(label3);
                rowContainer1.ProcessDimensions();

                // mainPanel.ProcessDimensions();
                mainPanel.CalcAllPositions();
                mainPanel.Draw();
            }
        };

        CheckBox menu1item2 = new CheckBox("Check 1");
        TextField menu1item3 = new TextField(12, "Type!");

        RadioButton menu2item1 = new RadioButton("radio 1");
        RadioButton menu2item2 = new RadioButton("radio 2");
        RadioButton menu2item3 = new RadioButton("radio 3");

        RadioButton menu3item1 = new RadioButton("radio 1");
        RadioButton menu3item2 = new RadioButton("radio 2");
        RadioButton menu3item3 = new RadioButton("radio 3");

        MenuItem menu4item1 = new MenuItem("Im a button!");
        CheckBox menu4item2 = new CheckBox("Check 1");
        TextField menu4item3 = new TextField(12, "Type!");


        // add items to menus
        row1menu1.Add(menu1item1);
        row1menu1.Add(menu1item2);
        row1menu1.Add(menu1item3);
        row1menu1.ProcessDimensions();
        row1menu1.backgroundColor = ConsoleColor.Cyan;

        row1menu2.Add(menu2item1);
        row1menu2.Add(menu2item2);
        row1menu2.Add(menu2item3);
        row1menu2.ProcessDimensions();
        row1menu2.backgroundColor = ConsoleColor.Red;

        row2menu1.Add(menu3item1);
        row2menu1.Add(menu3item2);
        row2menu1.Add(menu3item3);
        row2menu1.ProcessDimensions();
        row2menu1.backgroundColor = ConsoleColor.Yellow;

        row2menu2.Add(menu4item1);
        row2menu2.Add(menu4item2);
        row2menu2.Add(menu4item3);
        row2menu2.ProcessDimensions();
        row2menu2.backgroundColor = ConsoleColor.Green;


        // add menus to panels and panels to other panels
        rowContainer1.Add(row1menu1);
        rowContainer1.Add(row1menu2);
        rowContainer1.ProcessDimensions();

        rowContainer2.Add(row2menu1);
        rowContainer2.Add(row2menu2);
        rowContainer2.ProcessDimensions();


        mainPanel.Add(label1);
        mainPanel.Add(rowContainer1);
        mainPanel.Add(rowContainer2);
        mainPanel.Add(label2);
        mainPanel.ProcessDimensions();
        
        mainPanel.CalcAllPositions(); // figure out positions of children inside panel

        // draw
        mainPanel.Draw();
        
        row1menu1.MonitorInput();
        // mainPanel.ManageInput();
    }
}