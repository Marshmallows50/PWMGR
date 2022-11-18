// See https://aka.ms/new-console-template for more information

using System.Collections;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;
using TUIFrameWork.Selection;
using TUIFrameWork.Components;
using TUIFrameWork;
using TUIFrameWork.Containers;


Label newLabel = new Label("This is a Label!", 10, Alignment.Center, new Point(0,0));
newLabel.Draw();
newLabel.SetText("SomeText");
newLabel.Draw();

Label newLabel2 = new Label("This is a Label!", 9, Alignment.Center, new Point(0,0));
newLabel.Draw();

RadioButtonGroup radioGroup = new RadioButtonGroup(true, 0, LayoutDirection.Column, new Point(5, 13));
RadioButton r1 = new RadioButton("Radio 1");
RadioButton r2 = new RadioButton("Radio 2");
RadioButton r3 = new RadioButton("Radio 3");
RadioButton r4 = new RadioButton("Radio 4");



radioGroup.Add(r1);
radioGroup.Add(r2);
radioGroup.Add(r3);
radioGroup.Add(r4);
radioGroup.Draw();

Console.SetCursorPosition(0, 4);
Menu mainMenu = new Menu(false, 0, LayoutDirection.Column);
CheckBox checkBox = new CheckBox("CheckBox", new Point(0, 11));
TextField textField = new TextField(40, "enter stuff here", new Point(0, 4));

MenuItem op1 = new MenuItem("Print window Dimensions", new Point(0, 5)) 
{
    action = delegate
    {
        Console.SetCursorPosition(0, 1);
        Console.Write(Frame.WindowHeight + " ");
        Console.Write(Frame.WindowWidth);
    }
};

MenuItem op2 = new MenuItem("Go to RadioButtons", new Point(0, 7))
{
    action = delegate
    {
        mainMenu.isMonitoringInput = false;
        radioGroup.isMonitoringInput = true;
        radioGroup.MonitorInput();
        
        // radioGroup is Escapable by default. Pressing escape will make it stop monitoring for inputs
        // code underneath will be executed after ESC key is pressed in radio Group.
        Console.SetCursorPosition(0,3);
        switch (radioGroup.indexOfToggled)
        {
            case 0:
                Console.Write("The First Radio Button is Selected");
                break;
            case 1:
                Console.Write("The Second Radio Button is Selected");
                break;
            case 2:
                Console.Write("The Third Radio Button is Selected");
                break;
            case 3:
                Console.Write("The Fourth Radio Button is Selected");
                break;
        }
        
        // go back to main menu
        mainMenu.isMonitoringInput = true;
        mainMenu.MonitorInput();
    }
};

MenuItem op3 = new MenuItem("Click Me after Checkbox!", new Point(0, 9))
{
    action = delegate
    {
        if (checkBox.Toggled)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write($"the Width is: {mainMenu.Width} and the height is: {mainMenu.Height}");
        }
    }
};
MenuItem op4 = new MenuItem("Print text in TextEntry", new Point(0, 10))
{
    action = delegate
    {
        Console.SetCursorPosition(0, 20);
        Console.Write(textField.text);
    }
};

mainMenu.Add(textField);
mainMenu.Add(op1);
mainMenu.Add(op2);
mainMenu.Add(op3);
mainMenu.Add(op4);
mainMenu.Add(checkBox);


mainMenu.Draw();
// Console.Clear();
mainMenu.isMonitoringInput = true;
mainMenu.MonitorInput();

Console.ReadKey();