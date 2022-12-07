using TUIFrameWork.Base;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;

public class Ui
{
    // Data Structure
    public Data Entries;
    
    // Panels
    public Panel ContentPane { get; set; }
    public PanelSwitcher ContentPaneSwitcher { get; }
    
    public Panel loginPanel;
    
    public Panel MeatNPotatoes { get; set; }
    public PanelSwitcher MeatNPotatoesSwitcher { get; }
    public Menu menuBar;
    public EntryPanel entryPanel;
    public GeneratorPanel generatorPanel;
    public EditPanel editPanel;
    
    
    
    public Ui()
    {
        Frame.SetTitle("PW proof of concept");
        Entries = GetEntries();
        ContentPane = new Panel();
        ContentPane.SetDimensions(100,99);
        ContentPane.hAlignment = HAlignment.Center;

        loginPanel = new LoginPanel(this);
        ContentPaneSwitcher = new PanelSwitcher(loginPanel);
        
        MeatNPotatoes = new Panel(1);
        MeatNPotatoes.SetDimensions(93, 99);
        MeatNPotatoes.hAlignment = HAlignment.Center;
        menuBar = new MenuBar(this);
        entryPanel = new EntryPanel(this);
        generatorPanel = new GeneratorPanel();
        editPanel = new EditPanel(this);
        
        MeatNPotatoes.Add(menuBar);
        MeatNPotatoes.Add(entryPanel);
        MeatNPotatoes.ProcessDimensions();
        MeatNPotatoesSwitcher = new PanelSwitcher(entryPanel);
        
        ContentPane.Add(loginPanel);
        ContentPane.ProcessDimensions();
        ContentPane.CalcAllPositions();
        ContentPane.Draw();
        loginPanel.ManageInput();
    }

    private Data GetEntries()
    {
         // deserialize Data if it exists, and if not, create it.


         // create data
         Entries = new Data();
         #region Add Entry Groups to data
         EntryGroup finance = new EntryGroup("Finance");
         EntryGroup entertainment = new EntryGroup("Entertainment");
         EntryGroup shopping = new EntryGroup("Shopping");
         EntryGroup social = new EntryGroup("Social Media");
         EntryGroup work = new EntryGroup("Work");
        
         Entries.AddGroup(finance);
         Entries.AddGroup(entertainment);
         Entries.AddGroup(shopping);
         Entries.AddGroup(social);
         Entries.AddGroup(work);

         return Entries;
         #endregion
    }
}