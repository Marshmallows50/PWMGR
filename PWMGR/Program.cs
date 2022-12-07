using System.Reflection.Emit;
using PWMGR;
using PWMGR.UI;
using PWMGR.UI_Demos;
using TUIFrameWork;
using TUIFrameWork.Base;
using TUIFrameWork.Containers;
using TUIFrameWork.Components;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;
using Label = TUIFrameWork.Components.Label;


Ui start = new Ui();
Console.ReadLine();


//
//
//
//
//         
// Panel frame = new Panel();
// PanelSwitcher UnlockSwitch;
// Panel loginPanel;
// Panel mainPanel;
//
//
//
// Frame.SetTitle("Proof of Concept PW Manager");
// frame.SetDimensions(99,99);
// frame.hAlignment = HAlignment.Center;
// frame.vAlignment = VAlignment.Center;
//         
// loginPanel = CreateLoginPanel();
// mainPanel = TuiMain.CreateMainPanel();
//         
// UnlockSwitch = new PanelSwitcher(loginPanel);
//         
// frame.Add(loginPanel);
// frame.ProcessDimensions();
// frame.CalcAllPositions();
// frame.Draw();
//         
// loginPanel.ManageInput();
//
//
// Panel CreateLoginPanel()
// {
//     // create and configure login Panel 
//     loginPanel = new Panel(1);
//     loginPanel.SetDimensions(60, 40);
//     loginPanel.hAlignment = HAlignment.Center;
//     loginPanel.vAlignment = VAlignment.Center;
//
//     // Panel for login components
//     Panel loginInputPanel = new Panel(2);
//     loginInputPanel.direction = LayoutDirection.Row;
//     loginInputPanel.hAlignment = HAlignment.Center;
//
//     // login components
//     Label password = new Label("Password: ");
//
//     Menu passwordMenu = new Menu(false, 2, LayoutDirection.Row);
//     TextField passwordField = new TextField(30, "Login Password");
//     MenuItem unlockBtn = new MenuItem("Unlock");
//     passwordMenu.Add(passwordField);
//     passwordMenu.Add(unlockBtn);
//     passwordMenu.ProcessDimensions();
//         
//     loginInputPanel.Add(password);
//     loginInputPanel.Add(passwordMenu);
//     loginInputPanel.ProcessDimensions();
//         
//     loginPanel.Add(loginInputPanel);
//     loginPanel.ProcessDimensions();
//     loginPanel.CalcAllPositions();
//         
//     unlockBtn.action = delegate
//     {
//         //TODO create MainPanel and switch to it.
//         //TODO deserialize 
//         //TODO un-encrypt
//         UnlockSwitch.SwitchTo(mainPanel);
//         frame.vAlignment = VAlignment.Start;
//         frame.ProcessDimensions();
//         frame.CalcAllPositions();
//         frame.Draw();
//         mainPanel.ManageInput();
//     };
//
//     return loginPanel;
// }