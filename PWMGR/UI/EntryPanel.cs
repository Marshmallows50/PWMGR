using System.Globalization;
using System.Text;
using TUIFrameWork;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;

public class EntryPanel : Panel
{
    private Ui ui;
    
    private Menu groupMenu;
    private Panel tablePanel;
    private Menu tableMenu;                                     


    public EntryPanel(Ui ui) : base(6)
    {
        direction = LayoutDirection.Row;
        SetDimensions(100, 99);
        this.ui = ui;

        
        groupMenu = CreateGroupMenu();
        Add(groupMenu);
        
        tablePanel = CreateTablePanel();
        tableMenu = new Menu();
        Add(tablePanel);

        ProcessDimensions();
    }
    
    private Menu CreateGroupMenu()
    {
        groupMenu = new Menu(true, 1);

        #region Buttons
        MenuItem financeBtn = new MenuItem("Finance");
        MenuItem entertainmentBtn = new MenuItem("Entertainment");
        MenuItem shoppingBtn = new MenuItem("Shopping");
        MenuItem socialBtn = new MenuItem("Social Media");
        MenuItem workBtn = new MenuItem("Work");
        
        groupMenu.Add(financeBtn);
        groupMenu.Add(entertainmentBtn);
        groupMenu.Add(shoppingBtn);
        groupMenu.Add(socialBtn);
        groupMenu.Add(workBtn);
        #endregion
        groupMenu.ProcessDimensions();

        #region Button Actions
        financeBtn.action = delegate { SelectAndDisplay("Finance"); };
        entertainmentBtn.action = delegate { SelectAndDisplay("Entertainment"); };
        shoppingBtn.action = delegate { SelectAndDisplay("Shopping"); };
        socialBtn.action = delegate { SelectAndDisplay("Social Media"); };
        workBtn.action = delegate { SelectAndDisplay("Work"); };
        #endregion
        
        // financeBtn.Act();
        return groupMenu;
    }

    private Panel CreateTablePanel()
    {
        tablePanel = new Panel();
        tablePanel.direction = LayoutDirection.Column;

        Panel colHeads = new Panel();
        colHeads.direction = LayoutDirection.Row;
        Label title = new Label("Title", 12, Alignment.Center);
        Label usern = new Label("Username", 10, Alignment.Center);
        Label pass = new Label("Password", 9, Alignment.Center);
        Label url = new Label("URL", 14, Alignment.Center);
        colHeads.Add(title);
        colHeads.Add(usern);
        colHeads.Add(pass);
        colHeads.Add(url);
        
        title.InheritColors();
        usern.InheritColors();
        pass.InheritColors();
        url.InheritColors();
        colHeads.ProcessDimensions();
        tablePanel.Add(colHeads);
        
        Label line = new Label(new string('~', 69));
        tablePanel.Add(line);
        line.InheritColors();
        tablePanel.ProcessDimensions();
        return tablePanel;
    }

    private void SelectAndDisplay(string text)
    {
        ui.Entries.SelectGroup(ui.Entries
            .Single(g => g.Name.Equals(text)));
        DisplayGroup();
    }

    // display the currently selected Group
    public void DisplayGroup()
    {
        tablePanel.Remove(tableMenu);
        tableMenu = new Menu(true);
        
        List<string[]> rows = ui.Entries.selectedGroup.GetTableData().ToList();
        
        foreach (string[] t in rows)
        {
            StringBuilder sb = new StringBuilder();
            
            //loop 4 times because each t contain 5 elements, and we don't the last one.
            for (int i = 0; i < 4; i++)
            {
                sb.Append("|" + t[i].PadRight(16));
                if (i == 3)
                    sb.Append("|");

            }

            MenuItem entry = new MenuItem(sb.ToString());
            entry.action = delegate
            {
                ui.Entries.selectedGroup
                    .SelectEntry(ui.Entries.selectedGroup.Entries
                        .Single(e => e.Id == int.Parse(t[4])));
                
                ui.MeatNPotatoesSwitcher.SwitchTo(ui.editPanel);
                ui.editPanel.UpdateValues();
                ui.ContentPane.ProcessDimensions();
                ui.ContentPane.CalcAllPositions();
                ui.ContentPane.Draw();
                ui.ContentPane.RestartInput();
            };
            
            tableMenu.Add(entry);
        }
        tableMenu.ProcessDimensions();
        tablePanel.Add(tableMenu);
        tablePanel.ProcessDimensions();
        ui.ContentPane.ProcessDimensions();
        ui.ContentPane.CalcAllPositions();
        ui.ContentPane.Draw();
    }
}