using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using TUIFrameWork;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;
// ReSharper disable VirtualMemberCallInConstructor

public class LoginPanel : Panel
{
    public TextField PasswordField { get; }
    public LoginPanel(Ui ui) : base(2)
    {
        SetDimensions(100, 100);
        direction = LayoutDirection.Row;
        hAlignment = HAlignment.Center;
        vAlignment = VAlignment.Center;
        
        // login components
        Label passwordLbl = new Label("Password:");
        
        Menu passwordMenu = new Menu(true, 2, LayoutDirection.Row);
        #region add components to Menu
        PasswordField = new TextField(30, "Login Password");
        MenuItem unlockBtn = new MenuItem("Unlock");
        passwordMenu.Add(PasswordField);
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
            if (ui.Decrypt(PasswordField.text))
            {
                foreach (EntryGroup entryGroup in ui.Entries)
                {
                    entryGroup.ApplyParent();
                }
                ui.ContentPaneSwitcher.SwitchTo(ui.MeatNPotatoes);
                ui.ContentPane.ProcessDimensions();
                ui.ContentPane.CalcAllPositions();
                ui.ContentPane.Draw();
                ui.ContentPane.ManageInput();
            }
        };
    }
}