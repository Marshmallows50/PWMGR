using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
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
        
        // Encrypt();
        XmlSerializer ser = new XmlSerializer(typeof(Data));
        using Stream stream = new FileStream
            ("MyFile.xml", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        ser.Serialize(stream, Entries);
        
        
        

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

    public void Encrypt()
    {
        string password = "@myPassword1234";
        
        //create XMLSerializer
        XmlSerializer ser = new XmlSerializer(typeof(Data));
        
        //create FileStream
        using Stream stream = new FileStream
            ("MyFile.enc", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        
        //use AES algorithm
        using Aes aes = Aes.Create();
        
        // create key based on password string
        byte[] key = Encoding.UTF8.GetBytes(password);

        // byte[] salt = GenerateSalt();
        Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, key, 10000);
        key = rfc.GetBytes(32);
        
        //write salt and iv to file
        // stream.Write(salt, 0, 32);
        
        byte[] iv = aes.IV;
        stream.Write(iv, 0, iv.Length);
        
        ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
        //create crypto stream and write serialization stream to it.
        using CryptoStream cryptoStream =
            new(stream, encryptor, CryptoStreamMode.Write);
        // using StreamWriter encryptWriter = new(cryptoStream);
        // ser.Serialize(cryptoStream, Entries);
    }


    private byte[] GenerateSalt()
    {
        byte[] salt = new byte[32];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }


    public void Decrypt(string password)
    {
        //create XMLSerializer
        XmlSerializer ser = new XmlSerializer(typeof(Data));

        using Stream stream = new FileStream
            ("MyFile.enc", FileMode.Open, FileAccess.Read, FileShare.None);
        using Aes aes = Aes.Create();

        // get salt from file
        byte[] salt = new byte[32];
        // stream.Read(salt, 0, 32);

        // get iv from file
        byte[] iv = new byte[aes.IV.Length];
        // stream.Read(iv, 0, aes.IV.Length);
        
        int numBytesToRead = aes.IV.Length;
        int numBytesRead = 0;
        while (numBytesToRead > 0)
        {
            int n = stream.Read(iv, numBytesRead, numBytesToRead);
            if (n == 0) break;

            numBytesRead += n;
            numBytesToRead -= n;
        }
        
        byte[] key = Encoding.UTF8.GetBytes(password);
        Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, key, 10000);
        key = rfc.GetBytes(32);
        
        
        ICryptoTransform encryptor = aes.CreateDecryptor(key, iv);
        using CryptoStream cryptoStream =
            new(stream, encryptor, CryptoStreamMode.Read);
        Entries = (Data) ser.Deserialize(cryptoStream) ?? Entries;

    }
}