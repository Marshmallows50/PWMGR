// See https://aka.ms/new-console-template for more information
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;
using TUIFrameWork.Selection;
using TUIFrameWork.Components;
using TUIFrameWork;
using TUIFrameWork.Containers;


Label newLabel = new Label("This is a Label!", 10, Alignment.Center, new Point(0,0));
newLabel.Draw();
newLabel.Text = "someText";
newLabel.Draw();

Label newLabel2 = new Label("This is a Label!", 9, Alignment.Center, new Point(0,0));
newLabel.Draw();


RadioButtonGroup radioGroup = new RadioButtonGroup();
RadioButton r1 = new RadioButton("Radio 1", new Point(0, 13));
RadioButton r2 = new RadioButton("Radio 2", new Point(0, 14));
RadioButton r3 = new RadioButton("Radio 3", new Point(0, 15));
RadioButton r4 = new RadioButton("Radio 4", new Point(0, 16));

radioGroup.Add(r1);
radioGroup.Add(r2);
radioGroup.Add(r3);
radioGroup.Add(r4);
radioGroup.DrawItems();

Menu mainMenu = new Menu();
CheckBox checkBox = new CheckBox("CheckBox", new Point(0, 11));
TextField textField = new TextField(40, "enter stuff here", new Point(0, 4));

MenuItem op1 = new MenuItem("Option 1", new Point(0, 5)) 
{
    action = delegate
    {
        Console.SetCursorPosition(0, 1);
        Console.Write(Frame.WindowHeight + " ");
        Console.Write(Frame.WindowWidth);
    }
};

MenuItem op2 = new MenuItem("Option 2", new Point(0, 7))
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
            Console.Write("Selected Option 3");
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


mainMenu.DrawItems();
// Console.Clear();
mainMenu.isMonitoringInput = true;
mainMenu.MonitorInput();

Console.ReadKey();