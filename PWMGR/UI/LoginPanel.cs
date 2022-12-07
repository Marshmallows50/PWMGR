using TUIFrameWork;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;
// ReSharper disable VirtualMemberCallInConstructor

public class LoginPanel : Panel
{
    private Ui ui;
    public LoginPanel(Ui ui) : base(2)
    {
        SetDimensions(100, 100);
        direction = LayoutDirection.Row;
        hAlignment = HAlignment.Center;
        vAlignment = VAlignment.Center;

        this.ui = ui;
        // login components
        Label passwordLbl = new Label("Password:");
        
        Menu passwordMenu = new Menu(false, 2, LayoutDirection.Row);
        #region add components to Menu
        TextField passwordField = new TextField(30, "Login Password");
        MenuItem unlockBtn = new MenuItem("Unlock");
        passwordMenu.Add(passwordField);
        passwordMenu.Add(unlockBtn);
        passwordMenu.ProcessDimensions();
        #endregion
        
        Add(passwordLbl);
        Add(passwordMenu);
        ProcessDimensions();
        CalcAllPositions();
        
        passwordLbl.InheritColors();
        
        unlockBtn.action = delegate
        {
            //TODO create MainPanel and switch to it.
            //TODO deserialize 
            //TODO un-encrypt
            ui.ContentPaneSwitcher.SwitchTo(ui.MeatNPotatoes);
            ui.ContentPane.ProcessDimensions();
            ui.ContentPane.CalcAllPositions();
            ui.ContentPane.Draw();
            ui.ContentPane.ManageInput();
        };
    }
}