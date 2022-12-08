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
            ui.Entries.SelectedGroup.Add(new Entry("Default", ui.Entries.SelectedGroup));
            ui.Entry.DisplayGroup();
        };
        
        remEntryBtn.action = delegate
        {
            ui.Entries.SelectedGroup.Remove(ui.Entries.SelectedGroup.SelectedEntry);
            ui.Entry.DisplayGroup();
        };
        
        tableBtn.action = delegate
        {
            ui.MeatNPotatoesSwitcher.SwitchTo(ui.Entry);
            ui.Entry.FinanceBtn.Act();
            ui.MeatNPotatoes.ProcessDimensions();
            ui.MeatNPotatoes.CalcAllPositions();
            ui.MeatNPotatoes.Draw();
        };
        
        pwGeneratorBtn.action = delegate
        {
            ui.MeatNPotatoesSwitcher.SwitchTo(ui.Generator);
            ui.MeatNPotatoes.ProcessDimensions();
            ui.MeatNPotatoes.CalcAllPositions();
            ui.MeatNPotatoes.Draw();
        };
        
        //TODO add lockBtn action
        #endregion
    }
}