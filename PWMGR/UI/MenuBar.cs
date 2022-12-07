using TUIFrameWork;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;

public class MenuBar : Menu
{

    private Ui ui;
    private MenuItem newEntryBtn;
    private MenuItem editEntryBtn;
    private MenuItem remEntryBtn;
    private MenuItem tableBtn;
    private MenuItem pwGeneratorBtn;
    private MenuItem lockBtn;
    
    public MenuBar(Ui ui) : base(true, 8)
    {
        this.ui = ui;
        direction = LayoutDirection.Row;

        #region MenuBar Buttons
        newEntryBtn = new MenuItem("Create Entry");
        remEntryBtn = new MenuItem("Remove Entry");
        tableBtn = new MenuItem("Table");
        pwGeneratorBtn = new MenuItem("Generator");
        lockBtn = new MenuItem("Lock");
        
        Add(newEntryBtn);
        Add(remEntryBtn);
        Add(tableBtn);
        Add(pwGeneratorBtn);
        Add(lockBtn);
        #endregion
        
        ProcessDimensions();
    
        #region Button Actions
        newEntryBtn.action = delegate
        {
            ui.Entries.selectedGroup.Add(new Entry("Default", ui.Entries.selectedGroup));
            ui.entryPanel.DisplayGroup();
        };
        
        remEntryBtn.action = delegate
        {
            ui.Entries.selectedGroup.Remove(ui.Entries.selectedGroup.selectedEntry);
            ui.entryPanel.DisplayGroup();
        };
        
        tableBtn.action = delegate
        {
            ui.MeatNPotatoesSwitcher.SwitchTo(ui.entryPanel);
            ui.MeatNPotatoes.ProcessDimensions();
            ui.MeatNPotatoes.CalcAllPositions();
            ui.MeatNPotatoes.Draw();
        };
        
        pwGeneratorBtn.action = delegate
        {
            ui.MeatNPotatoesSwitcher.SwitchTo(ui.generatorPanel);
            ui.MeatNPotatoes.ProcessDimensions();
            ui.MeatNPotatoes.CalcAllPositions();
            ui.MeatNPotatoes.Draw();
        };
        
        //TODO add lockBtn action
        #endregion
    }
}