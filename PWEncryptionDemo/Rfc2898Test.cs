using System.Security.Cryptography;

namespace PWEncryptionDemo;

public static class Rfc2898Test
{
    private const string testPWD = "password1";
    private const string testPWD2 = "password2";
    private const string usageText = "Usage: RFC2898 <password>\nYou must specify the password for encryption.\n";

    public static void Rfc2898TestThing()
    {
        // using (StreamWriter writer = new StreamWriter("Data.txt"))
        // {
        //     writer.WriteLine("this is some text");
        // }
        
        //do salt stuff
        byte[] salt1 = new byte[8];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt1);
        }

        int iterations = 10;

        try
        {
            // key generator
            Rfc2898DeriveBytes key1 = new Rfc2898DeriveBytes(testPWD, salt1, iterations);
            Rfc2898DeriveBytes key2 = new Rfc2898DeriveBytes(testPWD, salt1);
            
            // encryption algorithm
            Aes myAes = Aes.Create();
            myAes.Key = key1.GetBytes(16);
            
            MemoryStream encryptionStream = new MemoryStream();
            CryptoStream encrypt = new CryptoStream(encryptionStream,
                myAes.CreateEncryptor(), CryptoStreamMode.Write);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }
}