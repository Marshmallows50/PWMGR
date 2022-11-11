// See https://aka.ms/new-console-template for more information
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;
using TUIFrameWork;
using TUIFrameWork.Components;


Label newLabel = new Label(new Point(0, 0), "This is a Label!", 10, Alignment.Center);
newLabel.Draw();


RadioButtonGroup radioGroup = new RadioButtonGroup();
RadioButton r1 = new RadioButton(new Point(0, 13), "Radio 1");
RadioButton r2 = new RadioButton(new Point(0, 14), "Radio 2");
RadioButton r3 = new RadioButton(new Point(0, 15), "Radio 3");
RadioButton r4 = new RadioButton(new Point(0, 16), "Radio 4");

radioGroup.Add(r1);
radioGroup.Add(r2);
radioGroup.Add(r3);
radioGroup.Add(r4);
radioGroup.DrawItems();

Menu mainMenu = new Menu();
CheckBox checkBox = new CheckBox(new Point(0, 11), "CheckBox");
MenuItem op1 = new MenuItem(new Point(0, 5), "Option 1") 
{
    action = delegate
    {
        Console.SetCursorPosition(0, 1);
        Console.Write("Selected Option 1");
    }
};

MenuItem op2 = new MenuItem(new Point(0, 7), "Option 2")
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

MenuItem op3 = new MenuItem(new Point(0, 9), "Click Me after Checkbox!")
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


mainMenu.Add(op1);
mainMenu.Add(op2);
mainMenu.Add(op3);
mainMenu.Add(checkBox);

mainMenu.DrawItems();
mainMenu.isMonitoringInput = true;
mainMenu.MonitorInput();