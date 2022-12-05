using TUIFrameWork;
using TUIFrameWork.Base;
using TUIFrameWork.Components;
using TUIFrameWork.Containers;
using TUIFrameWork.Selection.Components;
using TUIFrameWork.Selection.Containers;

    namespace PWMGR.UI;

    public class TopLevelPanel
    {
        private PanelSwitcher TopLevelSwitcher;
        private Panel TopLevel;
        public Panel LoginPanel;

        public Panel contentContainer;
        public Menu MenuBar;
        public Panel Entries;
        public Panel Generator;
        public PanelSwitcher switcher;
        public Panel content;



        public TopLevelPanel()
        {
            
            Panel TopLevel = new Panel();
            TopLevel.direction = LayoutDirection.Column;
            TopLevel.hAlignment = HAlignment.Center;
            TopLevel.vAlignment = VAlignment.Start;
            TopLevel.SetDimensions(70, 70);
            TopLevel.ProcessDimensions();

            LoginPanel = DrawLoginFrame();
            content = CreateContentPanel();

            TopLevel.Add(LoginPanel);
            TopLevelSwitcher = new PanelSwitcher(LoginPanel);

            TopLevel.Draw();
            TopLevel.ManageInput();

        }
    
        public Panel DrawLoginFrame()
            {
                // create and configure panels
                Panel mainPanel = new Panel(2);
                mainPanel.direction = LayoutDirection.Column;
                mainPanel.hAlignment = HAlignment.Center;
                mainPanel.vAlignment = VAlignment.Start;
                mainPanel.SetDimensions(70, 70);
                mainPanel.ProcessDimensions();

                Panel rowContainer1 = new Panel(2);
                rowContainer1.direction = LayoutDirection.Row;
                rowContainer1.hAlignment = HAlignment.Center;
                rowContainer1.vAlignment = VAlignment.Center;
                rowContainer1.SetDimensions(100, 20);
                rowContainer1.backgroundColor = ConsoleColor.DarkGray;

                Panel rowContainer2 = new Panel(2);
                rowContainer2.direction = LayoutDirection.Row;
                rowContainer2.hAlignment = HAlignment.Center;
                rowContainer2.vAlignment = VAlignment.Center;
                rowContainer2.SetDimensions(90, 50);
                rowContainer2.backgroundColor = ConsoleColor.Gray;

                // make menu for password input
                Menu row2menu1 = new Menu(true, 1, LayoutDirection.Row);

                // create labels
                Label label1 = new Label("Password Manager!", 20, Alignment.Center);
                Label label2 = new Label("Password:", 5, Alignment.Center);
                TextField menu1item2 = new TextField(25, " Type Password!");
                MenuItem menu1item3 = new MenuItem("unlock");
                menu1item3.action = delegate
                {
                    switcher.SwitchTo(content);
                    TopLevel.ProcessDimensions();
                    TopLevel.CalcAllPositions();
                    TopLevel.Draw();

                };

                // add components to menus
                row2menu1.Add(menu1item2);
                row2menu1.Add(menu1item3);
                row2menu1.ProcessDimensions();

                // add menus & labels to panels
                rowContainer1.Add(label1);
                rowContainer1.ProcessDimensions();

                rowContainer2.Add(label2);
                rowContainer2.Add(row2menu1);
                rowContainer2.ProcessDimensions();

                // add rows to main panel
                mainPanel.Add(rowContainer1);
                mainPanel.Add(rowContainer2);
                mainPanel.ProcessDimensions();
                mainPanel.CalcAllPositions();

      //  mainPanel.Draw();
            return mainPanel;
            }
    
        public Panel CreateContentPanel()
        {
            MenuBar = CreateMenuBar();
            Entries = CreateEntriesPanel();
            Generator = CreatePsswdGenerator();
        
            Panel contentContainer = new Panel(0);
            contentContainer.direction = LayoutDirection.Column;
            contentContainer.vAlignment = VAlignment.Start;
            contentContainer.hAlignment = HAlignment.Start;
            contentContainer.SetDimensions(70, 70);

            switcher = new PanelSwitcher(Entries);
            contentContainer.Add(MenuBar);
            contentContainer.Add(Entries);

            return contentContainer;
        }
    
        private Menu CreateMenuBar()
        {
            Menu menuBar = new Menu(true, 2, LayoutDirection.Row);

            MenuItem btnOpen = new MenuItem("open");
            MenuItem btnLock = new MenuItem("lock");
            btnLock.action = delegate
            {
                switcher.SwitchTo(LoginPanel);
            };
        
            MenuItem btnNew = new MenuItem("new");
            MenuItem btnEdit = new MenuItem("edit");
            MenuItem btnRemove = new MenuItem("remove");
            MenuItem btnPsswdGenerator = new MenuItem("password generator");
            btnPsswdGenerator.action = delegate
            {
                switcher.SwitchTo(Generator);
            };

            menuBar.Add(btnOpen);
            menuBar.Add(btnLock);
            menuBar.Add(btnNew);
            menuBar.Add(btnEdit);
            menuBar.Add(btnRemove);
            menuBar.Add(btnPsswdGenerator);
            menuBar.ProcessDimensions();
            menuBar.backgroundColor = ConsoleColor.Green;

            return menuBar;
        }

        private Menu CreateSideBarMenu()
        {
            Menu sideBarMenu = new Menu(true, 1);

            MenuItem group1 = new MenuItem("Btn 1");
            MenuItem group2 = new MenuItem("Btn 2");
            MenuItem group3 = new MenuItem("Btn 3");
            MenuItem group4 = new MenuItem("Btn 4");
            MenuItem group5 = new MenuItem("Btn 5");

            sideBarMenu.Add(group1);
            sideBarMenu.Add(group2);
            sideBarMenu.Add(group3);
            sideBarMenu.Add(group4);
            sideBarMenu.Add(group5);
            sideBarMenu.ProcessDimensions();
            sideBarMenu.backgroundColor = ConsoleColor.Blue;

            return sideBarMenu;
        }

        public Panel CreateEntriesPanel()
        {
            // create panels
            Panel mainPanel = new Panel(0);
            mainPanel.direction = LayoutDirection.Row;
            mainPanel.vAlignment = VAlignment.Start;
            mainPanel.hAlignment = HAlignment.Start;
            mainPanel.SetDimensions(70, 70);

            // panel for sidebar
            Panel sideBarPanel = new Panel(1);
            sideBarPanel.direction = LayoutDirection.Column;
            sideBarPanel.hAlignment = HAlignment.Center;
            sideBarPanel.vAlignment = VAlignment.End;
            sideBarPanel.SetDimensions(20, 85);
            sideBarPanel.backgroundColor = ConsoleColor.Gray;

            // add menus to containers 
            sideBarPanel.Add(CreateSideBarMenu());
            sideBarPanel.ProcessDimensions();
        
            // add tables
        

            // add conatiners to main panel
            mainPanel.Add(sideBarPanel);
        
            mainPanel.ProcessDimensions();
            mainPanel.CalcAllPositions();

            return mainPanel;
        }
    
        public Panel CreatePsswdGenerator()
            {
                // create and configure Panels
                Panel mainPanel = new Panel(1);
                mainPanel.direction = LayoutDirection.Column;
                mainPanel.hAlignment = HAlignment.Center;
                mainPanel.vAlignment = VAlignment.Start;
                mainPanel.SetDimensions(70, 70);
                mainPanel.ProcessDimensions();

                // panel for menu bar
                Panel menuBar = new Panel(2);
                menuBar.direction = LayoutDirection.Row;
                menuBar.hAlignment = HAlignment.Center;
                menuBar.vAlignment = VAlignment.Center;
                menuBar.SetDimensions(100, 20);
                menuBar.backgroundColor = ConsoleColor.DarkGray;

                Panel rowContainer1 = new Panel(4);
                rowContainer1.direction = LayoutDirection.Row;
                rowContainer1.hAlignment = HAlignment.Center;
                rowContainer1.vAlignment = VAlignment.Center;

                Panel rowContainer2 = new Panel(4);
                rowContainer2.direction = LayoutDirection.Row;
                rowContainer2.hAlignment = HAlignment.Center;
                rowContainer2.vAlignment = VAlignment.Start;

                // menus
                Menu row1menu1 = new Menu(true, 1, LayoutDirection.Column);
                Menu row2menu1 = new Menu(true, 1, LayoutDirection.Column);
                Menu row2menu2 = new Menu(true, 1, LayoutDirection.Column);

                // row1menu1
                Label label = new Label("Generate New Password");
                TextField menu1item3 = new TextField(20, "Type!");

                // row2menu1
                CheckBox menu2item1 = new CheckBox("Letters(e.g.Aa)");
                CheckBox menu2item2 = new CheckBox("Numbers(e.g.123)");
                CheckBox menu2item3 = new CheckBox("Symbols(e.g.@$?)");
                TextField menu2item4 = new TextField(5, "length");

                // row2menu2
                MenuItem menu1btn1 = new MenuItem("Generate Psswd Btn");
            menu1btn1.action = delegate
            {
                // TODO generate password
            };
                MenuItem menu1btn2 = new MenuItem("Copy Psswd Btn");
            menu1btn2.action = delegate
            {
                // TODO copy to clipboard
            };

                // add components to menus
                menuBar.Add(MainFrame.CreateMenuBar());
                row1menu1.Add(menu1item3);
                row1menu1.ProcessDimensions();

                row2menu1.Add(menu2item1);
                row2menu1.Add(menu2item2);
                row2menu1.Add(menu2item3);
                row2menu1.Add(menu2item4);
                row2menu1.ProcessDimensions();
                row2menu1.backgroundColor = ConsoleColor.Black;

                row2menu2.Add(menu1btn1);
                row2menu2.Add(menu1btn2);
                row2menu2.ProcessDimensions();
                row2menu2.backgroundColor = ConsoleColor.Black;

                // add menus to panels 
                rowContainer1.Add(label);
                rowContainer1.Add(row1menu1);
                rowContainer1.ProcessDimensions();

                rowContainer2.Add(row2menu1);
                rowContainer2.Add(row2menu2);
                rowContainer2.ProcessDimensions();

                mainPanel.Add(menuBar);
                mainPanel.Add(rowContainer1);
                mainPanel.Add(rowContainer2);
                mainPanel.ProcessDimensions();
                mainPanel.CalcAllPositions();
          //      mainPanel.Draw();

                return mainPanel;
            }
    }