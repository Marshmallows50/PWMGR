using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;
using TUIFrameWork.Selection;
using TUIFrameWork.Components;
using TUIFrameWork;
using TUIFrameWork.Containers;

int a = 30; // for testing method. ignore.
// create some Panels
Panel mainPanel = new Panel(1);
Panel rowContainer1 = new Panel(2);
Panel rowContainer2 = new Panel(2);

// create some labels
Label label1 = new Label("Demonstration of Cube layout!", 18, Alignment.Center);
Label label2 = new Label("I hope this made sense! look at my code", 8, Alignment.Center);

// make 2 menus for each row container panel. each menu with column layout direction
Menu row1menu1 = new Menu(false, 0, LayoutDirection.Column);
RadioButtonGroup row1menu2 = new RadioButtonGroup(true, 0, LayoutDirection.Column);

RadioButtonGroup row2menu1 = new RadioButtonGroup(true, 0, LayoutDirection.Column);
Menu row2menu2 = new Menu(false, 0, LayoutDirection.Column);

// make 3 items for each menu
MenuItem menu1item1 = new MenuItem("Im a button!");
CheckBox menu1item2 = new CheckBox("Check 1");
TextField menu1item3 = new TextField(12,"Type!");

RadioButton menu2item1 = new RadioButton("radio 1");
RadioButton menu2item2 = new RadioButton("radio 2");
RadioButton menu2item3 = new RadioButton("radio 3");

RadioButton menu3item1 = new RadioButton("radio 1");
RadioButton menu3item2 = new RadioButton("radio 2");
RadioButton menu3item3 = new RadioButton("radio 3");

MenuItem menu4item1 = new MenuItem("Im a button!");
CheckBox menu4item2 = new CheckBox("Check 1");
TextField menu4item3 = new TextField(12,"Type!");


// add items to menus
row1menu1.Add(menu1item1);
row1menu1.Add(menu1item2);
row1menu1.Add(menu1item3);
row1menu1.backgroundColor = ConsoleColor.Cyan;

row1menu2.Add(menu2item1);
row1menu2.Add(menu2item2);
row1menu2.Add(menu2item3);
row1menu2.backgroundColor = ConsoleColor.Red;

row2menu1.Add(menu3item1);
row2menu1.Add(menu3item2);
row2menu1.Add(menu3item3);
row2menu1.backgroundColor = ConsoleColor.Yellow;

row2menu2.Add(menu4item1);
row2menu2.Add(menu4item2);
row2menu2.Add(menu4item3);
row2menu2.backgroundColor = ConsoleColor.Green;


// add menus to panels and panels to other panels
rowContainer1.Add(row1menu1);
rowContainer1.Add(row1menu2);

rowContainer2.Add(row2menu1);
rowContainer2.Add(row2menu2);

mainPanel.Add(label1); 
mainPanel.Add(rowContainer1);
mainPanel.Add(rowContainer2);
mainPanel.Add(label2);


// configure each Panel
rowContainer1.direction = LayoutDirection.Row;
rowContainer2.direction = LayoutDirection.Row;
rowContainer1.ProcessDimensions();
rowContainer2.ProcessDimensions();

mainPanel.direction = LayoutDirection.Column;
mainPanel.hAlignment = HAlignment.Center;
mainPanel.vAlignment = VAlignment.Center;
mainPanel.SetHeight(70); // 70 percent of window size
mainPanel.SetWidth(70); // 70 percent of window size
mainPanel.ProcessDimensions();
mainPanel.CalcAllPositions(); // figure out positions of children inside panel

// draw
mainPanel.Draw();

row1menu1.MonitorInput();


void PrintStats(IComponent container)
{
    Console.SetCursorPosition(0, a++);
    Console.Write(
        $"Width: {container.Width} Height: {container.Height} Position: {container.Position.ToString()}\n");
}

void Stats(Panel panel, Panel rowContainer3, Panel mainPanel1)
{
    PrintStats(panel);
    PrintStats(rowContainer3);
    PrintStats(mainPanel1);
}

// old stuff:

// Menu mainMenu = new Menu(false, 0, LayoutDirection.Column);
// RadioButtonGroup radioGroup = new RadioButtonGroup(true, 0, LayoutDirection.Column);

// RadioButton r1 = new RadioButton("Radio 1");
// RadioButton r2 = new RadioButton("Radio 2");
// RadioButton r3 = new RadioButton("Radio 3");
// RadioButton r4 = new RadioButton("Radio 4");
//
// radioGroup.Add(r1);
// radioGroup.Add(r2);
// radioGroup.Add(r3);
// radioGroup.Add(r4);
//
// CheckBox checkBox = new CheckBox("CheckBox");
// TextField textField = new TextField(40, "enter stuff here");
// MenuItem op1 = new MenuItem("Print window Dimensions")
// {
//     action = delegate
//     {
//         Console.SetCursorPosition(70, 1);
//         Console.Write(Frame.WindowHeight + " ");
//         Console.Write(Frame.WindowWidth);
//     }
// };
//
// MenuItem op2 = new MenuItem("Go to RadioButtons")
// {
//     action = delegate
//     {
//         mainMenu.isMonitoringInput = false;
//         radioGroup.isMonitoringInput = true;
//         radioGroup.MonitorInput();
//         
//         // radioGroup is Escapable by default. Pressing escape will make it stop monitoring for inputs
//         // code underneath will be executed after ESC key is pressed in radio Group.
//         Console.SetCursorPosition(70,3);
//         switch (radioGroup.indexOfToggled)
//         {
//             case 0:
//                 Console.Write("The First Radio Button is Selected");
//                 break;
//             case 1:
//                 Console.Write("The Second Radio Button is Selected");
//                 break;
//             case 2:
//                 Console.Write("The Third Radio Button is Selected");
//                 break;
//             case 3:
//                 Console.Write("The Fourth Radio Button is Selected");
//                 break;
//         }
//         
//         // go back to main menu
//         mainMenu.isMonitoringInput = true;
//         mainMenu.MonitorInput();
//     }
// };
//
// MenuItem op3 = new MenuItem("Click Me after Checkbox!")
// {
//     action = delegate
//     {
//         if (checkBox.Toggled)
//         {
//             Console.SetCursorPosition(70, 2);
//             Console.Write($"the Width is: {mainMenu.Width} and the height is: {mainMenu.Height}");
//         }
//     }
// };
// MenuItem op4 = new MenuItem("Print text in TextEntry")
// {
//     action = delegate
//     {
//         Console.SetCursorPosition(70, 20);
//         Console.Write(textField.text);
//     }
// };
//
// radioGroup.backgroundColor = ConsoleColor.Red;
//
// mainMenu.Add(textField);
// mainMenu.Add(op1);
// mainMenu.Add(op2);
// mainMenu.Add(op3);
// mainMenu.Add(op4);
// mainMenu.Add(checkBox);
//
//
// // mainMenu.Draw();
// // Console.Clear();
// panel1.Add(newLabel);
// panel1.Add(mainMenu);
// panel1.Add(radioGroup);
//
//
// panel1.SetWidth(90);
// panel1.SetHeight(90);
// panel1.hAlignment = HAlignment.Center;
// panel1.vAlignment = VAlignment.End;
//
// panel1.CalcAllPositions();
// panel1.Draw();
//
// // mainMenu.isMonitoringInput = true;
// mainMenu.MonitorInput();