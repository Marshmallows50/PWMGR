using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

namespace PWMGR.UI;

public class EditPanel : Panel
{
    private Ui ui;
    private Menu editMenu;

    private TextField titleField;
    private TextField usernField;
    private TextField passField;
    private TextField urlField;
    private TextField addTag;



        public EditPanel(Ui ui)
    {
        this.ui = ui;
        SetDimensions(50, 99);
        hAlignment = HAlignment.Center;
        
        editMenu = new Menu(true, 1);
        titleField = new TextField(20);
        usernField = new TextField(20);
        passField = new TextField(20);
        urlField = new TextField(20);
        addTag = new TextField(20, "Type tag to add");

        MenuItem apply = new MenuItem("Apply");
        editMenu.Add(titleField);
        editMenu.Add(usernField);
        editMenu.Add(passField);
        editMenu.Add(urlField);
        editMenu.Add(addTag);
        editMenu.Add(apply);
        editMenu.ProcessDimensions();

        Add(editMenu);
        ProcessDimensions();

        apply.action = delegate
        {
            ui.Entries.SelectedGroup.SelectedEntry.Title = titleField.text;
            ui.Entries.SelectedGroup.SelectedEntry.Username = usernField.text;
            ui.Entries.SelectedGroup.SelectedEntry.Password = passField.text;
            ui.Entries.SelectedGroup.SelectedEntry.URL = urlField.text;

            if (addTag.text != String.Empty)
                ui.Entries.SelectedGroup.SelectedEntry.Tags.Add(addTag.text);

            ui.ContentPane.ProcessDimensions();
            ui.ContentPane.CalcAllPositions();
            ui.ContentPane.Draw();
        };

    }

    public void UpdateValues()
    {
        titleField.SetText(ui.Entries.SelectedGroup.SelectedEntry.Title);
        usernField.SetText(ui.Entries.SelectedGroup.SelectedEntry.Username);
        passField.SetText(ui.Entries.SelectedGroup.SelectedEntry.Password);
        urlField.SetText(ui.Entries.SelectedGroup.SelectedEntry.URL);
        addTag.SetText(String.Empty);
        
    }
}
