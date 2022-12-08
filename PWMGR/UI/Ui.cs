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
    public Data Entries { get; set; }
    
    // Panels
    public Panel ContentPane { get; }
    public PanelSwitcher ContentPaneSwitcher { get; }
    
    public LoginPanel Login { get; }
    
    public Panel MeatNPotatoes { get; }
    public PanelSwitcher MeatNPotatoesSwitcher { get; }
    public Menu MenuBar { get; }
    public EntryPanel Entry { get; }
    public GeneratorPanel Generator { get; }
    public EditPanel Edit { get; }



    public Ui()
    {
        Frame.SetTitle("PW proof of concept");
        Entries = GetEntries();
        ContentPane = new Panel();
        ContentPane.SetDimensions(100,99);
        ContentPane.hAlignment = HAlignment.Center;

        Login = new LoginPanel(this);
        ContentPaneSwitcher = new PanelSwitcher(Login);
        
        MeatNPotatoes = new Panel(1);
        MeatNPotatoes.SetDimensions(93, 99);
        MeatNPotatoes.hAlignment = HAlignment.Center;
        MenuBar = new MenuBar(this);
        Entry = new EntryPanel(this);
        Generator = new GeneratorPanel();
        Edit = new EditPanel(this);
        
        MeatNPotatoes.Add(MenuBar);
        MeatNPotatoes.Add(Entry);
        MeatNPotatoes.ProcessDimensions();
        MeatNPotatoesSwitcher = new PanelSwitcher(Entry);
        
        ContentPane.Add(Login);
        ContentPane.ProcessDimensions();
        ContentPane.CalcAllPositions();
        ContentPane.Draw();
        Login.ManageInput();

        
        Encrypt(Login.PasswordField.text);
    }

    private Data GetEntries()
    {
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

    public void Encrypt(string password)
    {
        // password = "myPassword"; // used for testing
        BinaryFormatter formatter = new BinaryFormatter();

        //create FileStream
        using Stream stream = new FileStream
            ("MyFile.enc", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        
        //use AES algorithm
        using Aes aes = Aes.Create();
        aes.Padding = PaddingMode.PKCS7;
        
        // create key based on password string
        byte[] key = Encoding.UTF8.GetBytes(password);
        
        Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, key, 10000);
        key = rfc.GetBytes(32);
        
        //write iv to file
        byte[] iv = aes.IV;
        stream.Write(iv, 0, iv.Length);
        
        ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
        //create crypto stream and write serialization stream to it.
        using CryptoStream cryptoStream =
            new(stream, encryptor, CryptoStreamMode.Write);
        formatter.Serialize(cryptoStream, Entries);
    }
    
    public bool Decrypt(string password)
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using FileStream stream = new FileStream
                ("MyFile.enc", FileMode.Open, FileAccess.Read, FileShare.None);
            using Aes aes = Aes.Create();
            aes.Padding = PaddingMode.PKCS7;

            // get iv from file
            byte[] iv = new byte[aes.IV.Length];
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
            // use key as salt for testing purposes
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(key, key, 10000);
            key = rfc.GetBytes(32);

            ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
            using CryptoStream cryptoStream =
                new(stream, decryptor, CryptoStreamMode.Read);
            Entries = (Data)formatter.Deserialize(cryptoStream);
            return true;
        }
        catch (SerializationException e)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Incorrect Password");
            return false;
        }
        catch (ArgumentNullException)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Enter a Password");
            return false;

        }
    }
    
    private byte[] GenerateSalt()
    {
        byte[] salt = new byte[32];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }
}